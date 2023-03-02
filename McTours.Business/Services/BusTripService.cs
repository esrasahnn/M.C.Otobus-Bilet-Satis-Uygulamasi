using McTours.Business.Validator;
using McTours.BusTrips;
using McTours.DataAccess;
using McTours.DataAccess.Migrations;
using McTours.Domain;
using McTours.VehicleDefinitions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Business.Services
{
    public class BusTripService
    {
        private readonly McToursContext _context = new McToursContext();
        private readonly BusTripValidator _validator = new BusTripValidator();

        public CommandResult Create(BusTripsDto busTripDto)
        {
            if (busTripDto == null)
                throw new ArgumentNullException(nameof(busTripDto));
            try
            {
                var busTrip = MapToEntity(busTripDto);
                var validationResult = _validator.Validate(busTrip);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }
                _context.BusTrips.Add(busTrip);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        public CommandResult Update(BusTripsDto busTripsDto)
        {
            if (busTripsDto == null)
                throw new ArgumentNullException(nameof(busTripsDto));
            try
            {
                var busTrip= MapToEntity(busTripsDto);
                var validationResult = _validator.Validate(busTrip);

                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }
                _context.BusTrips.Update(busTrip);
                _context.SaveChanges();
                return CommandResult.Success("Güncelleme işlemi başarılı");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error("Güncelleme hatası !!", ex);
                throw;
            }
        }

        public CommandResult Delete(int id)
        {
            return Delete(new BusTripsDto { Id = id });
        }

        public CommandResult Delete(BusTripsDto busTripsDto)
        {
            try
            {
                var busTrip = MapToEntity(busTripsDto);
                _context.BusTrips.Remove(busTrip);
                _context.SaveChanges();
                return CommandResult.Success("Silme işlemi başarılı");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error("Silme hatası !!", ex);
            }
        }

        public BusTripsDto? GetById(int id)
        {
            try
            {
                var busTripEntity = _context.BusTrips
                    .Include(def => def.Vehicle)
                    .SingleOrDefault(def => def.Id == id);

                if (busTripEntity != null)
                {
                    var dto = MapToDto(busTripEntity);

                    return dto;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
        }

        public IEnumerable<BusTripsDto> GetAll()
        {
            try
            {
                var busTripDto = _context.BusTrips.Select(MapToDto).ToList();
                return busTripDto;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return new List<BusTripsDto>();
            }
        }

        public IEnumerable<BusTripSummary> GetVehicle()
        {
            try
            {
                return _context.Vehicles.Select(vd => new BusTripSummary()
                {
                    Id = vd.Id,
                    VehicleName = string.Concat(vd.VehicleDefinition.VehicleModel.VehicleMake.Name, "/", vd.VehicleDefinition.VehicleModel.Name, "/", vd.PlateNumber)
                }).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<BusTripSummary>();
            }
        }
        public BusTripTicketDetails? GetSummaryById(int id)
        {
            try
            {
                return _context.BusTrips
                    .Select(trip => new BusTripTicketDetails()
                    {
                        Id = trip.Id,
                        Name = trip.Name,
                        Date = trip.Date,
                        TicketPrice = trip.TicketPrice,
                        BusSeatingType = trip.Vehicle.VehicleDefinition.SeatingType,
                        BusSeatingLineCount = trip.Vehicle.VehicleDefinition.LineCount,
                        VehicleName = string.Concat(trip.Vehicle.PlateNumber.ToUpper(), " - ", trip.Vehicle.VehicleDefinition.VehicleModel.Name, "/", trip.Vehicle.VehicleDefinition.VehicleModel.VehicleMake.Name),
                        Route = string.Concat(trip.DepartureCity.Name, "->", trip.ArrivalCity.Name, "/", trip.Date)
                    } ).FirstOrDefault(trip => trip.Id == id);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
        }

        public BusTripSeatsModel GetBusTripSeats(int id)
        {
            try
            {
                 var busTripSeats=_context.BusTrips
                    .Select(busTrip => new BusTripSeatsModel()
                    {
                        BusTripId = busTrip.Id,
                        BusSeatingType = busTrip.Vehicle.VehicleDefinition.SeatingType,
                        BusSeatingLineCount = busTrip.Vehicle.VehicleDefinition.LineCount

                    }).FirstOrDefault(seats => seats.BusTripId == id);

                //var soldTickets = _context.Tickets.Where(tic => tic.BusTripId == id).ToList();
                //foreach (var soldTicket in soldTickets)
                //{
                //    busTripSeats.SoldSeatNumbers.Add(soldTicket.SeatNumber);
                //}
                return busTripSeats;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                throw;
            }
        }


        public IEnumerable<BusTripSummary> GetSummaries()
        {
            try
            {
                var busTrip = _context.BusTrips.Select(busTrip => new BusTripSummary()
                {
                    Id = busTrip.Id,
                    Date = busTrip.Date,
                    EstimatedDuration = busTrip.EstimatedDuration,
                    TicketPrice = busTrip.TicketPrice,
                    BreakTimeDuration = busTrip.BreakTimeDuration,
                    VehicleMake =busTrip.Vehicle.VehicleDefinition.VehicleModel.VehicleMake.Name,
                    DepartureCityName = busTrip.DepartureCity.Name,
                    VehicleName = string.Concat(busTrip.Vehicle.PlateNumber, " - ", busTrip.Vehicle.VehicleDefinition.VehicleModel.VehicleMake.Name, "/",
                    busTrip.Vehicle.VehicleDefinition.VehicleModel.Name)

                }).ToList();

                return busTrip;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<BusTripSummary>();
            }
        }

        private static BusTrip? MapToEntity(BusTripsDto? busTripsDto)
        {
            var entity = default(BusTrip);
            if (busTripsDto != null)
            {
                entity = new BusTrip()
                {
                  Id= busTripsDto.Id,   
                  VehicleId=busTripsDto.VehicleId,  
                  Date= busTripsDto.Date,
                  DepartureCityId=busTripsDto.DepartureCityId,
                  ArrivalCityId=busTripsDto.ArrivalCityId,  
                  EstimatedDuration=busTripsDto.EstimatedDuration,  
                  TicketPrice=busTripsDto.TicketPrice,  

                };
            }
            return entity;
        }
      

        private static BusTripsDto? MapToDto(BusTrip busTrip)
        {
            var dto = default(BusTripsDto);
            if (busTrip != null)
            {
                dto = new BusTripsDto()
                {
                    Id = busTrip.Id,
                    VehicleId = busTrip.VehicleId,
                    Date = busTrip.Date,
                    DepartureCityId = busTrip.DepartureCityId,
                    ArrivalCityId = busTrip.ArrivalCityId,
                    EstimatedDuration = busTrip.EstimatedDuration,
                    TicketPrice = busTrip.TicketPrice,
                };
            }

            return dto;
        }
    }
}
