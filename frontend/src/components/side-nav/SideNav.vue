<template>
  <div class="SideNav">
    <SideNavBranding />
    <LinkTree />
    <UserArea id="user-area" />
  </div>
</template>

<script>
import SideNavBranding from "./SideNavBranding.vue";
import LinkTree from "./LinkTree.vue";
import UserArea from "./user-area/UserArea.vue";

export default {
  name: "SideNav",
  components: {
    SideNavBranding,
    LinkTree,
    UserArea,
  },
};
</script>

<style scoped>
.SideNav {
  background-color: #222126;
  padding: 0.5%;
}

.SideNav-Base-Content {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  margin-top: 5%;
  height: 90%;
}

#user-area {
  position: fixed;
  bottom: 0;
  padding: 0.25%;
}
</style>
