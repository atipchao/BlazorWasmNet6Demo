
using Blazored.LocalStorage;

namespace BlazorWasmNet6Demo.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;

        public event Action Onchange;

        public CartService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task AddToCart(CartItem cartItem)
        {
            List<CartItem>? cart = await FetchCartItems();
            cart.Add(cartItem);
            await _localStorage.SetItemAsync("cart", cart);
            Onchange?.Invoke();
        }
        
        public async Task<List<CartItem>> GetCartItems()
        {
            List<CartItem>? cart = await FetchCartItems();
            return cart;
        }

        private async Task<List<CartItem>?> FetchCartItems()
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            return cart;
        }
    }
}
