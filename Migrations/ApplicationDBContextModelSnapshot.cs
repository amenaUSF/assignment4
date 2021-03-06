﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using assignment4.data_access_folder;

namespace assignment4.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("assignment4.Models.safetyratings", b =>
                {
                    b.Property<int>("veh_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ComplaintsCount");

                    b.Property<string>("FrontCrashDriversideRating");

                    b.Property<string>("FrontCrashPassengersideRating");

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.Property<int>("ModelYear");

                    b.Property<string>("OverallFrontCrashRating");

                    b.Property<string>("OverallRating");

                    b.Property<string>("OverallSideCrashRating");

                    b.Property<string>("RecallsCount");

                    b.Property<string>("RolloverPossibility");

                    b.Property<string>("RolloverRating");

                    b.Property<string>("SideCrashDriversideRating");

                    b.Property<string>("SideCrashPassengersideRating");

                    b.Property<string>("SidePoleCrashRating");

                    b.Property<string>("VehicleDescription");

                    b.Property<int>("VehicleId");

                    b.Property<int>("make_id");

                    b.Property<int>("model_id");

                    b.Property<int>("year_id");

                    b.HasKey("veh_id");

                    b.HasIndex("make_id");

                    b.HasIndex("model_id");

                    b.HasIndex("year_id");

                    b.ToTable("safety");
                });

            modelBuilder.Entity("assignment4.Models.v_id", b =>
                {
                    b.Property<int>("veh_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("VehicleDescription");

                    b.Property<int>("VehicleId");

                    b.HasKey("veh_id");

                    b.ToTable("ids");
                });

            modelBuilder.Entity("assignment4.Models.v_make", b =>
                {
                    b.Property<int>("make_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Make");

                    b.Property<int>("ModelYear");

                    b.HasKey("make_id");

                    b.ToTable("makes");
                });

            modelBuilder.Entity("assignment4.Models.v_model", b =>
                {
                    b.Property<int>("model_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.Property<int>("ModelYear");

                    b.HasKey("model_id");

                    b.ToTable("models");
                });

            modelBuilder.Entity("assignment4.Models.v_year", b =>
                {
                    b.Property<int>("year_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ModelYear");

                    b.HasKey("year_id");

                    b.ToTable("years");
                });

            modelBuilder.Entity("assignment4.Models.vehicle_makes", b =>
                {
                    b.Property<int>("make_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Make");

                    b.HasKey("make_id");

                    b.ToTable("Vehicle_Makes");
                });

            modelBuilder.Entity("assignment4.Models.vehicle_models", b =>
                {
                    b.Property<int>("model_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Model");

                    b.HasKey("model_id");

                    b.ToTable("Vehicle_Models");
                });

            modelBuilder.Entity("assignment4.Models.vehicle_safetyratings", b =>
                {
                    b.Property<int>("veh_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ComplaintsCount");

                    b.Property<string>("FrontCrashDriversideRating");

                    b.Property<string>("FrontCrashPassengersideRating");

                    b.Property<string>("OverallFrontCrashRating");

                    b.Property<string>("OverallRating");

                    b.Property<string>("OverallSideCrashRating");

                    b.Property<string>("RecallsCount");

                    b.Property<string>("RolloverPossibility");

                    b.Property<string>("RolloverRating");

                    b.Property<string>("SideCrashDriversideRating");

                    b.Property<string>("SideCrashPassengersideRating");

                    b.Property<string>("SidePoleCrashRating");

                    b.Property<string>("VehicleDescription");

                    b.Property<int>("VehicleId");

                    b.Property<int>("make_id");

                    b.Property<int>("model_id");

                    b.Property<int>("year_id");

                    b.HasKey("veh_id");

                    b.HasIndex("make_id");

                    b.HasIndex("model_id");

                    b.HasIndex("year_id");

                    b.ToTable("Vehicle_Safetyratings");
                });

            modelBuilder.Entity("assignment4.Models.vehicle_years", b =>
                {
                    b.Property<int>("year_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ModelYear");

                    b.HasKey("year_id");

                    b.ToTable("Vehicle_Years");
                });

            modelBuilder.Entity("assignment4.Models.usercomments", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("name");
                b.Property<string>("email");
                b.Property<string>("comments");

                b.HasKey("Id");

                b.ToTable("UserReviews");
            });


            modelBuilder.Entity("assignment4.Models.safetyratings", b =>
                {
                    b.HasOne("assignment4.Models.v_make", "makes")
                        .WithMany("safetyrating")
                        .HasForeignKey("make_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("assignment4.Models.v_model", "models")
                        .WithMany("safetyrating")
                        .HasForeignKey("model_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("assignment4.Models.v_year", "years")
                        .WithMany("safetyrating")
                        .HasForeignKey("year_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("assignment4.Models.vehicle_safetyratings", b =>
                {
                    b.HasOne("assignment4.Models.vehicle_makes", "makes")
                        .WithMany()
                        .HasForeignKey("make_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("assignment4.Models.vehicle_models", "models")
                        .WithMany()
                        .HasForeignKey("model_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("assignment4.Models.vehicle_years", "years")
                        .WithMany()
                        .HasForeignKey("year_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
