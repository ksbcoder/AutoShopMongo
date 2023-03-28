namespace AutoShopMongo.Domain.Commands
{
    public class NewCustomer
    {
        public string Fullname { get; set; }
        public string Address_customer { get; set; }
        public string Phone_customer { get; set; }
        public bool State_customer { get; set; }
        public string Id_shop { get; set; }
    }
}
