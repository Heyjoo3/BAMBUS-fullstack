<template>
  <div>
    <h1>Benachrichtigungen</h1>
    <button class="notification-refresh-button" @click="updateNotifications">
      <i class="fa-solid fa-arrows-rotate"></i>
      <p>Neuladen</p>
    </button>
    <base-notification
      v-if="user.notifications != null && user.notifications.length > 0"
      v-for="notification in user.notifications"
      :key="notification.id"
      :notification="notification"
    />
  </div>
</template>

<script>
import { mapGetters } from "vuex";
import { mapActions } from "vuex";

import BaseNotification from "../../base-components/BaseNotification.vue";

export default {
  name: "OverviewTab",
  components: {
    BaseNotification,
  },
  methods: {
    ...mapActions("notificationStore", [
      "checkDueDates",
      "updateNotifications",
    ]),
  },
  computed: {
    ...mapGetters("userStore", { user: "getUser" }),
  },
  beforeMount() {
    this.checkDueDates();
  },
};
</script>

<style scoped>
.notification-refresh-button {
  display: flex;
  align-items: center;
  justify-content: center;
  margin: 0.5rem 0;
  padding: 0.5rem;
  background-color: #2d2d2d;
  color: white;
  border: none;
  border-radius: 0.5rem;
  cursor: pointer;
}

.notification-refresh-button:hover {
  background-color: #3d3d3d;
  box-shadow: 0 0 0.25rem rgba(0, 0, 0, 0.5);
}

.notification-refresh-button i,
p {
  padding: 0 0.25rem;
  color: #fff;
}
</style>
