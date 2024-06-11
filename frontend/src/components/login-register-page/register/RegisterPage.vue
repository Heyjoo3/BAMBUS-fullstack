<template>
  <div class="register-page">
    <base-content-container>
      <h1 slot="header">Registrieren</h1>
      <register-credential-form id="register-credential-form" />
      <p>Bereits registriert?</p>
      <base-text-button @click="$router.push('/login')">
        Login
      </base-text-button>
    </base-content-container>
  </div>
</template>

<script>
import BaseContentContainer from "../../base-components/BaseContentContainer.vue";
import BaseTextButton from "../../base-components/BaseTextButton.vue";
import RegisterCredentialForm from "./RegisterCredentialForm.vue";

export default {
  name: "RegisterPage",
  components: {
    BaseContentContainer,
    BaseTextButton,
    RegisterCredentialForm,
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

#register-credential-form {
  margin: 2.5% 0;
}
</style>
