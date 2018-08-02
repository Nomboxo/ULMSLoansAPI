using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ULMSLoansApi.Models;
using ULMSLoansDomain.Entities;

namespace ULMSLoansApi.AutoMapper
{
    public class LoansMapper
    {
        #region Initialize.
        public static void InitializeCustomerMapper()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<LoanViewModel, Loan>().ReverseMap();
            });
        }
        #endregion

        #region Map.
        public static Loan SaveNewLoan(LoanViewModel loanModel)
        {
            try
            {
                return Mapper.Map(loanModel, new Loan());
            }
            catch (Exception ex)
            {
                //Log exception details here.
                throw ex;
            }
        }

        public static Loan EditLoan(LoanViewModel loanModel)
        {
            try
            {
                return Mapper.Map(loanModel, new Loan());
            }
            catch (Exception ex)
            {
                //Log exception details here.
                throw ex;
            }
        }

        public static LoanViewModel GetLoan(Loan loan)
        {
            try
            {
                return Mapper.Map(loan, new LoanViewModel());
            }
            catch (Exception ex)
            {
                //Log exception details here.
                throw ex;
            }
        }

        public static IEnumerable<LoanViewModel> GetAllLoans(List<Loan> loans)
        {
            try
            {
                return Mapper.Map(loans, new List<LoanViewModel>());
            }
            catch (Exception ex)
            {
                //Log exception details here.
                throw ex;
            }
        }

        public static IEnumerable<LoanViewModel> GetCustomerLoans(List<Loan> customerLoans)
        {
            try
            {
                return Mapper.Map(customerLoans, new List<LoanViewModel>());
            }
            catch (Exception ex)
            {
                //Log exception details here.
                throw ex;
            }
        }
        #endregion
    }
}
