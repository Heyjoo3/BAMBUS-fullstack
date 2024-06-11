import ItemServices from "@/store/services/ItemServices";
import RatingService from "../../services/RatingService";

export default {
  setItemId({ commit }, itemId) {
    commit("setItemId", itemId);
  },
  deleteItemId({ commit }) {
    commit("deleteItemId");
  },
  async deleteRatingById({ commit }, payload) {
    try {
      await RatingService.DeleteRating(payload.ratingId).then((response) => {
        if (response.data.success) {
          let ratings = response.data.data;
          ItemServices.UpdateAvgRating(payload.itemId).then((response) => {
            if (response.data.success) {
              commit("itemStore/setItems", response.data.data, { root: true });
              commit("setRatings", ratings);
            } else {
              alert("Error when updating average rating in DB 1");
            }
          });
        } else {
          alert("Error when deletimg rating to DB");
        }
      });
    } catch (error) {
      console.warn("Error when deleting rating from DB:");
      console.error("Error:", error);
      throw error;
    }
  },
  async addRating({ commit }, rating) {
    try {
      await RatingService.AddRating(rating).then((response) => {
        if (response.data.success) {
          let ratings = response.data.data;
          ItemServices.UpdateAvgRating(rating.itemId).then((response) => {
            if (response.data.success) {
              commit("itemStore/setItems", response.data.data, { root: true });
              commit("setRatings", ratings);
            } else {
              alert(
                "Error when updating average rating in DB 0: " +
                  response.data.message
              );
            }
          });
        } else {
          alert("Error when adding rating to DB" + response.data.message);
        }
      });
    } catch (error) {
      console.warn("Error when adding rating to DB:");
      console.error("Error:", error);
      throw error;
    }
  },
  async updateRating({ commit }, rating) {
    try {
      await RatingService.UpdateRating(rating).then((response) => {
        if (response.data.success) {
          let ratings = response.data.data;
          commit("setRatings", ratings);
          ItemServices.UpdateAvgRating(rating.itemId).then((response) => {
            if (response.data.success) {
              commit("itemStore/setItems", response.data.data, { root: true });
            } else {
              alert(
                "Error when updating average rating in DB 1: " +
                  response.data.message
              );
            }
          });
        } else {
          alert("Error when updating rating to DB: " + response.data.message);
        }
      });
    } catch (error) {
      console.warn("Error when updating rating in DB:");
      console.error("Error:", error);
      throw error;
    }
  },
  async loadAllRatings({ commit }) {
    try {
      await RatingService.GetAllRatings().then((response) => {
        if (response.data.success) {
          commit("setRatings", response.data.data);
        } else {
          alert("Error when loading all ratings from DB");
        }
      });
    } catch (error) {
      console.warn("Error when getting all ratings from DB:");
      console.error("Error:", error);
      throw error;
    }
  },
};
