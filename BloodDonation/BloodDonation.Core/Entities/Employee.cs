﻿using System.ComponentModel.DataAnnotations;

namespace BloodDonation.Core.Entities
{
    public class Employee : BaseEntity
    {
        public Employee() 
        {
            Donations = [];
        }

        [MaxLength(100)]
        public required string Name { get; set; }
        [MaxLength(50)]
        public required string Email { get; set; }
        [MaxLength(20)]
        public required string Phone { get; set; }
        [MaxLength(50)]
        public required string Password { get; set; }
        [MaxLength(30)]
        public required string Profile { get; set; }
        public List<Donation> Donations { get; set; }
    }
}
