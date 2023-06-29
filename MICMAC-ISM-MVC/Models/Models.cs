using System.ComponentModel.DataAnnotations.Schema;

namespace MICMAC_ISM_MVC.Models
{
    public class ProjectIdentitiy
    {
        public ProjectIdentitiy()
        {
            this.Experts = new HashSet<Experts>();
            this.Features = new HashSet<Features>();
            this.Partition=new HashSet<Partition>();
        }

        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Organization { get; set; }
        public virtual ICollection<Experts> Experts { get; set; }
        public virtual ICollection<Features> Features { get; set; }
        public virtual ICollection<Partition> Partition { get; set; }
    }

    public class Experts
    {
        public Experts()
        {
            this.ExpertOpinions = new HashSet<ExpertOpinions>();
        }
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Organization { get; set; }
        public int ProjectID { get; set; }
        [ForeignKey("ProjectID")]
        public virtual ProjectIdentitiy ProjectIdentity { get; set; }
        public virtual ICollection<ExpertOpinions> ExpertOpinions { get; set; }
    }

    public class Features
    {
        public Features()
        {
            this.SSI = new HashSet<StructuralSelfInteraction>();
            this.IRM = new HashSet<InitialReachabilityMatrix>();
            this.FRM = new HashSet<FinalReachabilityMatrix>();
            this.TN = new HashSet<TransitivityNotes>();
            this.Coordinate = new HashSet<MICMACCoordinate>();
            this.PartitionFeatureSets = new HashSet<PartitionFeatureSet>();
            this.PartitionReachabilitySets = new HashSet<PartitionReachabilitySet>();
            this.PartitionAntecedentSets= new HashSet<PartitionAntecedentSet>();
            this.PartitionIntersectionSets= new HashSet<PartitionIntersectionSet>();
        }
        public int ID { get; set; }
        public string? Code { get; set; }
        public string? VariableName { get; set; }
        public string? Description { get; set; }
        public int ProjectID { get; set; }
        [ForeignKey("ProjectID")]
        public virtual ProjectIdentitiy ProjectIdentity { get; set; }
        public virtual ICollection<StructuralSelfInteraction>? SSI { get; set; }
        public virtual ICollection<InitialReachabilityMatrix>? IRM { get; set; }
        public virtual ICollection<FinalReachabilityMatrix> FRM { get; set; }
        public virtual ICollection<TransitivityNotes> TN { get; set; }
        public virtual ICollection<MICMACCoordinate> Coordinate { get; set; }
        public virtual ICollection<PartitionFeatureSet> PartitionFeatureSets { get; set; }
        public virtual ICollection<PartitionReachabilitySet> PartitionReachabilitySets { get; set; }
        public virtual ICollection<PartitionAntecedentSet> PartitionAntecedentSets { get; set; }
        public virtual ICollection<PartitionIntersectionSet> PartitionIntersectionSets { get; set; }

    }

    public class StructuralSelfInteraction
    {
        public StructuralSelfInteraction()
        {
            this.ExpertOpinions = new HashSet<ExpertOpinions>();
        }
        public int ID { get; set; }
        public int FeatureAID { get; set; }
        public int FeatureBID { get; set; }
        public string? InteractionType { get; set; }
        [ForeignKey("FeatureAID")]
        public virtual Features? FeatureA { get; set; }
        //[ForeignKey("FeatureBID")]
        //[NotMapped]
        //public virtual Features FeatureB { get; set; }
        public virtual ICollection<ExpertOpinions>? ExpertOpinions { get; set; }
    }

    public class InitialReachabilityMatrix
    {
        public int ID { get; set; }
        public int FeatureAID { get; set; }
        public int FeatureBID { get; set; }
        public int IRM { get; set; }
        [ForeignKey("FeatureAID")]
        public virtual Features? FeatureA { get; set; }
        //[ForeignKey("FeatureBID")]
        //[NotMapped]
        //public virtual Features FeatureB { get; set; }
    }

