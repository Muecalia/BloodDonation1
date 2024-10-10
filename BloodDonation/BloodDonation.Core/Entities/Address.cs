using System.ComponentModel.DataAnnotations;

namespace BloodDonation.Core.Entities
{
    public class Address : BaseEntity
    {
        [MaxLength(50)]
        public required string CEP { get; set; }
        public required int IdCity { get; set; }
        public required City City { get; set; }
        public required int IdLogradouro { get; set; }
        public required Logradouro Logradouro { get; set; }
    }
}
