using System;
using System.Collections.Generic;
using ULMSLoansDomain.Contracts.Repository;
using ULMSLoansDomain.Contracts.Services;
using ULMSLoansDomain.Entities;
using ULMSLookUps.Constants;
using ULMSLookUps.Models;

namespace ULMSLoansDomain.Services
{
    public class LoansService : ILoansService
    {
        #region Dependencies.
        ILoansRepository loansRepository;
        #endregion

        #region Constructors
        public LoansService(ILoansRepository loansRepository)
        {
            this.loansRepository = loansRepository;
        }
        #endregion

        #region CRUD methods.

        public Response SaveNewLoan(Loan loan)
        {
            var computedLoan = CalculateSaveLoanValues(loan);
            return loansRepository.SaveNewLoan(computedLoan);
        }

        public Loan EditLoan(Loan loan)
        {
            loan.FullyPaid = loan.TotalAmountToBePaid == loan.AmountPaidThusFar ? true : false;

            return loansRepository.EditLoan(loan);
        }

        public IEnumerable<Loan> GetLoan(int loanId)
        {
            return loansRepository.GetLoan(loanId);
        }

        public IEnumerable<Loan> GetAllLoans()
        {
            return loansRepository.GetAllLoans();
        }

        public IEnumerable<Loan> GetCustomerLoans(int customerId)
        {
            return loansRepository.GetCustomerLoans(customerId);
        }

        #endregion

        #region Public methods

        public double GetCustomerOutStandingBalance(int customerId)
        {
            var customerLoans = GetCustomerLoans(customerId);
            double totalOutstandingAmount = 0;

            foreach (Loan loan in customerLoans)
                totalOutstandingAmount = totalOutstandingAmount + (loan.TotalAmountToBePaid - loan.AmountPaidThusFar);

            return totalOutstandingAmount;
        }

        #endregion

        #region Private methods.

        private Loan CalculateSaveLoanValues(Loan loan)
        {
            loan.InterestRate = CalculateInterestRate();
            loan.InterestValue = CalculateLoanInterest(loan);
            loan.Profit = CalculateLoanInterest(loan);
            loan.TotalAmountToBePaid = CalculateTotalAmountToBePaid(loan);

            return loan;
        }

        private double CalculateInterestRate()
        {
            return LoanConstants.Interest;
        }

        private double CalculateLoanInterest(Loan loan)
        {
            return loan.Amount * loan.InterestRate;
        }

        private double CalculateTotalAmountToBePaid(Loan loan)
        {
            return loan.Amount + loan.InterestValue;
        }

        #endregion
    }
}
