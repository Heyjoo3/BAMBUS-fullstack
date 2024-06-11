<template>
  <div class="item-footer">
    <base-round-button v-if="role == 1" @click="openEditModal(item.itemId)"
      ><i class="fa-regular fa-pen-to-square" style="color: #222126"></i
    ></base-round-button>
    <base-round-button v-if="role == 1" @click="deleteItem(item.itemId)"
      ><i class="fa-solid fa-trash-can" style="color: #222126"></i
    ></base-round-button>
    <base-round-button v-if="role == 0" @click="addToCart(item)"
      ><i class="fa-solid fa-basket-shopping" style="color: #222126"></i
    ></base-round-button>
    <base-round-button
      v-if="role == 0 && item.condition == 0"
      @click="openReportModal(item.itemId)"
      ><i class="fa-solid fa-flag" style="color: #222126"></i>
    </base-round-button>
  </div>
</template>

<script>
import BaseRoundButton from "../../base-components/BaseRoundButton.vue";

export default {
  name: "ItemButtons",
  props: ["item", "role"],
  components: {
    BaseRoundButton,
  },
  methods: {
    addToCart(id) {
      this.$store.dispatch("cartStore/addItemToCart", id);
    },
    openEditModal(id) {
      this.$emit("openEditModal", id);
    },
    deleteItem(id) {
      this.$store.dispatch("itemStore/deleteItem", id);
    },
    openReportModal(id) {
      this.$emit("openReportModal", id);
    },
  },
};
</script>

<style>
div.item-footer {
  margin-top: 10%;
  margin-bottom: 0;
  display: flex;
  flex-direction: row;
  justify-content: space-around;
}

.item-footer i {
  color: #222126;
  text-align: center;
}
</style>
