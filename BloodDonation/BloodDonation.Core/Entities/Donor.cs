using BloodDonation.Core.Enuns;
using System.ComponentModel.DataAnnotations;

namespace BloodDonation.Core.Entities
{
    public class Donor : BaseEntity
    {
        public Donor() : base()
        {
            Donations = [];
        }

        public required string Name { get; set; }
        public required DateTime DateOfBirth { get; set; }
        [EmailAddress, Required]
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required Gender Gender { get; set; }
        public required FactorRh FactorRh { get; set; }
        public required BloodType BloodType { get; set; }
        public double Weight { get; set; }
        public required int IdAddress { get; set; }
        public required Address Address { get; set; }
        public List<Donation> Donations { get; set; }
    }
}
