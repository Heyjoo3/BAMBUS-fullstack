export default {
  getActiveLoansFromUserId: (state) => (userId) =>
    state.loans.filter(
      (loan) => loan.userId === userId && loan.returnDate === null
    ),

  getPastLoansFromUserId: (state) => (userId) =>
    state.loans.filter(
      (loan) => loan.userId === userId && loan.returnDate !== null
    ),

  getAllLoansFromUserId: (state) => (userId) =>
    state.loans.filter((loan) => loan.userId === userId),

  getAllLoans: (state) => state.loans,

  getLoanById: (state) => (loanId) =>
    state.loans.find(
      (loan) => loan.loanId === loanId && loan.returnDate === null
    ),

  getActiveItemIdFromUserId: (state) => {
    const loans = state.loans.filter((loan) => loan.returnDate === null);
    return loans.map((loan) => loan.itemId);
  },
};
