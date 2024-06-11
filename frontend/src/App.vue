<template>
  <div class="app-base">
    <side-nav class="app-base-side-nav"></side-nav>
    <RouterView class="app-base-content" />
  </div>
</template>

<script>
import { RouterLink, RouterView } from "vue-router";
import SideNav from "./components/side-nav/SideNav.vue";

export default {
  name: "App",
  components: {
    RouterLink,
    RouterView,
    SideNav,
  },
  mounted() {
    this.$store.dispatch("ratingStore/loadAllRatings");
  },
};
</script>

<style>
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  font-family: "Red Hat Text", sans-serif;
  color: #222126;
  scroll-behavior: smooth;
}

p {
  font-size: 18px;
}

h1 {
  font-size: 2rem;
  font-weight: bold;
}

h2 {
  font-size: 1.5rem;
  font-weight: bold;
}

.app-base {
  display: flex;
  flex-direction: row;
  height: 100vh;
  width: 100vw;
}

.app-base-side-nav {
  position: fixed;
  top: 0;
  left: 0;
  width: 20vw;
  height: 100vh;
}

.app-base-content {
  margin-left: 20vw;
  min-height: 100vh;
  width: 80vw;
}

::-webkit-scrollbar {
  width: 0px;
}
</style>
