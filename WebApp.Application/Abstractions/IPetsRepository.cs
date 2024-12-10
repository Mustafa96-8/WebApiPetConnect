using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domain.Common;
using WebApp.Domain.Entities;

namespace WebApp.Application.Abstractions
{
    public interface IPetsRepository
    {
        Task<Result<Guid,Error>> Add(Pet pet, CancellationToken ct);

        Task<Result<Pet, Error>> Get(Guid id, CancellationToken ct);
        Task<Result<IEnumerable<Pet>, Error>> GetAll(CancellationToken ct, string? includeProperties = null);
    }
}
