<template>
  <div class="rental-item">
    <h2>{{ rentalItem.title }}</h2>
    <div class="rental-item-content">
      <item-information
        class="rental-item-content-row"
        :itemId="rentalItem.itemId"
        :condition="rentalItem.condition"
      />
      <item-form
        class="rental-item-content-row"
        :itemId="rentalItem.itemId"
        @dueDateEntered="updateDueDate($event)"
      />
      <section class="rental-item-content-row">
        <base-text-button
          class="rental-item-content-row-button"
          @click="rentItem({ item: rentalItem, dueDate: dueDate })"
          >Item ausleihen</base-text-button
        >
        <base-text-button
          class="rental-item-content-row-button"
          @click="removeRentalItemFromCart(rentalItem.itemId)"
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
import ItemForm from "./ItemForm.vue";
import BaseTextButton from "../../../base-components/BaseTextButton.vue";

export default {
  name: "RentalItem",
  props: {
    rentalItem: Object,
  },
  data() {
    return {
      dueDate: null,
    };
  },
  components: {
    ItemInformation,
    ItemForm,
    BaseTextButton,
  },
  methods: {
    ...mapActions("cartStore", ["rentItem", "removeRentalItemFromCart"]),
    updateDueDate(dueDate) {
      this.dueDate = dueDate;
    },
  },
};
</script>

<style scoped>
.rental-item {
  width: 100%;
  margin-bottom: 2vh;
}

.rental-item-content {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
}

.rental-item-content-row {
  width: 100%;
  margin: 1vw, 0;
}

.rental-item-content-row-button {
  display: flex;
  flex-direction: column;
  align-items: center;
  width: 50%;
  margin-left: 25%;
}
</style>
