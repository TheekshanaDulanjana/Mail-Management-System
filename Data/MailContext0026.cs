using Microsoft.EntityFrameworkCore;
using MailManagementAPI0026.Models;

namespace MailManagementAPI0026.Data
{
    public class MailContext0026 : DbContext
    {
        public MailContext0026(DbContextOptions<MailContext0026> options) : base(options)
        {
        }

        public DbSet<Department0026> Departments { get; set; }
        public DbSet<Mail0026> Mails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<Mail0026>()
                .HasOne(m => m.SenderDepartment)
                .WithMany()
                .HasForeignKey(m => m.SenderDepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Mail0026>()
                .HasOne(m => m.RecipientDepartment)
                .WithMany()
                .HasForeignKey(m => m.RecipientDepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed some initial data
            modelBuilder.Entity<Department0026>().HasData(
                new Department0026 { DepartmentId = 1, DepartmentName = "IT Department" },
                new Department0026 { DepartmentId = 2, DepartmentName = "HR Department" },
                new Department0026 { DepartmentId = 3, DepartmentName = "Finance Department" }
            );
        }
    }
}
