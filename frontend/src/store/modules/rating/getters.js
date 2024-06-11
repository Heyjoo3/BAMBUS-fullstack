export default {
  getRatings: (state) => state.ratings,
  getRatingsByItemId: (state) => {
    let temp = [];
    let ratings = state.ratings;
    let counter = 0;
    for (let i = 0; i < ratings.length; i++) {
      if (ratings[i].itemId === state.itemId) {
        temp[counter] = ratings[i];
        counter++;
      }
    }
    return temp;
  },
  getRatingByUserAndItemId: (state) => (itemId, userId) => {
    let ratings = state.ratings;
    for (let i = 0; i < ratings.length; i++) {
      if (ratings[i].userId === userId && ratings[i].itemId === itemId) {
        return ratings[i];
      }
    }
    return null;
  },
};
