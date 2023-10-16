using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class MenuItemService
    {
        private RestaurantReservationDbContext _context;
        private MenuItemsRepository menuItemsRepository;

        public MenuItemService(RestaurantReservationDbContext context)
        {
            _context = context ;
            menuItemsRepository = new(_context);
        }

        ~MenuItemService()
        {
            _context.DisposeAsync();
        }

        /// <returns>The ID of the created object.</returns>
        public async Task<int> CreateAsync(MenuItemDTO newMenuItem)
        {
            return await menuItemsRepository.CreateAsync(newMenuItem);
        }

        /// <exception cref="KeyNotFoundException"></exception>
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

        /// <exception cref="KeyNotFoundException"></exception>
        public async Task DeleteAsync(int menuItemId)
        {
            await menuItemsRepository.DeleteAsync(menuItemId);
        }

        public async Task<List<MenuItemDTO>> ListOrderedMenuItemsAsync(int reservationId)
        {
            var orderService = new OrderService(_context);
            var x = await orderService.ListOrdersAndMenuItemsAsync(reservationId);
            var menuItems = new List<MenuItemDTO>();
            
            foreach (var order in x)
            {
                foreach (var orderItem in order.OrderItems)
                {
                    menuItems.Add(orderItem.MenuItem);
                }
            }

            return menuItems;
        }
    }
}
