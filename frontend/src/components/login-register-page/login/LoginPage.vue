<template>
  <div class="login-page">
    <base-content-container class="login-page-content">
      <h1 slot="header">Login</h1>
      <login-credential-form id="login-credential-form" />
      <p>Noch kein Konto?</p>
      <base-text-button @click="$router.push('/register')">
        Registrieren
      </base-text-button>
      <p>Passwort vergessen?</p>
      <base-text-button @click="this.$router.push({ name: 'reset-password' })">
        Passwort zurücksetzen
      </base-text-button>
    </base-content-container>
  </div>
</template>

<script>
import BaseContentContainer from "../../base-components/BaseContentContainer.vue";
import BaseTextButton from "../../base-components/BaseTextButton.vue";
import LoginCredentialForm from "./LoginCredentialForm.vue";

export default {
  name: "LoginPage",
  components: {
    BaseContentContainer,
    BaseTextButton,
    LoginCredentialForm,
  },
};
</script>

<style scoped>
h1,
h2,
p,
input::placeholder {
  color: #222126;
}

#login-credential-form {
  margin: 2.5% 0;
}
</style>
