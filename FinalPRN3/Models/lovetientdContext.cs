using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FinalPRN3.Models
{
    public partial class lovetientdContext : DbContext
    {
        public lovetientdContext()
        {
        }

        public lovetientdContext(DbContextOptions<lovetientdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chatroom> Chatrooms { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Contactdetail> Contactdetails { get; set; } = null!;
        public virtual DbSet<Contactgroup> Contactgroups { get; set; } = null!;
        public virtual DbSet<Friend> Friends { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Profile> Profiles { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Useractivity> Useractivities { get; set; } = null!;
        public virtual DbSet<Usercontact> Usercontacts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=lovetientd;user=springstudent;password=springstudent", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Chatroom>(entity =>
            {
                entity.HasKey(e => e.ChatId)
                    .HasName("PRIMARY");

                entity.ToTable("chatroom");

                entity.HasIndex(e => e.User1, "user1fk_idx");

                entity.HasIndex(e => e.User2, "user2_idx");

                entity.Property(e => e.ChatId).HasColumnName("chat_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.User1).HasColumnName("user_1");

                entity.Property(e => e.User2).HasColumnName("user_2");

                entity.HasOne(d => d.User1Navigation)
                    .WithMany(p => p.ChatroomUser1Navigations)
                    .HasForeignKey(d => d.User1)
                    .HasConstraintName("user1fk");

                entity.HasOne(d => d.User2Navigation)
                    .WithMany(p => p.ChatroomUser2Navigations)
                    .HasForeignKey(d => d.User2)
                    .HasConstraintName("user2");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contact");

                entity.HasIndex(e => e.ContactName, "contact_name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(45)
                    .HasColumnName("contact_name");
            });

            modelBuilder.Entity<Contactdetail>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("PRIMARY");

                entity.ToTable("contactdetail");

                entity.HasIndex(e => e.Image, "image_idx");

                entity.Property(e => e.ContactId)
                    .ValueGeneratedNever()
                    .HasColumnName("contact_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(45)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .HasColumnName("email");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Phone)
                    .HasMaxLength(45)
                    .HasColumnName("phone");

                entity.HasOne(d => d.Contact)
                    .WithOne(p => p.Contactdetail)
                    .HasForeignKey<Contactdetail>(d => d.ContactId)
                    .HasConstraintName("contact_id");

                entity.HasOne(d => d.ImageNavigation)
                    .WithMany(p => p.Contactdetails)
                    .HasForeignKey(d => d.Image)
                    .HasConstraintName("image");
            });

            modelBuilder.Entity<Contactgroup>(entity =>
            {
                entity.HasKey(e => e.Groupid)
                    .HasName("PRIMARY");

                entity.ToTable("contactgroup");

                entity.HasIndex(e => e.Ownerid, "owner_idx");

                entity.Property(e => e.Groupid)
                    .ValueGeneratedNever()
                    .HasColumnName("groupid");

                entity.Property(e => e.Groupname)
                    .HasMaxLength(45)
                    .HasColumnName("groupname");

                entity.Property(e => e.Ownerid).HasColumnName("ownerid");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Contactgroups)
                    .HasForeignKey(d => d.Ownerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("owner");
            });

            modelBuilder.Entity<Friend>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.FriendId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("friends");

                entity.HasIndex(e => e.FriendId, "userfriendfk_idx");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.FriendId).HasColumnName("friend_id");

                entity.Property(e => e.RequestDate)
                    .HasColumnType("datetime")
                    .HasColumnName("request_date");

                entity.Property(e => e.Status)
                    .HasMaxLength(45)
                    .HasColumnName("status");

                entity.HasOne(d => d.FriendNavigation)
                    .WithMany(p => p.FriendFriendNavigations)
                    .HasForeignKey(d => d.FriendId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userfriendfk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FriendUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userfk");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("image");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Url)
                    .HasMaxLength(325)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("message");

                entity.HasIndex(e => e.RoomId, "room_idx");

                entity.HasIndex(e => e.UserId, "user_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Mess)
                    .HasMaxLength(45)
                    .HasColumnName("mess");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.Senddate)
                    .HasColumnType("datetime")
                    .HasColumnName("senddate");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("room");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usermess");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("profile");

                entity.HasIndex(e => e.Image, "image_idx");

                entity.HasIndex(e => e.UserId, "profile_idx");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.Dob).HasColumnName("dob");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Realname)
                    .HasMaxLength(45)
                    .HasColumnName("realname");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.ImageNavigation)
                    .WithMany(p => p.Profiles)
                    .HasForeignKey(d => d.Image)
                    .HasConstraintName("imageprofile");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Profiles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("profile");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Role, "role_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(45)
                    .HasColumnName("password");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Role)
                    .HasConstraintName("role");
            });

            modelBuilder.Entity<Useractivity>(entity =>
            {
                entity.ToTable("useractivity");

                entity.HasIndex(e => e.UserId, "useract_fk_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Action)
                    .HasMaxLength(45)
                    .HasColumnName("action");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Useractivities)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user");
            });

            modelBuilder.Entity<Usercontact>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ContactId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("usercontact");

                entity.HasIndex(e => e.ContactId, "contact_fk_idx");

                entity.HasIndex(e => e.GroupId, "group_idx");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.IsFavorite).HasColumnName("is_favorite");

                entity.Property(e => e.IsTrash).HasColumnName("is_trash");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Usercontacts)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("contact_fk");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Usercontacts)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("group");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Usercontacts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
