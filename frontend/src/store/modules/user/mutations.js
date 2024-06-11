export default {
  login(state, payload) {
    state.userIsAuth = true;
    state.user = payload.data;
    state.user.token = payload.token;
  },
  setUsers(state, payload) {
    state.users = payload;
  },
  deleteAccount(state, payload) {
    state.users = state.users.filter((user) => user.userId !== payload);
  },
  adminChangePassword(state, payload) {
    const user = state.users.find((user) => user.userId === payload.userId);
    user.password = payload.newPassword;
  },
  setNotifications(state, payload) {
    if (!payload) return;
    state.user.notifications = payload;
  },

  logout(state) {
    state.userIsAuth = false;
    state.user.token = null;
    state.user = {
      userId: null,
      username: null,
      password: null,
      role: null,
      email: null,
      firstName: null,
      lastName: null,
      notifications: [],
    };
  },
};
