using System.Collections.Generic;
using ULMSLoansDomain.Contracts.Repository;
using ULMSLoansDomain.Contracts.Services;
using ULMSLoansDomain.Entities;
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
            return loansRepository.SaveNewLoan(loan);
        }

        public Response EditLoan(Loan loan)
        {
            return loansRepository.EditLoan(loan);
        }

        public IEnumerable<Response> GetLoan(int loanId)
        {
            return loansRepository.GetLoan(loanId);
        }

        public IEnumerable<Response> GetAllLoans()
        {
            return loansRepository.GetAllLoans();
        }

        public IEnumerable<Response> GetCustomerLoans(int customerId)
        {
            return loansRepository.GetCustomerLoans(customerId);
        }

        #endregion
    }
}
