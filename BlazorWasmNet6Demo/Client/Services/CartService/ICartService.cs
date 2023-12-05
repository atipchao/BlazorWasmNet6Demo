namespace BlazorWasmNet6Demo.Client.Services.CartService
{
    public interface ICartService
    {
        event Action Onchange;
        Task AddToCart(CartItem cartItem);
        Task<List<CartItem>> GetCartItems();
    }
}
