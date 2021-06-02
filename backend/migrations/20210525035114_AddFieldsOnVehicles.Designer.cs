﻿// <auto-generated />
using System;
using Backend;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace backend.migrations {
	[DbContext(typeof(FrotaContext))]
	[Migration("20210525035114_AddFieldsOnVehicles")]
	partial class AddFieldsOnVehicles {
		protected override void BuildTargetModel(ModelBuilder modelBuilder) {
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("Relational:MaxIdentifierLength", 128)
				.HasAnnotation("ProductVersion", "5.0.6")
				.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

			modelBuilder.Entity("Backend.Marca", b => {
				b.Property<int>("id")
					.ValueGeneratedOnAdd()
					.HasColumnType("int")
					.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

				b.Property<int>("idPais").HasColumnType("int");

				b.Property<string>("nome").HasColumnType("nvarchar(max)");

				b.HasKey("id");

				b.HasIndex("idPais");

				b.ToTable("marks");
			});

			modelBuilder.Entity("Backend.Pais", b => {
				b.Property<int>("id")
					.ValueGeneratedOnAdd()
					.HasColumnType("int")
					.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

				b.Property<string>("nome").HasColumnType("nvarchar(max)");

				b.HasKey("id");

				b.ToTable("countries");
			});

			modelBuilder.Entity("Backend.Veiculo", b => {
				b.Property<int>("id")
					.ValueGeneratedOnAdd()
					.HasColumnType("int")
					.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

				b.Property<int?>("IdMarca").HasColumnType("int");

				b.Property<string>("ano").HasColumnType("nvarchar(max)");

				b.Property<string>("cor").HasColumnType("nvarchar(max)");

				b.Property<int>("idMarca").HasColumnType("int");

				b.Property<string>("nome").HasColumnType("nvarchar(max)");

				b.Property<string>("placa")
					.HasMaxLength(50)
					.HasColumnType("nvarchar(50)");

				b.HasKey("id");

				b.HasIndex("IdMarca");

				b.ToTable("vehicles");
			});

			modelBuilder.Entity("Backend.Marca", b => {
				b.HasOne("Backend.Pais", "pais")
					.WithMany("marcas")
					.HasForeignKey("idPais")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();

				b.Navigation("pais");
			});

			modelBuilder.Entity("Backend.Veiculo", b => {
				b.HasOne("Backend.Marca", "marca")
					.WithMany("veiculos")
					.HasForeignKey("IdMarca");

				b.Navigation("marca");
			});

			modelBuilder.Entity("Backend.Marca", b => { b.Navigation("veiculos"); });

			modelBuilder.Entity("Backend.Pais", b => { b.Navigation("marcas"); });
#pragma warning restore 612, 618
		}
	}
}
