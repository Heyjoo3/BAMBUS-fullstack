<template>
  <div class="user-page">
    <user-tabs :tabs="tabs" :activeRoute="activeRoute" />
    <section class="user-page-content">
      <overview-tab v-if="activeRoute == 'overview'" />
      <orders-tab
        v-else-if="activeRoute == 'orders'"
        @openReturnModal="openReturnModal"
      />
      <account-tab v-else-if="activeRoute == 'account'" />
    </section>
    <return-modal v-if="showsReturnModal"></return-modal>
  </div>
</template>

<script>
import UserTabs from "../UserTabs.vue";
import OverviewTab from "./OverviewTab.vue";
import OrdersTab from "./rented-page/OrdersTab.vue";
import AccountTab from "./AccountTab.vue";
import ReturnModal from "../user-page/return-modal/ReturnModal.vue";
import { mapGetters } from "vuex";

export default {
  name: "UserPage",
  components: {
    UserTabs,
    OverviewTab,
    OrdersTab,
    AccountTab,
    ReturnModal,
  },
  data() {
    return {
      tabs: [
        { title: "Nachrichten", id: "overview", route: "/my-view/overview" },
        { title: "Leihübersicht", id: "orders", route: "/my-view/orders" },
        { title: "Account", id: "account", route: "/my-view/account" },
      ],
      activeRoute: undefined,
    };
  },
  computed: {
    ...mapGetters({
      showsReturnModal: "modalStore/getReturnModalStatus",
    }),
  },
  watch: {
    "$route.params": {
      immediate: true,
      handler(newParams) {
        this.activeRoute = newParams.overview;
      },
    },
    showsReturnModal(newVal) {
      if (!newVal) {
        this.activeRoute = "orders";
        this.$forceUpdate();
      }
    },
  },
  methods: {
    async openReturnModal(id) {
      await this.$store.dispatch("modalStore/closeAllModals");
      await this.$store.dispatch("itemStore/setReturnItemId", id);
      await this.$store.dispatch("itemStore/setReportItemId", id);
      await this.$store.dispatch("modalStore/toggleReturnModal");
    },
  },
};
</script>

<style scoped>
.user-page {
  min-height: 100vh;
  background-color: #f2eae4;
  padding: 1%;
  color: #222126;
}

.user-page-content {
  margin-top: 1%;
}
</style>
