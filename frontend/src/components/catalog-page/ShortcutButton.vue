<template>
  <div>
    <p><slot></slot></p>
  </div>
</template>

<script>
export default {
  name: "ShortcutButton",
};
</script>

<style scoped>
p {
  width: 16rem;
  margin: 1rem;
  padding: 1rem;
  font-size: 2.5rem;
  color: #f2eae4;
  background-color: #d9910d;
  border: none;
  border-radius: 0.5rem;
  cursor: pointer;
  text-align: center;
  text-decoration: none;
}

p:hover {
  background-color: #f2eae4;
  color: #d9910d;
}
</style>
