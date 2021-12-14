using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PostgresLibsTesting.Entities
{
    public partial class ErmDevContext : DbContext
    {
        public ErmDevContext()
        {
        }

        public ErmDevContext(DbContextOptions<ErmDevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<DeptManager> DeptManagers { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Salary> Salaries { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Title> Titles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Userpassword> Userpasswords { get; set; } = null!;
        public virtual DbSet<VAlluser> VAllusers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=192.168.1.227;Database=ErmDev;Username=app_user;Password=Iamsmart27@");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Country1)
                    .HasName("countries_pkey");

                entity.ToTable("countries");

                entity.Property(e => e.Country1)
                    .HasMaxLength(80)
                    .HasColumnName("country");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('country_seq'::regclass)");

                entity.Property(e => e.Iso)
                    .HasMaxLength(2)
                    .HasColumnName("iso")
                    .IsFixedLength();

                entity.Property(e => e.Iso3)
                    .HasMaxLength(3)
                    .HasColumnName("iso3")
                    .HasDefaultValueSql("NULL::bpchar")
                    .IsFixedLength();

                entity.Property(e => e.Nicename)
                    .HasMaxLength(80)
                    .HasColumnName("nicename");

                entity.Property(e => e.Numcode).HasColumnName("numcode");

                entity.Property(e => e.Phonecode).HasColumnName("phonecode");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptNo)
                    .HasName("departments_pkey");

                entity.ToTable("departments");

                entity.Property(e => e.DeptNo).HasColumnName("dept_no");

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(100)
                    .HasColumnName("createdby");

                entity.Property(e => e.DeptDesc)
                    .HasMaxLength(200)
                    .HasColumnName("dept_desc");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(40)
                    .HasColumnName("dept_name");

                entity.Property(e => e.Updatedat)
                    .HasMaxLength(40)
                    .HasColumnName("updatedat");

                entity.Property(e => e.Updatedby)
                    .HasMaxLength(40)
                    .HasColumnName("updatedby");
            });

            modelBuilder.Entity<DeptManager>(entity =>
            {
                entity.HasKey(e => new { e.EmpNo, e.DeptNo })
                    .HasName("dept_managers_pkey");

                entity.ToTable("dept_managers");

                entity.Property(e => e.EmpNo).HasColumnName("emp_no");

                entity.Property(e => e.DeptNo).HasColumnName("dept_no");

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(100)
                    .HasColumnName("createdby");

                entity.Property(e => e.FromDate).HasColumnName("from_date");

                entity.Property(e => e.ToDate).HasColumnName("to_date");

                entity.Property(e => e.Updatedat)
                    .HasMaxLength(40)
                    .HasColumnName("updatedat");

                entity.Property(e => e.Updatedby)
                    .HasMaxLength(40)
                    .HasColumnName("updatedby");

                entity.HasOne(d => d.DeptNoNavigation)
                    .WithMany(p => p.DeptManagers)
                    .HasForeignKey(d => d.DeptNo)
                    .HasConstraintName("dept_managers_dept_no_fkey");

                entity.HasOne(d => d.EmpNoNavigation)
                    .WithMany(p => p.DeptManagers)
                    .HasForeignKey(d => d.EmpNo)
                    .HasConstraintName("dept_managers_emp_no_fkey");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpNo)
                    .HasName("employees_pkey");

                entity.ToTable("employees");

                entity.Property(e => e.EmpNo)
                    .HasColumnName("emp_no")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Address)
                    .HasMaxLength(120)
                    .HasColumnName("address");

                entity.Property(e => e.Address1)
                    .HasMaxLength(120)
                    .HasColumnName("address1");

                entity.Property(e => e.Country)
                    .HasMaxLength(80)
                    .HasColumnName("country");

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(100)
                    .HasColumnName("createdby");

                entity.Property(e => e.Dob).HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Facebook)
                    .HasMaxLength(100)
                    .HasColumnName("facebook");

                entity.Property(e => e.Fax)
                    .HasMaxLength(40)
                    .HasColumnName("fax");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(40)
                    .HasColumnName("firstname");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .HasColumnName("gender");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(40)
                    .HasColumnName("lastname");

                entity.Property(e => e.Middlename)
                    .HasMaxLength(40)
                    .HasColumnName("middlename")
                    .HasDefaultValueSql("'N/A'::character varying");

                entity.Property(e => e.Pobox)
                    .HasMaxLength(80)
                    .HasColumnName("pobox")
                    .HasDefaultValueSql("'N/A'::character varying");

                entity.Property(e => e.Regionname)
                    .HasMaxLength(100)
                    .HasColumnName("regionname");

                entity.Property(e => e.State)
                    .HasMaxLength(100)
                    .HasColumnName("state");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(40)
                    .HasColumnName("telephone");

                entity.Property(e => e.Titre)
                    .HasMaxLength(40)
                    .HasColumnName("titre");

                entity.Property(e => e.Twitter)
                    .HasMaxLength(100)
                    .HasColumnName("twitter");

                entity.Property(e => e.Updatedat)
                    .HasMaxLength(40)
                    .HasColumnName("updatedat");

                entity.Property(e => e.Updatedby)
                    .HasMaxLength(40)
                    .HasColumnName("updatedby");

                entity.Property(e => e.Zip)
                    .HasMaxLength(80)
                    .HasColumnName("zip")
                    .HasDefaultValueSql("'N/A'::character varying");

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Country)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employees_country_fkey");

                entity.HasOne(d => d.RegionnameNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Regionname)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employees_regionname_fkey");

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.State)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employees_state_fkey");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.Regionname)
                    .HasName("regions_pkey");

                entity.ToTable("regions");

                entity.Property(e => e.Regionname)
                    .HasMaxLength(100)
                    .HasColumnName("regionname");

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(100)
                    .HasColumnName("createdby");

                entity.Property(e => e.Description)
                    .HasMaxLength(400)
                    .HasColumnName("description");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('country_seq'::regclass)");

                entity.Property(e => e.State)
                    .HasMaxLength(80)
                    .HasColumnName("state");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Updatedat)
                    .HasMaxLength(40)
                    .HasColumnName("updatedat");

                entity.Property(e => e.Updatedby)
                    .HasMaxLength(40)
                    .HasColumnName("updatedby");

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.Regions)
                    .HasForeignKey(d => d.State)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("regions_state_fkey");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Rolename)
                    .HasName("roles_pkey");

                entity.ToTable("roles");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(40)
                    .HasColumnName("rolename");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Createdat)
                    .HasMaxLength(40)
                    .HasColumnName("createdat");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(100)
                    .HasColumnName("createdby");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Updatedat)
                    .HasMaxLength(40)
                    .HasColumnName("updatedat");

                entity.Property(e => e.Updatedby)
                    .HasMaxLength(40)
                    .HasColumnName("updatedby");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasKey(e => new { e.EmpNo, e.FromDate })
                    .HasName("salaries_pkey");

                entity.ToTable("salaries");

                entity.Property(e => e.EmpNo).HasColumnName("emp_no");

                entity.Property(e => e.FromDate).HasColumnName("from_date");

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(100)
                    .HasColumnName("createdby");

                entity.Property(e => e.Salary1).HasColumnName("salary");

                entity.Property(e => e.ToDate).HasColumnName("to_date");

                entity.Property(e => e.Updatedat)
                    .HasMaxLength(40)
                    .HasColumnName("updatedat");

                entity.Property(e => e.Updatedby)
                    .HasMaxLength(40)
                    .HasColumnName("updatedby");

                entity.HasOne(d => d.EmpNoNavigation)
                    .WithMany(p => p.Salaries)
                    .HasForeignKey(d => d.EmpNo)
                    .HasConstraintName("salaries_emp_no_fkey");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.State1)
                    .HasName("states_pkey");

                entity.ToTable("states");

                entity.Property(e => e.State1)
                    .HasMaxLength(100)
                    .HasColumnName("state");

                entity.Property(e => e.Country)
                    .HasMaxLength(80)
                    .HasColumnName("country");

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(100)
                    .HasColumnName("createdby");

                entity.Property(e => e.Description)
                    .HasMaxLength(400)
                    .HasColumnName("description");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('country_seq'::regclass)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Updatedat)
                    .HasMaxLength(40)
                    .HasColumnName("updatedat");

                entity.Property(e => e.Updatedby)
                    .HasMaxLength(40)
                    .HasColumnName("updatedby");

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.Country)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("states_country_fkey");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.Status1)
                    .HasName("statuses_pkey");

                entity.ToTable("statuses");

                entity.Property(e => e.Status1).HasColumnName("status");

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(100)
                    .HasColumnName("createdby");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Updatedat)
                    .HasMaxLength(40)
                    .HasColumnName("updatedat");

                entity.Property(e => e.Updatedby)
                    .HasMaxLength(40)
                    .HasColumnName("updatedby");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.ToTable("titles");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(100)
                    .HasColumnName("createdby");

                entity.Property(e => e.FromDate).HasColumnName("from_date");

                entity.Property(e => e.Title1)
                    .HasMaxLength(50)
                    .HasColumnName("title");

                entity.Property(e => e.ToDate).HasColumnName("to_date");

                entity.Property(e => e.Updatedat)
                    .HasMaxLength(40)
                    .HasColumnName("updatedat");

                entity.Property(e => e.Updatedby)
                    .HasMaxLength(40)
                    .HasColumnName("updatedby");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(100)
                    .HasColumnName("createdby");

                entity.Property(e => e.Lastupdate).HasColumnName("lastupdate");

                entity.Property(e => e.Password)
                    .HasMaxLength(40)
                    .HasColumnName("password");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(40)
                    .HasColumnName("rolename");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Updatedat)
                    .HasMaxLength(40)
                    .HasColumnName("updatedat");

                entity.Property(e => e.Updatedby)
                    .HasMaxLength(40)
                    .HasColumnName("updatedby");

                entity.Property(e => e.Username)
                    .HasMaxLength(40)
                    .HasColumnName("username");

                entity.HasOne(d => d.RolenameNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Rolename)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_rolename_fkey");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_status_fkey");
            });

            modelBuilder.Entity<Userpassword>(entity =>
            {
                entity.ToTable("userpasswords");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(100)
                    .HasColumnName("createdby");

                entity.Property(e => e.Lastlogin).HasColumnName("lastlogin");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Updatedat)
                    .HasMaxLength(40)
                    .HasColumnName("updatedat");

                entity.Property(e => e.Updatedby)
                    .HasMaxLength(40)
                    .HasColumnName("updatedby");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userpasswords)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userpasswords_userid_fkey");
            });

            modelBuilder.Entity<VAlluser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_allusers");

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(100)
                    .HasColumnName("createdby");

                entity.Property(e => e.Lastupdate).HasColumnName("lastupdate");

                entity.Property(e => e.Password)
                    .HasMaxLength(40)
                    .HasColumnName("password");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(40)
                    .HasColumnName("rolename");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Updatedat)
                    .HasMaxLength(40)
                    .HasColumnName("updatedat");

                entity.Property(e => e.Updatedby)
                    .HasMaxLength(40)
                    .HasColumnName("updatedby");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Username)
                    .HasMaxLength(40)
                    .HasColumnName("username");
            });

            modelBuilder.HasSequence("country_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
