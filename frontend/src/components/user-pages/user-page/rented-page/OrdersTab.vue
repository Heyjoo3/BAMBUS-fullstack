<template>
  <div class="content">
    <div class="rented">
      <h1>Derzeit ausgeliehen</h1>
      <base-container-narrow v-if="rentedItems.length === 0"
        >Du hast derzeit keine Artikel ausgeliehen.</base-container-narrow
      >
      <rented-item
        v-for="item in rentedItems"
        :key="item.itemId"
        :item="item"
        @openReturnModal="openReturnModal(item.itemId)"
        @extensionRequested="updateRentedItems()"
      />
    </div>

    <div class="reserved">
      <h1>Reserviert für dich</h1>
      <base-container-narrow v-if="reservedItems(user.userId).length === 0"
        >Du hast derzeit keine Artikel reserviert.</base-container-narrow
      >
      <reserved-item
        v-for="item in reservedItems(user.userId)"
        :key="item.itemId"
        :item="item"
        :userId="user.userId"
      />
    </div>
  </div>
</template>

<script>
import RentedItem from "./RentedItem.vue";
import ReservedItem from "./ReservedItem.vue";
import BaseContainerNarrow from "@/components/base-components/BaseContainerNarrow.vue";

export default {
  name: "OrdersTab",
  components: {
    RentedItem,
    ReservedItem,
    BaseContainerNarrow,
  },
  computed: {
    rentedItems() {
      let rentedItems = [];
      let rentedItemsIds =
        this.$store.getters["loanStore/getActiveItemIdFromUserId"];
      if (!Array.isArray(rentedItemsIds)) {
        rentedItemsIds = [rentedItemsIds];
      }
      rentedItemsIds.forEach((id) => {
        let item = this.$store.getters["itemStore/getItemById"](id);
        rentedItems.push(item);
      });
      return rentedItems;
    },
    rentedItemIds() {
      return this.$store.getters["loanStore/getActiveItemIdFromUserId"];
    },
    loans() {
      return this.$store.getters["loanStore/getActiveItemIdFromUserId"];
    },
    user() {
      return this.$store.getters["userStore/getUser"];
    },
    reservedItems() {
      return this.$store.getters["itemStore/getItemsReservedByUser"];
    },
  },
  methods: {
    openReturnModal(id) {
      this.$emit("openReturnModal", id);
    },
    setRentedItems() {
      this.rentedItems = [];
      this.rentedItemIds.forEach((id) => {
        let item = this.$store.getters["itemStore/getItemById"](id);
        this.rentedItems.push(item);
      });
    },
    updateRentedItems() {
      this.rentedItems = [];
      let rentedItemsIds =
        this.$store.getters["loanStore/getActiveItemIdFromUserId"];
      if (!Array.isArray(rentedItemsIds)) {
        rentedItemsIds = [rentedItemsIds];
      }
      rentedItemsIds.forEach((id) => {
        let item = this.$store.getters["itemStore/getItemById"](id);
        this.rentedItems.push(item);
      });
    },
  },
};
</script>

<style scoped>
.content {
  width: 100%;
  display: grid;
  grid-template-columns: 2fr 1fr;
  grid-template-areas: "rented reserved";
  gap: 1rem;
  padding: 1rem;
}

.rented {
  grid-area: rented;
}

.reserved {
  grid-area: reserved;
}
</style>
