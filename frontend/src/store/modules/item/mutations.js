export default {
  setItems(state, items) {
    items.forEach((item) => {
      item.reservations = item.reservations || [];
      item.category = item.category || "";
      item.author = item.author || "";
      item.avgRating = item.avgRating || 0;
      item.currentLoanId = item.currentLoanId || 0;
    });
    state.items = items;
  },

  setEditItemId(state, id) {
    state.editItemId = id;
  },

  setReturnItemId(state, id) {
    state.returnItemId = id;
  },

  setReportItemId(state, id) {
    state.reportItemId = id;
  },

  deleteAllModalIds(state) {
    state.editItemId = null;
    state.returnItemId = null;
    state.reportItemId = null;
  },

  requestExtension(state, { index, newDueDate }) {
    state.items[index].dueDate = newDueDate;
  },

  logout(state) {
    state.editItemId = null;
    state.returnItemId = null;
    state.reportItemId = null;
    state.filteredBy = null;
    state.sortedBy = null;
    state.onlyAvailable = false;
    state.search = "";
  },

  setFilteredBy(state, filterBy) {
    const filterMap = {
      books: 1,
      games: 2,
      magazines: 0,
    };
    state.filteredBy = filterMap[filterBy] ?? filterBy;
  },

  setSortedBy(state, sortBy) {
    state.sortedBy = sortBy;
  },

  setOnlyAvailable(state, onlyAvailable) {
    state.onlyAvailable = onlyAvailable;
  },

  setSearch(state, search) {
    state.search = search;
  },
  updateItem(state, item) {
    console.log(item);
    let index = state.items.findIndex((i) => i.itemId === item.itemId);
    state.items[index] = item;
    if (index === -1) {
      state.items.push(item);
    }
  }
};
