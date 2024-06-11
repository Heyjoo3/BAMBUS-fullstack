<template>
  <div class="catalog-view">
    <startPage></startPage>
    <catalogPage :category="category" id="catalog"></catalogPage>
  </div>
</template>

<script>
import CatalogPage from "../components/catalog-page/CatalogPage.vue";
import StartPage from "../components/catalog-page/StartPage.vue";

export default {
  name: "CatalogView",
  data() {
    return {
      category: this.$route.params.category,
    };
  },
  watch: {
    $route(to, from) {
      this.category = to.params.category;
    },
  },
  components: {
    CatalogPage,
    StartPage,
  },
};
</script>

<style scoped></style>
