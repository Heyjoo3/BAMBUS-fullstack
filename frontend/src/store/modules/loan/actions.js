import LoanService from "@/store/services/LoanService";
import $router from "@/router";

export default {
  async returnItem({ commit, rootState }, itemId) {
    try {
      const returnDate = new Date().toISOString().split("T")[0];
      const item = rootState.itemStore.items.find(
        (item) => item.itemId === itemId
      );
      const loanId = item.currentLoanId;
      const response = await LoanService.SetReturnDate(loanId);

      if (response.data.success) {
        commit("setReturnDate", { loanId, returnDate });
      } else {
        throw new Error(response.data.message || "Error setting return date");
      }
    } catch (error) {
      console.error("Error returning item:", error);
      $router.push("/error");
    }
  },

  async extensionRequestResponse({ dispatch }, payload) {
    try {
      await LoanService.EndExtensionRequest({
        loanId: payload.loanId,
        response: payload.response,
        newDueDate: payload.newDueDate,
      }).then(async (response) => {
        if (response.data.success) {
          await dispatch("updateLoans");
          await dispatch(
            "notificationStore/managerRespondsToExtensionRequest",
            payload,
            { root: true }
          );
        } else {
          throw new Error(
            response.data.message || "Error ending extension request"
          );
        }
      });
    } catch (error) {
      console.error("Error responding to extension request:", error);
      $router.push("/error");
    }
  },

  async setReturnDate({ commit }, loanId) {
    try {
      const response = await LoanService.SetReturnDate(loanId);

      if (response.data.success) {
        commit("setReturnDate", response.data.data);
      } else {
        throw new Error(response.data.message || "Error setting return date");
      }
    } catch (error) {
      console.error("Error setting return date:", error);
      $router.push("/error");
    }
  },

  async updateLoans({ commit }) {
    try {
      const loanResponse = await LoanService.GetAllLoans();
      if (!loanResponse.data.success) {
        throw new Error(loanResponse.data.message || "Error updating loans");
      } else {
        commit("setLoans", loanResponse.data.data);
      }
    } catch (error) {
      console.error("Error updating loans:", error);
      throw error;
    }
  },
};
