using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Practice.Models;

public partial class PracticeContext : DbContext
{
    public PracticeContext()
    {
    }

    public PracticeContext(DbContextOptions<PracticeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bus> Buses { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=192.168.0.173;Port=5455;Username=postgres;Password=123;Database=Practice");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Buses_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SeatsCount).HasColumnName("Seats_count");
            entity.Property(e => e.Title).HasColumnType("character varying");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Drivers_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LicenceId).HasColumnName("Licence_id");
            entity.Property(e => e.Name).HasColumnType("character varying");
            entity.Property(e => e.PassportId).HasColumnName("Passport_id");
            entity.Property(e => e.Patronymic).HasColumnType("character varying");
            entity.Property(e => e.Surname).HasColumnType("character varying");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Employees_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login).HasColumnType("character varying");
            entity.Property(e => e.Name).HasColumnType("character varying");
            entity.Property(e => e.PassportId).HasColumnName("Passport_id");
            entity.Property(e => e.Password).HasColumnType("character varying");
            entity.Property(e => e.Patronymic).HasColumnType("character varying");
            entity.Property(e => e.RoleId).HasColumnName("Role_id");
            entity.Property(e => e.Surname).HasColumnType("character varying");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Employees_Role_id_fkey");
        });

        modelBuilder.Entity<Passenger>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Passengers_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login).HasColumnType("character varying");
            entity.Property(e => e.Name).HasColumnType("character varying");
            entity.Property(e => e.PassportId).HasColumnName("Passport_id");
            entity.Property(e => e.Password).HasColumnType("character varying");
            entity.Property(e => e.Patronymic).HasColumnType("character varying");
            entity.Property(e => e.Surname).HasColumnType("character varying");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Roles_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title).HasColumnType("character varying");
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Routes _pkey");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('\"Routes _id_seq\"'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.EndCity)
                .HasColumnType("character varying")
                .HasColumnName("End_city");
            entity.Property(e => e.StartCity)
                .HasColumnType("character varying")
                .HasColumnName("Start_city");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Statuses_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title).HasColumnType("character varying");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Tickets_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PassengerId).HasColumnName("Passenger_id");
            entity.Property(e => e.SeatNumber)
                .HasColumnType("character varying")
                .HasColumnName("Seat_number");
            entity.Property(e => e.TripId).HasColumnName("Trip_id");

            entity.HasOne(d => d.Passenger).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.PassengerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Tickets_Passenger_id_fkey");

            entity.HasOne(d => d.Trip).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Tickets_Trip_id_fkey");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Trips_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BusId).HasColumnName("Bus_id");
            entity.Property(e => e.DatetimeEnd)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Datetime_end");
            entity.Property(e => e.DatetimeStart)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Datetime_start");
            entity.Property(e => e.DriverId).HasColumnName("Driver_id");
            entity.Property(e => e.StatusId).HasColumnName("Status_id");

            entity.HasOne(d => d.Bus).WithMany(p => p.Trips)
                .HasForeignKey(d => d.BusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Trips_Bus_id_fkey");

            entity.HasOne(d => d.Driver).WithMany(p => p.Trips)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Trips_Driver_id_fkey");

            entity.HasOne(d => d.RouteNavigation).WithMany(p => p.Trips)
                .HasForeignKey(d => d.Route)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Trips_Route_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Trips)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Trips_Status_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
