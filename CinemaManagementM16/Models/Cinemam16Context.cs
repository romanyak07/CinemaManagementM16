using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagementM16.Models;

public partial class Cinemam16Context : DbContext
{
    public Cinemam16Context()
    {
    }

    public Cinemam16Context(DbContextOptions<Cinemam16Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Advertisement> Advertisements { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Resume> Resumes { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Sell> Sells { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=CINEMAM16;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ACTORS__3214EC275FFB2C2F");

            entity.ToTable("ACTORS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Nationality)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NATIONALITY");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SURNAME");
        });

        modelBuilder.Entity<Advertisement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ADVERTIS__3214EC2708D4C11D");

            entity.ToTable("ADVERTISEMENTS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Duration)
                .HasColumnType("datetime")
                .HasColumnName("DURATION");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("PRICE");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Clients");

            entity.ToTable("CLIENTS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
        });

        modelBuilder.Entity<Director>(entity =>
        {
            entity.HasKey(e => e.DirectorId).HasName("PK__DIRECTOR__71410F6B6FE366AD");

            entity.ToTable("DIRECTORS");

            entity.Property(e => e.DirectorId).HasColumnName("DIRECTOR_ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Nationality)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NATIONALITY");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SURNAME");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MOVIES__3214EC278605E7E4");

            entity.ToTable("MOVIES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DirectorId).HasColumnName("DIRECTOR_ID");
            entity.Property(e => e.Duration)
                .HasColumnType("datetime")
                .HasColumnName("DURATION");
            entity.Property(e => e.MovieImage)
                .HasColumnType("image")
                .HasColumnName("MOVIE_IMAGE");
            entity.Property(e => e.ResumeId).HasColumnName("RESUME_ID");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STATE");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TITLE");

            entity.HasOne(d => d.Director).WithMany(p => p.Movies)
                .HasForeignKey(d => d.DirectorId)
                .HasConstraintName("FK__MOVIES__DIRECTOR__60A75C0F");

            entity.HasOne(d => d.Resume).WithMany(p => p.Movies)
                .HasForeignKey(d => d.ResumeId)
                .HasConstraintName("FK__MOVIES__RESUME_I__619B8048");

            entity.HasMany(d => d.Actors).WithMany(p => p.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MoviesActor",
                    r => r.HasOne<Actor>().WithMany()
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__MOVIES_AC__ACTOR__628FA481"),
                    l => l.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__MOVIES_AC__MOVIE__6383C8BA"),
                    j =>
                    {
                        j.HasKey("MovieId", "ActorId").HasName("PK__MOVIES_A__372A8C5084871B96");
                        j.ToTable("MOVIES_ACTORS");
                        j.IndexerProperty<int>("MovieId").HasColumnName("MOVIE_ID");
                        j.IndexerProperty<int>("ActorId").HasColumnName("ACTOR_ID");
                    });
        });

        modelBuilder.Entity<Resume>(entity =>
        {
            entity.HasKey(e => e.ResumeId).HasName("PK__RESUMES__862E633CBD41A8C0");

            entity.ToTable("RESUMES");

            entity.Property(e => e.ResumeId).HasColumnName("RESUME_ID");
            entity.Property(e => e.Duration)
                .HasColumnType("datetime")
                .HasColumnName("DURATION");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ROOMS__3214EC271B900D02");

            entity.ToTable("ROOMS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Capacity).HasColumnName("CAPACITY");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Sell>(entity =>
        {
            entity.HasKey(e => e.SellId).HasName("PK__SELLS__ED9D75A91E67FF3A");

            entity.ToTable("SELLS");

            entity.Property(e => e.SellId).HasColumnName("SELL_ID");
            entity.Property(e => e.Date).HasColumnName("DATE");
            entity.Property(e => e.TicketId).HasColumnName("TICKET_ID");

            entity.HasOne(d => d.Ticket).WithMany(p => p.Sells)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK__VENDAS__BILHETEI__2C3393D0");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SESSIONS__3214EC27709BDB0E");

            entity.ToTable("SESSIONS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnName("DATE");
            entity.Property(e => e.Duration)
                .HasColumnType("datetime")
                .HasColumnName("DURATION");
            entity.Property(e => e.MovieId).HasColumnName("MOVIE_ID");
            entity.Property(e => e.RoomId).HasColumnName("ROOM_ID");
            entity.Property(e => e.StartTime).HasColumnName("START_TIME");
            entity.Property(e => e.State).HasColumnName("STATE");

            entity.HasOne(d => d.Movie).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK__SESSIONS__MOVIE___656C112C");

            entity.HasOne(d => d.Room).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__SESSIONS__ROOM_I__66603565");

            entity.HasMany(d => d.Ads).WithMany(p => p.Sessions)
                .UsingEntity<Dictionary<string, object>>(
                    "AdSession",
                    r => r.HasOne<Advertisement>().WithMany()
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__AD_SESSIO__AD_ID__5EBF139D"),
                    l => l.HasOne<Session>().WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__AD_SESSIO__SESSI__5FB337D6"),
                    j =>
                    {
                        j.HasKey("SessionId", "AdId").HasName("PK__AD_SESSI__5B4C296B5A7759E5");
                        j.ToTable("AD_SESSION");
                        j.IndexerProperty<int>("SessionId").HasColumnName("SESSION_ID");
                        j.IndexerProperty<int>("AdId").HasColumnName("AD_ID");
                    });
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__BILHETES__4CC0E0715655E0FB");

            entity.ToTable("TICKETS");

            entity.Property(e => e.TicketId).HasColumnName("TICKET_ID");
            entity.Property(e => e.ChairPlace).HasColumnName("CHAIR_PLACE");
            entity.Property(e => e.ClientId).HasColumnName("CLIENT_ID");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("PRICE");
            entity.Property(e => e.SessionId).HasColumnName("SESSION_ID");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TYPE");

            entity.HasOne(d => d.Client).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BILHETES_Clients");

            entity.HasOne(d => d.Session).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.SessionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BILHETES__SESSAO__276EDEB3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
