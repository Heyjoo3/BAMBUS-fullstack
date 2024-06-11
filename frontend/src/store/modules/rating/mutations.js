export default {
  setItemId(state, id) {
    state.itemId = id;
  },
  setRatings(state, ratings) {
    state.ratings = ratings;
  },
  deleteItemId(state) {
    state.itemId = null;
  },
  updateRating(state, rating) {
    const index = state.ratings.findIndex((r) => r.ratingId === rating.ratingId);
    state.ratings[index] = rating;
  },
  logout(state) {
    state.itemId = null;
  },
};
