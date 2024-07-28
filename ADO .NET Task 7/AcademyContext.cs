using Microsoft.EntityFrameworkCore;
namespace ADO_.NET_Task_7;

public class AcademyContext : DbContext
{
    public AcademyContext()
    {

        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Academy;Integrated Security=SSPI;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        #region Elaqeler
        //Department-Teacher
        modelBuilder.Entity<Teacher>().HasOne(t => t.Department).WithMany(d => d.Teachers).HasForeignKey(t => t.DepartamentId).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_Department");

        //FAcult-Student
        modelBuilder.Entity<Student>().HasOne(s => s.Faculty).WithMany(f => f.Students).HasForeignKey(s => s.FacultyId).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_Faculty");

        //Grup-Student
        modelBuilder.Entity<Student>().HasOne(s => s.Group).WithMany(f => f.Students).HasForeignKey(s => s.GroupId).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_Group");

        //Teacher-Grup
        modelBuilder.Entity<Teacher>().HasMany(t => t.Groups).WithMany(g => g.Teachers);
        #endregion



        //Departament
        //DP Id
        modelBuilder.Entity<Department>()
            .Property(x => x.DepartmentId)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();
        //DP Financing
        modelBuilder.Entity<Department>()
            .Property(x => x.Financing)
            .HasDefaultValue(0).HasColumnType("money")
            .IsRequired();
        //DP Name
        modelBuilder.Entity<Department>()
            .HasIndex(x => x.Name)
            .IsUnique();
        modelBuilder.Entity<Department>()
            .Property(x => x.Name)
            .HasMaxLength(100)// max value => 100
            .IsRequired();

        //Faculty
        //FC Id
        modelBuilder.Entity<Faculty>()
            .Property(x => x.FacultyId)
            .HasColumnName("Id")
            .IsRequired();

        //FC Name
        modelBuilder.Entity<Faculty>()
            .Property(x => x.Name)
            .HasMaxLength(100)//max value => 100
            .IsRequired();
        modelBuilder.Entity<Faculty>()
            .HasIndex(x => x.Name)
            .IsUnique();



        //Group
        //GR Id
        modelBuilder.Entity<Group>()
            .Property(x => x.GroupId)
            .HasColumnName("Id")
            .IsRequired();

        //GR Name
        modelBuilder.Entity<Group>()
            .Property(x => x.Name)
            .HasMaxLength(10)//max value => 10
            .IsRequired();//not null
        modelBuilder.Entity<Group>()
            .HasIndex(x => x.Name)
            .IsUnique();//unique

        //GR Rating
        modelBuilder.Entity<Group>()
            .Property(x => x.Rating)
            .IsRequired();

        //GR Year
        modelBuilder.Entity<Group>()
            .Property(x => x.Year)
            .IsRequired();




        //Teacher
        //TC Id
        modelBuilder.Entity<Teacher>()
            .Property(x => x.TeacherId)
            .HasColumnName("Id")
            .IsRequired();

        //TC EmpDate
        modelBuilder.Entity<Teacher>()
            .Property(x => x.EmploymentDate).HasColumnType("datetime")
            .IsRequired();

        //TC Name
        modelBuilder.Entity<Teacher>()
            .Property(x => x.FirstName)
            .HasColumnName("Name");

        //TC Premium
        modelBuilder.Entity<Teacher>()
            .Property(x => x.Premium)
            .IsRequired()
            .HasDefaultValue(0);//default => 0

        //TC Salary
        modelBuilder.Entity<Teacher>()
            .Property(x => x.Salary).HasColumnType("money")
            .IsRequired();

        //TC Surname
        modelBuilder.Entity<Teacher>()
            .Property(x => x.LastName)
            .HasColumnName("Surname")
            .IsRequired();


        //Student
        //ST Id
        modelBuilder.Entity<Student>()
            .Property(x => x.StudentId)
            .HasColumnName("Id")
            .IsRequired();

        modelBuilder.Entity<Student>()
            .Property(x => x.FirstName)
            .HasColumnName("Name")
            .IsRequired();

        modelBuilder.Entity<Student>()
            .Property(x => x.LastName)
            .HasColumnName("Surname")
            .IsRequired();


        #region Checks
        //CHECK Departament
        modelBuilder.Entity<Department>()
                .ToTable(x => x.HasCheckConstraint("CK_DP_MinValue", "Financing >= 0"))//Finance >= 0
                .ToTable(x => x.HasCheckConstraint("CH_DP_NullName", "Name != '' ")); //Name != bos


        //Check Faculty
        modelBuilder.Entity<Faculty>()
            .ToTable(x => x.HasCheckConstraint("CK_FC_NullName", "Name != '' "));//Name != bos


        //Check Group
        modelBuilder.Entity<Group>()
            .ToTable(x => x.HasCheckConstraint("CK_GR_NullName", "Name != '' "))//Name != bos
            .ToTable(x => x.HasCheckConstraint("CK_GR_GroupRating", "Rating >= 0 AND Rating<= 5")) //Rating(0-5)
            .ToTable(x => x.HasCheckConstraint("CK_GR_Year", "Year >=1 AND Year <= 5"));//Year 1-5

        //Check Teacher
        modelBuilder.Entity<Teacher>()
            .ToTable(x => x.HasCheckConstraint("CK_TC_EmDate", "EmploymentDate > 1990/01/01"))// Date > 01.01.1990
            .ToTable(x => x.HasCheckConstraint("CK_TC_NullName", "Name != ''")) //Name != bos
            .ToTable(x => x.HasCheckConstraint("CK_TC_PrValue", "Premium >= 0"))
            .ToTable(x => x.HasCheckConstraint("CK_TC_Salary", "Salary > 0")) // Salary > 0
            .ToTable(x => x.HasCheckConstraint("CK_TC_SurnameNUll", "Surname != '' "));//surname != bos



        //Check Student
        modelBuilder.Entity<Student>()
            .ToTable(x => x.HasCheckConstraint("CK_ST_NullName", "Name != '' "))// name != bos
            .ToTable(x => x.HasCheckConstraint("CK_ST_SurnameNull", "Surname != '' "));//surname != bos

        #endregion






    }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }






}
