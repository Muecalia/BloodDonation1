using BloodDonation.Core.Enuns;

namespace BloodDonation.Core.Entities
{
    public class BloodStock : BaseEntity
    {
        public required BloodType BloodType { get; set; }
        public required FactorRh FactorRh { get; set; }
        public int QtdMl { get; set; }
    }
}
