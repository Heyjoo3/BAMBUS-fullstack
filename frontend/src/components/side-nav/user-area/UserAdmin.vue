<template>
  <div>
    <i class="fa-solid fa-wrench" style="color: #f2eae4"></i>
    <p @click="$emit('clickedLogout')">Admin</p>
  </div>
</template>

<script>
export default {
  name: "UserAdmin",
  emits: ["clickedLogout"],
};
</script>

<style></style>
