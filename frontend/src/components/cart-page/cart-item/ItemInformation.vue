<template>
  <div class="item-information">
    <p>Artikel ID: {{ itemId }}</p>
    <p>Artikel Zustand: {{ conditionText[condition] }}</p>
  </div>
</template>

<script>
export default {
  name: "ItemInformation",
  props: {
    itemId: Number,
    condition: Number,
  },
  data() {
    return {
      conditionText: {
        0: "Nicht beschädigt",
        1: "Zustand wird geprüft",
        2: "Beschädigt",
      },
    };
  },
};
</script>

<style scoped>
.item-information {
  width: 100%;
}
</style>
