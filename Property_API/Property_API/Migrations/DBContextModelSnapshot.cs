﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Property_API.Models;

namespace Property_API.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Property_API.Models.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("AddressLine3");

                    b.Property<string>("City");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description");

                    b.Property<bool>("IsSale");

                    b.Property<decimal>("Price");

                    b.Property<string>("PricePer");

                    b.Property<int>("PropertyTypeId");

                    b.Property<string>("ShortDescription");

                    b.Property<string>("Suburb");

                    b.HasKey("Id");

                    b.HasIndex("PropertyTypeId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Property_API.Models.PropertyImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImagePath");

                    b.Property<bool>("IsDefault");

                    b.Property<int>("PropertyId");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("PropertyImages");
                });

            modelBuilder.Entity("Property_API.Models.PropertyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("UsageType");

                    b.HasKey("Id");

                    b.ToTable("PropertyTypes");
                });

            modelBuilder.Entity("Property_API.Models.PropertyUserField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("PropertyId");

                    b.Property<int>("UserDefinedFieldId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.HasIndex("UserDefinedFieldId");

                    b.ToTable("PropertyUserFields");
                });

            modelBuilder.Entity("Property_API.Models.UserDefinedField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FieldName");

                    b.Property<string>("FieldType");

                    b.Property<int>("GroupId");

                    b.Property<int>("Rank");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("UserDefinedFields");
                });

            modelBuilder.Entity("Property_API.Models.UserDefinedGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("Rank");

                    b.Property<int>("UsageType");

                    b.HasKey("Id");

                    b.ToTable("UserDefinedGroups");
                });

            modelBuilder.Entity("Property_API.Models.Property", b =>
                {
                    b.HasOne("Property_API.Models.PropertyType", "PropertyType")
                        .WithMany()
                        .HasForeignKey("PropertyTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Property_API.Models.PropertyImage", b =>
                {
                    b.HasOne("Property_API.Models.Property", "Property")
                        .WithMany("PropertyImages")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Property_API.Models.PropertyUserField", b =>
                {
                    b.HasOne("Property_API.Models.Property", "Property")
                        .WithMany("PropertyUserFields")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Property_API.Models.UserDefinedField", "UserDefinedField")
                        .WithMany()
                        .HasForeignKey("UserDefinedFieldId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Property_API.Models.UserDefinedField", b =>
                {
                    b.HasOne("Property_API.Models.UserDefinedGroup", "Group")
                        .WithMany("Fields")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
