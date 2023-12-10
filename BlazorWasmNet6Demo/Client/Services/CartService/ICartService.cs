using BlazorWasmNet6Demo.Shared.DTO;

namespace BlazorWasmNet6Demo.Client.Services.CartService
{
    public interface ICartService
    {
        event Action Onchange;
        Task AddToCart(CartItem cartItem);
        Task<List<CartItem>> GetCartItems();
        Task<List<CartProductResponse>> GetCartProducts();
        Task RemoveProductFromCart(int productId, int productTypeId);
        Task UpdateQuantity(CartProductResponse product);
    }
}
