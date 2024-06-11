import Mutations from "./mutations.js";
import Actions from "./actions.js";
import Getters from "./getters.js";

export default {
  namespaced: true,
  state: {
    editItemModalStatus: false,
    ratingsModalStatus: false,
    returnItemModalStatus: false,
    reportModalStatus: false,
  },
  mutations: Mutations,
  actions: Actions,
  getters: Getters,
};
