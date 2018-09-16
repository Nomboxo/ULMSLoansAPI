using System.Collections.Generic;
using ULMSLoansDomain.Entities;
using ULMSLookUps.Models;

namespace ULMSLoansDomain.Contracts.Services
{
    public interface ILoansService
    {
        #region CRUD methods.

        Response SaveNewLoan(Loan loan);
        Loan EditLoan(Loan loan);
        IEnumerable<Loan> GetLoan(int loanId);
        IEnumerable<Loan> GetAllLoans();
        IEnumerable<Loan> GetCustomerLoans(int customerId);
        double GetCustomerOutStandingBalance(int customerId);

        #endregion
    }
}
