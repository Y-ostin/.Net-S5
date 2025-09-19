using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using Teoria5.Models;

namespace Teoria5.Data;

public partial class AgenciaViajesContext : DbContext
{
    public AgenciaViajesContext()
    {
    }

    public AgenciaViajesContext(DbContextOptions<AgenciaViajesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Disponibilidad> Disponibilidads { get; set; }

    public virtual DbSet<EvaluacionesProveedore> EvaluacionesProveedores { get; set; }

    public virtual DbSet<IntentosAcceso> IntentosAccesos { get; set; }

    public virtual DbSet<Itinerario> Itinerarios { get; set; }

    public virtual DbSet<LogsSistema> LogsSistemas { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<PaqueteServicio> PaqueteServicios { get; set; }

    public virtual DbSet<PaquetesTuristico> PaquetesTuristicos { get; set; }

    public virtual DbSet<PersonalizacionesReserva> PersonalizacionesReservas { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=agenciadb;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.HasIndex(e => e.Dni, "dni").IsUnique();

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.Property(e => e.ClienteId)
                .HasColumnType("int(11)")
                .HasColumnName("cliente_id");
            entity.Property(e => e.Activo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Direccion)
                .HasColumnType("text")
                .HasColumnName("direccion");
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .HasColumnName("dni");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Disponibilidad>(entity =>
        {
            entity.HasKey(e => e.DisponibilidadId).HasName("PRIMARY");

            entity.ToTable("disponibilidad");

            entity.HasIndex(e => e.Fecha, "idx_disponibilidad_fecha");

            entity.HasIndex(e => new { e.PaqueteId, e.Fecha }, "paquete_id").IsUnique();

            entity.Property(e => e.DisponibilidadId)
                .HasColumnType("int(11)")
                .HasColumnName("disponibilidad_id");
            entity.Property(e => e.Bloqueado)
                .HasDefaultValueSql("'0'")
                .HasColumnName("bloqueado");
            entity.Property(e => e.CapacidadDisponible)
                .HasColumnType("int(11)")
                .HasColumnName("capacidad_disponible");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.PaqueteId)
                .HasColumnType("int(11)")
                .HasColumnName("paquete_id");
            entity.Property(e => e.PrecioEspecial)
                .HasPrecision(10, 2)
                .HasColumnName("precio_especial");

            entity.HasOne(d => d.Paquete).WithMany(p => p.Disponibilidads)
                .HasForeignKey(d => d.PaqueteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("disponibilidad_ibfk_1");
        });

        modelBuilder.Entity<EvaluacionesProveedore>(entity =>
        {
            entity.HasKey(e => e.EvaluacionId).HasName("PRIMARY");

            entity.ToTable("evaluaciones_proveedores");

            entity.HasIndex(e => e.ProveedorId, "proveedor_id");

            entity.HasIndex(e => e.ReservaId, "reserva_id");

            entity.Property(e => e.EvaluacionId)
                .HasColumnType("int(11)")
                .HasColumnName("evaluacion_id");
            entity.Property(e => e.Calificacion)
                .HasColumnType("int(11)")
                .HasColumnName("calificacion");
            entity.Property(e => e.Comentario)
                .HasColumnType("text")
                .HasColumnName("comentario");
            entity.Property(e => e.FechaEvaluacion)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("fecha_evaluacion");
            entity.Property(e => e.ProveedorId)
                .HasColumnType("int(11)")
                .HasColumnName("proveedor_id");
            entity.Property(e => e.ReservaId)
                .HasColumnType("int(11)")
                .HasColumnName("reserva_id");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.EvaluacionesProveedores)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("evaluaciones_proveedores_ibfk_2");

            entity.HasOne(d => d.Reserva).WithMany(p => p.EvaluacionesProveedores)
                .HasForeignKey(d => d.ReservaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("evaluaciones_proveedores_ibfk_1");
        });

        modelBuilder.Entity<IntentosAcceso>(entity =>
        {
            entity.HasKey(e => e.IntentoId).HasName("PRIMARY");

            entity.ToTable("intentos_acceso");

            entity.Property(e => e.IntentoId)
                .HasColumnType("int(11)")
                .HasColumnName("intento_id");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Exito)
                .HasDefaultValueSql("'0'")
                .HasColumnName("exito");
            entity.Property(e => e.FechaIntento)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("fecha_intento");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(45)
                .HasColumnName("ip_address");
        });

        modelBuilder.Entity<Itinerario>(entity =>
        {
            entity.HasKey(e => e.ItinerarioId).HasName("PRIMARY");

            entity.ToTable("itinerarios");

            entity.HasIndex(e => e.PaqueteId, "paquete_id");

            entity.Property(e => e.ItinerarioId)
                .HasColumnType("int(11)")
                .HasColumnName("itinerario_id");
            entity.Property(e => e.Actividades)
                .HasColumnType("text")
                .HasColumnName("actividades");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.DiaNumero)
                .HasColumnType("int(11)")
                .HasColumnName("dia_numero");
            entity.Property(e => e.PaqueteId)
                .HasColumnType("int(11)")
                .HasColumnName("paquete_id");
            entity.Property(e => e.Titulo)
                .HasMaxLength(200)
                .HasColumnName("titulo");

            entity.HasOne(d => d.Paquete).WithMany(p => p.Itinerarios)
                .HasForeignKey(d => d.PaqueteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("itinerarios_ibfk_1");
        });

        modelBuilder.Entity<LogsSistema>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PRIMARY");

            entity.ToTable("logs_sistema");

            entity.Property(e => e.LogId)
                .HasColumnType("int(11)")
                .HasColumnName("log_id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaOperacion)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("fecha_operacion");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(45)
                .HasColumnName("ip_address");
            entity.Property(e => e.RegistroId)
                .HasColumnType("int(11)")
                .HasColumnName("registro_id");
            entity.Property(e => e.TablaAfectada)
                .HasMaxLength(50)
                .HasColumnName("tabla_afectada");
            entity.Property(e => e.TipoOperacion)
                .HasMaxLength(50)
                .HasColumnName("tipo_operacion");
            entity.Property(e => e.UsuarioId)
                .HasColumnType("int(11)")
                .HasColumnName("usuario_id");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.PagoId).HasName("PRIMARY");

            entity.ToTable("pagos");

            entity.HasIndex(e => e.ReservaId, "reserva_id");

            entity.Property(e => e.PagoId)
                .HasColumnType("int(11)")
                .HasColumnName("pago_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'PENDIENTE'")
                .HasColumnType("enum('PENDIENTE','COMPLETADO','RECHAZADO','REEMBOLSADO')")
                .HasColumnName("estado");
            entity.Property(e => e.FechaPago)
                .HasColumnType("datetime")
                .HasColumnName("fecha_pago");
            entity.Property(e => e.MetodoPago)
                .HasColumnType("enum('TARJETA','TRANSFERENCIA','EFECTIVO')")
                .HasColumnName("metodo_pago");
            entity.Property(e => e.Monto)
                .HasPrecision(10, 2)
                .HasColumnName("monto");
            entity.Property(e => e.ReferenciaPago)
                .HasMaxLength(100)
                .HasColumnName("referencia_pago");
            entity.Property(e => e.ReservaId)
                .HasColumnType("int(11)")
                .HasColumnName("reserva_id");

            entity.HasOne(d => d.Reserva).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.ReservaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pagos_ibfk_1");
        });

