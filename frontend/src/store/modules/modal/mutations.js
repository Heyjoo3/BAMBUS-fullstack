export default {
  toggleEditModal(state) {
    state.editItemModalStatus = !state.editItemModalStatus;
  },
  toggleRatingsModal(state) {
    state.ratingsModalStatus = !state.ratingsModalStatus;
  },
  toggleReportModal(state) {
    state.reportModalStatus = !state.reportModalStatus;
  },
  toggleReturnModal(state) {
    state.returnItemModalStatus = !state.returnItemModalStatus;
  },
  closeAllModals(state) {
    state.editItemModalStatus = false;
    state.ratingsModalStatus = false;
    state.returnItemModalStatus = false;
    state.reportModalStatus = false;
  },
  logout(state) {
    state.editItemModalStatus = false;
    state.ratingsModalStatus = false;
    state.returnItemModalStatus = false;
    state.reportModalStatus = false;
  },
};
