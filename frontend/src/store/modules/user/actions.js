import router from "@/router";
import UserServices from "../../services/UserServices";
import MessageService from "@/store/services/MessageService";
import LoanService from "@/store/services/LoanService";
import RatingService from "@/store/services/RatingService";
import ItemServices from "@/store/services/ItemServices";

export default {
  async loginUser({ commit, dispatch }, payload) {
    try {
      const loginResponse = await UserServices.Login(payload);
      if (!loginResponse.data.success) {
        throw new Error("Invalid email or password");
      }
      commit("login", loginResponse.data);

      const ratingResponse = await RatingService.GetAllRatings();
      if (!ratingResponse.data.success) {
        throw new Error(ratingResponse.data.message);
      }

      const messageResponse = await MessageService.GetMessagesFromUserId(
        loginResponse.data.data.userId
      );
      if (!messageResponse.data.success) {
        throw new Error(messageResponse.data.message);
      }
      commit("setNotifications", messageResponse.data.data);

      if (loginResponse.data.data.role === 0) {
        dispatch("itemStore/checkReservationTime", null, { root: true });
        const loanResponse = await LoanService.GetAllLoansFromUser(
          loginResponse.data.data.userId
        );
        if (!loanResponse.data.success) {
          throw new Error(loanResponse.data.message);
        }
        commit("loanStore/setLoans", loanResponse.data.data, { root: true });
      }

      if (
        loginResponse.data.data.role === 2 ||
        loginResponse.data.data.role === 1
      ) {
        const userResponse = await UserServices.GetAllUsers();
        if (!userResponse.data.success) {
          throw new Error(userResponse.data.message);
        }
        commit("setUsers", userResponse.data.data);

        const loanResponse = await LoanService.GetAllLoans();
        if (!loanResponse.data.success) {
          throw new Error(loanResponse.data.message);
        }
        commit("loanStore/setLoans", loanResponse.data.data, { root: true });
      }

      if (loginResponse.data.data.role === 2) {
        router.push("/admin/overview");
      } else {
        router.push("/");
      }
    } catch (error) {
      alert(error.message);
    }
  },
  async registerUser({ commit, dispatch }, payload) {
    await UserServices.Register(payload).then((response) => {
      if (response.data.success) {
        commit("login", response.data);
        dispatch(
          "notificationStore/userRegistersAccount",
          {
            username: response.data.data.username,
            userId: response.data.data.userId,
          },
          {
            root: true,
          }
        );
        dispatch("itemStore/checkReservationTime", null, { root: true });
        router.push("/");
      } else {
        alert(response.data.message);
      }
    });
  },
  async changeUsername({ commit, state }, payload) {
    const userExists = state.users.find((user) => user.username === payload);
    if (userExists) {
      alert("Username ist bereits vergeben");
      return;
    }
    if (!payload) {
      alert("Bitte gib einen Benutzernamen ein");
      return;
    }

    const user = state.user;
    user.username = payload;
    await UserServices.UpdateUser(user).then((response) => {
      if (response.data.success) {
        alert("Benutzername erfolgreich geändert");
      } else {
        alert(response.data.message);
      }
    });
  },
  async changeEmail({ commit, state }, payload) {
    const emailExists = state.users.find((user) => user.email === payload);
    if (emailExists) {
      alert("Emailadresse ist bereits vergeben");
      return;
    }
    if (!payload) {
      alert("Bitte gib eine Emailadresse ein");
      return;
    }
    if (!payload.includes("@")) {
      alert("Bitte gib eine gültige Emailadresse ein");
      return;
    }

    const user = state.user;
    user.email = payload;
    await UserServices.UpdateUser(user).then((response) => {
      if (response.data.success) {
        alert("Emailadresse erfolgreich geändert");
      } else {
        alert(response.data.message);
      }
    });
  },
  async changeName({ commit, state }, payload) {
    if (!payload.firstName && !payload.lastName) {
      alert("Bitte gib einen Vornamen oder Nachnamen ein");
      return;
    }
    const user = state.user;
    if (payload.firstName) {
      user.firstName = payload.firstName;
    }
    if (payload.lastName) {
      user.lastName = payload.lastName;
    }
    await UserServices.UpdateUser(user).then((response) => {
      if (response.data.success) {
        alert("Name erfolgreich geändert");
      } else {
        alert(response.data.message);
      }
    });
  },
  async changePassword({ commit, state }, payload) {
    if (!payload.currentPassword) {
      alert("Bitte gib dein aktuelles Passwort ein");
      return;
    }
    if (!payload.newPassword) {
      alert("Bitte gib ein neues Passwort ein");
      return;
    }
    if (payload.currentPassword == payload.newPassword) {
      alert("Passwort muss sich von deinem aktuellen Passwort unterscheiden");
      return;
    }
    if (payload.newPassword.length < 6) {
      alert("Passwort muss mindestens 6 Zeichen lang sein");
      return;
    }
    const user = state.user;
    user.password = payload.newPassword;
    await UserServices.UpdateUser(user).then((response) => {
      if (response.data.success) {
        alert("Passwort erfolgreich geändert");
      } else {
        alert(response.data.message);
      }
    });
  },

  async deleteNotification({ commit, state }, payload) {
    const user = state.user;
    await MessageService.DeleteMessage(payload);
    await MessageService.GetMessagesFromUserId(user.userId).then((response) => {
      commit("setNotifications", response.data.data);
    });
  },

  async deleteAccount({ commit, state, rootState, rootGetters }) {
    let activeLoans = rootGetters["loanStore/getActiveItemIdFromUserId"];
    if (activeLoans.length > 0) {
      alert(
        "Du musst erst alle Artikel zurückgeben, bevor du dein Konto löschen kannst"
      );
      return;
    }

    if (
      confirm(
        "Bist du sicher, dass du deinen Account unwiderruflich löschen möchtest?"
      )
    ) {
      let activeReservations = rootGetters["itemStore/getItemsReservedByUser"](
        state.user.userId
      );
      if (activeReservations.length > 0) {
        for (let i = 0; i < activeReservations.length; i++) {
          let item = activeReservations[i];
          item.reservations = item.reservations.filter(
            (id) => id !== state.user.userId
          );
          await ItemServices.UpdateItem(item);
        }
      }
      await UserServices.DeleteUser(state.user.userId).then((response) => {
        if (response.data.success) {
          commit("deleteAccount", state.user.userId);
          commit("logout");
          router.push("/");
        } else {
          alert(response.data.message);
        }
      });
    }
  },
  async adminDeleteAccount({ commit, rootGetters }, payload) {
    let activeLoans =
      rootGetters["loanStore/getActiveLoansFromUserId"](payload);
    if (activeLoans.length > 0) {
      alert(
        "Der Benutzer muss erst alle Artikel zurückgeben, bevor sein Konto gelöscht werden kann."
      );
      return;
    }
    let activeReservations =
      rootGetters["itemStore/getItemsReservedByUser"](payload);

    if (activeReservations.length > 0) {
      for (let i = 0; i < activeReservations.length; i++) {
        let item = activeReservations[i];
        item.reservations = item.reservations.filter((id) => id != payload);
        await ItemServices.UpdateItem(item);
      }
    }
    await UserServices.DeleteUser(payload).then((response) => {
      if (response.data.success) {
        alert("Der Account wurde erfolgreich gelöscht.");
        commit("deleteAccount", payload);
      } else {
        alert("Leider ist ein Fehler aufgetreten.");
      }
    });
  },

  async adminChangePassword({ commit, state }, payload) {
    if (payload.newPassword.length < 8) {
      alert("Das Passwort muss mindestens 8 Zeichen lang sein.");
      return;
    }

    if (!/\d/.test(payload.newPassword)) {
      alert("Das Passwort muss mindestens eine Zahl enthalten.");
      return;
    }

    if (!/[A-Z]/.test(payload.newPassword)) {
      alert("Das Passwort muss mindestens einen Großbuchstaben enthalten.");
      return;
    }

    if (!/[a-z]/.test(payload.newPassword)) {
      alert("Das Passwort muss mindestens einen Kleinbuchstaben enthalten.");
      return;
    }

    if (!/[!@#$%^&*?/=,.:;'€]/.test(payload.newPassword)) {
      alert("Das Passwort muss mindestens ein Sonderzeichen enthalten.");
      return;
    }

    const user = state.users.find((user) => user.userId === payload.userId);
    user.password = payload.newPassword;
    await UserServices.UpdateUser(user).then((response) => {
      if (response.data.success) {
        alert("Das Passwort wurde erfolgreich geändert.");
        commit("adminChangePassword", payload);
      } else {
        alert(response.data.message);
      }
    });
  },
};
