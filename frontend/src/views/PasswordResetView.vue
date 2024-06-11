<template>
  <div>
    <password-reset-page class="password-reset-view-content" />
  </div>
</template>

<script>
import PasswordResetPage from "../components/login-register-page/password-reset/PasswordResetPage.vue";

export default {
  name: "PasswordResetView",
  components: {
    PasswordResetPage,
  },
};
</script>

<style scoped>
.password-reset-view-content {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  background-color: #3b8c84;
}
</style>
