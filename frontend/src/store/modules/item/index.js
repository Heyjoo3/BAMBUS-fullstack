import Mutations from "./mutations.js";
import Actions from "./actions.js";
import Getters from "./getters.js";

export default {
  namespaced: true,
  state: {
    editItemId: null,
    returnItemId: null,
    reportItemId: null,
    filteredBy: null,
    sortedBy: null,
    onlyAvailable: false,
    search: "",
    items: [],
  },
  mutations: Mutations,
  actions: Actions,
  getters: Getters,
};
