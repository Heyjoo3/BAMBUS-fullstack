<template>
  <div class="startpage">
    <div class="container">
      <h1>Was willst Du heute entdecken?</h1>
      <div class="shortcuts">
        <router-link
          :to="{
            name: 'catalog-category',
            params: { category: 'all' },
            hash: '#catalog',
          }"
        >
          <shortcut-button>Alles</shortcut-button></router-link
        >
        <router-link
          :to="{
            name: 'catalog-category',
            params: { category: 'books' },
            hash: '#catalog',
          }"
          ><shortcut-button>Bücher</shortcut-button></router-link
        >
        <router-link
          :to="{
            name: 'catalog-category',
            params: { category: 'magazines' },
            hash: '#catalog',
          }"
          ><shortcut-button>Zeitschriften</shortcut-button></router-link
        >
        <router-link
          :to="{
            name: 'catalog-category',
            params: { category: 'games' },
            hash: '#catalog',
          }"
          ><shortcut-button>Spiele</shortcut-button></router-link
        >
      </div>
    </div>
  </div>
</template>

<script>
import ShortcutButton from "./ShortcutButton.vue";

export default {
  name: "StartPage",
  components: {
    ShortcutButton,
  },
};
</script>

<style scoped>
.startpage {
  display: flex;
  height: 100vh;
  width: 80vw;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  background-image: url(../../assets/bambooBackground2.jpg);
  background-size: cover;
  background-position: center;
  background-color: #84bf9e;
}

.container {
  padding: 3%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  width: 50%;
  background-color: rgba(34, 33, 38, 0.8);
}

.shortcuts {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  justify-content: center;
  align-items: center;
  width: 100%;
}

.startpage h1 {
  font-size: 3em;
  text-align: center;
  color: #f2eae4;
}

a {
  text-decoration: none;
  color: #f2eae4;
}

a:hover {
  color: #d9910d;
}
</style>
