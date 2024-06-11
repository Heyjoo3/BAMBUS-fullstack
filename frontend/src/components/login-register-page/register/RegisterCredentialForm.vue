<template>
  <form @submit.prevent class="register-credential-form">
    <h2>Bitte geben Sie Ihre Anmeldedaten ein, um sich zu registrieren.</h2>
    <p>
      Alle Felder müssen ausgefüllt sein. <br />
      Das Passwort muss Groß- und Kleinbuchstaben, mindestens eine Zahl und ein
      Sonderzeichen beinhalten.
    </p>
    <section>
      <input
        class="register-credential-form-input"
        :class="{ 'is-invalid': v$.username.$error }"
        type="text"
        placeholder="Username"
        v-model="username"
      />
      <input
        class="register-credential-form-input"
        :class="{ 'is-invalid': v$.email.$error }"
        type="email"
        placeholder="Email"
        v-model="email"
      />
      <input
        class="register-credential-form-input"
        :class="{ 'is-invalid': v$.firstName.$error }"
        type="text"
        placeholder="Vorname"
        v-model="firstName"
      />
      <input
        class="register-credential-form-input"
        :class="{ 'is-invalid': v$.lastName.$error }"
        type="text"
        placeholder="Nachname"
        v-model="lastName"
      />
      <input
        class="register-credential-form-input"
        :class="{ 'is-invalid': v$.password.$error }"
        id="inputPassword"
        :type="showPassword ? 'text' : 'password'"
        placeholder="Passwort"
        v-model="password"
      />
      <input
        class="register-credential-form-input"
        :class="{ 'is-invalid': v$.repeatPassword.$error }"
        id="inputPasswordRepeat"
        :type="showPassword ? 'text' : 'password'"
        placeholder="Passwort wiederholen"
        v-model="repeatPassword"
      />
    </section>
    <button
      class="button-toggle-password"
      type="button"
      @click="togglePassword()"
    >
      <i v-if="showPassword" class="fas fa-eye"></i>
      <i v-else class="fa-regular fa-eye"></i>
    </button>
    <base-text-button @click="submitForm()">Registrieren</base-text-button>
  </form>
</template>

<script>
import { mapActions } from "vuex";
import { useVuelidate } from "@vuelidate/core";
import {
  required,
  email,
  minLength,
  maxLength,
  sameAs,
} from "@vuelidate/validators";

import BaseTextButton from "../../base-components/BaseTextButton.vue";

export default {
  name: "RegisterCredentialForm",
  components: {
    BaseTextButton,
  },
  setup() {
    return { v$: useVuelidate() };
  },
  data() {
    return {
      username: "",
      email: "",
      password: "",
      repeatPassword: "",
      firstName: "",
      lastName: "",
      showPassword: false,
    };
  },
  validations() {
    return {
      username: { required, minLength: minLength(3), maxLength: maxLength(30) },
      email: { required, email },
      password: {
        required,
        minLength: minLength(8),
        maxLength: maxLength(30),
        customPasswordValidation: this.customPasswordValidation,
      },
      repeatPassword: {
        required,
        sameAsPassword: sameAs(this.password),
        customPasswordValidation: this.customPasswordValidation,
      },
      firstName: {
        required,
        minLength: minLength(2),
        maxLength: maxLength(30),
      },
      lastName: { required, minLength: minLength(2), maxLength: maxLength(30) },
    };
  },
  methods: {
    ...mapActions("userStore", ["registerUser"]),
    customPasswordValidation() {
      const lowerCaseRegex = /[a-z]/;
      const upperCaseRegex = /[A-Z]/;
      const numberRegex = /[0-9]/;
      const specialCharRegex = /[^a-zA-Z0-9]/;
      return (
        lowerCaseRegex.test(this.password) &&
        upperCaseRegex.test(this.password) &&
        numberRegex.test(this.password) &&
        specialCharRegex.test(this.password)
      );
    },
    togglePassword() {
      this.showPassword = !this.showPassword;
    },
    async submitForm() {
      this.v$.$validate();
      if (!this.v$.$error) {
        await this.registerUser(this.registerForm);
      }
    },
  },
  computed: {
    registerForm: function () {
      return {
        username: this.username,
        email: this.email,
        password: this.password,
        repeatPassword: this.repeatPassword,
        firstName: this.firstName,
        lastName: this.lastName,
      };
    },
  },
};
</script>

<style scoped>
.register-credential-form {
  width: 100%;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  align-items: center;
}

.register-credential-form-input {
  width: 45%;
  border: 1px solid transparent;
  margin: 2.5%;
  padding: 2%;
  border-radius: 0.5rem;
  box-shadow: 0px 0px 5px 0px #222126;
  transition: all 0.3s;
}

.register-credential-form-input:focus {
  box-shadow: 0px 0px 10px 0px #222126;
}

.register-credential-form-input:active {
  box-shadow: 0px 0px 5px 0px #222126;
}
.button-toggle-password {
  background-color: transparent;
  border: none;
  cursor: pointer;
}

.is-invalid {
  border: 1px solid red;
  box-shadow: 0px 0px 5px 0px red;
}
</style>
