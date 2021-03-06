﻿using System;

namespace ULMSLoansApi.Models
{
    public class LoanViewModel : BaseModel
    {
        public int CustomerId { get; set; }
        public double Amount { get; set; }
        public double InterestRate { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime ActualPaymentDate { get; set; }
        public bool FullyPaid { get; set; }
        public double Profit { get; set; }
        public double AmountPaidThusFar { get; set; }
        public double InterestValue { get; set; }
        public double TotalAmountToBePaid { get; set; }
        public int CurrentStatus { get; set; }
    }
}