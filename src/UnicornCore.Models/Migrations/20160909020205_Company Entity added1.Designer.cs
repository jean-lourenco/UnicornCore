using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using UnicornCore.Models.Infrastructure;

namespace UnicornCore.Models.Migrations
{
    [DbContext(typeof(UnicornDBContext))]
    [Migration("20160909020205_Company Entity added1")]
    partial class CompanyEntityadded1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UnicornCore.Models.DatabaseEntity.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("UnicornCore.Models.DatabaseEntity.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthday");

                    b.Property<long?>("CompanyId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("UnicornCore.Models.DatabaseEntity.Person", b =>
                {
                    b.HasOne("UnicornCore.Models.DatabaseEntity.Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId");
                });
        }
    }
}
