<template>
  <div>
    <h1>User Management</h1>
    <br />
    <base-content-container>
      <all-users-table></all-users-table>
    </base-content-container>
  </div>
</template>

<script>
import BaseContentContainer from "@/components/base-components/BaseContentContainer.vue";
import AllUsersTable from "./AllUsersTable.vue";

export default {
  name: "UserManagementTab",
  components: {
    BaseContentContainer,
    AllUsersTable,
  },
};
</script>

<style scoped></style>
