<template>
  <div class="base-tab-header">
    <div
      v-for="(tab, index) in tabs"
      :key="index"
      :id="index"
      class="tab"
      :class="{ active: active == index }"
      @click="showTab"
    >
      <h2>
        <slot :name="'tab' + index">{{ tab }}</slot>
      </h2>
    </div>
  </div>
</template>

<script>
export default {
  name: "BaseTabHeader",
  data() {
    return {
      active: 0,
      tabs: ["1", "2", "3"],
    };
  },
  methods: {
    showTab(event) {
      this.active = event.target.parentElement.id;
    },
  },
};
</script>

<style scoped>
.base-tab-header {
  width: 100%;
  height: 2rem;
  background-color: #f2eae4;
  display: flex;
  flex-direction: row;
}

.tab {
  width: 33%;
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: #7ca692;
  border-radius: 1rem;
  border: none;
  box-sizing: border-box;
  transition: 0.2s;
}

.tab h2 {
  color: #f2eae4;
}

.tab:hover {
  background-color: #84bf9e;
}

.active {
  background-color: #d9910d;
}

.active:hover {
  background-color: #e3a23d;
}
</style>
