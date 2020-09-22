using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoofStock.CodingExercise.Api.Models;

namespace RoofStock.CodingExercise.Api.Services
{
    public interface IPropertyService
    {
        public Task<List<PropertyModel>> GetAll();

        public Task<PropertyModel> GetByGuid(Guid id);

        public Task<bool> Update(PropertyModel property);

        public Task<bool> Create(PropertyModel property);

        public Task Delete(Guid id);
    }
}
