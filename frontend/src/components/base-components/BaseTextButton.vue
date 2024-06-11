<template>
  <button>
    <slot></slot>
  </button>
</template>

<script>
export default {
  name: "BaseTextButton",
};
</script>

<style scoped>
button {
  margin: 0.5rem;
  padding: 0.5rem 1rem;
  border-radius: 0.5rem;
  border: none;
  box-shadow: 0px 0px 5px 0px #222126;
  background-color: #222126;
  color: #ffffff;
  cursor: pointer;
}

button:hover {
  box-shadow: 0px 0px 10px 0px #222126;
}

button:active {
  box-shadow: 0px 0px 5px 0px #222126;
}
</style>
