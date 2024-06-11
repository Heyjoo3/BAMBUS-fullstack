<template>
  <div class="manager-page">
    <user-tabs :tabs="tabs" :activeRoute="activeRoute" />
    <section class="manager-page-content">
      <overview-tab v-if="activeRoute == 'overview'" />
      <management-tab v-else-if="activeRoute == 'beschaedigungen'" />
      <statistic-tab v-else-if="activeRoute == 'statistics'" />
    </section>
  </div>
</template>

<script>
import UserTabs from "../UserTabs.vue";
import OverviewTab from "./OverviewTab.vue";
import ManagementTab from "./ManagementTab.vue";
import StatisticTab from "./StatisticTab.vue";

export default {
  name: "ManagerPage",
  components: {
    UserTabs,
    OverviewTab,
    ManagementTab,
    StatisticTab,
  },
  data() {
    return {
      tabs: [
        { title: "Nachrichten", id: "overview", route: "/managing/overview" },
        {
          title: "Beschädigungen",
          id: "beschaedigungen",
          route: "/managing/beschaedigungen",
        },
        {
          title: "Ausleihstatistiken",
          id: "statistics",
          route: "/managing/statistics",
        },
      ],
      activeRoute: undefined,
    };
  },
  watch: {
    "$route.params": {
      immediate: true,
      handler(newParams) {
        this.activeRoute = newParams.overview;
      },
    },
  },
};
</script>

<style scoped>
.manager-page {
  min-height: 100vh;
  background-color: #f2eae4;
  padding: 1%;
  color: #222126;
}

.manager-page-content {
  margin-top: 1%;
}
</style>
