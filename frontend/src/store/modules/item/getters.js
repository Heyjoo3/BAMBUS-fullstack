export default {
  getItemById: (state) => (itemId) =>
    state.items.find((item) => item.itemId === itemId),

  getEditItem: (state) =>
    state.items.find((item) => item.itemId === state.editItemId),

  getReturnItemId: (state) => state.returnItemId,

  getItemsReservedByUser: (state) => (userId) => {
    const items = state.items.filter((item) =>
      item.reservations.includes(userId)
    );
    return items ? items : [];
  },

  getReportedItem: (state) =>
    state.items.find((item) => item.itemId === state.reportItemId),

  isReservedItemAvailableForRenting: (state) => (itemId, userId) => {
    const item = state.items.find((item) => item.itemId === itemId);
    return item.reservations[0] === userId && item.currentLoanId === 0;
  },

  getFilteredItems: (state, _, __, rootGetters) => {
    if (state.search !== "") {
      return rootGetters["itemStore/getSearch"];
    }

    let filteredItems =
      state.filteredBy === null || state.filteredBy === "all"
        ? state.items
        : state.items.filter((item) => item.type === state.filteredBy);

    const sortedItems = rootGetters["itemStore/getSortedItems"](filteredItems);
    return rootGetters["itemStore/getOnlyAvailableItems"](sortedItems);
  },

  getSortedItems: (state) => (items) => {
    const sortOptions = {
      default: (a, b) => 0,
      avgRating: (a, b) => (a.avgRating || 0) - (b.avgRating || 0),
      title: (a, b) => a.title.localeCompare(b.title),
      author: (a, b) => (a.author || "").localeCompare(b.author || ""),
      avgRatingDesc: (a, b) => (b.avgRating || 0) - (a.avgRating || 0),
      titleDesc: (a, b) => b.title.localeCompare(a.title),
      authorDesc: (a, b) => (b.author || "").localeCompare(a.author || ""),
    };

    const sortFunction = sortOptions[state.sortedBy] || sortOptions.default;
    return items && items.length > 0 ? [...items].sort(sortFunction) : [];
  },

  getOnlyAvailableItems: (state) => (items) =>
    state.onlyAvailable
      ? items.filter(
          (item) =>
            (item.currentLoanId === 0 || item.currentLoanId === null) &&
            item.reservations.length === 0
        )
      : items,

  getSearch: (state) =>
    state.items.filter((item) => {
      const searchLower = state.search.toLowerCase();
      return (
        item.title?.toLowerCase().includes(searchLower) ||
        item.author?.toLowerCase().includes(searchLower) ||
        item.category?.toLowerCase().includes(searchLower)
      );
    }),

  getReportedItems: (state) =>
    state.items.filter((item) => item.condition === 1),

  getItemsWithoutLoanButReserved: (state) =>
    state.items.filter(
      (item) =>
        item.reservations.length > 0 &&
        (item.currentLoanId === 0 || item.currentLoanId === null)
    ),
};
