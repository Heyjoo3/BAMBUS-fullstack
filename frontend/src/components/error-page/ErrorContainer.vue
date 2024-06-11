<template>
  <base-content-container>
    <div class="error-container">
      <h1>Leider ist ein Fehler aufgetreten</h1>
      <p>Bitte versuche es später erneut.</p>
      <div class="buttons">
        <base-rectangle-button>
          <router-link
            :to="{
              name: 'catalog-category',
              params: { category: 'all' },
              hash: '#catalog',
            }"
            >Katalog</router-link
          ></base-rectangle-button
        >
        <base-rectangle-button @click="$router.go(-1)"
          >Zurück</base-rectangle-button
        >
      </div>
    </div>
  </base-content-container>
</template>

<script>
import BaseContentContainer from "../base-components/BaseContentContainer.vue";
import BaseRectangleButton from "../base-components/BaseRectangleButton.vue";
export default {
  name: "ErrorContainer",
  components: {
    BaseContentContainer,
    BaseRectangleButton,
  },
};
</script>

<style scoped>
a {
  text-decoration: none;
  color: #f2eae4;
}

a:hover {
  color: #d9910d;
  transition: 0.3s;
}

div.error-container {
  padding: 2rem;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

div.buttons {
  margin-top: 1rem;
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  gap: 20px;
}
</style>
