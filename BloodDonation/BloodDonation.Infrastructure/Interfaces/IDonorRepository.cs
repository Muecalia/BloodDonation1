﻿using BloodDonation.Core.Entities;

namespace BloodDonation.Infrastructure.Interfaces
{
    public interface IDonorRepository
    {
        Task<Donor> Create(Donor donor, CancellationToken cancellationToken);
        Task Update(Donor donor, CancellationToken cancellationToken);
        Task Delete(Donor donor, CancellationToken cancellationToken);
        Task<bool> IsDonorExist(string name, CancellationToken cancellationToken);
        Task<Donor?> GetDonor(int Id, CancellationToken cancellationToken);
        Task<Donor?> GetDonorDetail(int Id, CancellationToken cancellationToken);
        Task<List<Donor>> GetAllDonors(CancellationToken cancellationToken);
    }
}
