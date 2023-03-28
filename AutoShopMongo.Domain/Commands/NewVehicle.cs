namespace AutoShopMongo.Domain.Commands
{
    public class NewVehicle
    {
        public string Brand { get; set; }
        public int Model { get; set; }
        public int Km { get; set; }

        public bool State_vehicle { get; set; }
        public string Id_Customer { get; set; }
    }
}
