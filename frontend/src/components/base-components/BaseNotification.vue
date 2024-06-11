<template>
  <div class="base-notification-element">
    <section class="notification-base-content">
      <h2>{{ title }}</h2>
      <br />
      <h3>Von {{ senderName }} am {{ date }}</h3>
      <p>{{ notification.text }}</p>
    </section>
    <div>
      <section
        class="notification-manager-extension"
        v-if="this.notification.type == 4"
      >
        <base-text-button @click="sendResponse(true)"
          >Akzeptieren</base-text-button
        >
        <base-text-button @click="sendResponse(false)"
          >Ablehnen</base-text-button
        >
      </section>
      <section class="notification-delete" v-else>
        <base-text-button @click="deleteNotification(notification.messageId)"
          >Löschen</base-text-button
        >
      </section>
    </div>
  </div>
</template>

<script>
import { mapActions } from "vuex";

import BaseTextButton from "./BaseTextButton.vue";
import notification from "@/store/modules/notification";
import MessageService from "@/store/services/MessageService";

export default {
  name: "BaseNotification",
  props: {
    notification: {
      type: Object,
      required: true,
    },
  },
  components: {
    BaseTextButton,
  },
  computed: {
    senderName() {
      if (this.notification.senderId == 0) return "System";
      const user = this.$store.getters["userStore/getUserFromUsers"](
        this.notification.senderId
      );
      if (!user) return "Unbekannter User";
      const name = user.firstName + " " + user.lastName;
      return name;
    },
    title() {
      switch (this.notification.type) {
        case 0:
          return "Erinnerung an den Rückgabezeitpunkt";
        case 1:
          return "Benachrichtigung über die Reservierung";
        case 2:
          return "Benachrichtigung über die Ausleihe";
        case 3:
          return "Benachrichtigung über die Rückgabe";
        case 4:
          return "Anfrage zur Verlängerung einer Ausleihe";
        case 5:
          return "Rückgabe ist überfällig";
        case 6:
          return "User hat sich registriert";
        case 7:
          return "Anfrage zur Zurücksetzung des Passworts";
        case 8:
          return "Schaden wurde gemeldet";
        case 9:
          return "Ein neuer Artikel ist im System verfügbar!";
        case 10:
          return "Der Manager hat deine Anfrage zur Verlängerung der Ausleihe bearbeitet";
        default:
          return "Neue Benachrichtigung";
      }
    },
    date() {
      let date = new Date(this.notification.date).toLocaleDateString("de-DE");
      return date;
    },
  },
  methods: {
    ...mapActions("loanStore", ["extensionRequestResponse"]),
    ...mapActions("userStore", ["deleteNotification"]),
    ...mapActions("notificationStore", ["updateNotifications"]),
    async sendResponse(response) {
      const loanId = parseInt(this.notification.payload.split(";")[0]);
      const newDueDate = this.notification.payload.split(";")[2];
      await this.extensionRequestResponse({
        loanId: loanId,
        newDueDate: newDueDate,
        response: response,
        messageId: this.notification.messageId,
      });
    },
  },
};
</script>

<style scoped>
.base-notification-element {
  background-color: #f2eae4;
  padding: 1.25rem;
  margin: 1%;
  border-radius: 2rem;
  box-shadow: 0 0 0.5rem #222126;
  color: #222126;
  display: flex;
  justify-content: space-between;
  align-items: center;
}
</style>
