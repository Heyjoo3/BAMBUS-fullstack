<template>
  <div class="password-reset-page">
    <base-content-container>
      <h1 slot="header">Passwort zurücksetzen</h1>
      <username-form />
      <p>Sie haben Ihr Passwort wieder gefunden?</p>
      <base-text-button @click="this.$router.push({ name: 'login' })"
        >Zurück zum Login</base-text-button
      >
    </base-content-container>
  </div>
</template>

<script>
import BaseContentContainer from "../../base-components/BaseContentContainer.vue";
import BaseTextButton from "../../base-components/BaseTextButton.vue";
import UsernameForm from "./UsernameForm.vue";

export default {
  name: "PasswordResetPage",
  components: {
    BaseContentContainer,
    BaseTextButton,
    UsernameForm,
  },
};
</script>

<style scoped></style>
