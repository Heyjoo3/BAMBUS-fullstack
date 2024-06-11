<template>
  <form class="rental-item-form">
    <label for="fromDate">Ausleihen vom:</label>
    <p name="fromDate">{{ formattedFromDate }}</p>
    <label for="dueDate">Bis zum:</label>
    <input
      id="inputDueDate"
      type="date"
      name="dueDate"
      :min="minDate"
      :max="maxDate"
      v-model="dueDate"
      @change="$emit('dueDateEntered', dueDate)"
    />
  </form>
</template>

<script>
export default {
  name: "ItemForm",
  props: {
    itemId: Number,
  },
  data() {
    return {
      dueDate: "",
    };
  },
  computed: {
    formattedFromDate() {
      return new Date().toLocaleDateString("de-DE");
    },
    minDate() {
      return new Date().toISOString().split("T")[0];
    },
    maxDate() {
      const maxDate = new Date();
      maxDate.setDate(maxDate.getDate() + 31);
      return maxDate.toISOString().split("T")[0];
    },
  },
};
</script>

<style scoped>
.rental-item-form {
  display: flex;
  flex-direction: column;
  width: 15%;
  margin: 2% 0;
}

#inputDueDate {
  width: 33%;
}
</style>
