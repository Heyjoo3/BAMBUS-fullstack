import axios from "axios";
import userStore from "../modules/user/index.js";

async function GetMessagesFromUserId(payload) {
  try {
    const response = await axios({
      method: "post",
      url: `http://localhost:5240/GetMessagesFromUserId/${payload}`,
      headers: {
        "Content-Type": "application/json",
        accept: "*/*",
        Authorization: "Bearer " + userStore.state.user.token,
      },
      data: {
        userId: payload,
      },
    });
    return response;
  } catch (error) {
    console.warn("Error when getting messages from DB:");
    console.error("Error:", error);
    throw error;
  }
}

async function CreateMessage(payload) {
  try {
    const response = await axios({
      method: "post",
      url: `http://localhost:5240/CreateMessage`,
      headers: {
        "Content-Type": "application/json",
        accept: "*/*",
        Authorization: "Bearer " + userStore.state.user.token,
      },
      data: {
        senderId: payload.senderId,
        receiverId: payload.receiverId,
        date: new Date().toISOString(),
        text: payload.text,
        type: payload.type,
        payload: payload.payload,
      },
    });
    return response;
  } catch (error) {
    console.warn("Error when creating message in DB:");
    console.error("Error:", error);
    throw error;
  }
}

async function DeleteMessage(payload) {
  try {
    const response = await axios({
      method: "post",
      url: `http://localhost:5240/DeleteMessage/${payload}`,
      headers: {
        "Content-Type": "application/json",
        accept: "*/*",
        Authorization: "Bearer " + userStore.state.user.token,
      },
      data: {
        messageId: payload,
      },
    });
    return response;
  } catch (error) {
    console.warn("Error when deleting message in DB:");
    console.error("Error:", error);
    throw error;
  }
}

async function UserRequestsPasswordReset(payload) {
  try {
    const response = await axios({
      method: "post",
      url: `http://localhost:5240/RequestPasswordReset`,
      headers: {
        "Content-Type": "application/json",
        accept: "*/*",
      },
      data: {
        senderId: payload.senderId,
        receiverId: payload.receiverId,
        text: payload.text,
        date: new Date().toISOString(),
        type: 7,
        payload: payload.payload,
      },
    });
    return response;
  } catch (error) {
    console.warn("Error when creating message in DB:");
    console.error("Error:", error);
    throw error;
  }
}

export default {
  GetMessagesFromUserId,
  CreateMessage,
  DeleteMessage,
  UserRequestsPasswordReset,
};
