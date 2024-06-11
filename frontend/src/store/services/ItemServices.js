import axios from "axios";
import userStore from "../modules/user/index.js";

async function LoadAllItems() {
  try {
    const response = await axios({
      method: "post",
      url: `http://localhost:5240/GetItems`,
      headers: {
        accept: "*/*",
      },
    });
    return response;
  } catch (error) {
    console.warn("Error when getting all items from DB:");
    console.error("Error:", error);
    throw error;
  }
}

async function AddItem(payload) {
  try {
    const response = await axios({
      method: "post",
      url: `http://localhost:5240/CreateItem`,
      headers: {
        "Content-Type": "application/json",
        accept: "*/*",
        Authorization: "Bearer " + userStore.state.user.token,
      },
      data: {
        title: payload.title,
        condition: payload.condition,
        type: payload.type,
        author: payload.author || "",
        category: payload.category || "",
        isbn: payload.isbn || "",
        issn: payload.issn || "",
        reservations: [],
        currentLoanId: 0,
        avgRating: 0,
        itemId: 0,
      },
    });
    return response;
  } catch (error) {
    console.warn("Error when adding item to DB:");
    console.error("Error:", error);
    throw error;
  }
}

async function DeleteItem(payload) {
  try {
    const response = await axios({
      method: "post",
      url: `http://localhost:5240/DeleteItem?itemId=${payload}`,
      headers: {
        "Content-Type": "application/json",
        accept: "*/*",
        Authorization: "Bearer " + userStore.state.user.token,
      },
    });
    return response;
  } catch (error) {
    console.warn("Error when deleting item from DB:");
    console.error("Error:", error);
    throw error;
  }
}

async function UpdateItem(payload) {
  try {
    const response = await axios({
      method: "put",
      url: `http://localhost:5240/UpdateItem`,
      headers: {
        "Content-Type": "application/json",
        accept: "*/*",
        Authorization: "Bearer " + userStore.state.user.token,
      },
      data: {
        itemId: payload.itemId,
        title: payload.title,
        condition: payload.condition,
        type: payload.type,
        isbn: payload.isbn,
        issn: payload.issn,
        category: payload.category,
        author: payload.author,
        reservations: payload.reservations,
        currentLoanId: payload.currentLoanId,
        avgRating: payload.avgRating,
        extensionRequestActive: payload.extensionRequestActive,
      },
    });
    return response;
  } catch (error) {
    console.warn("Error when updating item in DB:");
    console.error("Error:", error);
    throw error;
  }
}

async function IsReturnLongerThanWeekAgo(payload) {
  try {
    const response = await axios({
      method: "put",
      url: `http://localhost:5240/IsReturnLongerThanWeekAgo/${payload}`,
      headers: {
        "Content-Type": "application/json",
        accept: "*/*",
        Authorization: "Bearer " + userStore.state.user.token,
      },
      data: {
        loanId: payload,
      },
    });
    return response;
  } catch (error) {
    console.warn("Error when checking if return is longer than a week ago:");
    console.error("Error:", error);
    throw error;
  }
}

async function UpdateAvgRating(payload) {
  try {
    const response = await axios({
      method: "put",
      url: `http://localhost:5240/UpdateAvgRating/${payload}`,
      headers: {
        "Content-Type": "application/json",
        accept: "*/*",
        Authorization: "Bearer " + userStore.state.user.token,
      },
      data: {
        itemId: payload,
      },
    });
    return response;
  } catch (error) {
    console.warn("Error when updating average rating in DB:");
    console.error("Error:", error);
    throw error;
  }
}

export default {
  LoadAllItems,
  AddItem,
  DeleteItem,
  UpdateItem,
  IsReturnLongerThanWeekAgo,
  UpdateAvgRating,
};
