<template>
  <form class="email-form">
    <label for="email"
      >Bitte gebe Deine Emailadresse ein, um eine Passwortzurücksetzung zu
      benatragen.
    </label>
    <Form v-slot="{ validate }" @submit="onSubmit">
      <Field
        name="email"
        type="email"
        :rules="validateEmail"
        class="email-form-input"
        placeholder="Emailadresse"
      />
      <ErrorMessage name="email" />
      <base-text-button @click="validate">
        Passwort zurücksetzen
      </base-text-button>
    </Form>
  </form>
</template>

<script>
import { mapActions } from "vuex";
import { Form, Field, ErrorMessage } from "vee-validate";

import BaseTextButton from "../../base-components/BaseTextButton.vue";

export default {
  name: "PasswordResetPage",
  components: {
    BaseTextButton,
    Form,
    Field,
    ErrorMessage,
  },
  methods: {
    ...mapActions("notificationStore", {
      requestPasswordReset: "userRequestsPasswordReset",
    }),
    onSubmit(values) {
      this.requestPasswordReset(values.email);
    },
    validateEmail(value) {
      if (!value) {
        return "Dieses Feld muss ausgefüllt werden";
      }
      const regex = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i;
      if (!regex.test(value)) {
        return "Bitte gebe eine gültige Emailadresse an";
      }
      return true;
    },
  },
};
</script>

<style scoped>
.email-form,
Form {
  width: 100%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

.email-form-input {
  width: 80%;
  margin: 2.5%;
  padding: 2%;
  border-radius: 0.5rem;
  border: none;
  box-shadow: 0px 0px 5px 0px #222126;
}

.email-form-input:focus {
  box-shadow: 0px 0px 10px 0px #222126;
}

.email-form-input:active {
  box-shadow: 0px 0px 5px 0px #222126;
}

span {
  color: red;
  margin-bottom: 0.5rem;
}

h1,
h2,
p,
Field::placeholder {
  color: #222126;
}
</style>
