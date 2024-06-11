<template>
  <div class="SideNav-Branding">
    <img src="/logo.jpg" alt="Bambus Logo" id="side-nav-logo" />
    <h1>BAMBUS</h1>
  </div>
</template>

<script>
export default {
  name: "SideNavBranding",
};
</script>

<style scoped>
.SideNav-Branding {
  display: flex;
  flex-direction: row;
  align-items: center;
  height: 10%;
  margin-bottom: 5%;
}

.SideNav-Branding h1 {
  font-size: 2.5vw;
  margin-left: 5%;
  color: #f2eae4;
}

#side-nav-logo {
  width: 4vw;
  height: 4vw;
  border-radius: 50%;
  margin-right: 2.5%;
}
</style>
