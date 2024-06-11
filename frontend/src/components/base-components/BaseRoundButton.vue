<template>
  <button class="round-button">
    <div class="button-content">
      <slot>
        <i class="fa-solid fa-face-smile" style="color: #f2eae4"></i>
      </slot>
    </div>
  </button>
</template>

<script>
export default {
  name: "BaseRoundButton",
};
</script>

<style scoped>
button.round-button {
  width: 50px;
  height: 50px;
  border-radius: 50%;
  background-color: #d9910d;
  color: #f2eae4;
  border: none;
  box-shadow: 0px 0px 5px 0px #222126;
  cursor: pointer;
  transition: 0.3s;
  font-size: 1.4rem;
}

button.round-button:hover {
  background-color: #f2eae4;
  color: #d9910d;
}

.button-content :hover {
  color: #d9910d;
}
</style>
