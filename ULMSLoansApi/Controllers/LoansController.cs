using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ULMSLoansApi.AutoMapper;
using ULMSLoansApi.Models;
using ULMSLoansDomain.Contracts.Services;
using ULMSLookUps.Constants;

namespace ULMSLoansApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Loans")]
    public class LoansController : Controller
    {

        #region Dependencies.

        ILoansService loanService;

        #endregion

        #region Constructors

        public LoansController (ILoansService loansService)
        {
            this.loanService = loansService;
        }

        #endregion

        #region CRUD Actions

        [HttpPost("{loan}")]
        public JsonResult SaveNewLoan(LoanViewModel loan)
        {
            var loanEntity = LoansMapper.SaveNewLoan(loan);
            var response = loanService.SaveNewLoan(loanEntity);

            return new JsonResult(response)
            {
                StatusCode = response.StatusCode
            };
        }

        [HttpPut("{loan}")]
        public JsonResult EditLoan(LoanViewModel loan)
        {
            var loanEntity = LoansMapper.EditLoan(loan);
            var response = loanService.EditLoan(loanEntity);

            return new JsonResult(response)
            {
                StatusCode = response.StatusCode
            };
        }

        [Route("{loanId}")]
        public JsonResult GetLoan(int loanId)
        {
            var response = loanService.GetLoan(loanId).ToList();
            
            return new JsonResult(response)
            {
                StatusCode = response[0].StatusCode
            };
        }

        //[HttpGet]
        [Route("/GetAllLoans")]
        public JsonResult GetAllLoans()
        {
            var response = loanService.GetAllLoans().ToList();

            return new JsonResult(response)
            {
                StatusCode = response[0].StatusCode
            };
        }

        [HttpGet("/GetCustomerLoans/{customerId}")]
        public JsonResult GetCustomerLoans(int customerId)
        {
            var response = loanService.GetCustomerLoans(customerId).ToList();

            return new JsonResult(response)
            {
                StatusCode = response[0].StatusCode
            };
        }

        [HttpGet]
        public JsonResult GetCustomerOutStandingBalance(int customerId)
        {
            var response = loanService.GetCustomerOutStandingBalance(customerId);
            
            return new JsonResult(response)
            {
                StatusCode = response > 0 ? ResponseCodes.Ok : ResponseCodes.NoOutstandingBalanceFound
            };
        }

        #endregion
    }
}