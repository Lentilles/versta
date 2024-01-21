using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using versta24.Data;
using versta24.Models;
using versta24.Services;
using versta24.ViewModels;

namespace versta24.Controllers
{
    [Route("Orders/")]
    public class OrderController : Controller
    {
        // GET: Order/Create

        private readonly NumberService numberService;
        private readonly VerstaDbContext dbContext;

        public OrderController(NumberService numberService, VerstaDbContext dbContext)
        {
            this.numberService = numberService;
            this.dbContext = dbContext;
        }

        [HttpGet("Create")]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Order order)
        {
            order.Number = numberService.GetNumber();
            order.Pickup = order.Pickup.ToUniversalTime();

            dbContext.Orders.Add(order);
            await dbContext.SaveChangesAsync();
            
            return View();
        }

        [HttpGet("List")]
        public async Task<ActionResult> List()
        {
            OrderList orderList = new OrderList();
            dbContext.Addresses.ToList();
            orderList.Orders = dbContext.Orders.ToList();

            return View(orderList);
        }

        [HttpGet("Get/{id:Guid}")]
        public async Task<ActionResult> Get(Guid id)
        {
            Order order;
            dbContext.Addresses.ToList();
            order = dbContext.Orders.Where(record => record.Id == id).FirstOrDefault();

            if (order == null)
                return View("Error");

            return View(order);
        }
    }
}