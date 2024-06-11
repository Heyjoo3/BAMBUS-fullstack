import { createStore } from "vuex";

import Mutations from "./mutations.js";
import Actions from "./actions.js";
import Getters from "./getters.js";

import UserStore from "./modules/user/index.js";
import ItemStore from "./modules/item/index.js";
import ModalStore from "./modules/modal/index.js";
import RatingStore from "./modules/rating/index.js";
import CartStore from "./modules/cart/index.js";
import NotificationStore from "./modules/notification/index.js";
import LoanStore from "./modules/loan/index.js";

const store = createStore({
  modules: {
    userStore: UserStore,
    itemStore: ItemStore,
    modalStore: ModalStore,
    ratingStore: RatingStore,
    cartStore: CartStore,
    notificationStore: NotificationStore,
    loanStore: LoanStore,
  },
  state: {},
  mutations: Mutations,
  actions: Actions,
  getters: Getters,
});

export default store;
