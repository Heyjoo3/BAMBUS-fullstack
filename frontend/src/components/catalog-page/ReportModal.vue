<template>
    <div class="report-modal">
        <base-modal-small :hideModal>
            <template v-slot:modal-title>
                <h1>Artikel beschädigt melden</h1>
            </template>
            <template v-slot:modal-content>
                <div class="report-modal-content">
                    <p>Bitte benenne die Schäden.</p>
                    <input v-model="damageDescription" placeholder="Grund für die Meldung" maxlength="150"></input>
                </div>
            </template>
            <template v-slot:modal-button>
                <base-rectangle-button @click="processReport">Melden</base-rectangle-button>
            </template>
        </base-modal-small>
    </div>
</template>

<script>
import { mapGetters } from "vuex";

import BaseRectangleButton from "@/components/base-components/BaseRectangleButton.vue";
import BaseContentContainer from "../base-components/BaseContentContainer.vue";
import BaseModalSmall from "../base-components/BaseModalSmall.vue";

export default {
    name: "ReportModal",
    components: {
        BaseModalSmall,
        BaseRectangleButton,
        BaseContentContainer,
    },
    data() {
        return {
            damageDescription: "",
            hideModal: false,
        };
    },
    computed: {
        ...mapGetters("userStore", { user: "getUser" }),
        ...mapGetters("itemStore", { item: "getReportedItem" }),
    },
    methods: {
        processReport() {
            this.item.condition = 1;
            this.$store.dispatch("itemStore/editItem", this.item);
            this.$store.dispatch("notificationStore/userReportsDamage", ({ itemId: this.item.itemId, userId: this.user.userId, title: this.item.title  , damageDescription: this.damageDescription }));
            this.hideModal = true;
            setTimeout(() => {
                this.$store.dispatch("modalStore/closeAllModals");
            }, 500);
            this.$store.dispatch("itemStore/deleteAllModalIds");
        },
    },

}
</script>

<style scoped>
h1,
p {
    color: #f2eae4;
}

.report-modal-content {
    width: 100%;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
}

input {
    width: 80%;
    margin-top: 0.5rem;
}
</style>