        modelBuilder.Entity<PaqueteServicio>(entity =>
        {
            entity.HasKey(e => e.PaqueteServicioId).HasName("PRIMARY");

            entity.ToTable("paquete_servicios");

            entity.HasIndex(e => e.PaqueteId, "paquete_id");

            entity.HasIndex(e => e.ProveedorId, "proveedor_id");

            entity.Property(e => e.PaqueteServicioId)
                .HasColumnType("int(11)")
                .HasColumnName("paquete_servicio_id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaServicio).HasColumnName("fecha_servicio");
            entity.Property(e => e.Orden)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("orden");
            entity.Property(e => e.PaqueteId)
                .HasColumnType("int(11)")
                .HasColumnName("paquete_id");
            entity.Property(e => e.ProveedorId)
                .HasColumnType("int(11)")
                .HasColumnName("proveedor_id");
            entity.Property(e => e.TipoServicio)
                .HasColumnType("enum('TRANSPORTE','ALOJAMIENTO','ACTIVIDAD','ALIMENTACION','OTRO')")
                .HasColumnName("tipo_servicio");

            entity.HasOne(d => d.Paquete).WithMany(p => p.PaqueteServicios)
                .HasForeignKey(d => d.PaqueteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("paquete_servicios_ibfk_1");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.PaqueteServicios)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("paquete_servicios_ibfk_2");
        });

        modelBuilder.Entity<PaquetesTuristico>(entity =>
        {
            entity.HasKey(e => e.PaqueteId).HasName("PRIMARY");

            entity.ToTable("paquetes_turisticos");

            entity.HasIndex(e => new { e.Activo, e.DestinoPrincipal }, "idx_paquetes_activos");

            entity.Property(e => e.PaqueteId)
                .HasColumnType("int(11)")
                .HasColumnName("paquete_id");
            entity.Property(e => e.Activo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.CapacidadMaxima)
                .HasColumnType("int(11)")
                .HasColumnName("capacidad_maxima");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.DestinoPrincipal)
                .HasMaxLength(100)
                .HasColumnName("destino_principal");
            entity.Property(e => e.DuracionDias)
                .HasColumnType("int(11)")
                .HasColumnName("duracion_dias");
            entity.Property(e => e.FechaFinDisponibilidad).HasColumnName("fecha_fin_disponibilidad");
            entity.Property(e => e.FechaInicioDisponibilidad).HasColumnName("fecha_inicio_disponibilidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioBase)
                .HasPrecision(10, 2)
                .HasColumnName("precio_base");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<PersonalizacionesReserva>(entity =>
        {
            entity.HasKey(e => e.PersonalizacionId).HasName("PRIMARY");

            entity.ToTable("personalizaciones_reserva");

            entity.HasIndex(e => e.ReservaId, "reserva_id");

            entity.Property(e => e.PersonalizacionId)
                .HasColumnType("int(11)")
                .HasColumnName("personalizacion_id");
            entity.Property(e => e.CostoAdicional)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("costo_adicional");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.ReservaId)
                .HasColumnType("int(11)")
                .HasColumnName("reserva_id");
            entity.Property(e => e.Tipo)
                .HasColumnType("enum('ALIMENTACION','ALOJAMIENTO','ACTIVIDAD','TRANSPORTE','OTRO')")
                .HasColumnName("tipo");

            entity.HasOne(d => d.Reserva).WithMany(p => p.PersonalizacionesReservas)
                .HasForeignKey(d => d.ReservaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personalizaciones_reserva_ibfk_1");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.ProveedorId).HasName("PRIMARY");

            entity.ToTable("proveedores");

            entity.HasIndex(e => new { e.Tipo, e.Activo }, "idx_proveedores_tipo");

            entity.Property(e => e.ProveedorId)
                .HasColumnType("int(11)")
                .HasColumnName("proveedor_id");
            entity.Property(e => e.Activo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.CalificacionPromedio)
                .HasPrecision(3, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("calificacion_promedio");
            entity.Property(e => e.ContactoEmail)
                .HasMaxLength(150)
                .HasColumnName("contacto_email");
            entity.Property(e => e.ContactoNombre)
                .HasMaxLength(100)
                .HasColumnName("contacto_nombre");
            entity.Property(e => e.ContactoTelefono)
                .HasMaxLength(20)
                .HasColumnName("contacto_telefono");
            entity.Property(e => e.Direccion)
                .HasColumnType("text")
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasColumnType("enum('TRANSPORTE','ALOJAMIENTO','ACTIVIDAD','OTRO')")
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.ReservaId).HasName("PRIMARY");

            entity.ToTable("reservas");

            entity.HasIndex(e => e.ClienteId, "idx_reservas_cliente");

            entity.HasIndex(e => new { e.FechaInicioViaje, e.FechaFinViaje }, "idx_reservas_fechas");

            entity.HasIndex(e => e.PaqueteId, "idx_reservas_paquete");

            entity.Property(e => e.ReservaId)
                .HasColumnType("int(11)")
                .HasColumnName("reserva_id");
            entity.Property(e => e.ClienteId)
                .HasColumnType("int(11)")
                .HasColumnName("cliente_id");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'PENDIENTE'")
                .HasColumnType("enum('PENDIENTE','CONFIRMADA','CANCELADA','COMPLETADA')")
                .HasColumnName("estado");
            entity.Property(e => e.FechaFinViaje).HasColumnName("fecha_fin_viaje");
            entity.Property(e => e.FechaInicioViaje).HasColumnName("fecha_inicio_viaje");
            entity.Property(e => e.FechaReserva)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("fecha_reserva");
            entity.Property(e => e.NumeroPersonas)
                .HasColumnType("int(11)")
                .HasColumnName("numero_personas");
            entity.Property(e => e.Observaciones)
                .HasColumnType("text")
                .HasColumnName("observaciones");
            entity.Property(e => e.PaqueteId)
                .HasColumnType("int(11)")
                .HasColumnName("paquete_id");
            entity.Property(e => e.PrecioTotal)
                .HasPrecision(10, 2)
                .HasColumnName("precio_total");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reservas_ibfk_1");

            entity.HasOne(d => d.Paquete).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.PaqueteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reservas_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
