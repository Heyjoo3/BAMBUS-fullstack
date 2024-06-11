<template>
  <div class="error-view">
    <error-container></error-container>
  </div>
</template>

<script>
import ErrorContainer from "../components/error-page/ErrorContainer.vue";
export default {
  name: "ErrorView",
  components: {
    ErrorContainer,
  },
};
</script>

<style scoped>
.error-view {
  width: 100%;
  height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: #3b8c84;
}
</style>
