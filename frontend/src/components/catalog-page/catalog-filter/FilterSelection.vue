<template>
  <div>
    <label for="filter">Filter: </label>
    <select name="filter" id="filter" v-model="selected">
      <option value="all">Alles</option>
      <option value="books">Bücher</option>
      <option value="magazines">Zeitschriften</option>
      <option value="games">Spiele</option>
    </select>
  </div>
</template>

<script>
export default {
  name: "FilterSelection",
  props: {
    category: {
      type: String,
    },
  },
  data() {
    return {
      selected: this.category,
    };
  },
  watch: {
    selected(newValue) {
      this.$store.dispatch("itemStore/setFilteredBy", newValue);
    },
    category(newValue) {
      this.selected = newValue;
    },
  },
};
</script>

<style scoped>
label {
  margin-right: 0.5rem;
}
</style>
