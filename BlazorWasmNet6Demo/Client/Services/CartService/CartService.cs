
using Blazored.LocalStorage;
using BlazorWasmNet6Demo.Shared;
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
            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            var sameItem = cart.Find(x => x.ProductId == cartItem.ProductId
            && x.ProductTypeId == cartItem.ProductTypeId);
            if(sameItem == null)
            {
                cart.Add(cartItem);
            }
            else
            {
                sameItem.Quantity += cartItem.Quantity;
            }
            

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

        public async Task RemoveProductFromCart(int productId, int productTypeId)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if(cart == null)
            {
                return;
            }

            // get the cart item we will remove
            var cartItem = cart.Find(s => s.ProductId == productId
                && s.ProductTypeId == productTypeId);
            if(cartItem != null)
            {
                cart.Remove(cartItem);
                await _localStorage.SetItemAsync("cart", cart);
                Onchange.Invoke();
            }
                

        }

        public async Task UpdateQuantity(CartProductResponse product)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                return;
            }

            // get the cart item we will remove
            var cartItem = cart.Find(s => s.ProductId ==product.ProductId
                && s.ProductTypeId == product.ProductTypeId);
            if (cartItem != null)
            {
                cartItem.Quantity = product.Quantity;
                //Set items to the local storage below
                await _localStorage.SetItemAsync("cart", cart);
                
            }

        }
    }
}
