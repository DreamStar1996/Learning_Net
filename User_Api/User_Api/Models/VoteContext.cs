using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace User_Api.Models
{
    public partial class VoteContext : DbContext
    {
        public VoteContext()
        {
        }

        public VoteContext(DbContextOptions<VoteContext> options)
            : base(options)
        {
        }
        public virtual DbSet<VoteData> VoteData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user id=root;password=xingchen1996;database=user_test", x => x.ServerVersion("8.0.21-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VoteData>(entity =>
            {
                entity.ToTable("vote_data");

                entity.HasIndex(e => e.UserId)
                    .HasName("index_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnName("group_name")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.VoteId).HasColumnName("vote_id");

                entity.Property(e => e.VoteName)
                    .IsRequired()
                    .HasColumnName("vote_name")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
