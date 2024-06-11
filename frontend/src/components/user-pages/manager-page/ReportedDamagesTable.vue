<template>
  <div class="header">
    <p class="itemID" @click="sortId">ID</p>
    <p class="title" @click="sortTitle">Titel</p>
    <p class="description">Beschreibung</p>
    <p class="acceptDamage" @click="sortacceptDamage">Akzeptieren</p>
    <p class="rejectDamage" @click="sortRejectDamage">Ablehnen</p>
  </div>
  <hr />
  <div
    class="row"
    v-for="(item, index) in reportedItems"
    :key="item.index"
    :class="{ uneven: index % 2 == 0 }"
  >
    <p class="itemID">{{ item.itemId }}</p>
    <p class="title">{{ item.title }}</p>
    <p class="description">{{ item.damageDescription }}</p>
    <p class="acceptDamage" @click="acceptDamage(item)">
      <BaseRectangleButton>Beschädigt</BaseRectangleButton>
    </p>
    <p class="rejectDamage" @click="rejectDamage(item)">
      <BaseRectangleButton>Noch gut</BaseRectangleButton>
    </p>
  </div>
</template>

<script>
import BaseRectangleButton from "@/components/base-components/BaseRectangleButton.vue";

export default {
  name: "ReportedDamagesTable",
  components: {
    BaseRectangleButton,
  },
  computed: {
    reportedItems() {
      return this.$store.getters["itemStore/getReportedItems"].map((item) => {
        let description = this.$store.getters["userStore/getDamageDescription"](
          item.itemId
        );
        return {
          ...item,
          damageDescription: description,
        };
      });
    },
  },

  methods: {
    acceptDamage(item) {
      item.condition = 2;
      this.$store.dispatch("itemStore/editItem", item);
    },

    rejectDamage(item) {
      item.condition = 0;
      this.$store.dispatch("itemStore/editItem", item);
    },
    sortId() {
      this.reportedItems.sort((a, b) => a.itemId - b.itemId);
    },
    sortTitle() {
      this.reportedItems.sort((a, b) => a.title.localeCompare(b.title));
    },
    sortacceptDamage() {
      this.reportedItems.sort((a, b) => a.acceptDamage - b.acceptDamage);
    },
    sortRejectDamage() {
      this.reportedItems.sort((a, b) => a.rejectDamage - b.rejectDamage);
    },
  },
};
</script>

<style scoped>
.header,
.row {
  display: inline-flex;
  width: 75vw;
  align-items: center;
  padding: 0.5rem;
  overflow: auto;
}
.header {
  font-weight: bold;
}

.header p:hover {
  cursor: pointer;
}
.uneven {
  background-color: #d8c6b9;
}

.title {
  width: 20%;
  text-align: left;
  min-width: 120px;
  overflow-wrap: break-word;
}

.description {
  width: 30%;
  text-align: left;
  min-width: 120px;
  overflow-wrap: break-word;
}

.acceptDamage,
.rejectDamage {
  width: 20%;
  text-align: center;
  min-width: 40px;
  overflow-wrap: break-word;
}

.itemID {
  width: 10%;
  text-align: center;
  min-width: 50px;
  overflow-wrap: break-word;
}

hr {
  width: 75vw;
  background-color: #222126;
}
</style>
