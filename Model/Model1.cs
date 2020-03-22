namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=MainConnection")
        {
        }

        public virtual DbSet<DBBC> DBBCs { get; set; }
        public virtual DbSet<SelectedDBBC> SelectedDBBCs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DBBC>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<DBBC>()
                .Property(e => e.Chair)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FatherName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Credit)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.DBBCs)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.TeacherId)
                .WillCascadeOnDelete(false);
        }
    }
}
