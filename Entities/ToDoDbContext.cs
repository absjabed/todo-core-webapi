using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace todo_core_webapi.Entities
{
    public partial class ToDoDbContext : DbContext
    {
        public ToDoDbContext()
        {
        }

        public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TodoTable> TodoTable { get; set; }
        public virtual DbSet<UserInfoTable> UserInfoTable { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoTable>(entity =>
            {
                entity.HasKey(e => e.IAutoId);

                entity.HasIndex(e => e.VTodoId)
                    .HasName("IX_TodoTable")
                    .IsUnique();

                entity.Property(e => e.IAutoId).HasColumnName("iAutoID");

                entity.Property(e => e.BIsDeleted)
                    .HasColumnName("bIsDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BIsDone)
                    .HasColumnName("bIsDone")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DDate)
                    .HasColumnName("dDate")
                    .HasColumnType("date");

                entity.Property(e => e.DDateOfEntry)
                    .HasColumnName("dDateOfEntry")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TNotifyTime)
                    .HasColumnName("tNotifyTime")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TTime)
                    .HasColumnName("tTime")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VColorLabel)
                    .HasColumnName("vColorLabel")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VLocation)
                    .HasColumnName("vLocation")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VTodoDescription)
                    .HasColumnName("vTodoDescription")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.VTodoId)
                    .IsRequired()
                    .HasColumnName("vTodoId")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.VTodoTitle)
                    .HasColumnName("vTodoTitle")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VUserId)
                    .IsRequired()
                    .HasColumnName("vUserId")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.VUser)
                    .WithMany(p => p.TodoTable)
                    .HasPrincipalKey(p => p.VUserId)
                    .HasForeignKey(d => d.VUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TodoTable_TodoTable");
            });

            modelBuilder.Entity<UserInfoTable>(entity =>
            {
                entity.HasKey(e => e.IAutoId)
                    .HasName("PK_Table");

                entity.HasIndex(e => e.VUserId)
                    .HasName("IX_Table")
                    .IsUnique();

                entity.Property(e => e.IAutoId).HasColumnName("iAutoId");

                entity.Property(e => e.BIsActive)
                    .HasColumnName("bIsActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DDateOfBirth)
                    .HasColumnName("dDateOfBirth")
                    .HasColumnType("date");

                entity.Property(e => e.VFullName)
                    .HasColumnName("vFullName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VPassword)
                    .HasColumnName("vPassword")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VUserId)
                    .IsRequired()
                    .HasColumnName("vUserId")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
