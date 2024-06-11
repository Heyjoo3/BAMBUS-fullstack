<template>
  <div class="catalog-filter">
    <filter-selection :category="category" />
    <sort-selection />
    <div>
      <label for="Verfuegbarkeit">nur verfügbare Objekte: </label>
      <input
        type="checkbox"
        name="available"
        id="available"
        v-model="onlyAvailable"
      />
    </div>
    <div id="search">
      <label for="search">Suche: </label>
      <input type="text" name="search" id="search" v-model="search" />
      <div class="buttons">
        <round-button @click="searchItem">
          <i class="fa-solid fa-magnifying-glass"></i>
        </round-button>
        <round-button @click="deleteSearch">
          <i class="fa-solid fa-eraser"></i
        ></round-button>
      </div>
    </div>
  </div>
</template>

<script>
import RectangleButton from "../../base-components/BaseRectangleButton.vue";
import RoundButton from "@/components/base-components/BaseRoundButton.vue";
import FilterSelection from "./FilterSelection.vue";
import SortSelection from "./SortSelection.vue";

export default {
  name: "CatalogFilter",
  props: {
    category: {
      type: String,
    },
  },
  components: {
    RectangleButton,
    FilterSelection,
    SortSelection,
    RoundButton,
  },
  data() {
    return {
      onlyAvailable: false,
      search: "",
    };
  },
  watch: {
    onlyAvailable(newValue) {
      this.$store.dispatch("itemStore/setOnlyAvailable", newValue);
    },
  },
  methods: {
    searchItem() {
      this.$store.dispatch("itemStore/setSearch", this.search.trim());
    },
    deleteSearch() {
      this.search = "";
      this.searchItem();
    },
  },
};
</script>

<style scoped>
.catalog-filter {
  position: sticky;
  top: 0;
  z-index: 100;
  width: 100%;
  background-color: #f2eae4;
  display: flex;
  justify-content: space-around;
  align-items: center;
  padding: 0.5rem;
}

#search {
  display: flex;
  align-items: center;
}

input,
label {
  margin-right: 0.5rem;
}

.buttons {
  width: 6.5rem;
  display: flex;
  align-items: center;
  justify-content: space-between;
}

i {
  color: #f2eae4;
}
</style>
