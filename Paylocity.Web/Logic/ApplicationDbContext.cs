using Microsoft.EntityFrameworkCore;
using Paylocity.Web.Models.Entities;

namespace Paylocity.Web.Logic
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<BenefitAssessmentConfiguration> BenefitAssessmentConfigurations { get; set; }
        public DbSet<BenefitAssessmentConfigurationCost> BenefitAssessmentConfigurationCosts { get; set; }
        public DbSet<BenefitAssessmentConfigurationPayPeriod> BenefitAssessmentConfigurationPayPeriods { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
