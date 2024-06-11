<template>
  <div>
    <br />
    <h1>Stats</h1>
    <br />
    <base-content-container>
      <stats-table></stats-table>
    </base-content-container>
  </div>
</template>

<script>
import BaseContentContainer from "@/components/base-components/BaseContentContainer.vue";
import StatsTable from "./StatsTable.vue";
export default {
  name: "StatisticsTab",
  components: {
    BaseContentContainer,
    StatsTable,
  },
};
</script>

<style></style>
