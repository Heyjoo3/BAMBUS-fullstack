import Mutations from "./mutations.js";
import Actions from "./actions.js";
import Getters from "./getters.js";

export default {
  namespaced: true,
  state: {
    users: [],
    userIsAuth: false,
    user: {
      userId: null,
      username: null,
      password: null,
      role: null,
      email: null,
      firstName: null,
      lastName: null,
      notifications: [],
      token: null,
    },
  },
  mutations: Mutations,
  actions: Actions,
  getters: Getters,
};
