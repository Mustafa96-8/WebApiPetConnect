﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domain.Entities;
using WebApp.Infrastracture;

namespace WebApp.Application.Services
{
    public class VaccinationService(PetFamilyDbContext petFamilyDbContext)
    {
        private readonly PetFamilyDbContext _petFamilyDbContext = petFamilyDbContext;

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Pet> Get(Guid id)
        {
            var Pet = await _petFamilyDbContext.Pets.FirstOrDefaultAsync(p => p.Id == id);
            return Pet;

        }

        public Task<List<Pet>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
