using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Domain
{
    public class VehicleDefinition
    {
        public int Id { get; set; }
        public int VehicleModelId { get; set; }
        public short Year { get; set; }
        public SeatingType SeatingType { get; set; }
        public int LineCount { get; set; }
        public FuelType FuelType { get; set; }
        public Utility Utilities { get; set; }

        public int TotalCount
        {
            get
            {
                int seatCounterPerLine;

                switch (SeatingType)
                {
                   
                    case SeatingType.Normal:
                        seatCounterPerLine = 4;
                        break;
                    case SeatingType.Single:
                        seatCounterPerLine = 3;
                        break;
                    case SeatingType.Vip:
                        seatCounterPerLine = 2;
                        break;
                  
                    default:
                        seatCounterPerLine = 0;
                        break;
                }
                return seatCounterPerLine * LineCount;
            }
        }

        //Navigation Property
        public VehicleModel VehicleModel { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}
