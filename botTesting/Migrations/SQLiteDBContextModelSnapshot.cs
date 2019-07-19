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

            modelBuilder.Entity("botTesting.NamingThings", b =>
                {
                    b.Property<ulong>("GuildId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IntroChannel");

                    b.HasKey("GuildId");

                    b.ToTable("namings");
                });

            modelBuilder.Entity("botTesting.SpecificCMDS", b =>
                {
                    b.Property<ulong>("GuildId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Joinmsgs");

                    b.Property<string>("Leavemsgs");

                    b.Property<string>("MsgPrefix");

                    b.Property<string>("NameOfBot");

                    b.HasKey("GuildId");

                    b.ToTable("Spclcmds");
                });

            modelBuilder.Entity("botTesting.Stone", b =>
                {
                    b.Property<ulong>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("Item1");

                    b.Property<int>("Item10");

                    b.Property<int>("Item2");

                    b.Property<int>("Item3");

                    b.Property<int>("Item4");

                    b.Property<int>("Item5");

                    b.Property<int>("Item6");

                    b.Property<int>("Item7");

                    b.Property<int>("Item8");

                    b.Property<int>("Item9");

                    b.Property<int>("Warnings");

                    b.HasKey("UserId");

                    b.ToTable("Stones");
                });

            modelBuilder.Entity("botTesting.Welcome", b =>
                {
                    b.Property<ulong>("userid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("age");

                    b.Property<string>("desc");

                    b.Property<string>("favcolor");

                    b.Property<string>("favfood");

                    b.Property<string>("location");

                    b.Property<string>("name");

                    b.Property<string>("plurals");

                    b.HasKey("userid");

                    b.ToTable("welcomes");
                });
#pragma warning restore 612, 618
        }
    }
}
