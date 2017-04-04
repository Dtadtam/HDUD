using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HDUD_WEBAPI.Models
{
    public partial class HDUDContext : DbContext
    {
        public virtual DbSet<Mention> Mention { get; set; }
        public virtual DbSet<MentionDescription> MentionDescription { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserFollowingId> UserFollowingId { get; set; }
        public virtual DbSet<UserMention> UserMention { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=supakit-pc;database=HDUD;user id=sa;password=123456;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mention>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MentionDescription>(entity =>
            {
                entity.HasKey(e => e.UserMentionId)
                    .HasName("PK_MentionDescription");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Feel).HasColumnType("nchar(10)");

                entity.HasOne(d => d.Mention)
                    .WithMany(p => p.MentionDescription)
                    .HasForeignKey(d => d.MentionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MentionDescription_Mention");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password).IsRequired();
            });

            modelBuilder.Entity<UserFollowingId>(entity =>
            {
                entity.HasKey(e => e.UserFollowingId1)
                    .HasName("PK_UserFollowingId");

                entity.Property(e => e.UserFollowingId1).HasColumnName("UserFollowingId");

                entity.HasOne(d => d.Mention)
                    .WithMany(p => p.UserFollowingId)
                    .HasForeignKey(d => d.MentionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserFollowingId_Mention");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserFollowingId)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserFollowingId_User");
            });

            modelBuilder.Entity<UserMention>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();

                entity.HasOne(d => d.Mention)
                    .WithMany(p => p.UserMention)
                    .HasForeignKey(d => d.MentionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserMention_Mention");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserMention)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserMention_User");
            });
        }
    }
}