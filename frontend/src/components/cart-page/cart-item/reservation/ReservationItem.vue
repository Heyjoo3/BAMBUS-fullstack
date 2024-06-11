<template>
  <div class="reservation-item">
    <h2>{{ reservationItem.title }}</h2>
    <div class="reservation-item-content">
      <item-information
        class="reservation-item-content-row"
        :itemId="reservationItem.itemId"
        :condition="reservationItem.condition"
      />
      <p class="reservation-item-content-row">
        Warteschlangenlänge {{ reservationQueueLength }}
      </p>
      <section class="reservation-item-content-row">
        <base-text-button
          class="reservation-item-content-row-button"
          @click="reserveItem(reservationItem.itemId)"
          >Item reservieren</base-text-button
        >
        <base-text-button
          class="reservation-item-content-row-button"
          @click="removeReservationItemFromCart(reservationItem.itemId)"
          >Aus Korb entfernen</base-text-button
        >
      </section>
    </div>
    <hr />
  </div>
</template>

<script>
import { mapActions } from "vuex";

import ItemInformation from "../ItemInformation.vue";
import BaseTextButton from "../../../base-components/BaseTextButton.vue";

export default {
  name: "ReservationItem",
  props: {
    reservationItem: Object,
  },
  components: {
    ItemInformation,
    BaseTextButton,
  },
  computed: {
    reservationQueueLength() {
      return this.reservationItem.reservations.length;
    },
  },
  methods: {
    ...mapActions("cartStore", [
      "reserveItem",
      "removeReservationItemFromCart",
    ]),
  },
};
</script>

<style scoped>
.reservation-item {
  width: 100%;
  margin-bottom: 2vh;
}

.reservation-item-content {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
}

.reservation-item-content-row {
  width: 100%;
  margin: 1vw, 0;
}

.reservation-item-content-row-button {
  display: flex;
  flex-direction: column;
  align-items: center;
  width: 50%;
  margin-left: 25%;
}
</style>
