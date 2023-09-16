using Microsoft.EntityFrameworkCore;

namespace Resturant_RES_API_ITI_PRJ.Models
{
    public class ResturantContext : DbContext
    {

        public ResturantContext(DbContextOptions<ResturantContext> options) : base(options)
        {

        }

        // Management
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddresses { get; set; }
        public DbSet<EmployeeCategory> EmployeeCategories { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

        // Dish
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishCategory> DishCategories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredientRel> DishIngredientRels { get; set; }

        // Order
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderState> OrderStates { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<OrderDishesRel> OrderDishesRels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Management
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.ToTable("employee", "manage");

                entity.Property(e => e.EmpId).HasComment("كود الموظف");

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
                    .HasComment("البريد الالكتروني");

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

                entity.Property(e => e.EmpHirigDate)
                    .IsRequired(true)
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()")
                    .HasComment("تاريخ التعيين");

                entity.Property(e => e.EmpSalary)
                    .IsRequired(true)
                    .HasColumnType("decimal")
                    .HasComment("المرتب");

                entity.Property(e => e.FranchiseId)
                    .IsRequired(true)
                    .HasComment("كود الفرع");

                entity.Property(e => e.EmpCategoryId)
                    .IsRequired(true)
                    .HasComment("كود الوظيفه");

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

                entity.Property(e => e.EmployeeAddressId)
                    .HasComment("كود العنوان");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasComment("المدينه");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(false)
                    //.HasDefaultValueSql("'Egypt'")
                    .HasComment("الدوله");

                entity.Property(e => e.EmpId)
                    .IsRequired(true)
                    .HasComment("كود الموظف");

                entity.HasOne(e => e.EmployeeIdNavigation)
                    .WithMany(c => c.EmployeeAddresses)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasForeignKey(e => e.EmpId)
                    .HasConstraintName("FK_employeeAddress_employee");
            });

            modelBuilder.Entity<Franchise>(entity =>
            {
                entity.HasKey(e => e.FranchiseId);

                entity.ToTable("franchise", "manage");

                entity.Property(e => e.FranchiseId)
                    .HasComment("كود الفرع");

                entity.Property(e => e.Street)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasComment("الشارع");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasComment("المدينه");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    //.HasDefaultValueSql("'Egypt'")
                    .IsUnicode(false)
                    .HasComment("الدوله");

                entity.Property(e => e.ManagerId)
                    .IsRequired(false)
                    .HasComment("كود المدير");

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

                entity.Property(e => e.CategoryId)
                    .HasComment("كود الوظيفه");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasComment("اسم الوظيفه");
            });

