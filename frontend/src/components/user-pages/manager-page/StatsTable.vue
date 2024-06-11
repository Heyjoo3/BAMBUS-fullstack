<template>
  <div class="header">
    <p id="firstName" @click="sortFirstName">Vorname</p>
    <p id="lastName" @click="sortLastName">Nachname</p>
    <p id="numberLoans" @click="sortNumberLoans">Ausleihen</p>
    <p id="numberExtensions" @click="sortNumberExtensions">Verlängerungen</p>
    <p id="numberMissedReturns" @click="sortMissedReturns">
      Verpasste Rückgaben
    </p>
  </div>
  <hr />
  <div
    class="row"
    v-for="(user, index) in users"
    :key="user.index"
    :class="{ uneven: index % 2 == 0 }"
  >
    <p id="firstName">{{ user.firstName }}</p>
    <p id="lastName">{{ user.lastName }}</p>
    <p id="numberLoans">{{ user.numberLoans }}</p>
    <p id="numberExtensions">{{ user.numberExtensions }}</p>
    <p id="numberMissedReturns">{{ user.numberMissedReturns }}</p>
  </div>
</template>

<script>
import { mapGetters } from "vuex";

export default {
  name: "StatsTable",
  data() {
    return {
      firstNameDesc: false,
      lastNameDesc: false,
      numberLoansDesc: false,
      numberExtensionsDesc: false,
      numberMissedReturnsDesc: false,
    };
  },
  computed: {
    ...mapGetters("userStore", { users: "getEmployees" }),
  },
  methods: {
    sortFirstName() {
      if (this.firstNameDesc) {
        this.users.sort((a, b) => a.firstName.localeCompare(b.firstName));
      } else {
        this.users.sort((a, b) => b.firstName.localeCompare(a.firstName));
      }
      this.firstNameDesc = !this.firstNameDesc;
      this.$forceUpdate();
    },
    sortLastName() {
      if (this.lastNameDesc) {
        this.users.sort((a, b) => a.lastName.localeCompare(b.lastName));
      } else {
        this.users.sort((a, b) => b.lastName.localeCompare(a.lastName));
      }
      this.lastNameDesc = !this.lastNameDesc;
      this.$forceUpdate();
    },
    sortNumberLoans() {
      if (this.numberLoansDesc) {
        this.users.sort((a, b) => a.numberLoans - b.numberLoans);
      } else {
        this.users.sort((a, b) => b.numberLoans - a.numberLoans);
      }
      this.numberLoansDesc = !this.numberLoansDesc;
      this.$forceUpdate();
    },
    sortNumberExtensions() {
      if (this.numberExtensionsDesc) {
        this.users.sort((a, b) => a.numberExtensions - b.numberExtensions);
      } else {
        this.users.sort((a, b) => b.numberExtensions - a.numberExtensions);
      }
      this.numberExtensionsDesc = !this.numberExtensionsDesc;
      this.$forceUpdate();
    },
    sortMissedReturns() {
      if (this.numberMissedReturnsDesc) {
        this.users.sort(
          (a, b) => a.numberMissedReturns - b.numberMissedReturns
        );
      } else {
        this.users.sort(
          (a, b) => b.numberMissedReturns - a.numberMissedReturns
        );
      }
      this.numberMissedReturnsDesc = !this.numberMissedReturnsDesc;
      this.$forceUpdate();
    },
  },
};
</script>

<style scoped>
.header,
.row {
  display: inline-flex;
  width: 75vw;
  align-items: center;
  padding: 0.5rem;
  overflow: auto;
}
.header {
  font-weight: bold;
}

.header p:hover {
  cursor: pointer;
}
.uneven {
  background-color: #d8c6b9;
}

#firstName,
#lastName {
  width: 20%;
  text-align: left;
  min-width: 120px;
  overflow-wrap: break-word;
}
#numberLoans,
#numberExtensions,
#numberMissedReturns {
  width: 20%;
  text-align: center;
  min-width: 50px;
  overflow-wrap: break-word;
}

hr {
  width: 75vw;
  background-color: #222126;
}
</style>
