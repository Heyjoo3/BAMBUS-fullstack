export default {
  toggleEditModal({ commit }) {
    commit("toggleEditModal");
  },
  toggleRatingsModal({ commit }) {
    commit("toggleRatingsModal");
  },
  toggleReturnModal({ commit }) {
    commit("toggleReturnModal");
  },
  toggleReportModal({ commit }) {
    commit("toggleReportModal");
  },
  closeAllModals({ commit }) {
    commit("closeAllModals");
  },
};
