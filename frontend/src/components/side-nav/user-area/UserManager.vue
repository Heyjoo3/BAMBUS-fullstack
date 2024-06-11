<template>
  <div>
    <i class="fa-solid fa-book-open" style="color: #f2eae4"></i>
    <p @click="$emit('clickedLogout')">Management</p>
  </div>
</template>

<script>
export default {
  name: "UserManager",
  emits: ["clickedLogout"],
};
</script>

<style></style>
