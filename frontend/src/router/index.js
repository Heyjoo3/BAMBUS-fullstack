import { createRouter, createWebHistory } from "vue-router";

import store from "../store/index.js";

import CatalogView from "../views/CatalogView.vue";
import LoginView from "../views/LoginView.vue";
import RegisterView from "../views/RegisterView.vue";
import CartView from "../views/CartView.vue";
import UserView from "../views/UserView.vue";
import AdminView from "../views/AdminView.vue";
import ManagerView from "../views/ManagerView.vue";
import PasswordResetView from "../views/PasswordResetView.vue";
import NewItemView from "../views/NewItemView.vue";
import ErrorView from "../views/ErrorView.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  scrollBehavior(to, from, savedPosition) {
    if (to.hash) {
      let el = document.querySelector(to.hash);
      if (el) {
        return {
          top: el.offsetTop,
          behavior: "smooth",
        };
      }
    }
    return { x: 0, y: 0 };
  },

  routes: [
    {
      path: "/",
      name: "catalog",
      component: CatalogView,
      children: [
        {
          path: ":category",
          name: "catalog-category",
          component: CatalogView,
          props: true,
          params: true,
          paramsAsProps: true,
        },
      ],
    },
    {
      path: "/cart",
      name: "cart",
      component: CartView,
      beforeEnter: (to, from, next) => {
        const userRole = store.state.userStore.user.role;
        if (userRole === 0) {
          next();
        } else {
          next("/");
        }
      },
    },

    {
      path: "/new-item",
      name: "new-item",
      component: NewItemView,
      beforeEnter: (to, from, next) => {
        const userRole = store.state.userStore.user.role;
        if (userRole === 1) {
          next();
        } else {
          next("/");
        }
      },
    },

    {
      path: "/my-view",
      name: "user-view",
      redirect: { name: "user-view-overview" },
      beforeEnter: (to, from, next) => {
        const userRole = store.state.userStore.user.role;
        if (userRole === 0) {
          next();
        } else {
          next("/");
        }
      },
      children: [
        {
          path: ":overview",
          name: "user-view-overview",
          component: UserView,
          props: true,
        },
        {
          path: ":orders",
          name: "user-view-orders",
          component: UserView,
          props: true,
        },
        {
          path: ":account",
          name: "user-view-account",
          component: UserView,
          props: true,
        },
      ],
    },
    {
      path: "/admin",
      name: "admin-view",
      redirect: { name: "admin-view-overview" },
      beforeEnter: (to, from, next) => {
        const userRole = store.state.userStore.user.role;
        if (userRole === 2) {
          next();
        } else {
          next("/");
        }
      },
      children: [
        {
          path: ":overview",
          name: "admin-view-overview",
          component: AdminView,
          props: true,
        },
        {
          path: ":management",
          name: "admin-view-management",
          component: AdminView,
          props: true,
        },
        {
          path: ":settings",
          name: "admin-view-settings",
          component: AdminView,
          props: true,
        },
      ],
    },
    {
      path: "/managing",
      name: "manager-view",
      redirect: { name: "manager-view-overview" },
      beforeEnter: (to, from, next) => {
        const userRole = store.state.userStore.user.role;
        if (userRole === 1) {
          next();
        } else {
          next("/");
        }
      },
      children: [
        {
          path: ":overview",
          name: "manager-view-overview",
          component: ManagerView,
          props: true,
        },
        {
          path: ":beschädigungen",
          name: "manager-view-beschaedigungen",
          component: ManagerView,
          props: true,
        },
        {
          path: ":statistics",
          name: "manager-view-statistics",
          component: ManagerView,
          props: true,
        },
      ],
    },
    {
      path: "/login",
      name: "login",
      component: LoginView,
    },
    {
      path: "/register",
      name: "register",
      component: RegisterView,
    },
    {
      path: "/reset-password",
      name: "reset-password",
      component: PasswordResetView,
    },
    {
      path: "/:pathMatch(.*)*",
      name: "not-found",
      redirect: { name: "catalog" },
    },
    {
      path: "/sorry",
      name: "LoadingProblems",
      component: ErrorView,
    },
  ],
});

export default router;
