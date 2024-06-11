<template>
  <div class="edit-container-fields" id="editGame">
    <div class="field">
      <label for="title">Title </label>
      <input type="text" id="title" v-model="title" required />
    </div>
    <div class="field">
      <label for="category">Kategorie </label>
      <input type="text" id="category" v-model="category" required />
    </div>
  </div>
</template>

<script>
export default {
  name: "GameForm",
  props: ["item", "saveItem"],
  data() {
    return {
      title: "",
      category: "",
    };
  },
  watch: {
    saveItem: {
      immediate: true,
      handler: function (newVal) {
        if (newVal) {
          this.$store.dispatch("itemStore/editItem", {
            itemId: this.item.itemId,
            condition: this.item.condition,
            title: this.title,
            type: 2,
            isbn: "",
            author: "",
            category: this.category,
            issn: "",
            reservations: this.item.reservations,
            currentLoanId: this.item.currentLoanId,
            avgRating: this.item.avgRating,
          });
          this.$emit("saved");
        }
      },
    },
  },
  beforeMount() {
    this.title = this.item.title;
    this.category = this.item.category;
  },
};
</script>

<style scoped>
.edit-container-fields {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: space-around;
  margin: 1rem;
}

.field {
  display: inline-flex;
  width: 20vw;
  justify-content: space-between;
  margin: 1rem;
}

select,
input {
  width: 10vw;
  padding: 0.3rem;
  border-radius: 0.5rem;
  border: none;
  box-shadow: 0px 0px 5px 0px #222126;
}
</style>
