using Newtonsoft.Json.Linq;
using RoofStock.CodingExercise.Api.Domain;
using RoofStock.CodingExercise.DatabaseUtil;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RoofStock.CodingExercise.DatabaseUtil
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync("https://samplerspubcontent.blob.core.windows.net/public/properties.json");
                var data = JObject.Parse(response);

                JArray properties = (JArray)data["properties"];

                var props = new List<Property>();

                for (int i = 0; i < properties.Count; i++)
                {
                    var address = properties[i]["address"];
                    var financial = properties[i]["financial"];
                    var physical = properties[i]["physical"];

                    var p = new Property();

                    if (address.HasValues)
                    {
                        p.Address = address["address1"].Value<string>();
                    }

                    if (financial.HasValues)
                    {
                        p.MonthlyRent = financial["monthlyRent"].Value<decimal>();
                        p.ListPrice = financial["listPrice"].Value<decimal>();
                    }

                    if (physical.HasValues)
                    {
                        p.YearBuilt = physical["yearBuilt"].Value<int>();
                    }

                    props.Add(p);
                }

                using (var context = new Context())
                {
                    foreach (var p in props)
                    {
                        context.Properties.Add(p);
                    }

                    context.SaveChanges();
                }
            }

            Console.WriteLine("Done!");
        }
    }
}