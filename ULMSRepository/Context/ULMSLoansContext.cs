using Microsoft.EntityFrameworkCore;
using ULMSLoansDomain.Entities;

namespace ULMSRepository.Context
{
    public class ULMSLoansContext : DbContext
    {
        public ULMSLoansContext(DbContextOptions<ULMSLoansContext> options) :
            base(options)
        {
        }

        public ULMSLoansContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO: Move this to the confif file.
            string cn = @"Server=MANE2\MANELISI;Database=ULMSLoans;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(cn);

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Loan> Loans { get; set; }

    }
}
