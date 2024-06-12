using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BACK_FLK.Models;

public partial class BdFlkContext : DbContext
{
    public BdFlkContext()
    {
    }

    public BdFlkContext(DbContextOptions<BdFlkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<AlumnoXcurso> AlumnoXcursos { get; set; }

    public virtual DbSet<AsignacionInspectore> AsignacionInspectores { get; set; }

    public virtual DbSet<Asignatura> Asignaturas { get; set; }

    public virtual DbSet<CertificadoCurso> CertificadoCursos { get; set; }

    public virtual DbSet<CertificadoInspeccion> CertificadoInspeccions { get; set; }

    public virtual DbSet<CertificadoresDisponible> CertificadoresDisponibles { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<DocenteDisponible> DocenteDisponibles { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Inspeccione> Inspecciones { get; set; }

    public virtual DbSet<InspectoresDisponible> InspectoresDisponibles { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<TipoDeVehiculo> TipoDeVehiculos { get; set; }

    public virtual DbSet<TipoDocumentoIdentidad> TipoDocumentoIdentidads { get; set; }

    public virtual DbSet<TipoInspeccion> TipoInspeccions { get; set; }

    public virtual DbSet<TiposServicio> TiposServicios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-JV065NN\\SQLEXPRESS;Database=BD_FLK;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.PkAlumno).HasName("PK__Alumno__A023A0AA1FF301DD");

            entity.ToTable("Alumno");

            entity.Property(e => e.PkAlumno)
                .ValueGeneratedNever()
                .HasColumnName("PK_Alumno");
            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.FechaNacimiento).HasColumnName("Fecha_Nacimiento");
            entity.Property(e => e.FkTipoDocumentoIdentidad).HasColumnName("FK_Tipo_Documento_Identidad");
            entity.Property(e => e.Nombres).HasMaxLength(100);
            entity.Property(e => e.NroDocumento)
                .HasMaxLength(50)
                .HasColumnName("Nro_Documento");

            entity.HasOne(d => d.FkTipoDocumentoIdentidadNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.FkTipoDocumentoIdentidad)
                .HasConstraintName("FK__Alumno__FK_Tipo___72C60C4A");
        });

