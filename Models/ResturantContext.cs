﻿using Microsoft.EntityFrameworkCore;

namespace Resturant_RES_API_ITI_PRJ.Models
{
    public class ResturantContext : DbContext
    {

        public ResturantContext(DbContextOptions<ResturantContext> options) : base(options)
        {

        }

        //Management
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddresses { get; set; }
        public DbSet<EmployeeCategory> EmployeeCategories { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.ToTable("employee", "manage");

                entity.Property(e => e.EmpFirstName)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasComment("الاسم الاول");

                entity.Property(e => e.EmpLastName)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasComment("الاسم الثاني");

                entity.Property(e => e.EmpEmail)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasComment("البريد الاليكتروني");


                entity.Property(e => e.EmpPassword)
                    .HasMaxLength(50)
                    .IsRequired(false)
                    .IsUnicode(true)
                    .HasComment("كلمه السر");

                entity.Property(e => e.EmpPhone)
                    .HasMaxLength(11)
                    .IsRequired(false)
                    .IsUnicode(false)
                    .HasComment("رقم التيلفون");

                entity.Property(e => e.EmpNationalId)
                    .HasMaxLength(14)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasComment("الرقم القومي");

                entity.Property(e => e.EmpHirigDate).HasColumnType("datetime2").HasComment("تاريخ التعيين");


                entity.Property(e => e.EmpSalary).HasColumnType("decimal").HasComment("المرتب");

                entity.HasIndex(e => e.EmpEmail).IsUnique(true);

                entity.HasIndex(e => e.EmpPhone).IsUnique(true);

                entity.HasIndex(e => e.EmpNationalId).IsUnique(true);

                //entity.HasIndex(e => new
                //{
                //    e.EmpEmail,
                //    e.EmpPhone,
                //    e.EmpNationalId
                //}).IsUnique(true);

                entity.HasOne(e => e.FranchiseIdNavigation)
                    .WithMany(c => c.Employees)
                    .HasForeignKey(e => e.FranchiseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_franchise");

                entity.HasOne(e => e.EmpCategoryIdNavigation)
                    .WithMany(c => c.Employees)
                    .HasForeignKey(e => e.EmpCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_category");
            });

            modelBuilder.Entity<EmployeeAddress>(entity =>
            {
                entity.HasKey(e => e.EmployeeAddressId);

                entity.ToTable("employeeAddress", "manage");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(false);

                entity.HasOne(e => e.EmployeeIdNavigation)
                    .WithMany(c => c.EmployeeAddresses)
                    .HasForeignKey(e => e.EmpId)
                    .HasConstraintName("FK_employeeAddress_employee");
            });

            modelBuilder.Entity<Franchise>(entity =>
            {
                entity.HasKey(e => e.FranchiseId);

                entity.ToTable("franchise", "manage");

                entity.Property(e => e.Street)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerId)
                    .IsRequired(false) 
                    .IsUnicode(false);

                entity.HasOne(e => e.ManagerIdNavigation)
                    .WithMany(c => c.Franchises)
                    .HasForeignKey(e => e.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)

                    .HasConstraintName("FK_franchise_manager");
            });

            modelBuilder.Entity<EmployeeCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("employeeCategory", "manage");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(false);
            });
        }
    }
}
