<template>
  <div class="SideNav-Content">
    <cart-link
      class="SideNav-Content-Section"
      v-if="isLoggedIn && user.role === 0"
      @click="redirectTo('/cart')"
    ></cart-link>
    <br />
    <return-link
      class="SideNav-Content-Section"
      v-if="isLoggedIn && user.role === 0"
      @click="redirectTo('/my-view/orders')"
    ></return-link>

    <new-item-link
      class="SideNav-Content-Section"
      v-if="isLoggedIn && user.role === 1"
      @click="redirectTo('/new-item')"
    ></new-item-link>

    <section class="SideNav-Content-User-Area">
      <user-login
        class="SideNav-Content-Section"
        v-if="!isLoggedIn"
        @click="redirectTo('/login')"
      />
      <user-employee
        class="SideNav-Content-Section"
        v-else-if="isLoggedIn && user.role === 0"
        @click="redirectTo('/my-view/overview')"
      />
      <user-manager
        class="SideNav-Content-Section"
        v-else-if="isLoggedIn && user.role === 1"
        @click="redirectTo('/managing/overview')"
      />
      <user-admin
        class="SideNav-Content-Section"
        v-else-if="isLoggedIn && user.role === 2"
        @click="redirectTo('/admin/overview')"
      />
    </section>
    <user-logout class="SideNav-Content-Section" v-if="isLoggedIn" />
  </div>
</template>

<script>
import { mapGetters } from "vuex";

import CartLink from "./CartLink.vue";
import UserLogin from "./UserLogin.vue";
import UserEmployee from "./UserEmployee.vue";
import UserManager from "./UserManager.vue";
import UserAdmin from "./UserAdmin.vue";
import ReturnLink from "./ReturnLink.vue";
import UserLogout from "./UserLogout.vue";
import NewItemLink from "./NewItemLink.vue";

export default {
  name: "SideNavUserArea",
  components: {
    CartLink,
    UserLogin,
    UserEmployee,
    UserManager,
    UserAdmin,
    ReturnLink,
    UserLogout,
    NewItemLink,
  },
  methods: {
    redirectTo(path) {
      this.$router.push(path);
    },
  },
  computed: {
    ...mapGetters("userStore", {
      isLoggedIn: "isUserAuthenticated",
      user: "getUser",
    }),
  },
};
</script>

<style>
.SideNav-Content-Section {
  display: inline-flex;
  flex-direction: row;
  align-items: center;
  height: 10%;
  margin: 5% 1%;
  justify-content: start;
}

.SideNav-Content-Section.is-hidden {
  visibility: hidden;
}

.SideNav-Content-Section p {
  display: inline-flex;
  font-size: 1.5vw;
  color: #f2eae4;
}

.SideNav-Content-Section p:hover {
  cursor: pointer;
  color: #d9910d;
  transition: 0.3s;
}

.SideNav-Content-Section i {
  width: 2.5rem;
  font-size: 1.5vw;
  display: inline-flex;
  color: #f2eae4;
}
</style>
