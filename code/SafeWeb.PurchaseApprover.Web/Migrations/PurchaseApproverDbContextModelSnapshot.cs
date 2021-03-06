﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SafeWeb.PurchaseApprover.Infrastructure;

namespace SafeWeb.PurchaseApprover.Web.Migrations
{
    [DbContext(typeof(PurchaseApproverDbContext))]
    partial class PurchaseApproverDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SafeWeb.PurchaseApprover.Model.Administration.Configuration", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value");

                    b.HasKey("Name");

                    b.ToTable("Configurations");
                });

            modelBuilder.Entity("SafeWeb.PurchaseApprover.Model.Administration.ProfileRole", b =>
                {
                    b.Property<int>("Role");

                    b.Property<int>("UserProfileID");

                    b.HasKey("Role", "UserProfileID");

                    b.HasIndex("UserProfileID");

                    b.ToTable("ProfileRoles");
                });

            modelBuilder.Entity("SafeWeb.PurchaseApprover.Model.Administration.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DocumentNumber");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<int?>("UserProfileID");

                    b.Property<string>("Username");

                    b.HasKey("ID");

                    b.HasIndex("UserProfileID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SafeWeb.PurchaseApprover.Model.Administration.UserProfile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("SafeWeb.PurchaseApprover.Model.Proposals.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SafeWeb.PurchaseApprover.Model.Proposals.Proposal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<int?>("CategoryID");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.Property<int?>("SupplierID");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("SupplierID");

                    b.ToTable("Proposals");
                });

            modelBuilder.Entity("SafeWeb.PurchaseApprover.Model.Proposals.Supplier", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DocumentNumber");

                    b.Property<string>("Email");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.HasKey("ID");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("SafeWeb.PurchaseApprover.Model.Administration.ProfileRole", b =>
                {
                    b.HasOne("SafeWeb.PurchaseApprover.Model.Administration.UserProfile")
                        .WithMany("ProfileRoles")
                        .HasForeignKey("UserProfileID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SafeWeb.PurchaseApprover.Model.Administration.User", b =>
                {
                    b.HasOne("SafeWeb.PurchaseApprover.Model.Administration.UserProfile", "UserProfile")
                        .WithMany()
                        .HasForeignKey("UserProfileID");
                });

            modelBuilder.Entity("SafeWeb.PurchaseApprover.Model.Proposals.Proposal", b =>
                {
                    b.HasOne("SafeWeb.PurchaseApprover.Model.Proposals.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.HasOne("SafeWeb.PurchaseApprover.Model.Proposals.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierID");
                });
#pragma warning restore 612, 618
        }
    }
}
