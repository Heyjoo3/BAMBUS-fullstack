<template>
  <div>
    <h1>Account Einstellungen</h1>
    <div class="account-container">
      <div class="account-container-left-panel">
        <BaseContainerNarrow>
          <form @submit.prevent="changeUsername(this.newUsername)">
            <h2>Benutzernamen ändern</h2>
            <div class="label-input">
              <label for="newUsername">Neuer Benutzername:</label>
              <input
                type="text"
                id="newUsername"
                v-model="newUsername"
                required
              />
            </div>
            <button type="submit">Speichern</button>
          </form>

          <form @submit.prevent="changeEmail(newEmail)">
            <h2>Email ändern</h2>
            <div class="label-input">
              <label for="newEmail">Neue Email:</label>
              <input type="email" id="newEmail" v-model="newEmail" required />
            </div>
            <button type="submit">Speichern</button>
          </form>

          <form
            @submit.prevent="
              changeName({ firstName: newFirstname, lastName: newLastname })
            "
          >
            <h2>Namen ändern</h2>
            <div class="label-input">
              <label for="newFirstname">Neuer Vorname:</label>
              <input type="text" id="newFirstname" v-model="newFirstname" />
            </div>
            <br />
            <div class="label-input2">
              <label for="newLastname">Neuer Nachname:</label>
              <input type="text" id="newLastname" v-model="newLastname" />
            </div>
            <button type="submit">Speichern</button>
          </form>

          <form
            @submit.prevent="
              changePassword({
                currentPassword: currentPassword,
                newPassword: newPassword,
              })
            "
          >
            <h2>
              Passwort ändern
              <i
                v-if="showPassword"
                class="fa-regular fa-eye-slash"
                style="color: #222126"
                @click="togglePasswordVisibility"
              ></i>
              <i
                v-else
                class="fa-regular fa-eye"
                style="color: #222126"
                @click="togglePasswordVisibility"
              ></i>
            </h2>
            <div class="label-input">
              <label for="currentPassword">Aktuelles Passwort:</label>
              <input
                :type="currentPasswordType"
                id="currentPassword"
                v-model="currentPassword"
                required
              />
            </div>
            <br />
            <div class="label-input2">
              <label for="newPassword">Neues Passwort:</label>
              <input
                :type="currentPasswordType"
                id="newPassword"
                v-model="newPassword"
                required
              />
            </div>
            <button type="submit">Speichern</button>
          </form>
        </BaseContainerNarrow>
        <BaseContainerNarrow>
          <div class="delete-account">
            <h2>Account löschen</h2>
            <button @click="deleteAccount">Account löschen</button>
          </div>
        </BaseContainerNarrow>
      </div>

      <div class="account-container-right-panel">
        <BaseContainerNarrow>
          <h2>Account Daten</h2>
          <p><strong>Benutzername:</strong> {{ user.username }}</p>
          <p><strong>Email:</strong> {{ user.email }}</p>
          <p><strong>Vorname:</strong> {{ user.firstName }}</p>
          <p><strong>Nachname:</strong> {{ user.lastName }}</p>
        </BaseContainerNarrow>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters } from "vuex";
import { mapActions } from "vuex";
import BaseContainerNarrow from "@/components/base-components/BaseContainerNarrow.vue";

export default {
  name: "AccountTab",
  components: {
    BaseContainerNarrow,
  },
  data() {
    return {
      currentPassword: "",
      newPassword: "",
      newUsername: "",
      newEmail: "",
      newFirstname: "",
      newLastname: "",
      showPassword: false,
    };
  },
  methods: {
    ...mapActions("userStore", [
      "changeUsername",
      "changeEmail",
      "changeName",
      "changePassword",
      "deleteAccount",
    ]),
    togglePasswordVisibility() {
      this.showPassword = !this.showPassword;
    },
  },
  computed: {
    ...mapGetters("userStore", { user: "getUser" }),
    currentPasswordType() {
      return this.showPassword ? "text" : "password";
    },
  },
};
</script>

<style scoped>
h2 {
  grid-area: h2;
  margin-bottom: 0.5rem;
}
.label-input {
  grid-area: label-input;
  display: grid;
  grid-template-columns: 1fr 2fr;
  gap: 0.5rem;
}
.label-input2 {
  grid-area: label-input2;
  display: grid;
  grid-template-columns: 1fr 2fr;
  gap: 0.5rem;
}
input {
  width: 100%;
  justify-self: end;
}
label {
  justify-self: start;
  width: 100%;
}
button {
  grid-area: button;
  justify-self: end;
  width: 10rem;
  padding: 0.5rem;
  background-color: #d9910d;
  color: #f2eae4;
  border: none;
  border-radius: 0.5rem;
  box-shadow: 0px 0px 5px 0px #222126;
  cursor: pointer;
  transition: 0.3s;
  font-size: 1rem;
}
.account-container {
  width: 100%;
  display: grid;
  grid-template-columns: 2fr 1fr;
  margin-top: 2.5%;
}
.account-container-left-panel {
  flex: 1;
  padding-right: 1%;
}

.account-container-left-panel form {
  margin-bottom: 2.5%;
}

.account-container-right-panel {
  flex: 1;
  padding-left: 1%;
}

.delete-account {
  display: inline-flex;
  flex-direction: row;
  align-items: center;
  width: 100%;
  justify-content: space-between;
}

form {
  width: 100%;
  display: grid;

  grid-template-rows: 1fr, 1fr, 1fr, 1fr;
  gap: 0.5rem;
  grid-template-areas: "h2" "label-input" "label-input" "label-input2" "button";
}
</style>
