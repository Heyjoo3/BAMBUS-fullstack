<template>
  <base-modal-large :hasCloseButton="true" :hideModal>
    <template v-slot:modal-title>
      <h1>Rückgabe</h1>
    </template>
    <template v-slot:modal-content>
      <div class="modal-content">
        <div class="rating">
          <h3>Wie hat dir deine Ausleihe gefallen?</h3>
          <p>Wie viele Sterne würdest du vergeben?</p>
          <i v-if="showAlert">Bitte gebe Sterne an, wenn du bewertest.</i>

          <div class="stars">
            <div v-for="(star, index) in stars" :key="index" @click="changeStar(index + 1)">
              <i :class="[star ? 'fa-solid' : 'fa-regular', 'fa-star']" style="color: #222126"></i>
            </div>
          </div>

          <p v-if="rating != 0">{{ rating }} Sterne</p>

          <br />
          <textarea id="comment" name="comment" rows="5" cols="60" maxlength="200" v-model="comment"
            placeholder="Möchtest du noch was hinzufügen?"></textarea>
        </div>
        <div class="recommendation">
          <h3>Würdest du den Gegenstand weiter empfehlen?</h3>
          <div class="radio-group">
            <input type="radio" id="yesRecommend" name="recommendation" value="yes" :checked="recommendation" />
            <label for="yes">Ja</label>
            <input type="radio" id="noRecommend" name="recommendation" value="no" :checked="recommendation == false" />
            <label for="no">Nein</label>
          </div>
        </div>
        <div class="condition">
          <h3>Ist der Gegenstand beschädigt worden?</h3>

          <div class="radio-group">
            <input type="radio" id="yesBroken" name="condition" value="yes" @click="checkcondition" />
            <label for="yes">Ja</label>
            <input type="radio" id="noNotBroken" name="condition" value="no" @click="checkcondition" />
            <label for="no">Nein</label>
          </div>

          <input type="text" v-if="condition == true" v-model="damageDescription" maxlength="150"
            placeholder="Bitte benenne den Schaden..." />
        </div>
      </div>
    </template>
    <template v-slot:modal-button>
      <base-rectangle-button @click="processReturn">Abgeben</base-rectangle-button>
    </template>
  </base-modal-large>
</template>

<script>
import { mapGetters } from "vuex";
import { mapActions } from "vuex";

import BaseModalLarge from "@/components/base-components/BaseModalLarge.vue";
import BaseRectangleButton from "@/components/base-components/BaseRectangleButton.vue";
import BaseRoundButton from "@/components/base-components/BaseRoundButton.vue";
import rating from "@/store/modules/rating";
// import loan from "@/store/modules/loan";
// import item from "@/store/modules/item";

export default {
  name: "ReturnModal",
  components: {
    BaseModalLarge,
    BaseRectangleButton,
    BaseRoundButton,
  },
  data() {
    return {
      rating: 0,
      comment: "",
      recommendation: null,
      condition: null,
      stars: [false, false, false, false, false],
      showAlert: false,
      damageDescription: "",
      hideModal: false,
      hasRating: false,
      ratingId: 0,
      oldRating: null,
      needsRating: false,

    };
  },
  computed: {
    ...mapGetters("userStore", { user: "getUser" }),
    ...mapGetters("itemStore", { id: "getReturnItemId" }),
  },
  methods: {
    ...mapActions("modalStore", ["closeAllModals"]),
    ...mapActions("ratingStore", ["addRating", "updateRating"]),

    checkRecommendation() {
      if (yesRecommend.checked) {
        this.recommendation = true;
      } else if (noRecommend.checked) {
        this.recommendation = false;
      } else {
        this.recommendation = null;
      }
    },

    checkcondition() {
      if (yesBroken.checked) {
        this.condition = 1;
      } else {
        this.condition = 0;
        this.damageDescription = "";
      }
    },

    processRating() {
      this.checkRecommendation();
      this.needsRating = false;
      if (this.rating != 0 || this.comment.trim() != "" || this.recommendation != null) {
        this.needsRating = true;
        if (this.rating == 0 || this.recommendation == null) {
          this.showAlert = true;
          return false;
        }
        if (this.comment.trim() == "") {
          this.comment = "Kein Kommentar";
          return true
        }
      }
      this.showAlert = false;
      return true;
    },

    processDamage() {
      this.checkcondition();
      if (this.damageDescription.trim() == "") {
        this.damageDescription = "Keine Beschreibung";
      }
    },

    processReturn() {
      this.processRating();
      this.processDamage();
      if (this.processRating() ) {
        this.$store.dispatch("itemStore/returnItem", {
          itemId: this.id,
          userId: this.user.userId,
          ratingId: this.ratingId,
          rating: this.rating,
          comment: this.comment,
          isRecommended: this.recommendation,
          condition: this.condition,
          damageDescription: this.damageDescription,
          needsRating: this.needsRating,
        });
        this.hideModal = true;
      setTimeout(() => {
        this.$store.dispatch("modalStore/closeAllModals");
      }, 500);
      this.$store.dispatch("itemStore/deleteAllModalIds");
      }
    },

    changeStar(index) {
      this.stars = this.stars.map((star, i) => i < index);
      this.rating = this.stars.filter((star) => star).length;
    },
  },

  created() {
    let oldRating = this.$store.getters["ratingStore/getRatingByUserAndItemId"](
      this.id,
      this.user.userId
    );
    if (oldRating) {
      this.hasRating = true;
      this.rating = oldRating.rating;
      this.comment = oldRating.comment;
      this.recommendation = oldRating.isRecommended;
      this.stars = this.stars.map((star, i) => i < this.rating);
      this.ratingId = oldRating.ratingId;
      this.oldRating = oldRating;
    }
  },
};
</script>

<style scoped>
.modal-content {
  background-color: #f2eae4;
  padding: 2.5rem;
  border-radius: 1rem;
}

.rating,
.recommendation,
.condition {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

.stars {
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
}

.recommendation {
  margin-top: 1rem;
}

.condition {
  margin-top: 1rem;
}

.radio-group {
  width: 6rem;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}

h1 {
  color: #f2eae4;
}

input[type="text"] {
  width: 100%;
  margin-top: 1rem;
}
</style>
