<template>
  <div class="cart-page">
    <h1 v-if="!cartRentalItems.length && !cartReservationItems.length">
      Der Korb ist leer.
    </h1>
    <cart-container v-if="cartRentalItems.length > 0">
      <h1 slot="header">Ausleihen</h1>
      <rental-item
        v-for="rentalItem in cartRentalItems"
        :key="rentalItem.itemId"
        :rentalItem="rentalItem"
      ></rental-item>
    </cart-container>
    <cart-container v-if="cartReservationItems.length > 0">
      <h1 slot="header">Reservieren</h1>
      <reservation-item
        v-for="reservationItem in cartReservationItems"
        :key="reservationItem.itemId"
        :reservationItem="reservationItem"
      ></reservation-item>
    </cart-container>
  </div>
</template>

<script>
import { mapGetters } from "vuex";

import CartContainer from "./CartContainer.vue";
import RentalItem from "./cart-item//rental/RentalItem.vue";
import ReservationItem from "./cart-item/reservation/ReservationItem.vue";

export default {
  name: "CartPage",
  components: {
    CartContainer,
    RentalItem,
    ReservationItem,
  },
  computed: {
    ...mapGetters("cartStore", {
      cartRentalItems: "getCartRentalItems",
      cartReservationItems: "getCartReservationItems",
    }),
  },
};
</script>

<style scoped>
.cart-page {
  display: flex;
  min-height: 100vh;
  width: 80vw;
  background-color: #3b8c84;
  align-items: center;
  justify-content: space-around;
  flex-direction: column;
}
</style>
