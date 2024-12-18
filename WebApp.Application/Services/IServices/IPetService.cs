﻿using Contracts;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domain.Common;
using WebApp.Domain.Entities;

namespace WebApp.Application.Services.IServices
{
    public interface IPetService

    {
        Task<Result<Pet,Error>> Get(Guid id, CancellationToken ct);

        Task<List<Pet>> GetAll();

        Task Delete(Guid id);

        Task<Result<Guid, Error>> Create(CreatePetRequest request, CancellationToken ct);

    }
}
