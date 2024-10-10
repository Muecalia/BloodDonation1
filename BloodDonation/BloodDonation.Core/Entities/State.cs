using System.ComponentModel.DataAnnotations;

namespace BloodDonation.Core.Entities
{
    public class State : BaseEntity
    {
        [MaxLength(50)]
        public required string Name { get; set; }
    }
}
