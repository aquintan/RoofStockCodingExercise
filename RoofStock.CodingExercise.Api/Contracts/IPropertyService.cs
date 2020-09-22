using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoofStock.CodingExercise.Api.Models;

namespace RoofStock.CodingExercise.Api.Contracts
{
    public interface IPropertyService
    {
        public List<PropertyModel> GetAll();
    }
}
