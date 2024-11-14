using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mineet.Models;

public partial class MineetDbContext : DbContext
{
    public MineetDbContext()
    {
    }

    public MineetDbContext(DbContextOptions<MineetDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Meeting> Meetings { get; set; }

    public virtual DbSet<MeetingItem> MeetingItems { get; set; }

    public virtual DbSet<MeetingItemHistory> MeetingItemHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=Vulth;Initial Catalog=MineetDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Meeting>(entity =>
        {
            entity.HasKey(e => e.MeetingId).HasName("PK__Meetings__C7B81B73A864D9CD");

            entity.Property(e => e.MeetingId).HasColumnName("meeting_Id");
            entity.Property(e => e.MeetingDate).HasColumnName("meeting_Date");
            entity.Property(e => e.MeetingName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("meeting_Name");
            entity.Property(e => e.MeetingType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("meeting_Type");
        });

        modelBuilder.Entity<MeetingItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__MeetingI__52030BA576E5822E");

            entity.ToTable("MeetingItem");

            entity.Property(e => e.ItemId).HasColumnName("item_Id");
            entity.Property(e => e.ItemDescription)
                .IsUnicode(false)
                .HasColumnName("item_Description");
            entity.Property(e => e.ItemMeetingDate).HasColumnName("itemMeeting_Date");
            entity.Property(e => e.ItemName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("item_Name");
            entity.Property(e => e.ItemPersonResponsible)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("item_PersonResponsible");
            entity.Property(e => e.ItemStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("item_Status");
            entity.Property(e => e.MeetingId).HasColumnName("meeting_Id");

            entity.HasOne(d => d.Meeting).WithMany(p => p.MeetingItems)
                .HasForeignKey(d => d.MeetingId)
                .HasConstraintName("FK__MeetingIt__meeti__5AEE82B9");
        });

        modelBuilder.Entity<MeetingItemHistory>(entity =>
        {
            entity.HasKey(e => e.ItemHistoryId).HasName("PK__MeetingI__BDC68F3610DF4143");

            entity.ToTable("MeetingItemHistory");

            entity.Property(e => e.ItemHistoryId).HasColumnName("item_HistoryId");
            entity.Property(e => e.ItemDescription)
                .IsUnicode(false)
                .HasColumnName("item_Description");
            entity.Property(e => e.ItemId).HasColumnName("item_Id");
            entity.Property(e => e.ItemMeetingDate).HasColumnName("itemMeeting_Date");
            entity.Property(e => e.ItemName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("item_Name");
            entity.Property(e => e.ItemPersonResponsible)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("item_PersonResponsible");
            entity.Property(e => e.ItemStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("item_Status");
            entity.Property(e => e.MeetingId).HasColumnName("meeting_Id");

            entity.HasOne(d => d.Item).WithMany(p => p.MeetingItemHistories)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__MeetingIt__item___5EBF139D");

            entity.HasOne(d => d.Meeting).WithMany(p => p.MeetingItemHistories)
                .HasForeignKey(d => d.MeetingId)
                .HasConstraintName("FK__MeetingIt__meeti__5DCAEF64");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
