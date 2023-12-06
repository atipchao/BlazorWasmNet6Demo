
using Blazored.LocalStorage;
using BlazorWasmNet6Demo.Shared.DTO;

namespace BlazorWasmNet6Demo.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;

        private readonly HttpClient _http;

        public event Action Onchange;

        public CartService(ILocalStorageService localStorage, HttpClient http)
        {
            _localStorage = localStorage;
            _http = http;
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

        public async Task<List<CartProductResponse>> GetCartProducts()
        {
            var cartItems = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cartItems == null)
                return new List<CartProductResponse>();            
            var response = await _http.PostAsJsonAsync("api/cart/products", cartItems);
            var cartProducts =
                await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartProductResponse>>>();
            return cartProducts.Data;
        }
    }
}
