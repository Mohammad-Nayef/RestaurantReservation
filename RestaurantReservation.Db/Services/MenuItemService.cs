using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class MenuItemService : IMenuItemService
    {
        private RestaurantReservationDbContext _context;
        private MenuItemRepository _menuItemsRepository;
        private OrderService _orderService;

        public MenuItemService(RestaurantReservationDbContext context)
        {
            _context = context;
            _menuItemsRepository = new(_context);
            _orderService = new OrderService(_context);
        }

        public async Task<int> CreateAsync(MenuItem newMenuItem)
        {
            return await _menuItemsRepository.CreateAsync(newMenuItem);
        }

        public async Task<MenuItem> GetAsync(int menuItemId)
        {
            return await _menuItemsRepository.GetAsync(menuItemId);
        }

        public async Task<List<MenuItem>> GetAllAsync()
        {
            return await _menuItemsRepository.GetAllAsync();
        }

        public async Task UpdateAsync(MenuItem updatedMenuItem)
        {
            await _menuItemsRepository.UpdateAsync(updatedMenuItem);
        }

        public async Task DeleteAsync(int menuItemId)
        {
            await _menuItemsRepository.DeleteAsync(menuItemId);
        }

        public async Task<List<MenuItem>> ListOrderedMenuItemsAsync(int reservationId)
        {
            var orders = await _orderService.ListOrdersAndMenuItemsAsync(reservationId);
            var menuItems = new List<MenuItem>();

            orders.SelectMany(order => order.OrderItems)
                .ToList()
                .ForEach(orderItem => menuItems.Add(orderItem.MenuItem));

            return menuItems;
        }
    }
}
