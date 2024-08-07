﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Xp_Sgpi.Infrastructure.Data;

#nullable disable

namespace Xp_Sgpi.Infrastructure.Migrations
{
    [DbContext(typeof(Xp_SgpiDbContext))]
    [Migration("20240617215344_IniteCreate")]
    partial class IniteCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Xp_Sgpi.Domain.Entities.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("account_id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.HasKey("AccountId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("accounts", (string)null);

                    b.HasData(
                        new
                        {
                            AccountId = new Guid("f291ec66-8d25-4533-912a-020f055e9b75"),
                            CreatedAt = new DateTime(2024, 6, 17, 18, 53, 43, 881, DateTimeKind.Local).AddTicks(8200),
                            Email = "joao@operacao.com",
                            Name = "João da Silva"
                        },
                        new
                        {
                            AccountId = new Guid("54a2a569-905a-4a72-b53c-c5e3344f8556"),
                            CreatedAt = new DateTime(2024, 6, 17, 18, 53, 43, 881, DateTimeKind.Local).AddTicks(8216),
                            Email = "maria@operacao.com",
                            Name = "Maria da Silva"
                        },
                        new
                        {
                            AccountId = new Guid("9f2c64ba-cdc5-4012-809d-e60478fc4fb6"),
                            CreatedAt = new DateTime(2024, 6, 17, 18, 53, 43, 881, DateTimeKind.Local).AddTicks(8230),
                            Email = "jose@operacao.com",
                            Name = "José da Silva"
                        });
                });

            modelBuilder.Entity("Xp_Sgpi.Domain.Entities.Asset", b =>
                {
                    b.Property<Guid>("AssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("asset_id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("expiration_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("price");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("symbol");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("types");

                    b.HasKey("AssetId");

                    b.HasIndex("Symbol")
                        .IsUnique();

                    b.ToTable("assets", (string)null);

                    b.HasData(
                        new
                        {
                            AssetId = new Guid("ce9455e5-cc39-4547-8221-c5d2aec32ac5"),
                            CreatedAt = new DateTime(2024, 6, 17, 18, 53, 43, 881, DateTimeKind.Local).AddTicks(8346),
                            ExpirationDate = new DateTime(2029, 6, 17, 18, 53, 43, 881, DateTimeKind.Local).AddTicks(8337),
                            Name = "Ação XYZ",
                            Price = 100m,
                            Quantity = 100,
                            Symbol = "ACXYZ",
                            Type = "Ações"
                        },
                        new
                        {
                            AssetId = new Guid("b5da053f-63af-4d83-bbf5-8f3532b37f70"),
                            CreatedAt = new DateTime(2024, 6, 17, 18, 53, 43, 881, DateTimeKind.Local).AddTicks(8350),
                            ExpirationDate = new DateTime(2027, 6, 17, 18, 53, 43, 881, DateTimeKind.Local).AddTicks(8349),
                            Name = "Tesouro Selic 2025",
                            Price = 50m,
                            Quantity = 200,
                            Symbol = "TS2025",
                            Type = "Tesouro Direto"
                        },
                        new
                        {
                            AssetId = new Guid("1c0efd94-3b9c-4926-b6ba-c9f301ed1782"),
                            CreatedAt = new DateTime(2024, 6, 17, 18, 53, 43, 881, DateTimeKind.Local).AddTicks(8354),
                            ExpirationDate = new DateTime(2027, 6, 17, 18, 53, 43, 881, DateTimeKind.Local).AddTicks(8354),
                            Name = "Fundo Imobiliário ABC",
                            Price = 150.00m,
                            Quantity = 50,
                            Symbol = "FIABC",
                            Type = "Fundos de Investimentos"
                        });
                });

            modelBuilder.Entity("Xp_Sgpi.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("customer_id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("amount");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.HasKey("CustomerId");

                    b.ToTable("customers", (string)null);

                    b.HasData(
                        new
                        {
                            CustomerId = new Guid("8bb1ab75-3060-492e-802d-368d577de3b0"),
                            Amount = 5000.00m,
                            CreatedAt = new DateTime(2024, 6, 17, 18, 53, 43, 881, DateTimeKind.Local).AddTicks(8383),
                            Email = "ricardo@customer.com",
                            Name = "Ricardo dos Santos"
                        },
                        new
                        {
                            CustomerId = new Guid("030270cf-a15f-4091-a46d-ce13fb552f7c"),
                            Amount = 10000.00m,
                            CreatedAt = new DateTime(2024, 6, 17, 18, 53, 43, 881, DateTimeKind.Local).AddTicks(8386),
                            Email = "ana@customer.com",
                            Name = "Ana dos Santos"
                        },
                        new
                        {
                            CustomerId = new Guid("df033a27-90f5-4276-9f93-9389a8078c31"),
                            Amount = 300.00m,
                            CreatedAt = new DateTime(2024, 6, 17, 18, 53, 43, 881, DateTimeKind.Local).AddTicks(8388),
                            Email = "felipe@customer.com",
                            Name = "Felipe dos Santos"
                        });
                });

            modelBuilder.Entity("Xp_Sgpi.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("order_id");

                    b.Property<Guid>("AssetId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("asset_id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("customer_id");

                    b.Property<bool>("IsBuyOrder")
                        .HasMaxLength(255)
                        .HasColumnType("bit")
                        .HasColumnName("is_buy_order");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("price");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("status");

                    b.HasKey("OrderId");

                    b.HasIndex("AssetId");

                    b.HasIndex("CustomerId");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("Xp_Sgpi.Domain.Entities.Transaction", b =>
                {
                    b.Property<Guid>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("transaction_id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("customer_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("price");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("type");

                    b.HasKey("TransactionId");

                    b.HasIndex("CustomerId");

                    b.ToTable("transactions", (string)null);
                });

            modelBuilder.Entity("Xp_Sgpi.Domain.Entities.Wallet", b =>
                {
                    b.Property<Guid>("WalletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("wallet_id");

                    b.Property<Guid>("AssetId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("asset_id");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("customer_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("WalletId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("AssetId", "CustomerId")
                        .IsUnique();

                    b.ToTable("wallets", (string)null);
                });

            modelBuilder.Entity("Xp_Sgpi.Domain.Entities.Order", b =>
                {
                    b.HasOne("Xp_Sgpi.Domain.Entities.Asset", "Asset")
                        .WithMany()
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Xp_Sgpi.Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Asset");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Xp_Sgpi.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("Xp_Sgpi.Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Xp_Sgpi.Domain.Entities.Wallet", b =>
                {
                    b.HasOne("Xp_Sgpi.Domain.Entities.Asset", "Asset")
                        .WithMany()
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Xp_Sgpi.Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Asset");

                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}
