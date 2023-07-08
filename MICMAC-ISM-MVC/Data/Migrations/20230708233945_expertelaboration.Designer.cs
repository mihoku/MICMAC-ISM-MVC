﻿// <auto-generated />
using System;
using MICMAC_ISM_MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MICMACISMMVC.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230708233945_expertelaboration")]
    partial class expertelaboration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.ExpertElaborations", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Elaboration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExpertID")
                        .HasColumnType("int");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ExpertID");

                    b.ToTable("ExpertElaborations");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.ExpertOpinions", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ExpertID")
                        .HasColumnType("int");

                    b.Property<string>("InteractionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opinion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StructuralSelfInteractionID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ExpertID");

                    b.HasIndex("StructuralSelfInteractionID");

                    b.ToTable("ExpertOpinions");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.Experts", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Experts");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.Features", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.Property<string>("VariableName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.FinalReachabilityMatrix", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("AddingTransitivity")
                        .HasColumnType("bit");

                    b.Property<int>("FRM")
                        .HasColumnType("int");

                    b.Property<int>("FeatureAID")
                        .HasColumnType("int");

                    b.Property<int>("FeatureBID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FeatureAID");

                    b.ToTable("FinalReachabilityMatrix");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.InitialReachabilityMatrix", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("FeatureAID")
                        .HasColumnType("int");

                    b.Property<int>("FeatureBID")
                        .HasColumnType("int");

                    b.Property<int>("IRM")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FeatureAID");

                    b.ToTable("InitialReachabilityMatrix");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.MICMACCoordinate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Dependence")
                        .HasColumnType("int");

                    b.Property<int>("DrivingPower")
                        .HasColumnType("int");

                    b.Property<int>("FeatureID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FeatureID");

                    b.ToTable("MICMACCoordinate");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.Partition", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Iteration")
                        .HasColumnType("int");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Partition");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.PartitionAntecedentSet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("FeatureID")
                        .HasColumnType("int");

                    b.Property<int>("PartitionFeatureSetID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FeatureID");

                    b.HasIndex("PartitionFeatureSetID");

                    b.ToTable("PartitionAntecedentSet");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.PartitionFeatureSet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("FeatureID")
                        .HasColumnType("int");

                    b.Property<int>("PartitionID")
                        .HasColumnType("int");

                    b.Property<bool>("SelectedLevel")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("FeatureID");

                    b.HasIndex("PartitionID");

                    b.ToTable("PartitionFeatureSet");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.PartitionIntersectionSet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("FeatureID")
                        .HasColumnType("int");

                    b.Property<int>("PartitionFeatureSetID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FeatureID");

                    b.HasIndex("PartitionFeatureSetID");

                    b.ToTable("PartitionIntersectionSet");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.PartitionReachabilitySet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("FeatureID")
                        .HasColumnType("int");

                    b.Property<int>("PartitionFeatureSetID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FeatureID");

                    b.HasIndex("PartitionFeatureSetID");

                    b.ToTable("PartitionReachabilitySet");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.ProjectIdentitiy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ProjectIdentitiy");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.StructuralSelfInteraction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("FeatureAID")
                        .HasColumnType("int");

                    b.Property<int>("FeatureBID")
                        .HasColumnType("int");

                    b.Property<string>("InteractionType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("FeatureAID");

                    b.ToTable("StructuralSelfInteractions");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.TransitivityNotes", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("FRMID")
                        .HasColumnType("int");

                    b.Property<int>("FeatureAID")
                        .HasColumnType("int");

                    b.Property<int>("FeatureBID")
                        .HasColumnType("int");

                    b.Property<int>("FeatureCID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FRMID");

                    b.HasIndex("FeatureAID");

                    b.ToTable("TransitivityNotes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.ExpertElaborations", b =>
                {
                    b.HasOne("MICMAC_ISM_MVC.Models.Experts", "Expert")
                        .WithMany("ExpertElaborations")
                        .HasForeignKey("ExpertID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expert");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.ExpertOpinions", b =>
                {
                    b.HasOne("MICMAC_ISM_MVC.Models.Experts", "Expert")
                        .WithMany("ExpertOpinions")
                        .HasForeignKey("ExpertID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MICMAC_ISM_MVC.Models.StructuralSelfInteraction", "SSI")
                        .WithMany("ExpertOpinions")
                        .HasForeignKey("StructuralSelfInteractionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expert");

                    b.Navigation("SSI");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.Experts", b =>
                {
                    b.HasOne("MICMAC_ISM_MVC.Models.ProjectIdentitiy", "ProjectIdentity")
                        .WithMany("Experts")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectIdentity");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.Features", b =>
                {
                    b.HasOne("MICMAC_ISM_MVC.Models.ProjectIdentitiy", "ProjectIdentity")
                        .WithMany("Features")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectIdentity");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.FinalReachabilityMatrix", b =>
                {
                    b.HasOne("MICMAC_ISM_MVC.Models.Features", "FeatureA")
                        .WithMany("FRM")
                        .HasForeignKey("FeatureAID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FeatureA");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.InitialReachabilityMatrix", b =>
                {
                    b.HasOne("MICMAC_ISM_MVC.Models.Features", "FeatureA")
                        .WithMany("IRM")
                        .HasForeignKey("FeatureAID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FeatureA");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.MICMACCoordinate", b =>
                {
                    b.HasOne("MICMAC_ISM_MVC.Models.Features", "Feature")
                        .WithMany("Coordinate")
                        .HasForeignKey("FeatureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feature");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.Partition", b =>
                {
                    b.HasOne("MICMAC_ISM_MVC.Models.ProjectIdentitiy", "Project")
                        .WithMany("Partition")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.PartitionAntecedentSet", b =>
                {
                    b.HasOne("MICMAC_ISM_MVC.Models.Features", "Feature")
                        .WithMany("PartitionAntecedentSets")
                        .HasForeignKey("FeatureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MICMAC_ISM_MVC.Models.PartitionFeatureSet", "PartitionFeatureSet")
                        .WithMany("PartitionAntecedentSets")
                        .HasForeignKey("PartitionFeatureSetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feature");

                    b.Navigation("PartitionFeatureSet");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.PartitionFeatureSet", b =>
                {
                    b.HasOne("MICMAC_ISM_MVC.Models.Features", "Feature")
                        .WithMany("PartitionFeatureSets")
                        .HasForeignKey("FeatureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MICMAC_ISM_MVC.Models.Partition", "Partition")
                        .WithMany("PartitionFeatureSets")
                        .HasForeignKey("PartitionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feature");

                    b.Navigation("Partition");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.PartitionIntersectionSet", b =>
                {
                    b.HasOne("MICMAC_ISM_MVC.Models.Features", "Feature")
                        .WithMany("PartitionIntersectionSets")
                        .HasForeignKey("FeatureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MICMAC_ISM_MVC.Models.PartitionFeatureSet", "PartitionFeatureSet")
                        .WithMany("PartitionIntersectionSets")
                        .HasForeignKey("PartitionFeatureSetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feature");

                    b.Navigation("PartitionFeatureSet");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.PartitionReachabilitySet", b =>
                {
                    b.HasOne("MICMAC_ISM_MVC.Models.Features", "Feature")
                        .WithMany("PartitionReachabilitySets")
                        .HasForeignKey("FeatureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MICMAC_ISM_MVC.Models.PartitionFeatureSet", "PartitionFeatureSet")
                        .WithMany("PartitionReachabilitySets")
                        .HasForeignKey("PartitionFeatureSetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feature");

                    b.Navigation("PartitionFeatureSet");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.StructuralSelfInteraction", b =>
                {
                    b.HasOne("MICMAC_ISM_MVC.Models.Features", "FeatureA")
                        .WithMany("SSI")
                        .HasForeignKey("FeatureAID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FeatureA");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.TransitivityNotes", b =>
                {
                    b.HasOne("MICMAC_ISM_MVC.Models.FinalReachabilityMatrix", "FinalReachabilityMatrix")
                        .WithMany("TransitivityNotes")
                        .HasForeignKey("FRMID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MICMAC_ISM_MVC.Models.Features", "FeatureA")
                        .WithMany("TN")
                        .HasForeignKey("FeatureAID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FeatureA");

                    b.Navigation("FinalReachabilityMatrix");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.Experts", b =>
                {
                    b.Navigation("ExpertElaborations");

                    b.Navigation("ExpertOpinions");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.Features", b =>
                {
                    b.Navigation("Coordinate");

                    b.Navigation("FRM");

                    b.Navigation("IRM");

                    b.Navigation("PartitionAntecedentSets");

                    b.Navigation("PartitionFeatureSets");

                    b.Navigation("PartitionIntersectionSets");

                    b.Navigation("PartitionReachabilitySets");

                    b.Navigation("SSI");

                    b.Navigation("TN");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.FinalReachabilityMatrix", b =>
                {
                    b.Navigation("TransitivityNotes");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.Partition", b =>
                {
                    b.Navigation("PartitionFeatureSets");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.PartitionFeatureSet", b =>
                {
                    b.Navigation("PartitionAntecedentSets");

                    b.Navigation("PartitionIntersectionSets");

                    b.Navigation("PartitionReachabilitySets");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.ProjectIdentitiy", b =>
                {
                    b.Navigation("Experts");

                    b.Navigation("Features");

                    b.Navigation("Partition");
                });

            modelBuilder.Entity("MICMAC_ISM_MVC.Models.StructuralSelfInteraction", b =>
                {
                    b.Navigation("ExpertOpinions");
                });
#pragma warning restore 612, 618
        }
    }
}
