<template>
  <div>
    <i class="fa-solid fa-arrow-right-to-bracket" style="color: #f2eae4"></i>
    <p @click="$emit('clickedLogin')">Login</p>
  </div>
</template>

<script>
export default {
  name: "UserLogin",
  emits: ["clickedLogin"],
};
</script>

<style></style>