    public class FinalReachabilityMatrix
    {
        public FinalReachabilityMatrix()
        {
            this.TransitivityNotes= new HashSet<TransitivityNotes>();
        }
        public int ID { get; set; }
        public int FeatureAID { get; set; }
        public int FeatureBID { get; set; }
        public int FRM { get; set; }
        public bool AddingTransitivity { get; set; }
        [ForeignKey("FeatureAID")]
        public virtual Features? FeatureA { get; set; }
        public virtual ICollection<TransitivityNotes> TransitivityNotes { get; set; }
        //[ForeignKey("FeatureBID")]
        //[NotMapped]
        //public virtual Features FeatureB { get; set; }
    }

    public class TransitivityNotes
    {
        public int ID { get; set; }
        public int FeatureAID { get; set; }
        public int FeatureBID { get; set; }
        public int FeatureCID { get; set; }
        public int FRMID { get; set; }
        [ForeignKey("FeatureAID")]
        public virtual Features? FeatureA { get; set; }
        [ForeignKey("FRMID")]
        public virtual FinalReachabilityMatrix FinalReachabilityMatrix { get; set; }
    }

    public class MICMACCoordinate
    {
        public int ID { get; set; }
        public int FeatureID { get; set; }
        public int Dependence { get; set; }
        public int DrivingPower { get; set; }
        [ForeignKey("FeatureID")]
        public virtual Features Feature { get; set; }
    }

    public class Partition
    {
        public Partition()
        {
            this.PartitionFeatureSets = new HashSet<PartitionFeatureSet>();
        }
        public int ID { get; set; }
        public int Iteration { get; set; }
        public int ProjectID { get; set; }
        [ForeignKey("ProjectID")]
        public virtual ProjectIdentitiy Project { get; set; }
        public virtual ICollection<PartitionFeatureSet> PartitionFeatureSets { get; set; }
    }

    public class PartitionFeatureSet
    {
        public PartitionFeatureSet()
        {
            this.PartitionReachabilitySets = new HashSet<PartitionReachabilitySet>();
            this.PartitionAntecedentSets = new HashSet<PartitionAntecedentSet>();
            this.PartitionIntersectionSets = new HashSet<PartitionIntersectionSet>();
        }
        public int ID { get; set; }
        public int PartitionID { get; set; }
        public int FeatureID { get; set; }
        public bool SelectedLevel { get; set; }
        [ForeignKey("FeatureID")]
        public virtual Features Feature { get; set; }
        [ForeignKey("PartitionID")]
        public virtual Partition Partition { get; set; }
        public virtual ICollection<PartitionReachabilitySet> PartitionReachabilitySets { get; set; }
        public virtual ICollection<PartitionAntecedentSet> PartitionAntecedentSets { get; set; }
        public virtual ICollection<PartitionIntersectionSet> PartitionIntersectionSets { get; set; }
    }

    public class PartitionReachabilitySet
    {
        public int ID { get; set; }
        public int FeatureID { get; set; }
        public int PartitionFeatureSetID { get; set; }
        [ForeignKey("FeatureID")]
        public virtual Features Feature { get; set; }
        [ForeignKey("PartitionFeatureSetID")]
        public virtual PartitionFeatureSet PartitionFeatureSet { get; set; }
    }

    public class PartitionAntecedentSet
    {
        public int ID { get; set; }
        public int FeatureID { get; set; }
        public int PartitionFeatureSetID { get; set; }
        [ForeignKey("FeatureID")]
        public virtual Features Feature { get; set; }
        [ForeignKey("PartitionFeatureSetID")]
        public virtual PartitionFeatureSet PartitionFeatureSet { get; set; }
    }

    public class PartitionIntersectionSet
    {
        public int ID { get; set; }
        public int FeatureID { get; set; }
        public int PartitionFeatureSetID { get; set; }
        [ForeignKey("FeatureID")]
        public virtual Features Feature { get; set; }
        [ForeignKey("PartitionFeatureSetID")]
        public virtual PartitionFeatureSet PartitionFeatureSet { get; set; }
    }

    public class ExpertOpinions
    {
        public int ID { get; set; }
        public int ExpertID { get; set; }
        public int StructuralSelfInteractionID { get; set; }
        public string InteractionType { get; set; }
        [ForeignKey("ExpertID")]
        public virtual Experts? Expert { get; set; }
        [ForeignKey("StructuralSelfInteractionID")]
        public virtual StructuralSelfInteraction? SSI { get; set; }
    }

}
