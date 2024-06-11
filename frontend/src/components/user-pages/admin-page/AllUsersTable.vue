<template>
  <div class="header">
    <p class="firstName">Vorname</p>
    <p class="lastName">Nachname</p>
    <p class="email">Email</p>
    <div class="editPasswordHeader">
      <p>Passwort ändern </p>
      <button @click="showPasswords">
        <i v-if="showPassword" class="fa-regular fa-eye-slash"></i>
        <i v-else class="fa-regular fa-eye"></i>
      </button>
    </div>
    <div class = "deletePassword">
      <p>Account löschen?</p>
    </div> 
  </div>
  <hr />
  <div class="content" v-for="(user, index) in users" :key="user.class" :class="{ uneven: index % 2 == 0 }">
    <p class="firstName">{{ user.firstName }}</p>
    <p class="lastName">{{ user.lastName }}</p>
    <p class="email">{{ user.email }}</p>
    <div class="editPassword">
      <input type="password" v-model="passwordInputs[index]" placeholder="Neues Passwort" />
      <base-rectangle-button @click="
        changePassword(index, user.userId)
        ">Speichern</base-rectangle-button>
    </div class="deletePassword">
    <base-rectangle-button @click="adminDeleteAccount(user.userId)">Löschen</base-rectangle-button>
  </div>
</template>

<script>
import { mapGetters } from "vuex";
import { mapActions } from "vuex";

import BaseRectangleButton from "@/components/base-components/BaseRectangleButton.vue";

export default {
  name: "UserManagementTab",
  components: {
    BaseRectangleButton,
  },
  data() {
    return {
      passwordInputs: [],
      showPassword: false,
    };
  },
  methods: {
    ...mapActions("userStore", ["adminChangePassword", "adminDeleteAccount"]),
    showPasswords() {
      var passwordInputs = document.querySelectorAll("input");
      passwordInputs.forEach((input) => {
        if (input.type === "password") {
          input.type = "text";
          this.showPassword = true;
        } else {
          input.type = "password";
          this.showPassword = false;
        }
      });
    },
    changePassword(index, userId) {
      this.adminChangePassword({
        newPassword: this.passwordInputs[index],
        userId: userId,
      });
      this.passwordInputs[index] = "";
    }
  },
  computed: {
    ...mapGetters("userStore", { users: "getEmployees" }),
  },
};
</script>

<style scoped>
.header,
.content {
  display: flex;
  flex-direction: row;
  width: 75vw;
  align-items: center;
  padding: 0.5rem;
  overflow: auto;
}

.header {
  font-weight: bold;
}

.uneven {
  background-color: #d8c6b9;
}

.firstName,
.lastName {
  width: 15%;
  text-align: left;
  min-width: 120px;
  overflow-wrap: break-word;
}

.email {
  width: 30%;
  text-align: left;
  min-width: 120px;
  overflow-wrap: break-word;
}

.editPasswordHeader {
  width: 30%;
  display: flex;
  flex-direction: row;
  min-width: 240px;
}

.editPasswordHeader button {
  border: none;
  background-color: transparent;
  margin-left: 0.5rem;
}

.editPassword {
  width: 30%;
  display: flex;
  flex-direction: row;
  min-width: 240px;
  justify-content: space-between;
  padding-right: 5%;
}

.editPassword input {
  width: 60%;
  min-width: 120px;
}

.deletePassword {
  width: 10%;
  min-width: 80px;
  text-align: left;
}

.deletePassword button {
  height: 1rem;
}
</style>
