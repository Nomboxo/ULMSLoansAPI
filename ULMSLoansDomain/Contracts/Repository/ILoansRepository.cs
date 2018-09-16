using System.Collections.Generic;
using ULMSLoansDomain.Entities;
using ULMSLookUps.Models;

namespace ULMSLoansDomain.Contracts.Repository
{
    public interface ILoansRepository
    {
        #region CRUD methods.

        Loan SaveNewLoan(Loan loan);
        Loan EditLoan(Loan loan);
        IEnumerable<Loan> GetLoan(int loanId);
        IEnumerable<Loan> GetAllLoans();
        IEnumerable<Loan> GetCustomerLoans(int customerId);
        IEnumerable<Loan> GetUnpaidLoans();

        #endregion 
    }
}
