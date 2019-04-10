﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using botTesting;

namespace botTesting.Migrations
{
    [DbContext(typeof(SQLiteDBContext))]
    partial class SQLiteDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("botTesting.Stone", b =>
                {
                    b.Property<ulong>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.HasKey("UserId");

                    b.ToTable("Stones");
                });
#pragma warning restore 612, 618
        }
    }
}