            // Dish
            modelBuilder.Entity<Dish>(entity =>
            {
                entity.HasKey(e => e.DishId);

                entity.ToTable("dish", "dish");

                entity.Property(e => e.DishId)
                    .HasComment("كود الطبق");

                entity.Property(e => e.DishName)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasComment("اسم الطبق");

                entity.Property(e => e.DishPrice)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasComment("سعر الطبق");

                entity.Property(e => e.DishImageName)
                    .HasColumnType("varchar(max)")
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasComment("صوره الطبق");

                entity.Property(e => e.DishCategoryId)
                    .IsRequired(true)
                    .HasComment("كود التصنيف");

                entity.HasOne(e => e.DishCategoryIdNavigation)
                    .WithMany(c => c.Dishes)
                    .HasForeignKey(e => e.DishCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dish_dishCategory");
            });

            modelBuilder.Entity<DishCategory>(entity =>
            {
                entity.HasKey(e => e.DishCategoryId);

                entity.ToTable("dishCategory", "dish");

                entity.Property(e => e.DishCategoryId)
                    .IsRequired(true)
                    .HasComment("كود الصنف");

                entity.Property(e => e.DishCategoryName)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasComment("اسم الصنف");

            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(e => e.IngredientId);

                entity.ToTable("ingredient", "dish");

                entity.Property(e => e.IngredientId)
                    .IsRequired(true)
                    .HasComment("كود المكونات");

                entity.Property(e => e.IngredientName)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasComment("اسم المكونات");
            });

            modelBuilder.Entity<DishIngredientRel>(entity =>
            {
                entity.HasKey(e => e.DishIngredientRelId);

                entity.ToTable("dishIngredient", "dish");

                entity.Property(e => e.DishIngredientRelId)
                .HasComment("كود الطبق و المكون");

                entity.Property(e => e.DishId)
                    .IsRequired(true)
                    .HasComment("كود الطبق");

                entity.Property(e => e.IngredientId)
                    .IsRequired(true)
                    .HasComment("كود المكون");

                entity.HasOne(e => e.DishIdNavigation)
                    .WithMany(c => c.DishIngredientRels)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dishIngredient_dish");

                entity.HasOne(e => e.IngredientIdNavigation)
                    .WithMany(c => c.DishIngredientRels)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dishIngredient_ingredient");
            });

            // Order
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("order", "order");

                entity.Property(e => e.OrderId).HasComment("كود الطلب");

                entity.Property(e => e.OrderSerialNum)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasComment("رقم الطلب");

                entity.Property(e => e.IsPaid)
                    .IsRequired(true)
                    .HasDefaultValueSql("0")
                    .HasComment("هل تم الدفع؟");

                entity.Property(e => e.OrderDate)
                    .IsRequired(true)
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETDATE()")
                    .HasComment("تاريخ الطلب");

                entity.Property(e => e.OrderTypeId)
                    .IsRequired(true)
                    .HasComment("كود نوع الطلب");

                entity.Property(e => e.OrderStateId)
                    .IsRequired(true)
                    .HasComment("كود حاله الطلب");

                entity.Property(e => e.PaymentMethodId)
                    .IsRequired(true)
                    .HasComment("طريقه الدفع");

                entity.Property(e => e.CustomerId)
                    .IsRequired(true)
                    .HasComment("كود العميل");

                entity.Property(e => e.FranchiseId)
                    .IsRequired(true)
                    .HasComment("كود الفرع");

                entity.HasIndex(e => e.OrderSerialNum).IsUnique(true);

                entity.HasOne(e => e.OrderTypeIdNavigation)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(e => e.OrderTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_orderType");

                entity.HasOne(e => e.OrderStateIdNavigation)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(e => e.OrderStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_orderState");

                entity.HasOne(e => e.PaymentMethodIdNavigation)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(e => e.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_paymentMethod");

                entity.HasOne(e => e.CustomerIdNavigation)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(e => e.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_customer");

                entity.HasOne(e => e.FranchiseIdNavigation)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(e => e.FranchiseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_Franchise");
            });

            modelBuilder.Entity<OrderType>(entity =>
            {
                entity.HasKey(e => e.OrderTypeId);

                entity.ToTable("orderType", "order");

                entity.Property(e => e.OrderTypeId)
                    .IsRequired(true)
                    .HasComment("كود نوع الطلب");

                entity.Property(e => e.OrderTypeName)
                    .IsRequired(true)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("اسم نوع الطلب");
            });

            modelBuilder.Entity<OrderState>(entity =>
            {
                entity.HasKey(e => e.OrderStateId);

                entity.ToTable("orderState", "order");

                entity.Property(e => e.OrderStateId)
                    .IsRequired(true)
                    .HasComment("كود حاله الطلب");

                entity.Property(e => e.OrderStateName)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasMaxLength(50)
                    .HasComment("اسم حاله الطلب");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.HasKey(e => e.PaymentMethodId);

                entity.ToTable("paymentMethod", "order");

                entity.Property(e => e.PaymentMethodId)
                    .IsRequired(true)
                    .HasComment("كود طريقه الدفع");

                entity.Property(e => e.PaymentMethodName)
                    .IsRequired(true)
                    .IsUnicode(false)
                    .HasMaxLength(50)
                    .HasComment("اسم طريقه الدفع");
            });

            modelBuilder.Entity<OrderDishesRel>(entity =>
            {
                entity.HasKey(e => e.OrderDishesRelId);

                entity.ToTable("orderDishesRel", "order");

                entity.Property(e => e.OrderDishesRelId)
                    .IsRequired(true)
                    .HasComment("كود الطلب والطبق");

                entity.Property(e => e.Quantity)
                    .HasColumnType("integer")
                    .IsUnicode(false)
                    .IsRequired(true)
                    .HasComment("الكميه");

                entity.Property(e => e.OrderId)
                    .IsRequired(true)
                    .HasComment("كود الطلب");

                entity.Property(e => e.DishId)
                    .IsRequired(true)
                    .HasComment("كود الطبق");

                entity.HasOne(e => e.OrderIdNavigation)
                    .WithMany(c => c.OrderDishesRels)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orderDishesRel_order");

                entity.HasOne(e => e.DishIdNavigation)
                    .WithMany(c => c.OrderesDishesRels)
                    .HasForeignKey(e => e.DishId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orderDishesRel_dish");
            });
        }
    }
}
