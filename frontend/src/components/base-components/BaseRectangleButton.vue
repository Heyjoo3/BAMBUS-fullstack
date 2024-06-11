<template>
  <button class="rectangle-button">
    <p>
      <slot>
        <i class="fa-solid fa-dog" style="color: #f2eae4"></i>
        <i class="fa-solid fa-otter" style="color: #f2eae4"></i>
        <i class="fa-solid fa-dragon" style="color: #f2eae4"></i>
      </slot>
    </p>
  </button>
</template>

<script>
export default {
  name: "BaseRectangleButton",
};
</script>

<style scoped>
button.rectangle-button {
  width: 100px;
  height: 50px;
  border-radius: 10px;
  background-color: #d9910d;
  color: #f2eae4;
  border: none;
  box-shadow: 0px 0px 5px 0px #222126;
  cursor: pointer;
  transition: 0.3s;
  font-size: 1rem;
}

button.rectangle-button:hover {
  background-color: #f2eae4;
  color: #d9910d;
}

button.rectangle-button:hover p {
  color: #d9910d;
}

p {
  color: #f2eae4;
}
</style>
