import axios from "axios";
import userStore from "../modules/user/index.js";

async function Register(paylaod) {
  try {
    const response = await axios({
      method: "post",
      url: `http://localhost:5240/Register`,
      headers: {
        "Content-Type": "application/json",
        accept: "*/*",
      },
      data: {
        username: paylaod.username,
        password: paylaod.password,
        email: paylaod.email,
        firstName: paylaod.firstName,
        lastName: paylaod.lastName,
        role: 0,
      },
    });
    return response;
  } catch (error) {
    console.warn("Error when registering user in DB:");
    console.error("Error:", error);
    throw error;
  }
}

async function Login(payload) {
  try {
    const response = await axios({
      method: "post",
      url: `http://localhost:5240/Login`,
      headers: {
        "Content-Type": "application/json",
        accept: "*/*",
      },
      data: {
        email: payload.email,
        password: payload.password,
      },
    });
    return response;
  } catch (error) {
    console.warn("Error when logging in user in DB:");
    console.error("Error:", error);
    throw error;
  }
}

async function UpdateUser(payload) {
  try {
    const response = await axios({
      method: "put",
      url: `http://localhost:5240/UpdateUser`,
      headers: {
        "Content-Type": "application/json",
        accept: "*/*",
        Authorization: "Bearer " + userStore.state.user.token,
      },
      data: {
        userId: payload.userId,
        username: payload.username,
        password: payload.password,
        email: payload.email,
        firstName: payload.firstName,
        lastName: payload.lastName,
      },
    });
    return response;
  } catch (error) {
    console.warn("Error when updating user in DB:");
    console.error("Error:", error);
    throw error;
  }
}

async function DeleteUser(payload) {
  try {
    const response = await axios({
      method: "post",
      url: `http://localhost:5240/DeleteUser/${payload}`,
      headers: {
        "Content-Type": "application/json",
        accept: "*/*",
        Authorization: "Bearer " + userStore.state.user.token,
      },
      data: {
        id: payload,
      },
    });
    return response;
  } catch (error) {
    console.warn("Error when deleting user in DB:");
    console.error("Error:", error);
    throw error;
  }
}

async function GetAllUsers() {
  try {
    const response = await axios({
      method: "post",
      headers: {
        "Content-Type": "application/json",
        accept: "*/*",
        Authorization: "Bearer " + userStore.state.user.token,
      },
      url: `http://localhost:5240/GetAllUser`,
    });
    return response;
  } catch (error) {
    console.warn("Error when getting all users from DB:");
    console.error("Error:", error);
    throw error;
  }
}

export default { Register, Login, UpdateUser, DeleteUser, GetAllUsers };
