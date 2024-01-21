using versta24.Models;

namespace versta24.ViewModels
{
    public sealed class OrderList
    {
        public List<Order> Orders { get; set; }
        public OrderList() {

            Orders = new ();
        }
    }
}
