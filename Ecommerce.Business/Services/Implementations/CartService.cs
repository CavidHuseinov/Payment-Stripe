
using AutoMapper;
using Ecommerce.Business.Helpers.DTOs.Cart;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Entities.Identity;
using Ecommerce.DAL.IUO;
using Ecommerce.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Business.Services.Implementations
{
    public class CartService : ICartService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorks _work;
        private readonly ICartRepo _command;
        private readonly IQueryRepo<Cart> _query;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _http;

        public CartService(IQueryRepo<Cart> query, ICartRepo command, IUnitOfWorks work, IMapper mapper, IHttpContextAccessor http, UserManager<User> userManager)
        {
            _query = query;
            _command = command;
            _work = work;
            _mapper = mapper;
            _http = http;
            _userManager = userManager;
        }

        public async Task<CartDto> CreateAsync(CreateCartDto dto)
        {
            var userId = _userManager.GetUserId(_http.HttpContext.User);
            if (userId == null)
                throw new InvalidOperationException("İstifadəçi tapılmadı");
            var cart = new Cart
            {
                UserId = userId
            };
            await _command.CreateAsync(cart);
            await _work.SaveChangesAsync();

            return _mapper.Map<CartDto>(cart);
        }

        public async Task<CartDto> GetByIdAsync(Guid id)
        {
            var cartId = await _query.GetByIdAsync(id);
            if (cartId == null) throw new InvalidOperationException("cart tapilmadi");
            return _mapper.Map<CartDto>(cartId);
        }

        public async Task<CartDto> GetByUser()
        {
            var userId = _userManager.GetUserId(_http.HttpContext.User);
            if (userId == null) throw new InvalidOperationException("Istifadeci tapilmadi");

            var query = await _query.GetAsync(
                        x => x.UserId == userId,
            include: q => q.Include(x => x.CartItems).ThenInclude(x=>x.Product));
            return _mapper.Map<CartDto>(query);
        }
    }
}
