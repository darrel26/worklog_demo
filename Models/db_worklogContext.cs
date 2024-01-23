using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace worklog_demo.Models
{
    public partial class db_worklogContext : DbContext
    {
        public db_worklogContext()
        {
        }

        public db_worklogContext(DbContextOptions<db_worklogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbProject> TbProjects { get; set; }
        public virtual DbSet<TbUser> TbUsers { get; set; }
        public virtual DbSet<TbUsersProject> TbUsersProjects { get; set; }
        public virtual DbSet<TbWorklog> TbWorklogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=db_worklog", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<TbProject>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("PRIMARY");

                entity.ToTable("tb_projects");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("int(11)")
                    .HasColumnName("projectID");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("projectName");
            });

            modelBuilder.Entity<TbUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("tb_users");

                entity.HasIndex(e => e.Username, "username")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("userID");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fullName");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<TbUsersProject>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tb_users_projects");

                entity.HasIndex(e => e.ProjectId, "FK_projectID");

                entity.HasIndex(e => e.UserId, "FK_userID");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("int(11)")
                    .HasColumnName("projectID");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("userID");

                entity.HasOne(d => d.Project)
                    .WithMany()
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_projectID");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_userID");
            });

            modelBuilder.Entity<TbWorklog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PRIMARY");

                entity.ToTable("tb_worklog");

                entity.HasIndex(e => e.ProjectId, "FK_log_projectID");

                entity.HasIndex(e => e.UserId, "FK_log_userID");

                entity.Property(e => e.LogId)
                    .HasColumnType("int(11)")
                    .HasColumnName("logID");

                entity.Property(e => e.LogDate)
                    .HasColumnType("date")
                    .HasColumnName("logDate");

                entity.Property(e => e.LogDetails)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("logDetails");

                entity.Property(e => e.LogEnd)
                    .HasColumnType("time")
                    .HasColumnName("logEnd");

                entity.Property(e => e.LogStart)
                    .HasColumnType("time")
                    .HasColumnName("logStart");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("int(11)")
                    .HasColumnName("projectID");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("userID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Worklogs)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_log_projectID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Worklogs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_log_userID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
