using System;
using RoofStock.CodingExercise.Api.Data.Repository;
using RoofStock.CodingExercise.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RoofStock.CodingExercise.Api.Domain;

namespace RoofStock.CodingExercise.Api.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IRepository<Property> _repository;
        private readonly IMapper _mapper;

        public PropertyService(IMapper mapper, IRepository<Property> repository)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<List<PropertyModel>> GetAll()
        {
            var data = await _repository.GetAllAsync();
            var result = _mapper.Map<List<PropertyModel>>(data);
            
            return result;
        }

        public async Task<PropertyModel> GetByGuid(Guid id)
        {
            var data = await _repository.Get().FirstOrDefaultAsync(w => w.Guid == id);
            var result = _mapper.Map<PropertyModel>(data);

            return result;
        }

        public async Task<bool> Update(PropertyModel property)
        {
            var data = await _repository.Get().FirstOrDefaultAsync(w => w.Guid == property.Id);

            if (data != null)
            {
                try
                {
                    data.YearBuilt = property.YearBuilt;
                    data.Address = property.Address;
                    data.MonthlyRent = property.MonthlyRent;
                    data.ListPrice = property.ListPrice;

                    var updatedModel = await _repository.UpdateAsync(data);

                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return false;
        }

        public async Task<bool> Create(PropertyModel property)
        {
            var data = await _repository.Get().FirstOrDefaultAsync(w => w.Guid == property.Id);

            if (data == null)
            {
                var p = new Property()
                {
                    Address = property.Address,
                    YearBuilt = property.YearBuilt,
                    MonthlyRent = property.MonthlyRent,
                    ListPrice = property.ListPrice
                };

                try
                {
                    var createdModel = await _repository.AddAsync(p);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                return true;
            }

            return false;
        }

        public async Task Delete(Guid id)
        {
            var data = await _repository.Get().FirstOrDefaultAsync(w => w.Guid == id);

            if (data != null)
            {
                await _repository.DeleteAsync(data);
            }
        }
    }
}