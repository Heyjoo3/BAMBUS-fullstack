<template>
  <div>
    <register-page class="register-view-content" />
  </div>
</template>

<script>
import RegisterPage from "../components/login-register-page/register/RegisterPage.vue";

export default {
  name: "LoginView",
  components: {
    RegisterPage,
  },
};
</script>

<style scoped>
.register-view-content {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  background-color: #3b8c84;
}
</style>
