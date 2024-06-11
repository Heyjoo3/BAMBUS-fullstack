<template>
  <div>
    <login-page class="login-view-content" />
  </div>
</template>

<script>
import LoginPage from "../components/login-register-page/login/LoginPage.vue";

export default {
  name: "LoginView",
  components: {
    LoginPage,
  },
};
</script>

<style scoped>
.login-view-content {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  background-color: #3b8c84;
}
</style>
