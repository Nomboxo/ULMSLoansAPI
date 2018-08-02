using System.Collections.Generic;
using ULMSLoansDomain.Entities;
using ULMSLookUps.Models;

namespace ULMSLoansDomain.Contracts.Services
{
    public interface ILoansService
    {
        #region CRUD methods.

        Response SaveNewLoan(Loan loan);
        Response EditLoan(Loan loan);
        IEnumerable<Response> GetLoan(int loanId);
        IEnumerable<Response> GetAllLoans();
        IEnumerable<Response> GetCustomerLoans(int customerId);

        #endregion
    }
}
