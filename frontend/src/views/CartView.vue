<template>
  <div class="cart-view-content">
    <cart-page />
  </div>
</template>

<script>
import CartPage from "../components/cart-page/CartPage.vue";

export default {
  name: "CartView",
  components: {
    CartPage,
  },
};
</script>

<style scoped>
.cart-view-content {
  display: fixed;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  background-color: #3b8c84;
}
</style>
