using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class MenuItemService : IMenuItemService
    {
        private RestaurantReservationDbContext _context;
        private MenuItemRepository menuItemsRepository;
        private OrderService _orderService;

        public MenuItemService(RestaurantReservationDbContext context)
        {
            _context = context;
            menuItemsRepository = new(_context);
            _orderService = new OrderService(_context);
        }

        public async Task<int> CreateAsync(MenuItemDTO newMenuItem)
        {
            return await menuItemsRepository.CreateAsync(newMenuItem);
        }

        public async Task<MenuItemDTO> GetAsync(int menuItemId)
        {
            return await menuItemsRepository.GetAsync(menuItemId);
        }

        public async Task<List<MenuItemDTO>> GetAllAsync()
        {
            return await menuItemsRepository.GetAllAsync();
        }

        public async Task UpdateAsync(MenuItemDTO updatedMenuItem)
        {
            await menuItemsRepository.UpdateAsync(updatedMenuItem);
        }

        public async Task DeleteAsync(int menuItemId)
        {
            await menuItemsRepository.DeleteAsync(menuItemId);
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
