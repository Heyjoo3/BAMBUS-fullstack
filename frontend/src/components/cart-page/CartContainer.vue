<template>
  <div class="cart-container">
    <h1><slot name="header"></slot></h1>
    <slot></slot>
  </div>
</template>

<script>
export default {
  name: "CartContainer",
};
</script>

<style scoped>
.cart-container {
  width: 66%;
  min-height: 20%;
  margin: 2%;
  border-radius: 1rem;
  border: none;
  box-sizing: border-box;
  padding: 2rem;
  background-color: #f2eae4;
  box-shadow: 0px 0px 5px 0px #222126;
}

h1,
h2,
h3,
p,
i {
  color: #222126;
}
</style>
