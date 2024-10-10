using System.ComponentModel.DataAnnotations;

namespace BloodDonation.Core.Entities
{
    public class Logradouro : BaseEntity
    {
        [MaxLength(50)]
        public required string Name { get; set; }
    }
}
