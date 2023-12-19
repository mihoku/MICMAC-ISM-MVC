using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MICMAC_ISM_MVC.Models;
using System.Reflection.Metadata;

namespace MICMAC_ISM_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MICMAC_ISM_MVC.Models.ProjectIdentitiy> ProjectIdentitiy { get; set; } = default!;
        public DbSet<MICMAC_ISM_MVC.Models.Features> Features { get; set; } = default!;
        public DbSet<MICMAC_ISM_MVC.Models.Experts> Experts { get; set; } = default!;
        public DbSet<MICMAC_ISM_MVC.Models.StructuralSelfInteraction> StructuralSelfInteractions { get; set; } = default!;
        public DbSet<MICMAC_ISM_MVC.Models.ExpertOpinions> ExpertOpinions { get; set; } = default!;
        public DbSet<MICMAC_ISM_MVC.Models.ExpertElaborations> ExpertElaborations { get; set; } = default!;
        public DbSet<MICMAC_ISM_MVC.Models.InitialReachabilityMatrix> InitialReachabilityMatrix { get; set; } = default!;
        public DbSet<MICMAC_ISM_MVC.Models.FinalReachabilityMatrix> FinalReachabilityMatrix { get; set; } = default!;
        public DbSet<MICMAC_ISM_MVC.Models.TransitivityNotes> TransitivityNotes { get; set; } = default!;
        public DbSet<MICMAC_ISM_MVC.Models.MICMACCoordinate> MICMACCoordinate { get; set; } = default!;
        public DbSet<MICMAC_ISM_MVC.Models.Partition> Partition { get; set; } = default!;
        public DbSet<MICMAC_ISM_MVC.Models.PartitionFeatureSet> PartitionFeatureSet { get; set; } = default!;
        public DbSet<MICMAC_ISM_MVC.Models.PartitionReachabilitySet> PartitionReachabilitySet { get; set; } = default!;
        public DbSet<MICMAC_ISM_MVC.Models.PartitionAntecedentSet> PartitionAntecedentSet { get; set; } = default!;
        public DbSet<MICMAC_ISM_MVC.Models.PartitionIntersectionSet> PartitionIntersectionSet { get; set; } = default!;
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //modelBuilder.Entity<Features>()
        //    .HasMany(e => e.SSI)
        //    .WithOne(e => e.FeatureA)
        //    .HasForeignKey(e => e.FeatureAID)
        //    .HasPrincipalKey(e => e.ID);

        //modelBuilder.Entity<Features>()
        //    .HasMany(e => e.SSI)
        //    .WithOne(e => e.FeatureB)
        //    .HasForeignKey(e => e.FeatureBID)
        //    .HasPrincipalKey(e => e.ID);
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Features>().HasMany(x => x.SSI).WithMany().HasForeignKey(y => y.FeatureAID);

        //    modelBuilder.Entity<Features>().HasMany(x => x.SSI).
        //}



    }
}