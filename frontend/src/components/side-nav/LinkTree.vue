<template>
  <div class="SideNav-Item-Link-Tree">
    <router-link
      :to="{
        name: 'catalog-category',
        params: { category: 'all' },
        hash: '#catalog',
      }"
      >Zeige mir Alles</router-link
    >
    <br />
    <router-link
      :to="{
        name: 'catalog-category',
        params: { category: 'books' },
        hash: '#catalog',
      }"
      >Zeige mir Bücher</router-link
    >
    <br />
    <router-link
      :to="{
        name: 'catalog-category',
        params: { category: 'magazines' },
        hash: '#catalog',
      }"
      >Zeige mir Zeitschriften</router-link
    >
    <br />
    <router-link
      :to="{
        name: 'catalog-category',
        params: { category: 'games' },
        hash: '#catalog',
      }"
      >Zeige mir Spiele</router-link
    >
  </div>
</template>

<script>
export default {
  name: "LinkTree",
};
</script>

<style scoped>
.SideNav-Item-Link-Tree a {
  font-size: 1.2vw;
  color: #f2eae4;
  margin-bottom: 5%;
  text-decoration: none;
}

.SideNav-Item-Link-Tree a:hover {
  cursor: pointer;
  color: #d9910d;
  transition: 0.3s;
}
</style>
