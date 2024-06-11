<template>
  <div class="user-view">
    <user-page></user-page>
  </div>
</template>

<script>
import UserPage from "../components/user-pages/user-page/UserPage.vue";

export default {
  name: "UserView",
  components: {
    UserPage,
  },
};
</script>

<style></style>
