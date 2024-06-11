<template>
  <Transition
    ><div class="backdrop" v-if="isShowing" @click="closeModal"></div
  ></Transition>

  <Transition>
    <div class="modal" v-if="isShowing">
      <h1>
        <slot name="modal-title">
          <h1>Modal Title</h1>
        </slot>
      </h1>

      <div class="modal-content">
        <slot name="modal-content">
          <p>Modal Content</p>
        </slot>
      </div>

      <slot name="modal-button" @click="closeModal()"
        ><base-rectangle-button> Schließen </base-rectangle-button></slot
      >
    </div>
  </Transition>
</template>

<script>
import BaseRectangleButton from "./BaseRectangleButton.vue";

export default {
  name: "BaseModal",
  components: {
    BaseRectangleButton,
  },
  props: {
    hideModal: {
      type: Boolean,
      default: false,
    },
  },
  data() {
    return {
      isShowing: false,
    };
  },
  watch: {
    hideModal: {
      immediate: true,
      handler(newVal) {
        if (newVal) {
          this.isShowing = false;
        }
      },
    },
  },
  methods: {
    hideModel() {
      this.isShowing = false;
    },
    closeModal() {
      this.isShowing = false;
      setTimeout(() => {
        this.$store.dispatch("modalStore/closeAllModals");
      }, 500);
      this.$store.dispatch("itemStore/deleteAllModalIds");
    },
  },

  mounted() {
    this.isShowing = true;
  },
};
</script>

<style scoped>
.v-enter-from,
.v-leave-to {
  opacity: 0;
}

.v-enter-to,
.v-leave-from {
  opacity: 1;
}

.v-enter-active,
.v-leave-active {
  transition: opacity 0.5s ease-out;
}
.modal {
  position: fixed;
  width: 50vw;
  height: 20vh;
  top: 40vh;
  left: 25vw;
  z-index: 200;
  transition: all 1s;
  background-color: #7ca692;
  border-radius: 2rem;
  border: none;
  display: flex;
  flex-direction: column;
  justify-content: space-around;
  align-items: center;
  padding: 1rem;
  text-align: center;
}

.modal-content {
  overflow-y: auto;
  padding: 1rem;
  width: 100%;
}

h1,
h2,
h3,
p,
i {
  color: #f2eae4;
}

.backdrop {
  position: fixed;
  top: 0;
  left: 0;
  width: 100vw;
  height: 100vh;
  z-index: 150;
  background-color: rgba(0, 0, 0, 0.8);
}
</style>
