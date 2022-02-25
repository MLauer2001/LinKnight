﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Linknight.PL
{
    public partial class LinknightEntities : DbContext
    {
        public LinknightEntities()
        {
        }

        public LinknightEntities(DbContextOptions<LinknightEntities> options)
            : base(options)
        {
        }

        public virtual DbSet<tblArmor> tblArmors { get; set; }
        public virtual DbSet<tblCharacter> tblCharacters { get; set; }
        public virtual DbSet<tblHelm> tblHelms { get; set; }
        public virtual DbSet<tblLobby> tblLobbies { get; set; }
        public virtual DbSet<tblProfile> tblProfiles { get; set; }
        public virtual DbSet<tblVideo> tblVideos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Linknight.DB;Integrated Security=true");
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblArmor>(entity =>
            {
                entity.ToTable("tblArmor");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ArmorType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<tblCharacter>(entity =>
            {
                entity.ToTable("tblCharacter");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Armor)
                    .WithMany(p => p.tblCharacters)
                    .HasForeignKey(d => d.ArmorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tblCharacter_ArmorId");

                entity.HasOne(d => d.Helm)
                    .WithMany(p => p.tblCharacters)
                    .HasForeignKey(d => d.HelmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tblCharacter_HelmId");
            });

            modelBuilder.Entity<tblHelm>(entity =>
            {
                entity.ToTable("tblHelm");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.HelmType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<tblLobby>(entity =>
            {
                entity.ToTable("tblLobby");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LobbyKey)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<tblProfile>(entity =>
            {
                entity.ToTable("tblProfile");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.tblProfiles)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tblProfile_ColorId");

                entity.HasOne(d => d.Lobby)
                    .WithMany(p => p.tblProfiles)
                    .HasForeignKey(d => d.LobbyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tblProfile_LobbyId");
            });

            modelBuilder.Entity<tblVideo>(entity =>
            {
                entity.ToTable("tblVideo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.VideoURL)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lobby)
                    .WithMany(p => p.tblVideos)
                    .HasForeignKey(d => d.LobbyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tblVideo_LobbyId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
