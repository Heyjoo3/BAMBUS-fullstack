<template>
  <div>
    <label for="sort">Sortieren nach: </label>
    <select name="sort" id="sort" v-model="sortedBy">
      <option value="default">Default</option>
      <option value="title">Titel A-Z</option>
      <option value="titleDesc">Titel Z-A</option>
      <option value="author">Autor A-Z</option>
      <option value="authorDesc">Autor Z-A</option>
      <option value="avgRating">Bewertung 0-5</option>
      <option value="avgRatingDesc">Bewertung 5-1</option>
    </select>
  </div>
</template>

<script>
export default {
  name: "SortSelection",
  data() {
    return {
      sortedBy: "default",
    };
  },
  watch: {
    sortedBy(newValue) {
      this.$store.dispatch("itemStore/setSortedBy", newValue);
    },
  },
};
</script>

<style scoped>
label {
  margin-right: 0.5rem;
}
</style>
