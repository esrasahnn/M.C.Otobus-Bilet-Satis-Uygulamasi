using McTours.Business.Validator;
using McTours.BusTrips;
using McTours.Cities;
using McTours.DataAccess;
using McTours.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Business.Services
{
    public class CityService
    {
        private readonly McToursContext _context = new McToursContext();


        public IEnumerable<CityDto> GetAll()
        {
            try
            {
                return _context.Cities.Select(city => new CityDto
                {
                    Id = city.Id,
                    Name = city.Name

                }).ToList();

              
            }
            catch (Exception ex)
            {

                return new List<CityDto>();
            }
        }

        
    }
}
