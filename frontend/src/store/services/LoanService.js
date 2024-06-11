import axios from "axios";
import userStore from "../modules/user/index.js";

async function GetAllLoans() {
  try {
    const response = await axios({
      method: "post",
      url: `http://localhost:5240/GetAllLoans`,
      headers: {
        "Content-Type": "application/json",
        accept: "*/*",
        Authorization: "Bearer " + userStore.state.user.token,
      },
    });
    return response;
  } catch (error) {
    console.warn("Error when getting all loans from DB:");
    console.error("Error:", error);
    throw error;
  }
}

async function GetAllLoansFromUser() {
  try {
    const response = await axios({
      method: "post",
      url: `http://localhost:5240/GetAllLoansFromUser/${userStore.state.user.userId}`,
      headers: {
        "Content-Type": "application/json",
        accept: "*/*",
        Authorization: "Bearer " + userStore.state.user.token,
      },
    });
    return response;
  } catch (error) {
    console.warn("Error when getting all loans from user from DB:");
    console.error("Error:", error);
    throw error;
  }
}

async function CreateLoan(payload) {
  try {
    const response = await axios({
      method: "post",
      url: `http://localhost:5240/CreateLoan`,
      headers: {
        "Content-Type": "application/json",
        accept: "*/*",
        Authorization: "Bearer " + userStore.state.user.token,
      },
      data: {
        userId: payload.userId,
        itemId: payload.itemId,
        itemType: payload.itemType,
        startDate: payload.startDate,
        dueDate: payload.dueDate,
      },
    });
    return response;
  } catch (error) {
    console.warn("Error when creating loan in DB:");
    console.error("Error:", error);
    throw error;
  }
}

async function ActivateExtensionRequest(payload) {
  try {
    const response = await axios({
      method: "put",
      url: `http://localhost:5240/ActivateExtensionRequest`,
      headers: {
        "Content-Type": "application/json",
        accept: "*/*",
        Authorization: "Bearer " + userStore.state.user.token,
      },
      data: payload,
    });
    return response;
  } catch (error) {
    console.warn("Error when activating extension request in DB:");
    console.error("Error:", error);
    throw error;
  }
}

async function ReturnItem(payload) {
  try {
    const response = await axios({
      method: "put",
      url: `http://localhost:5240/ReturnItem`,
      headers: {
        "Content-Type": "application/json",
        accept: "*/*",
        Authorization: "Bearer " + userStore.state.user.token,
      },
      data: payload,
    });
    return response;
  } catch (error) {
    console.warn("Error when returning item in DB:");
    console.error("Error:", error);
    throw error;
  }
}

async function SetReturnDate(payload) {
  try {
    const response = await axios({
      method: "put",
      url: `http://localhost:5240/SetReturnDate/${payload}`,
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
    console.warn("Error when setting return date in DB:");
    console.error("Error:", error);
    throw error;
  }
}

async function EndExtensionRequest(payload) {
  try {
    const response = await axios({
      method: "put",
      url: `http://localhost:5240/EndExtensionRequest`,
      headers: {
        "Content-Type": "application/json",
        accept: "*/*",
        Authorization: "Bearer " + userStore.state.user.token,
      },
      data: {
        loanId: payload.loanId,
        newDueDate: payload.newDueDate,
        response: payload.response,
      },
    });
    return response;
  } catch (error) {
    console.warn("Error when ending extension request in DB:");
    console.error("Error:", error);
    throw error;
  }
}

export default {
  GetAllLoans,
  GetAllLoansFromUser,
  CreateLoan,
  SetReturnDate,
  ReturnItem,
  EndExtensionRequest,
  EndExtensionRequest,
  ActivateExtensionRequest,
};
