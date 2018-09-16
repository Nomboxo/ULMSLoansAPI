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

        #region Constructors.

        public LoansRepository()
        {
            context = new ULMSLoansContext();
        }

        #endregion

        #region CRUD methods.

        public Loan SaveNewLoan(Loan loan)
        {
            try
            {
                context.Loans.Add(loan);
                context.SaveChanges();

                loan.StatusCode = ResponseCodes.Ok;
                loan.Message = ResponseMessages.SaveSuccessfully;
            }
            catch (Exception ex)
            {
                //Log exception details here.
                loan.Message = ex.ToString();
                loan.StatusCode = ResponseCodes.InternalServerError;
            }

            return loan;
        }

        public Loan EditLoan(Loan loan)
        {
            try
            {
                context.Loans.Update(loan);
                context.SaveChanges();

                loan.Message = ResponseMessages.Success;
                loan.StatusCode = ResponseCodes.Ok;
            }
            catch (Exception ex)
            {
                //Log exception details here.
                loan.Message = ex.ToString();
                loan.StatusCode = ResponseCodes.InternalServerError;
            }

            return loan;
        }

        public IEnumerable<Loan> GetLoan(int loanId)
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
                return new Loan[]
                {
                    new Loan
                    {
                        StatusCode = ResponseCodes.InternalServerError,
                        Message = ex.ToString()
                    }
                };
            }
        }

        public IEnumerable<Loan> GetUnpaidLoans()
        {
            try
            {
                var loans = context.Loans.Where(x => x.FullyPaid == false).ToList();
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
                return new Loan[]
                {
                    new Loan
                    {
                        StatusCode = ResponseCodes.InternalServerError,
                        Message = ex.ToString()
                    }
                };
            }
        }

        public IEnumerable<Loan> GetAllLoans()
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
                return new Loan[]
                {
                    new Loan
                    {
                        StatusCode = ResponseCodes.InternalServerError,
                        Message = ex.ToString()
                    }
                };
            }
        }

        public IEnumerable<Loan> GetCustomerLoans(int customerId)
        {
            try
            {
                var loans = context.Loans.Where(x => x.CustomerId == customerId).ToList();
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
                return new Loan[]
                {   new Loan{
                    StatusCode = ResponseCodes.InternalServerError,
                        Message = ex.ToString()
                }
                };
            }
        }

        #endregion

        #region private methods


        private double GetTotalAmountOwed()
        {
            double totalAmount = 0;
            var loans = GetUnpaidLoans();

            foreach (Loan loan in loans)
                totalAmount = totalAmount + (loan.TotalAmountToBePaid - loan.AmountPaidThusFar);

            return totalAmount;
        }

        #endregion
    }
}