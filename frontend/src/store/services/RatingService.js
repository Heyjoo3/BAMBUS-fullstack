import axios from "axios";
import userStore from "../modules/user/index.js";

async function AddRating(payload) {
  try {
    const response = await axios({
      method: "post",
      url: `http://localhost:5240/AddRating`,
      headers: {
        "Content-Type": "application/json",
        accept: "*/*",
        Authorization: "Bearer " + userStore.state.user.token,
      },
      data: {
        itemId: payload.itemId,
        userId: payload.userId,
        rating: payload.rating,
        isRecommended: payload.isRecommended,
        comment: payload.comment,
      },
    });
    return response;
  } catch (error) {
    console.warn("Error when adding rating to DB:");
    console.error("Error:", error);
    throw error;
  }
}

async function UpdateRating(payload) {
  try {
    const response = await axios({
      method: "put",
      url: `http://localhost:5240/UpdateRating`,
      data: {
        ratingId: payload.ratingId,
        rating: payload.rating,
        isRecommended: payload.isRecommended,
        comment: payload.comment,
      },
      headers: {
        "Content-Type": "application/json",
        accept: "*/*",
        Authorization: "Bearer " + userStore.state.user.token,
      },
    });
    return response;
  } catch (error) {
    console.warn("Error when updating rating in DB:");
    console.error("Error:", error);
    throw error;
  }
}

async function DeleteRating(payload) {
  try {
    const response = await axios({
      method: "post",
      url: `http://localhost:5240/DeleteRating/${payload}`,
      data: {
        ratingId: payload,
      },
      headers: {
        "Content-Type": "application/json",
        accept: "*/*",
        Authorization: "Bearer " + userStore.state.user.token,
      },
    });
    return response;
  } catch (error) {
    console.warn("Error when deleting rating in DB:");
    console.error("Error:", error);
    throw error;
  }
}

async function GetAllRatings() {
  try {
    const response = await axios({
      method: "post",
      url: `http://localhost:5240/GetAllRating`,
    });
    return response;
  } catch (error) {
    console.warn("Error when getting all ratings from DB:");
    console.error("Error:", error);
    throw error;
  }
}

async function DeleteRatingByItemId(payload) {
  try {
    const response = await axios({
      method: "post",
      url: `http://localhost:5240/DeleteRatingsByItemId/${payload}`,
      data: {
        itemId: payload,
      },
      headers: {
        "Content-Type": "application/json",
        accept: "*/*",
        Authorization: "Bearer " + userStore.state.user.token,
      },
    });
    return response;
  } catch (error) {
    console.warn("Error when deleting rating in DB:");
    console.error("Error:", error);
    throw error;
  }
}

export default {
  AddRating,
  UpdateRating,
  DeleteRating,
  GetAllRatings,
  DeleteRatingByItemId,
};
