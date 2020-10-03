using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace VagaFPF.Models
{
    public class EntityDBContext : DbContext
    {
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public EntityDBContext()
            : base("name=OracleDbContext")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("FPF");

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Rule>().ToTable("rule");
            modelBuilder.Entity<Rule>().HasKey(c => c.RuleID);
            modelBuilder.Entity<Rule>().Property(c => c.RuleID)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Rule>().Property(c => c.name)
                .HasColumnName("name")
                .HasMaxLength(54);

            modelBuilder.Entity<Rule>().Property(c => c.active)
                .HasColumnName("active")
                .HasMaxLength(1);

            modelBuilder.Entity<Rule>().Property(c => c.created_at)
              .HasColumnName("created_at");

            modelBuilder.Entity<Rule>().Property(c => c.modified_at)
              .HasColumnName("modified_at");

            modelBuilder.Entity<Employee>().ToTable("employee");
            modelBuilder.Entity<Employee>().HasKey(c => c.EmployeeID);
            modelBuilder.Entity<Employee>().Property(c => c.EmployeeID)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Employee>().Property(c => c.name)
                .HasColumnName("name")
                .HasMaxLength(104);

            modelBuilder.Entity<Employee>().Property(c => c.salary)
                .HasColumnName("salary")
                .HasPrecision(10,2);

            modelBuilder.Entity<Employee>().Property(c => c.gender)
                .HasColumnName("gender")
                .HasMaxLength(1);

            modelBuilder.Entity<Employee>().Property(c => c.active)
                .HasColumnName("active")
                .HasMaxLength(1);


            modelBuilder.Entity<Employee>().Property(c => c.created_at)
              .HasColumnName("created_at");

            modelBuilder.Entity<Employee>().Property(c => c.modified_at)
              .HasColumnName("modified_at");

            modelBuilder.Entity<Employee>().Property(c => c.RuleID)
              .HasColumnName("id_rule");


            // configures one-to-many relationship
            modelBuilder.Entity<Employee>()
                .HasRequired<Rule>(s => s.Rule)
                .WithMany(g => g.Employees)
                .HasForeignKey<int>(s => s.RuleID);

        }
    }
}