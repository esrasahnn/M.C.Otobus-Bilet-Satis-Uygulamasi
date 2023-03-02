namespace McTours.Domain
{
    public class VehicleMake
    {
        public VehicleMake() 
        {
            VehicleModels = new List<VehicleModel>(); 
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<VehicleModel> VehicleModels { get; set; }
    }
}