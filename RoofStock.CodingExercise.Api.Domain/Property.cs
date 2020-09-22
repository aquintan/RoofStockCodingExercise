using System;

namespace RoofStock.CodingExercise.Api.Domain
{
    public class Property
    {
        public int? Id { get; set; }

        public Guid? Guid { get; set; }

        public string Address { get; set; }

        public int YearBuilt { get; set; }

        public decimal MonthlyRent { get; set; }

        public decimal ListPrice { get; set; }
    }
}
