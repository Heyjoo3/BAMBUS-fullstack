<template>
  <div>
    <i class="fa-solid fa-arrow-right-from-bracket" style="color: #f2eae4"></i>
    <p @click="logoutUser()">Logout</p>
  </div>
</template>

<script>
import { mapActions } from "vuex";

export default {
  name: "UserLogout",
  methods: {
    ...mapActions(["logoutUser"]),
  },
};
</script>
