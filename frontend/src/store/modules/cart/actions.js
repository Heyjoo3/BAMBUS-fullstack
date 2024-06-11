import LoanService from "@/store/services/LoanService";
import ItemServices from "@/store/services/ItemServices";

export default {
  async rentItem({ commit, dispatch, rootState }, { item, dueDate }) {
    if (!dueDate) {
      alert("Bitte gib ein Rückgabedatum an");
      return;
    }
    try {
      const userId = rootState.userStore.user.userId;
      const startDate = new Date().toISOString();
      dueDate = new Date(dueDate).toISOString();
      const loanResponse = await LoanService.CreateLoan({
        userId,
        itemId: item.itemId,
        itemType: item.type,
        dueDate,
        startDate,
      });
      if (!loanResponse.data.success) {
        alert("Error beim Erstellen des Loans");
        return;
      }
      commit("removeRentalItemFromCart", item.itemId);
      await dispatch("itemStore/loadItems", null, { root: true });
      const userLoansResponse = await LoanService.GetAllLoansFromUser(userId);
      if (!userLoansResponse.data.success) {
        alert("Error beim Updaten der Loans");
        return;
      }
      commit("loanStore/setLoans", userLoansResponse.data.data, { root: true });
    } catch (error) {
      console.error("An error occurred while processing the rental:", error);
      alert("Ein Fehler ist aufgetreten. Bitte versuche es später erneut.");
    }
  },

  async reserveItem({ commit, _, rootState }, itemId) {
    try {
      const item = rootState.itemStore.items.find(
        (item) => item.itemId === itemId
      );
      if (!item) {
        throw new Error("Item not found");
      }
      const userId = rootState.userStore.user.userId;
      item.reservations.push(userId);
      const response = await ItemServices.UpdateItem(item);
      if (response.data.success) {
        commit("itemStore/setItems", response.data.data, { root: true });
        commit("removeReservationItemFromCart", itemId);
      } else {
        throw new Error("Failed to update item");
      }
    } catch (error) {
      console.error("An error occurred while reserving the item:", error);
      $router.push("/error");
    }
  },

  removeRentalItemFromCart({ commit }, itemId) {
    commit("removeRentalItemFromCart", itemId);
  },

  removeReservationItemFromCart({ commit }, itemId) {
    commit("removeReservationItemFromCart", itemId);
  },

  addItemToCart({ commit, state, rootState }, payload) {
    const userId = rootState.userStore.user.userId;
    const itemIsInCartAlready =
      state.cartRentalItems.some((item) => item.itemId === payload.itemId) ||
      state.cartReservationItems.some((item) => item.itemId === payload.itemId);
    const itemIsAlreadyReservedByUser = payload.reservations.includes(userId);
    const itemIsReserved =
      payload.reservations.length > 0 && payload.reservations[0] !== 0;
    const activeLoansByUser = rootState.loanStore.loans.filter(
      (loan) => loan.returnDate === null
    );
    const itemIsAlreadyRented = activeLoansByUser.some(
      (item) => item.itemId === payload.itemId
    );
    if (itemIsInCartAlready) {
      alert("Der Gegenstand ist bereits im Warenkorb");
      return;
    }
    if (itemIsAlreadyReservedByUser) {
      alert("Du hast diesen Gegenstand bereits reserviert");
      return;
    }
    if (itemIsAlreadyRented) {
      alert("Du leiht diesen Gegenstand bereits aus");
      return;
    }
    if (payload.currentLoanId === 0 && !itemIsReserved) {
      commit("addItemToRentalCart", payload);
    } else if (itemIsReserved || payload.currentLoanId != null) {
      commit("addItemToReservationCart", payload);
    } else {
      alert(
        `Der Gegenstand kann zurzeit weder ausgeliehen noch reserviert werden. 
        Reserviert: ${itemIsReserved}, currentLoanId: ${payload.currentLoanId}`
      );
    }
  },

  addReservedItemToCart({ commit, state, rootState }, payload) {
    const itemIsInCartAlready = state.cartRentalItems.some(
      (item) => item.itemId === payload.itemId
    );
    if (itemIsInCartAlready) {
      alert("Das Item ist bereits im Warenkorb");
      return;
    }
    const item = rootState.itemStore.items.find(
      (item) => item.itemId === payload.itemId
    );
    if (item) {
      commit("addItemToRentalCart", item);
    } else {
      alert("Item nicht gefunden");
    }
  },
};
