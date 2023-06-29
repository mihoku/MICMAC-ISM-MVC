namespace MICMAC_ISM_MVC.Models
{
    public class PartitioningOfLevels
    {
        public int Iteration { get; set; }
        public string Code { get; set; }
        public string VariableName { get; set; }
        public bool SelectedLevel { get; set; }
        public string ReachabilitySet { get; set; }
        public string AntecedentSet { get; set; }
        public string IntersectionSet { get; set; }
    }
}