        modelBuilder.Entity<AlumnoXcurso>(entity =>
        {
            entity.HasKey(e => e.PkParticipantesCursos).HasName("PK__AlumnoXC__D770F8AF5CB0CD8A");

            entity.ToTable("AlumnoXCurso");

            entity.Property(e => e.PkParticipantesCursos)
                .ValueGeneratedNever()
                .HasColumnName("PK_ParticipantesCursos");
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.FkCurso).HasColumnName("FK_Curso");
            entity.Property(e => e.PkAlumno).HasColumnName("PK_Alumno");

            entity.HasOne(d => d.FkCursoNavigation).WithMany(p => p.AlumnoXcursos)
                .HasForeignKey(d => d.FkCurso)
                .HasConstraintName("FK__AlumnoXCu__FK_Cu__6FE99F9F");

            entity.HasOne(d => d.PkAlumnoNavigation).WithMany(p => p.AlumnoXcursos)
                .HasForeignKey(d => d.PkAlumno)
                .HasConstraintName("FK__AlumnoXCu__PK_Al__70DDC3D8");
        });

        modelBuilder.Entity<AsignacionInspectore>(entity =>
        {
            entity.HasKey(e => e.PkAsignacionId).HasName("PK__Asignaci__05D5AD78D0A6F561");

            entity.Property(e => e.PkAsignacionId)
            .ValueGeneratedOnAdd()
                //.ValueGeneratedNever()
                .HasColumnName("PK_AsignacionID");
            entity.Property(e => e.FkInpectoresDisponibles).HasColumnName("FK_InpectoresDisponibles");

            entity.HasOne(d => d.FkInpectoresDisponiblesNavigation).WithMany(p => p.AsignacionInspectores)
                .HasForeignKey(d => d.FkInpectoresDisponibles)
                .HasConstraintName("FK_AsignacionInspectores_InpectoresDisponibles");
        });

        modelBuilder.Entity<Asignatura>(entity =>
        {
            entity.HasKey(e => e.PkAsignatura).HasName("PK__Asignatu__41C0F2156808A97A");

            entity.ToTable("Asignatura");

            entity.Property(e => e.PkAsignatura)
            .ValueGeneratedOnAdd()
               // .ValueGeneratedNever()
                .HasColumnName("PK_Asignatura");
            entity.Property(e => e.HoraPractica)
                .HasMaxLength(20)
                .HasColumnName("Hora_Practica");
            entity.Property(e => e.HorasTeoria)
                .HasMaxLength(20)
                .HasColumnName("Horas_Teoria");
            entity.Property(e => e.Nombre).HasMaxLength(20);
        });

        modelBuilder.Entity<CertificadoCurso>(entity =>
        {
            entity.HasKey(e => e.PkCertificadoCurso).HasName("PK__Certific__6292FEB019D09F18");

            entity.ToTable("CertificadoCurso");

            entity.Property(e => e.PkCertificadoCurso)
                .ValueGeneratedNever()
                .HasColumnName("PK_CertificadoCurso");
            entity.Property(e => e.FkCurso).HasColumnName("FK_Curso");

            entity.HasOne(d => d.FkCursoNavigation).WithMany(p => p.CertificadoCursos)
                .HasForeignKey(d => d.FkCurso)
                .HasConstraintName("FK__Certifica__FK_Cu__60A75C0F");
        });

        modelBuilder.Entity<CertificadoInspeccion>(entity =>
        {
            entity.HasKey(e => e.PkCertificadoInspeccion).HasName("PK__Certific__29F54AEE350A5816");

            entity.ToTable("CertificadoInspeccion");

            entity.Property(e => e.PkCertificadoInspeccion)
                .ValueGeneratedNever()
                .HasColumnName("PK_CertificadoInspeccion");
            entity.Property(e => e.FkInspeccion).HasColumnName("FK_Inspeccion");

            entity.Property(e => e.FechaHoraRegistroCertificacion)
              .HasColumnName("FechaHoraRegistroCertificacion");
          

            entity.HasOne(d => d.FkInspeccionNavigation).WithMany(p => p.CertificadoInspeccions)
                .HasForeignKey(d => d.FkInspeccion)
                .HasConstraintName("FK__Certifica__FK_In__619B8048");
        });

        modelBuilder.Entity<CertificadoresDisponible>(entity =>
        {
            entity.HasKey(e => e.PkCertificadoresDisponibles).HasName("PK__Certific__05FE58118FB4B578");

            entity.Property(e => e.PkCertificadoresDisponibles)
                .ValueGeneratedNever()
                .HasColumnName("PK_CertificadoresDisponibles");
            entity.Property(e => e.CertificadoPdf).HasColumnName("CertificadoPDF");
            entity.Property(e => e.FirmaYselloDigital).HasColumnName("FirmaYSelloDigital");
            entity.Property(e => e.FkTipoInspeccion).HasColumnName("FK_Tipo_Inspeccion");
            entity.Property(e => e.FkUsuario).HasColumnName("FK_Usuario");

            entity.HasOne(d => d.FkTipoInspeccionNavigation).WithMany(p => p.CertificadoresDisponibles)
                .HasForeignKey(d => d.FkTipoInspeccion)
                .HasConstraintName("FK__Certifica__FK_Ti__6383C8BA");

            entity.HasOne(d => d.FkUsuarioNavigation).WithMany(p => p.CertificadoresDisponibles)
                .HasForeignKey(d => d.FkUsuario)
                .HasConstraintName("FK__Certifica__FK_Us__628FA481");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.PkCurso).HasName("PK__Curso__D76122BE831F8426");

            entity.ToTable("Curso");

            entity.Property(e => e.PkCurso)
                .ValueGeneratedNever()
                .HasColumnName("PK_Curso");
            entity.Property(e => e.ComentariosIncidencias)
                .HasMaxLength(200)
                .HasColumnName("Comentarios_Incidencias");
            entity.Property(e => e.FinPractica).HasColumnType("datetime");
            entity.Property(e => e.FinTeoria).HasColumnType("datetime");
            entity.Property(e => e.FkAsinatura).HasColumnName("FK_Asinatura");
            entity.Property(e => e.FkDocentePractica).HasColumnName("FK_DocentePractica");
            entity.Property(e => e.FkDocenteTeoria).HasColumnName("FK_DocenteTeoria");
            entity.Property(e => e.FkServicio).HasColumnName("FK_Servicio");
            entity.Property(e => e.InicioPractica).HasColumnType("datetime");
            entity.Property(e => e.InicioTeoria).HasColumnType("datetime");
            entity.Property(e => e.UbicacionPractica).HasMaxLength(200);
            entity.Property(e => e.UbicacionTeoria).HasMaxLength(200);

            entity.HasOne(d => d.FkAsinaturaNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.FkAsinatura)
                .HasConstraintName("FK__Curso__FK_Asinat__6754599E");

            entity.HasOne(d => d.FkDocentePracticaNavigation).WithMany(p => p.CursoFkDocentePracticaNavigations)
                .HasForeignKey(d => d.FkDocentePractica)
                .HasConstraintName("FK__Curso__FK_Docent__66603565");

            entity.HasOne(d => d.FkDocenteTeoriaNavigation).WithMany(p => p.CursoFkDocenteTeoriaNavigations)
                .HasForeignKey(d => d.FkDocenteTeoria)
                .HasConstraintName("FK__Curso__FK_Docent__656C112C");

            entity.HasOne(d => d.FkServicioNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.FkServicio)
                .HasConstraintName("FK__Curso__FK_Servic__6477ECF3");
        });

        modelBuilder.Entity<DocenteDisponible>(entity =>
        {
            entity.HasKey(e => e.PkDocenteDisponibles).HasName("PK__DocenteD__FA090BDE4C1B597B");

            entity.Property(e => e.PkDocenteDisponibles)
                .ValueGeneratedNever()
                .HasColumnName("PK_DocenteDisponibles");
            entity.Property(e => e.CertificadoPdf).HasColumnName("CertificadoPDF");
            entity.Property(e => e.FkAsinaturaCertificada).HasColumnName("FK_AsinaturaCertificada");
            entity.Property(e => e.FkUsuario).HasColumnName("FK_Usuario");

            entity.HasOne(d => d.FkAsinaturaCertificadaNavigation).WithMany(p => p.DocenteDisponibles)
                .HasForeignKey(d => d.FkAsinaturaCertificada)
                .HasConstraintName("FK__DocenteDi__FK_As__693CA210");

            entity.HasOne(d => d.FkUsuarioNavigation).WithMany(p => p.DocenteDisponibles)
                .HasForeignKey(d => d.FkUsuario)
                .HasConstraintName("FK__DocenteDi__FK_Us__68487DD7");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.PkEmpresas).HasName("PK_Empresas");

            entity.Property(e => e.PkEmpresas)
            .ValueGeneratedOnAdd()
                //.ValueGeneratedNever()
                .HasColumnName("PK_Empresas");
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.RazonSocial).HasMaxLength(100);
            entity.Property(e => e.Ruc)
                .HasMaxLength(20)
                .HasColumnName("RUC");
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Inspeccione>(entity =>
        {
            entity.HasKey(e => e.PkInspeccion).HasName("PK__Inspecci__9B00EA3ACA803837"); 

            entity.Property(e => e.PkInspeccion)
            .ValueGeneratedOnAdd()
                //.ValueGeneratedNever()
                .HasColumnName("PK_Inspeccion");
            entity.Property(e => e.Estado).HasMaxLength(200);
            entity.Property(e => e.FkCertificadorAsignado).HasColumnName("FK_CertificadorAsignado");
            entity.Property(e => e.FkEmpresas).HasColumnName("FK_Empresas");
            entity.Property(e => e.FkInspectoresAsignados).HasColumnName("FK_Inspectores_Asignados");
            entity.Property(e => e.FkServicio).HasColumnName("FK_Servicio");
            entity.Property(e => e.FkTipoInspeccion).HasColumnName("FK_Tipo_Inspeccion");
            entity.Property(e => e.FkVehiculo).HasColumnName("FK_Vehiculo");
            entity.Property(e => e.FechaHoraInicio).HasColumnName("FechaHoraInicio");
            entity.Property(e => e.FechaHoraFinalizacion).HasColumnName("FechaHoraFinalizacion");
            entity.Property(e => e.FechaHoraEntrada).HasColumnName("FechaHoraEntrada");
            entity.Property(e => e.FechaHoraSalida).HasColumnName("FechaHoraSalida");
            entity.Property(e => e.FechaHoraRegistroInspeccion).HasColumnName("FechaHoraRegistroInspeccion");
            entity.Property(e => e.ObservacionesYRecomendaciones)
                .HasMaxLength(200)
                .HasColumnName("Observaciones_y_recomendaciones");
            entity.Property(e => e.Ubicacion).HasMaxLength(200);

            entity.HasOne(d => d.FkCertificadorAsignadoNavigation).WithMany(p => p.Inspecciones)
                .HasForeignKey(d => d.FkCertificadorAsignado)
                .HasConstraintName("FK_Inspecciones_CertificadorAsignado");

            entity.HasOne(d => d.FkEmpresasNavigation).WithMany(p => p.Inspecciones)
                .HasForeignKey(d => d.FkEmpresas)
                .HasConstraintName("FK_Inspecciones_Empresas");

            entity.HasOne(d => d.FkInspectoresAsignadosNavigation).WithMany(p => p.Inspecciones)
                .HasForeignKey(d => d.FkInspectoresAsignados)
                .HasConstraintName("FK_Inspecciones_Inspectores_Asignados");

            entity.HasOne(d => d.FkServicioNavigation).WithMany(p => p.Inspecciones)
                .HasForeignKey(d => d.FkServicio)
                .HasConstraintName("FK_Inspecciones_Servicio");

            entity.HasOne(d => d.FkTipoInspeccionNavigation).WithMany(p => p.Inspecciones)
                .HasForeignKey(d => d.FkTipoInspeccion)
                .HasConstraintName("FK_Inspecciones_TipoInspeccion");

            entity.HasOne(d => d.FkVehiculoNavigation).WithMany(p => p.Inspecciones)
                .HasForeignKey(d => d.FkVehiculo)
                .HasConstraintName("FK_Inspecciones_Vehiculo ");
        });

        modelBuilder.Entity<InspectoresDisponible>(entity =>
        {
            entity.HasKey(e => e.PkInpectoresDisponibles).HasName("PK__Inspecto__9AA0A4CB4505B63A");

            entity.Property(e => e.PkInpectoresDisponibles)
            .ValueGeneratedOnAdd()
                //.ValueGeneratedNever()
                .HasColumnName("PK_InpectoresDisponibles");
            entity.Property(e => e.CertificadoPdf).HasColumnName("CertificadoPDF");
            entity.Property(e => e.FirmaYselloDigital).HasColumnName("FirmaYSelloDigital");
            entity.Property(e => e.FkTipoInspeccion).HasColumnName("FK_Tipo_Inspeccion");
            entity.Property(e => e.FkUsuario).HasColumnName("FK_Usuario");

            entity.HasOne(d => d.FkTipoInspeccionNavigation).WithMany(p => p.InspectoresDisponibles)
                .HasForeignKey(d => d.FkTipoInspeccion)
                .HasConstraintName("FK_InspectoresDisponibles_TipoInspeccion");

            entity.HasOne(d => d.FkUsuarioNavigation).WithMany(p => p.InspectoresDisponibles)
                .HasForeignKey(d => d.FkUsuario)
                .HasConstraintName("FK_InspectoresDisponibles_Usuario");
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.PkPersonal).HasName("PK__Personal__1EA7C9C7BEC49E55");

            entity.ToTable("Personal");

            entity.Property(e => e.PkPersonal)
            .ValueGeneratedOnAdd()
                //.ValueGeneratedNever()
                .HasColumnName("PK_Personal");
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .HasColumnName("DNI");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FkUsuario).HasColumnName("FK_Usuario");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.FkUsuarioNavigation).WithMany(p => p.Personals)
                .HasForeignKey(d => d.FkUsuario)
                .HasConstraintName("FK_Personal_Usuario");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.PkRol).HasName("PK__Rol__15CAC98654E65AAF");

            entity.ToTable("Rol");

            entity.Property(e => e.PkRol)
              .ValueGeneratedOnAdd()
                //.ValueGeneratedNever()
                .HasColumnName("PK_Rol");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.PkServicio).HasName("PK__Servicio__4037BCBE3B51A025");

            entity.Property(e => e.PkServicio)
             .ValueGeneratedOnAdd()
            //.ValueGeneratedNever()
                .HasColumnName("PK_Servicio");
            entity.Property(e => e.FkTipoServicio).HasColumnName("FK_TipoServicio");

            entity.HasOne(d => d.FkTipoServicioNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.FkTipoServicio)
                .HasConstraintName("FK_Servicios_TipoServicio");
        });

        modelBuilder.Entity<TipoDeVehiculo>(entity =>
        {
            entity.HasKey(e => e.PkTipoDeVehiculos).HasName("PK__Tipo_de___436ED725AAFA4FF1");

            entity.ToTable("Tipo_de_Vehiculos");

            entity.Property(e => e.PkTipoDeVehiculos)
                 .ValueGeneratedOnAdd()
                //.ValueGeneratedNever()
                .HasColumnName("PK_tipo_de_vehiculos");
            entity.Property(e => e.CapacidadCarga).HasColumnName("capacidad_carga");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.TipoDeVehiculo1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Tipo_de_Vehiculo");
        });

        modelBuilder.Entity<TipoDocumentoIdentidad>(entity =>
        {
            entity.HasKey(e => e.PkTipoDocumentoIdentidad).HasName("PK__TipoDocu__13E624EB23132922");

            entity.ToTable("TipoDocumentoIdentidad");

            entity.Property(e => e.PkTipoDocumentoIdentidad)
                .ValueGeneratedNever()
                .HasColumnName("PK_Tipo_Documento_Identidad");
            entity.Property(e => e.Descripcion).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<TipoInspeccion>(entity =>
        {
            entity.HasKey(e => e.PkTipoInspeccion).HasName("PK__TipoInsp__389FF9C85A21A7EB");

            entity.ToTable("TipoInspeccion");

            entity.Property(e => e.PkTipoInspeccion)
                .ValueGeneratedNever()
                .HasColumnName("PK_Tipo_Inspeccion");
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.Titulo).HasMaxLength(50);
        });

        modelBuilder.Entity<TiposServicio>(entity =>
        {
            entity.HasKey(e => e.PkTiposServicio).HasName("PK__TiposSer__18DBF56EC830C574");

            entity.ToTable("TiposServicio");

            entity.Property(e => e.PkTiposServicio)
            .ValueGeneratedOnAdd()
                //.ValueGeneratedNever()
                .HasColumnName("PK_TiposServicio");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.PkUsuario).HasName("PK__Usuario__7D08CC9CA33E099B");

            entity.ToTable("Usuario");

            entity.Property(e => e.PkUsuario)
               .ValueGeneratedOnAdd()
                //.ValueGeneratedNever()
                .HasColumnName("PK_Usuario");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(100)
                .HasColumnName("contraseña");
            entity.Property(e => e.FkRol).HasColumnName("FK_Rol");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .HasColumnName("Nombre_usuario");

            entity.HasOne(d => d.FkRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.FkRol)
                .HasConstraintName("FK_Usuario_Rol");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.PkVehiculo).HasName("PK__Vehiculo__0032D3343ABEA981");

            entity.Property(e => e.PkVehiculo)
              .ValueGeneratedOnAdd()
                //.ValueGeneratedNever()
                .HasColumnName("PK_Vehiculo");
            entity.Property(e => e.Fabricante)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FkEmpresas).HasColumnName("FK_Empresas");
            entity.Property(e => e.FkTipoDeVehiculos).HasColumnName("FK_tipo_de_vehiculos");
            entity.Property(e => e.Marca)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NumeroSerie)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Numero_Serie");

            entity.HasOne(d => d.FkEmpresasNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.FkEmpresas)
                .HasConstraintName("FK_Vehiculos_Empresas");

            entity.HasOne(d => d.FkTipoDeVehiculosNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.FkTipoDeVehiculos)
                .HasConstraintName("FK_Vehiculos_tipo_de_vehiculos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
