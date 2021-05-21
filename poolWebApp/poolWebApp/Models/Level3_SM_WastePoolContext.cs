using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace poolWebApp.Models
{
    public partial class Level3_SM_WastePoolContext : DbContext
    {
        public Level3_SM_WastePoolContext()
        {
        }

        public Level3_SM_WastePoolContext(DbContextOptions<Level3_SM_WastePoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DataType> DataTypes { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<EmailType> EmailTypes { get; set; }
        public virtual DbSet<Pool> Pools { get; set; }
        public virtual DbSet<PoolAction> PoolActions { get; set; }
        public virtual DbSet<PoolActionHistory> PoolActionHistories { get; set; }
        public virtual DbSet<PoolStatusEmail> PoolStatusEmails { get; set; }
        public virtual DbSet<PoolStatusEmailHistory> PoolStatusEmailHistories { get; set; }
        public virtual DbSet<PoolStatusProperty> PoolStatusProperties { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<StatusEmailType> StatusEmailTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=TR-157-NB;Database=Level3_SM_WastePool;User Id=sa; Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<DataType>(entity =>
            {
                entity.HasKey(e => e.IdDataType)
                    .HasName("PK__DataType__1E0FC06E1F52010E");

                entity.ToTable("DataType", "Pool");

                entity.Property(e => e.IdDataType).HasColumnName("idDataType");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.InsDateTime)
                    .HasPrecision(0)
                    .HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Type).HasMaxLength(100);
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.HasKey(e => e.IdEmail)
                    .HasName("PK__Email__DF537710C6198E46");

                entity.ToTable("Email", "Pool");

                entity.HasIndex(e => e.EmailAddress, "Unique_Email_1")
                    .IsUnique();

                entity.Property(e => e.IdEmail).HasColumnName("idEmail");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.InsDateTime).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.UpdDateTime).HasDefaultValueSql("(sysdatetimeoffset())");
            });

            modelBuilder.Entity<EmailType>(entity =>
            {
                entity.HasKey(e => e.IdEmailType)
                    .HasName("PK__EmailTyp__63251B6ED8093948");

                entity.ToTable("EmailType", "Pool");

                entity.Property(e => e.IdEmailType).HasColumnName("idEmailType");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.EmailBody).IsUnicode(false);

                entity.Property(e => e.EmailSubject)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.InsDateTime).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.UpdDateTime).HasDefaultValueSql("(sysdatetimeoffset())");
            });

            modelBuilder.Entity<Pool>(entity =>
            {
                entity.HasKey(e => e.IdPool)
                    .HasName("PK__Pool__BE0C21F58B2604F3");

                entity.ToTable("Pool", "Pool");

                entity.Property(e => e.IdPool).HasColumnName("idPool");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.IdStatus).HasColumnName("idStatus");

                entity.Property(e => e.Identification).HasMaxLength(50);

                entity.Property(e => e.InsDateTime).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.SentEmail).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdDateTime).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Pools)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("FK_Pool_Status_1");
            });

            modelBuilder.Entity<PoolAction>(entity =>
            {
                entity.HasKey(e => new { e.IdPool, e.IdStatus, e.IdProperty })
                    .HasName("PK__PoolActi__48791FBB9F190E93");

                entity.ToTable("PoolAction", "Pool");

                entity.Property(e => e.IdPool).HasColumnName("idPool");

                entity.Property(e => e.IdStatus).HasColumnName("idStatus");

                entity.Property(e => e.IdProperty).HasColumnName("idProperty");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.InsDateTime)
                    .HasPrecision(0)
                    .HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.UpdDateTime)
                    .HasPrecision(0)
                    .HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.Value).HasMaxLength(100);

                entity.Property(e => e.ValueDateTime).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.HasOne(d => d.IdPoolNavigation)
                    .WithMany(p => p.PoolActions)
                    .HasForeignKey(d => d.IdPool)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PoolAction_Pool_1");

                entity.HasOne(d => d.IdPropertyNavigation)
                    .WithMany(p => p.PoolActions)
                    .HasForeignKey(d => d.IdProperty)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PoolAction_Property_1");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.PoolActions)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PoolAction_Status_1");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.PoolActions)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("fk_PoolAction_User_1");
            });

            modelBuilder.Entity<PoolActionHistory>(entity =>
            {
                entity.HasKey(e => e.IdPoolActionHistory)
                    .HasName("PK__PoolActi__DB6AA75820F7CE4C");

                entity.ToTable("PoolActionHistory", "Pool");

                entity.Property(e => e.IdPoolActionHistory).HasColumnName("idPoolActionHistory");

                entity.Property(e => e.IdPool).HasColumnName("idPool");

                entity.Property(e => e.IdProperty).HasColumnName("idProperty");

                entity.Property(e => e.IdStatus).HasColumnName("idStatus");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Identification).HasMaxLength(50);

                entity.Property(e => e.InsDateTime).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.UpdDateTime).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.Value).HasMaxLength(100);

                entity.Property(e => e.ValueDateTime).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.HasOne(d => d.IdPoolNavigation)
                    .WithMany(p => p.PoolActionHistories)
                    .HasForeignKey(d => d.IdPool)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PoolActionHistory_Pool_1");

                entity.HasOne(d => d.IdPropertyNavigation)
                    .WithMany(p => p.PoolActionHistories)
                    .HasForeignKey(d => d.IdProperty)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PoolActionHistory_Property_1");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.PoolActionHistories)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PoolActionHistory_Status_1");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.PoolActionHistories)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("fk_PoolActionHistory_User_1");
            });

            modelBuilder.Entity<PoolStatusEmail>(entity =>
            {
                entity.HasKey(e => new { e.IdPool, e.IdStatusEmailType })
                    .HasName("PK__PoolStat__6C761D0A110D072B");

                entity.ToTable("PoolStatusEmail", "Pool");

                entity.Property(e => e.IdPool).HasColumnName("idPool");

                entity.Property(e => e.IdStatusEmailType).HasColumnName("idStatusEmailType");

                entity.HasOne(d => d.IdPoolNavigation)
                    .WithMany(p => p.PoolStatusEmails)
                    .HasForeignKey(d => d.IdPool)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PoolStatusEmail_Pool_1");

                entity.HasOne(d => d.IdStatusEmailTypeNavigation)
                    .WithMany(p => p.PoolStatusEmails)
                    .HasForeignKey(d => d.IdStatusEmailType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PoolStatusEmail_StatusEmailType_1");
            });

            modelBuilder.Entity<PoolStatusEmailHistory>(entity =>
            {
                entity.HasKey(e => e.IdPoolStatusEmailHistory)
                    .HasName("PK__PoolStat__A5E7325D146298F1");

                entity.ToTable("PoolStatusEmailHistory", "Pool");

                entity.Property(e => e.IdPoolStatusEmailHistory).HasColumnName("idPoolStatusEmailHistory");

                entity.Property(e => e.IdPool).HasColumnName("idPool");

                entity.Property(e => e.IdStatusEmailType).HasColumnName("idStatusEmailType");

                entity.HasOne(d => d.IdPoolNavigation)
                    .WithMany(p => p.PoolStatusEmailHistories)
                    .HasForeignKey(d => d.IdPool)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PoolStatusEmailHistory_Pool_1");

                entity.HasOne(d => d.IdStatusEmailTypeNavigation)
                    .WithMany(p => p.PoolStatusEmailHistories)
                    .HasForeignKey(d => d.IdStatusEmailType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PoolStatusEmailHistory_StatusEmailType_1");
            });

            modelBuilder.Entity<PoolStatusProperty>(entity =>
            {
                entity.HasKey(e => new { e.IdStatus, e.IdPool, e.IdProperty })
                    .HasName("PK__PoolStat__EC1FA5D21E0BE35D");

                entity.ToTable("PoolStatusProperties", "Pool");

                entity.Property(e => e.IdStatus).HasColumnName("idStatus");

                entity.Property(e => e.IdPool).HasColumnName("idPool");

                entity.Property(e => e.IdProperty).HasColumnName("idProperty");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.InsDateTime).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.IsCountDown).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdDateTime).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.Value).HasMaxLength(100);

                entity.HasOne(d => d.IdPoolNavigation)
                    .WithMany(p => p.PoolStatusProperties)
                    .HasForeignKey(d => d.IdPool)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PoolStatusProperties_Pool_1");

                entity.HasOne(d => d.IdPropertyNavigation)
                    .WithMany(p => p.PoolStatusProperties)
                    .HasForeignKey(d => d.IdProperty)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PoolStatusProperties_Property_1");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.PoolStatusProperties)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PoolStatusProperties_Status_1");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasKey(e => e.IdProperty)
                    .HasName("PK__Property__6C08B9A7DD2D3C95");

                entity.ToTable("Property", "Pool");

                entity.Property(e => e.IdProperty).HasColumnName("idProperty");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.IdDataType).HasColumnName("idDataType");

                entity.Property(e => e.InsDateTime).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdDateTime).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.HasOne(d => d.IdDataTypeNavigation)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.IdDataType)
                    .HasConstraintName("fk_Property_DataType_1");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("PK__Status__01936F74D36AF3D7");

                entity.ToTable("Status", "Pool");

                entity.Property(e => e.IdStatus).HasColumnName("idStatus");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Color).HasMaxLength(255);

                entity.Property(e => e.EmailAlert).HasDefaultValueSql("((0))");

                entity.Property(e => e.InsDateTime)
                    .HasPrecision(0)
                    .HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdDateTime)
                    .HasPrecision(0)
                    .HasDefaultValueSql("(sysdatetimeoffset())");
            });

            modelBuilder.Entity<StatusEmailType>(entity =>
            {
                entity.HasKey(e => e.IdStatusEmailType)
                    .HasName("PK__StatusEm__27A3CFFC0F377AD9");

                entity.ToTable("StatusEmailType", "Pool");

                entity.Property(e => e.IdStatusEmailType).HasColumnName("idStatusEmailType");

                entity.Property(e => e.IdEmailType).HasColumnName("idEmailType");

                entity.Property(e => e.IdProperty).HasColumnName("idProperty");

                entity.Property(e => e.IdStatus).HasColumnName("idStatus");

                entity.Property(e => e.IdStatusNextPool).HasColumnName("idStatusNextPool");

                entity.Property(e => e.Interval).HasColumnName("interval");

                entity.HasOne(d => d.IdEmailTypeNavigation)
                    .WithMany(p => p.StatusEmailTypes)
                    .HasForeignKey(d => d.IdEmailType)
                    .HasConstraintName("fk_StatusEmailType_EmailType_1");

                entity.HasOne(d => d.IdPropertyNavigation)
                    .WithMany(p => p.StatusEmailTypes)
                    .HasForeignKey(d => d.IdProperty)
                    .HasConstraintName("fk_StatusEmailType_Property_1");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.StatusEmailTypeIdStatusNavigations)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("fk_Email_Status_Status_1");

                entity.HasOne(d => d.IdStatusNextPoolNavigation)
                    .WithMany(p => p.StatusEmailTypeIdStatusNextPoolNavigations)
                    .HasForeignKey(d => d.IdStatusNextPool)
                    .HasConstraintName("fk_StatusEmailType_Status_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__User__3717C982836C8DBC");

                entity.ToTable("User", "Pool");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Identification).HasMaxLength(50);

                entity.Property(e => e.InsDateTime).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.IsAdmin).HasDefaultValueSql("((0))");

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.UpdDateTime).HasDefaultValueSql("(sysdatetimeoffset())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
