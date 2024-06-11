<template>
  <div>
    <br />
    <h1>Als beschädigt gemeldete Gegenstände</h1>
    <br />
    <ReportedDamagesTable></ReportedDamagesTable>
  </div>
</template>

<script>
import ReportedDamagesTable from "./ReportedDamagesTable.vue";
export default {
  name: "ManagementTab",
  components: {
    ReportedDamagesTable,
  },
};
</script>

<style></style>
