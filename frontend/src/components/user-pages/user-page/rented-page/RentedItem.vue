<template>
  <base-container-narrow>
    <div class="cardContent">
      <div class="informations">
        <h2>{{ item.title }}</h2>
        <p><strong>Ausgeliehen bis zum: </strong>{{ dueDate }}</p>
      </div>
      <div class="return">
        <base-rectangle-button @click="returnItem">
          Rückgabe
        </base-rectangle-button>
      </div>
      <div class="extend" v-if="!loan.extensionRequestRunning">
        <p>
          <strong>Verlängern zum: </strong>
        </p>
        <input
          id="inputNewDueDate"
          type="date"
          name="newDueDate"
          :min="loan.dueDate"
          :max="maxDate"
          v-model="newDueDate"
        />
        <base-rectangle-button @click="extendLoan()">
          Verlängern
        </base-rectangle-button>
      </div>
      <div v-else>
        <p>Verlängerung wird bearbeitet...</p>
      </div>
    </div>
  </base-container-narrow>
</template>

<script>
import { mapGetters } from "vuex";
import { mapActions } from "vuex";

import BaseContentContainer from "@/components/base-components/BaseContentContainer.vue";
import BaseRectangleButton from "@/components/base-components/BaseRectangleButton.vue";
import BaseContainerNarrow from "@/components/base-components/BaseContainerNarrow.vue";

export default {
  name: "RentedItem",
  components: {
    BaseContentContainer,
    BaseRectangleButton,
    BaseContainerNarrow,
  },
  props: ["item"],
  data() {
    return {
      newDueDate: "",
    };
  },
  methods: {
    ...mapActions("notificationStore", {
      requestExtension: "userRequestsLoanExtension",
    }),
    returnItem() {
      this.$emit("openReturnModal");
    },
    async extendLoan() {
      await this.requestExtension({
        itemTitle: this.item.title,
        loanId: this.loan.loanId,
        newDueDate: this.newDueDate,
      });
    },
  },
  computed: {
    ...mapGetters("userStore", {
      user: "getUser",
    }),
    loan() {
      return this.$store.getters["loanStore/getLoanById"](
        this.item.currentLoanId
      );
    },
    dueDate() {
      return new Date(this.loan.dueDate).toLocaleDateString("de-DE");
    },
    maxDate() {
      let date = new Date(this.loan.dueDate);
      date.setDate(date.getDate() + 31);
      return date;
    },
  },
};
</script>

<style scoped>
.cardContent {
  width: 100%;
  display: grid;
  grid-template-columns: 1fr 1fr;
  grid-template-rows: 1fr 1fr;
  grid-template-areas:
    "informations informations"
    "extend return ";
  gap: 1rem;
}

.informations {
  grid-area: informations;
}

.return {
  grid-area: return;
  display: flex;
  justify-content: flex-end;
  align-items: flex-end;
}

.extend {
  grid-area: extend;
}

#inputNewDueDate {
  margin: 0.5rem;
}
</style>
