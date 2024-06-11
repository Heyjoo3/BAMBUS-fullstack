<template>
  <base-modal-large :hideModal>
    <template v-slot:modal-title>
      <h1>Bewertungen</h1>
    </template>
    <template v-slot:modal-content>
      <div v-for="rating in ratings" class="ratings">
        <div class="rating" v-if="showRating && editId != rating.ratingId">
          <rating-container
            :rating="rating"
            @toggleEditStatus="toggleEditStatus"
            :numberOfRatings
            @closeModal="closeModal"
          ></rating-container>
        </div>
        <div class="edit" v-else-if="!showRating && editId == rating.ratingId">
          <edit-rating-container
            :rating="rating"
            @toggleEditStatus="toggleEditStatus"
            @saveEdit="saveEdit"
          ></edit-rating-container>
        </div>
      </div>
    </template>
    <template v-slot:modal-button>
      <base-rectangle-button @click="closeModal"
        >Schließen</base-rectangle-button
      >
    </template>
  </base-modal-large>
</template>

<script>
import { mapGetters } from "vuex";
import { mapActions } from "vuex";

import BaseModalLarge from "../../base-components/BaseModalLarge.vue";
import BaseContentContainer from "../../base-components/BaseContentContainer.vue";
import BaseRectangleButton from "../../base-components/BaseRectangleButton.vue";
import RatingContainer from "./RatingContainer.vue";
import EditRatingContainer from "./EditRatingContainer.vue";

export default {
  name: "ratings-modal",
  components: {
    BaseModalLarge,
    BaseContentContainer,
    BaseRectangleButton,
    RatingContainer,
    EditRatingContainer,
  },
  data() {
    return {
      editId: null,
      showRating: true,
      comment: "",
      isRecommended: "",
      numericalRating: "",
      itemId: "",
      creatorId: "",
      stars: [false, false, false, false, false],
      hideModal: false,
    };
  },
  computed: {
    ...mapGetters({
      ratings: "ratingStore/getRatingsByItemId",
      role: "userStore/getRoleLoggedUser",
      userId: "userStore/getUserIdLoggedUser",
    }),
    numberOfRatings() {
      return this.ratings.length;
    },
  },
  methods: {
    ...mapActions({
      deleteRating: "ratingStore/deleteRatingById",
    }),

    toggleEditStatus(id) {
      this.editId = id;
      this.showRating = !this.showRating;
    },

    saveEdit() {
      this.editId = null;
      this.showRating = !this.showRating;
      this.$forceUpdate();
    },

    closeModal() {
      this.hideModal = true;
      setTimeout(() => {
        this.$store.dispatch("modalStore/closeAllModals");
      }, 500);
      this.$store.dispatch("ratingStore/deleteItemId");
    },
  },
};
</script>

<style scoped>
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

.radio-group {
  display: flex;
  justify-content: space-between;
  width: 100px;
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
