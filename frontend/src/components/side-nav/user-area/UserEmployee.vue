<template>
  <div>
    <i class="fa-regular fa-user" style="color: #f2eae4"></i>
    <p @click="$router.push('/my-view')">Account</p>
  </div>
</template>

<script>
export default {
  name: "UserEmployee",
  emits: ["clickedLogout"],
};
</script>

<style></style>
