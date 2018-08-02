using System;
using System.Collections.Generic;
using System.Linq;
using ULMSLoansDomain.Contracts.Repository;
using ULMSLoansDomain.Entities;
using ULMSLookUps.Constants;
using ULMSLookUps.Models;
using ULMSRepository.Context;

namespace ULMSRepository.Logic
{
    public class LoansRepository : ILoansRepository
    {
        ULMSLoansContext context;

        public LoansRepository()
        {
            context = new ULMSLoansContext();
        }


        #region CRUD methods.

        public Response SaveNewLoan(Loan loan)
        {
            try
            {
                context.Loans.Add(loan);
                context.SaveChanges();
                return new Response
                {
                    StatusCode = ResponseCodes.Ok,
                    Message = ResponseMessages.SaveSuccessfully
                };
            }
            catch (Exception ex)
            {
                //Log exception details here.
                return new Response
                {
                    StatusCode = ResponseCodes.InternalServerError,
                    Message = ex.ToString()
                };
            }
        }

        public Response EditLoan(Loan loan)
        {
            try
            {
                context.Loans.Update(loan);
                context.SaveChanges();
                return new Response
                {
                    StatusCode = ResponseCodes.Ok,
                    Message = ResponseMessages.SaveSuccessfully
                };
            }
            catch (Exception ex)
            {
                //Log exception details here.
                return new Response
                {
                    StatusCode = ResponseCodes.InternalServerError,
                    Message = ex.ToString()
                };
            }
        }

        public IEnumerable<Response> GetLoan(int loanId)
        {
            try
            {
                var loans = context.Loans.Where(x => x.Id == loanId).ToList();
                if (loans != null && loans.Any())
                {
                    loans[0].StatusCode = ResponseCodes.Ok;
                    loans[0].Message = ResponseMessages.Success;
                }
                else
                {
                    return new Loan[]
                    {
                        new Loan
                        {
                            StatusCode = ResponseCodes.NotFound,
                            Message = ResponseMessages.LoanNotFound
                        }
                    };
                }
                
                return loans;
            }
            catch (Exception ex)
            {
                //Log exception details here.
                return new Response[]
                {
                    new Response
                    {
                        StatusCode = ResponseCodes.InternalServerError,
                        Message = ex.ToString()
                    }
                };
            }
        }

        public IEnumerable<Response> GetAllLoans()
        {
            try
            {
                var loans = context.Loans.ToList();
                if (loans != null && loans.Any())
                {
                    loans[0].StatusCode = ResponseCodes.Ok;
                    loans[0].Message = ResponseMessages.Success;
                }
                else
                {
                    return new Loan[]
                    {
                        new Loan
                        {
                            StatusCode = ResponseCodes.NotFound,
                            Message = ResponseMessages.LoanNotFound
                        }
                    };
                }

                return loans;
            }
            catch (Exception ex)
            {
                //Log exception details here.
                return new Response[]
                {
                    new Response
                    {
                        StatusCode = ResponseCodes.InternalServerError,
                        Message = ex.ToString()
                    }
                };
            }
        }

        public IEnumerable<Response> GetCustomerLoans(int customerId)
        {
            try
            {
                var loans = context.Loans.Where(x=>x.CustomerId == customerId).ToList();
                if (loans != null && loans.Any())
                {
                    loans[0].StatusCode = ResponseCodes.Ok;
                    loans[0].Message = ResponseMessages.Success;
                }
                else
                {
                    return new Loan[]
                    {
                        new Loan
                        {
                            StatusCode = ResponseCodes.NotFound,
                            Message = ResponseMessages.LoanNotFound
                        }
                    };
                }

                return loans;
            }
            catch (Exception ex)
            {
                //Log exception details here.
                return new Response[]
                {
                    new Response
                    {
                        StatusCode = ResponseCodes.InternalServerError,
                        Message = ex.ToString()
                    }
                };
            }
        }

        #endregion
    }
}