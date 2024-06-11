<template>
  <base-container-narrow>
    <div class="cardContent">
      <h2>{{ item.title }}</h2>
      <div class="button-area">
        <base-round-button
          class="button"
          @click="addToCart({ itemId: item.itemId, userId: userId })"
          v-if="isItemAvailable(item.itemId, userId)"
        >
          <div class="button-content">
            <i class="fa-solid fa-basket-shopping"></i>
          </div>
        </base-round-button>
        <base-round-button
          @click="cancelReservation({ itemId: item.itemId, userId: userId })"
        >
          <div class="button-content">
            <i class="fa-solid fa-trash-can"></i>
          </div>
        </base-round-button>
      </div>
    </div>
  </base-container-narrow>
</template>

<script>
import { mapGetters, mapActions } from "vuex";

import BaseContainerNarrow from "@/components/base-components/BaseContainerNarrow.vue";
import BaseRoundButton from "@/components/base-components/BaseRoundButton.vue";

export default {
  name: "ReservedItem",
  components: {
    BaseContainerNarrow,
    BaseRoundButton,
  },
  props: ["item", "userId"],
  methods: {
    ...mapActions("cartStore", {
      addToCart: "addReservedItemToCart",
    }),
    ...mapActions("itemStore", ["cancelReservation"]),
  },
  computed: {
    ...mapGetters("itemStore", {
      isItemAvailable: "isReservedItemAvailableForRenting",
    }),
  },
};
</script>

<style scoped>
.cardContent {
  width: 100%;
  max-width: 100%;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  word-wrap: break-word;
}

h2 {
  width: 100%;
  max-width: 11vw;
  overflow: hidden;
  word-wrap: break-word;
}

.button-area {
  width: 110px;
  display: flex;
  flex-direction: row;
  justify-content: end;
}

.button {
  margin-right: 10px;
}

.button-content i {
  color: #f2eae4;
  padding: 1rem;
  display: flex;
  justify-content: center;
  align-items: center;
}

.button-content i :hover {
  color: #d9910d;
}
</style>
