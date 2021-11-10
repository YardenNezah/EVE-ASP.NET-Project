﻿// <auto-generated />
using System;
using EVE.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EVE.Migrations
{
    [DbContext(typeof(EVEContext))]
    [Migration("20211110093558_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EVE.Controllers.Stores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("countrey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("houseNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("EVE.Models.About", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageSource")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("About");
                });

            modelBuilder.Entity("EVE.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Memberid")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Memberid");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("EVE.Models.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<int?>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("UserNameMemberID")
                        .HasColumnType("int");

                    b.HasKey("CommentID");

                    b.HasIndex("ProductID");

                    b.HasIndex("UserNameMemberID");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("EVE.Models.Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Memberid")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Memberid");

                    b.ToTable("Favorite");
                });

            modelBuilder.Entity("EVE.Models.Member", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Birthdate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberID");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("EVE.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("NumOfItem")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("EVE.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BackImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<int?>("FavoriteId")
                        .HasColumnType("int");

                    b.Property<string>("FrontImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageSource")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderDetailId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.HasIndex("CartId");

                    b.HasIndex("FavoriteId");

                    b.HasIndex("OrderDetailId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("EVE.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("EVE.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("ProductId");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("EVE.Models.Cart", b =>
                {
                    b.HasOne("EVE.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("Memberid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("EVE.Models.Comment", b =>
                {
                    b.HasOne("EVE.Models.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductID");

                    b.HasOne("EVE.Models.Member", "UserName")
                        .WithMany()
                        .HasForeignKey("UserNameMemberID");

                    b.Navigation("Product");

                    b.Navigation("UserName");
                });

            modelBuilder.Entity("EVE.Models.Favorite", b =>
                {
                    b.HasOne("EVE.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("Memberid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("EVE.Models.OrderDetail", b =>
                {
                    b.HasOne("EVE.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("EVE.Models.Product", b =>
                {
                    b.HasOne("EVE.Models.Cart", null)
                        .WithMany("Products")
                        .HasForeignKey("CartId");

                    b.HasOne("EVE.Models.Favorite", null)
                        .WithMany("Products")
                        .HasForeignKey("FavoriteId");

                    b.HasOne("EVE.Models.OrderDetail", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderDetailId");

                    b.HasOne("EVE.Models.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("EVE.Models.Rating", b =>
                {
                    b.HasOne("EVE.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EVE.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EVE.Models.Cart", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("EVE.Models.Favorite", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("EVE.Models.OrderDetail", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("EVE.Models.Product", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("EVE.Models.ProductType", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
