using System.ComponentModel.DataAnnotations;

namespace BloodDonation.Core.Entities
{
    public class City : BaseEntity
    {
        [MaxLength(50)]
        public required string Name { get; set; }
        public required int IdState { get; set; }
        public required State State { get; set; }
    }
}
