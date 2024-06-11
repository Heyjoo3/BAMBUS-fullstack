<template>
  <div class="catalog">
    <catalog-filter :category="category"></catalog-filter>
    <div class="catalog-items" v-if="items.length > 0">
      <item-container
        v-for="item in items"
        :key="item.itemId"
        :item="item"
        @openEditModal="openEditModal(item.itemId)"
        @openRatingsModal="openRatingsModal(item.itemId)"
        @openReportModal="openReportModal(item.itemId)"
      ></item-container>
    </div>
    <div class="no-catalog-items" v-if="items.length == 0">
      <h1>Wie schade! Wir haben leider keine Ergebnisse für Dich.</h1>
    </div>
    <edit-item-modal v-if="showsEditModal"></edit-item-modal>
    <ratings-modal v-if="showsRatingsModal"></ratings-modal>
    <report-modal v-if="showsReportModal"></report-modal>
  </div>
</template>

<script>
import { mapGetters } from "vuex";

import CatalogFilter from "./catalog-filter/CatalogFilter.vue";
import ItemContainer from "./item-container/ItemContainer.vue";
import EditItemModal from "./edit-item-modal/EditItemModal.vue";
import RatingsModal from "./rating-modal/RatingsModal.vue";
import ReportModal from "./ReportModal.vue";

export default {
  name: "CatalogPage",
  components: {
    CatalogFilter,
    ItemContainer,
    EditItemModal,
    RatingsModal,
    ReportModal,
  },
  props: {
    category: {
      type: String,
      default: "all",
    },
  },
  computed: {
    ...mapGetters({
      items: "itemStore/getFilteredItems",
      showsEditModal: "modalStore/getEditModalStatus",
      showsRatingsModal: "modalStore/getRatingsModalStatus",
      showsReportModal: "modalStore/getReportModalStatus",
    }),
  },
  methods: {
    async openEditModal(id) {
      await this.$store.dispatch("modalStore/closeAllModals");
      await this.$store.dispatch("itemStore/setEditItemId", id);
      await this.$store.dispatch("modalStore/toggleEditModal");
    },
    async openRatingsModal(id) {
      await this.$store.dispatch("modalStore/closeAllModals");
      await this.$store.dispatch("ratingStore/setItemId", id);
      await this.$store.dispatch("modalStore/toggleRatingsModal");
    },
    async openReportModal(id) {
      await this.$store.dispatch("modalStore/closeAllModals");
      await this.$store.dispatch("itemStore/setReportItemId", id);
      await this.$store.dispatch("modalStore/toggleReportModal");
    },
  },

  async mounted() {
    await this.$store.dispatch("itemStore/loadItems");
  },
};
</script>

<style scoped>
.catalog {
  min-height: 100vh;
  width: 80vw;
  background-color: #3b8c84;
}

.catalog-items {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
  grid-gap: 2rem;
  padding: 2rem;
  align-items: stretch;
  justify-items: center;
}

.no-catalog-items {
  display: flex;
  justify-content: center;
  align-items: center;
  height: calc(100vh - 66px);
}

.no-catalog-items h1 {
  color: #f2eaf2;
  font-size: 2rem;
}
</style>
