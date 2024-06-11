import store from "../../index.js";
import $router from "@/router";
import ItemServices from "../../services/ItemServices";
import LoanService from "@/store/services/LoanService";
import RatingService from "@/store/services/RatingService";

export default {
  async loadItems({ commit }) {
    try {
      const response = await ItemServices.LoadAllItems();
      if (response.data.success) {
        commit("setItems", response.data.data);
      } else {
        $router.push("/error");
      }
    } catch (error) {
      console.error("Error loading items:", error);
      $router.push("/error");
    }
  },

  async deleteItem({ commit }, id) {
    const item = store.getters["itemStore/getItemById"](id);
    if (item.currentLoanId !== 0) {
      const confirmDeletion = confirm(
        "Dieser Artikel ist noch ausgeliehen. Wollen Sie ihn trotzdem löschen?"
      );
      if (!confirmDeletion) return;

      await Promise.all([
        LoanService.SetReturnDate(item.currentLoanId),
        LoanService.EndExtensionRequest(item.currentLoanId),
      ]);
    }

    try {
      const response = await ItemServices.DeleteItem(id);
      if (response.data.success) {
        commit("setItems", response.data.data);
        await RatingService.DeleteRatingByItemId(id);
      } else {
        $router.push("/error");
      }
    } catch (error) {
      console.error("Error deleting item:", error);
      $router.push("/error");
    }
  },

  async createItem({ commit, dispatch }, item) {
    try {
      const response = await ItemServices.AddItem(item);
      if (response.data.success) {
        commit("setItems", response.data.data);
        dispatch(
          "notificationStore/managerAddsItem",
          { title: item.title },
          { root: true }
        );
      } else {
        $router.push("/error");
      }
    } catch (error) {
      console.error("Error creating item:", error);
      $router.push("/error");
    }
  },

  async editItem({ commit }, payload) {
    try {
      const response = await ItemServices.UpdateItem(payload);
      if (response.data.success) {
        commit("setItems", response.data.data);
      } else {
        $router.push("/error");
      }
    } catch (error) {
      console.error("Error editing item:", error);
      $router.push("/error");
    }
  },

  setEditItemId({ commit }, id) {
    commit("setEditItemId", id);
  },

  setReturnItemId({ commit }, id) {
    commit("setReturnItemId", id);
  },

  setReportItemId({ commit }, id) {
    commit("setReportItemId", id);
  },

  deleteAllModalIds({ commit }) {
    commit("deleteAllModalIds");
  },

  requestExtension({ commit, rootState }, payload) {
    const { newDueDate, item } = payload;
    if (!newDueDate) {
      alert("Bitte wählen Sie ein neues Rückgabedatum");
      return;
    }
    if (newDueDate <= item.dueDate) {
      alert(
        "Das neue Rückgabedatum muss nach dem aktuellen Rückgabedatum liegen"
      );
      return;
    }

    const maxFutureDate = new Date(item.dueDate);
    maxFutureDate.setDate(maxFutureDate.getDate() + 31);
    const formattedDate = maxFutureDate.toISOString().split("T")[0];
    if (newDueDate > formattedDate) {
      alert(
        "Das neue Rückgabedatum darf nicht mehr als 31 Tage in der Zukunft liegen"
      );
      return;
    }

    const userId = rootState.userStore.user.userId;
    alert(
      `Benutzer ${userId} beantragt eine Verlängerung für Artikel ${item.itemId} bis zum ${newDueDate}`
    );

    const index = rootState.itemStore.items.findIndex(
      (storeItem) => storeItem.itemId === item.itemId
    );
    commit("requestExtension", { index, newDueDate });
  },

  async checkReservationTime({ dispatch, getters }) {
    const items = getters.getItemsWithoutLoanButReserved;
    if (!items) return;

    for (const item of items) {
      try {
        const response = await ItemServices.IsReturnLongerThanWeekAgo(
          item.itemId
        );
        if (
          response.data.success &&
          response.data.data &&
          item.reservations.length > 0
        ) {
          const userId = item.reservations[1];
          dispatch(
            "notificationStore/informAboutAvailableReservation",
            { itemId: item.itemId, userId, title: item.title },
            { root: true }
          );
        }
      } catch (error) {
        console.error("Error checking reservation time:", error);
      }
    }
  },

  async cancelReservation({ commit, dispatch, state }, payload) {
    const item = state.items.find((item) => item.itemId === payload.itemId);

    if (item.reservations[0] !== payload.userId) {
      item.reservations = item.reservations.filter(
        (userId) => userId !== payload.userId
      );
    } else {
      item.reservations.shift();
      if (item.reservations.length > 0) {
        dispatch(
          "notificationStore/informAboutAvailableReservation",
          {
            itemId: item.itemId,
            userId: item.reservations[0],
            title: item.title,
          },
          { root: true }
        );
      }
    }

    try {
      const response = await ItemServices.UpdateItem(item);
      if (response.data.success) {
        commit("setItems", response.data.data);
      } else {
        $router.push("/error");
      }
    } catch (error) {
      console.error("Error canceling reservation:", error);
      $router.push("/error");
    }
  },

  setSortedBy({ commit }, payload) {
    commit("setSortedBy", payload);
  },

  setFilteredBy({ commit }, payload) {
    commit("setFilteredBy", payload);
  },

  setOnlyAvailable({ commit }, payload) {
    commit("setOnlyAvailable", payload);
  },

  setSearch({ commit }, payload) {
    commit("setSearch", payload);
  },

  returnItem({ commit, dispatch, rootState }, payload) {

    let item = store.getters["itemStore/getItemById"](payload.itemId);
    console.log(item);
    payload.userId = rootState.userStore.user.userId;
    payload.itemType = item.type;
    payload.loanId=item.currentLoanId;
    console.log(payload);


    LoanService.ReturnItem(payload).then((response) => {
      console.log(response);
      if (response.data.success) {
        console.log("Item returned");
        console.log(response.data.data);

        if (response.data.data.book != null) {
          commit("updateItem", response.data.data.book);
        }
        else if (response.data.data.game != null) {
          commit("updateItem", response.data.data.game);
        }
        else if (response.data.data.magazine != null) {
          commit("updateItem", response.data.data.magazine);
        }

        commit("loanStore/updateLoan", response.data.data.loan, { root: true });
        commit("ratingStore/updateRating", response.data.data.rating, { root: true });

       dispatch("notificationStore/userReportsDamage", {
          itemId: payload.itemId,
          userId: rootState.userStore.user.userId,
          title: item.title,
          damageDescription: payload.damageDescription,
        }, { root: true });
        if (item.reservations.length > 0) {
          dispatch(
            "notificationStore/informAboutAvailableReservation",
            {
              itemId: item.itemId,
              userId: item.reservations[0],
              title: item.title,
            },
            { root: true }
          );
        }
      }
      else {
        alert("Fehler beim Zurückgeben des Artikels");
      }
    });
  },
};
