<template>
  <base-content-container>
    <template v-slot:header>
      <i
        v-for="index in 5"
        :key="index"
        :class="getStarClass(index, rating.rating)"
        style="color: #222126"
      ></i>
    </template>
    <template v-slot:body>
      <div class="body">
        <div class="text">
          <p>{{ rating.comment }}</p>
          <br />
          <p v-if="rating.isRecommended">Zu empfehlen</p>
          <p v-else-if="rating.isRecommended == false">Nicht zu empfehlen</p>
          <p v-else>Keine Empfehlung abgegeben</p>
        </div>
        <div class="buttons" v-if="userId == rating.userId">
          <base-rectangle-button @click="toggleEditStatus(rating.ratingId)"
            >Bearbeiten</base-rectangle-button
          >
          <base-rectangle-button
            @click="deleteRating(rating.ratingId, rating.itemId)"
          >
            Löschen
          </base-rectangle-button>
        </div>
        <div class="buttons" v-if="role == 1">
          <base-rectangle-button
            @click="deleteRating(rating.ratingId, rating.itemId)"
          >
            Löschen
          </base-rectangle-button>
        </div>
      </div>
    </template>
  </base-content-container>
</template>

<script>
import BaseContentContainer from "../../base-components/BaseContentContainer.vue";
import BaseRectangleButton from "../../base-components/BaseRectangleButton.vue";

export default {
  name: "RatingContainer",
  components: {
    BaseContentContainer,
    BaseRectangleButton,
  },
  props: {
    rating: {
      type: Object,
      required: true,
    },
    numberOfRatings: {
      type: Number,
      required: true,
    },
  },
  computed: {
    role() {
      return this.$store.getters["userStore/getRoleLoggedUser"];
    },
    userId() {
      return this.$store.getters["userStore/getUserIdLoggedUser"];
    },
  },
  data() {
    return {
      stars: [false, false, false, false, false],
    };
  },
  methods: {
    getStarClass(index, rating) {
      const roundedNumber = Math.round(rating);
      if (index <= roundedNumber) {
        return "fa-solid fa-star";
      } else {
        return "fa-regular fa-star";
      }
    },
    toggleEditStatus(id) {
      this.$emit("toggleEditStatus", id);
    },
    deleteRating(ratingId, itemId) {
      this.$store.dispatch("ratingStore/deleteRatingById", {
        ratingId: ratingId,
        itemId: itemId,
      });
      if (this.numberOfRatings === 1) {
        this.$emit("closeModal");
      }
    },
  },
};
</script>
<style scoped>
.stars {
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
}

.ratings {
  margin-top: 2rem;
  width: 50vw;
}

.body {
  width: 40vw;
  display: flex;
  min-height: 8.5vw;
}

.text {
  width: 90%;
  min-width: 200px;
  margin-right: 2rem;
  text-align: left;
}

.buttons {
  width: 10%;
  min-width: 100px;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  align-items: center;
}
</style>
