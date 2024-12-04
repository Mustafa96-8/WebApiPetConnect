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
    public interface IVaccinationsRepository
    {
        Task<IResult<Guid, Error>> Add(Vaccination vaccination, CancellationToken ct);

        Task<IResult<Vaccination, Error>> Get( Guid id,CancellationToken ct);
    }
}
