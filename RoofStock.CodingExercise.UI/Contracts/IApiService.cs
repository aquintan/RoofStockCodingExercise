using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoofStock.CodingExercise.UI.Models;

namespace RoofStock.CodingExercise.UI.Contracts
{
    public interface IApiService
    {
        public Task<List<PropertyModel>> GetProperties();

        public Task<PropertyModel> GetProperty(Guid id);

        public Task UpdateProperty(PropertyModel property);

        public Task CreateProperty(PropertyModel property);

        public Task DeleteProperty(Guid id);
    }
}
