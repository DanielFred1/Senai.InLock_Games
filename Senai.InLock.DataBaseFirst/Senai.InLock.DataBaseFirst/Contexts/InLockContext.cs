using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.InLock.DataBaseFirst.Domains
{
    public partial class InLockContext : DbContext
    {
        public InLockContext()
        {
        }

        public InLockContext(DbContextOptions<InLockContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estudios> Estudios { get; set; }
        public virtual DbSet<Jogos> Jogos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress01; Initial Catalog=InLock_Games_Manha; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudios>(entity =>
            {
                entity.HasKey(e => e.Estudioid);

                entity.ToTable("ESTUDIOS");

                entity.Property(e => e.Estudioid).HasColumnName("ESTUDIOID");

                entity.Property(e => e.Nomeestudio)
                    .IsRequired()
                    .HasColumnName("NOMEESTUDIO")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Jogos>(entity =>
            {
                entity.HasKey(e => e.Jogoid);

                entity.ToTable("JOGOS");

                entity.Property(e => e.Jogoid).HasColumnName("JOGOID");

                entity.Property(e => e.Datalancamento)
                    .HasColumnName("DATALANCAMENTO")
                    .HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("DESCRICAO")
                    .HasColumnType("text");

                entity.Property(e => e.Estudioid).HasColumnName("ESTUDIOID");

                entity.Property(e => e.Imagem)
                    .HasColumnName("IMAGEM")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nomejogo)
                    .IsRequired()
                    .HasColumnName("NOMEJOGO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .HasColumnName("VALOR")
                    .HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.Estudio)
                    .WithMany(p => p.Jogos)
                    .HasForeignKey(d => d.Estudioid)
                    .HasConstraintName("FK__JOGOS__ESTUDIOID__4D94879B");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.Usuarioid);

                entity.ToTable("USUARIOS");

                entity.Property(e => e.Usuarioid).HasColumnName("USUARIOID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tipousuario)
                    .IsRequired()
                    .HasColumnName("TIPOUSUARIO")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
