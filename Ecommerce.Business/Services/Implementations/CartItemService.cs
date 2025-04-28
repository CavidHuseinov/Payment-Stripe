
using AutoMapper;
using Ecommerce.Business.Helpers.DTOs.Cart;
using Ecommerce.Business.Helpers.DTOs.CartItem;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.Core.Entities;
using Ecommerce.DAL.IUO;
using Ecommerce.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Business.Services.Implementations
{
    public class CartItemService : ICartItemService
    {
        private readonly IMapper _mapper;
        private readonly ICartItemRepo _command;
        private readonly IUnitOfWorks _work;
        private readonly IQueryRepo<CartItem> _query;
        private readonly ICartService _cartService;

        public CartItemService(IQueryRepo<CartItem> query, IUnitOfWorks work, ICartItemRepo command, IMapper mapper, ICartService cartService)
        {
            _query = query;
            _work = work;
            _command = command;
            _mapper = mapper;
            _cartService = cartService;
        }

        public async Task<CartItemDto> CreateAsync(CreateCartItemDto dto)
        {
            var cart = await _cartService.GetByUser();

            if (cart == null)
            {
                throw new InvalidOperationException("Istifadeciye aid sebet tapilmadi");
            }
            var cartItemMap = _mapper.Map<CartItem>(dto);
            cartItemMap.CartId = cart.Id;
            var existingCartItem = await _query.GetAsync(x => x.ProductId == dto.ProductId && x.CartId == cart.Id);
            if (existingCartItem != null)
            {
                existingCartItem.Quantity += dto.Quantity;
                await _command.UpdateAsync(existingCartItem);
            }
            else
            {
                await _command.CreateAsync(cartItemMap);
            }
            await _work.SaveChangesAsync();
            return _mapper.Map<CartItemDto>(cartItemMap);
        }



        public async Task DeleteAsync(Guid id)
        {
            var cartId = await _query.GetByIdAsync(id);
            if (cartId == null) throw new ArgumentNullException("CartItem Id'si tapilmadi");
            await _command.DeleteAsync(cartId);
            await _work.SaveChangesAsync();
        }

        public async Task<ICollection<CartItemDto>> GetAllAsync()
        {
            var cart = await _query.GetAllAsync(include:x=>x.Include(x=>x.Product)).ToListAsync();
            return _mapper.Map<ICollection<CartItemDto>>(cart);
        }

        public async Task<CartItemDto> GetByIdAsync(Guid id)
        {
            var cartId = await _query.GetByIdAsync(id);
            if (cartId == null) throw new ArgumentNullException("CartItem Id'si tapilmadi");
            return _mapper.Map<CartItemDto>(cartId);
        }
    }

}
