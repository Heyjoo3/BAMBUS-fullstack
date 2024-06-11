<template>
  <base-content-container class="ratings">
    <template v-slot:header>
      <div class="stars">
        <div
          v-for="(star, index) in stars"
          :key="index"
          @click="changeStar(index + 1)"
        >
          <i
            :class="[star ? 'fa-solid' : 'fa-regular', 'fa-star']"
            style="color: #222126"
          ></i>
        </div>
      </div>
    </template>
    <template v-slot:body>
      <div class="body">
        <div class="text">
          <textarea
            name="editRating"
            id="editRating"
            cols="55"
            rows="5"
            maxlength="200"
            v-model="comment"
          ></textarea>
          <p>Ist die Ausleihe zu empfehlen?</p>
          <div class="radio-group">
            <input
              type="radio"
              id="yesRecommend"
              name="recommendation"
              value="yes"
              :checked="isRecommended"
            />
            <label for="yes">Ja</label>
            <input
              type="radio"
              id="noRecommend"
              name="recommendation"
              value="no"
              :checked="isRecommended == false"
            />
            <label for="no">Nein</label>
          </div>
        </div>
        <div class="buttons">
          <base-rectangle-button @click="saveRating"
            >Speichern</base-rectangle-button
          >
          <base-rectangle-button @click="toggleEditStatus"
            >Abbrechen</base-rectangle-button
          >
        </div>
      </div>
    </template>
  </base-content-container>
</template>

<script>
import BaseContentContainer from "../../base-components/BaseContentContainer.vue";
import BaseRectangleButton from "../../base-components/BaseRectangleButton.vue";
export default {
  name: "EditRatingContainer",
  components: {
    BaseContentContainer,
    BaseRectangleButton,
  },
  props: {
    rating: {
      type: Object,
      required: true,
    },
  },
  data() {
    return {
      comment: this.rating.comment,
      isRecommended: this.rating.isRecommended,
      numericalRating: this.rating.rating,
      itemId: this.rating.itemId,
      stars: [false, false, false, false, false],
    };
  },
  methods: {
    changeStar(index) {
      this.stars = this.stars.map((star, i) => i < index);
    },
    toggleEditStatus() {
      this.$emit("toggleEditStatus");
    },
    saveRating() {
      if (yesRecommend.checked) {
        this.isRecommended = true;
      } else if (noRecommend.checked) {
        this.isRecommended = false;
      } else {
        this.isRecommended = null;
      }
      this.numericalRating = this.stars.filter((star) => star).length;
      const rating = {
        ratingId: this.rating.ratingId,
        itemId: this.itemId,
        userId: this.rating.userId,
        rating: this.numericalRating,
        comment: this.comment,
        isRecommended: this.isRecommended,
      };
      this.$store.dispatch("ratingStore/updateRating", rating);
      this.$emit("saveEdit");
    },
  },
  beforeMount() {
    this.stars = this.stars.map((star, i) => i < this.rating.rating);
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

.text textarea {
  width: 100%;
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
