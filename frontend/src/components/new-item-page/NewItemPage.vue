<template>
  <div class="newItemPage">
    <NewItemContainer></NewItemContainer>
  </div>
</template>

<script>
import NewItemContainer from "./NewItemContainer.vue";
export default {
  name: "NewItemPage",
  components: {
    NewItemContainer,
  },
};
</script>

<style scoped>
.newItemPage {
  padding: 10%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  height: 100vh;
  background-color: #3b8c84;
}

h1 {
  color: #f2eae4;
  text-transform: uppercase;
}
</style>
