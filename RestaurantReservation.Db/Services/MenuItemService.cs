using RestaurantReservation.Db.Models;
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

        public async Task<int> CreateAsync(MenuItemDTO newMenuItem)
        {
            return await _menuItemsRepository.CreateAsync(newMenuItem);
        }

        public async Task<MenuItemDTO> GetAsync(int menuItemId)
        {
            return await _menuItemsRepository.GetAsync(menuItemId);
        }

        public async Task<List<MenuItemDTO>> GetAllAsync()
        {
            return await _menuItemsRepository.GetAllAsync();
        }

        public async Task UpdateAsync(MenuItemDTO updatedMenuItem)
        {
            await _menuItemsRepository.UpdateAsync(updatedMenuItem);
        }

        public async Task DeleteAsync(int menuItemId)
        {
            await _menuItemsRepository.DeleteAsync(menuItemId);
        }

        public async Task<List<MenuItemDTO>> ListOrderedMenuItemsAsync(int reservationId)
        {
            var orders = await _orderService.ListOrdersAndMenuItemsAsync(reservationId);
            var menuItems = new List<MenuItemDTO>();

            orders.SelectMany(order => order.OrderItems)
                .ToList()
                .ForEach(orderItem => menuItems.Add(orderItem.MenuItem));

            return menuItems;
        }
    }
}
