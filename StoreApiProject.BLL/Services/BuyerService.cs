using StoreApiProject.BLL.Interfaces;
using StoreApiProject.Domain.Models;
using StoreApiProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace StoreApiProject.BLL.Services
{
    public class BuyerService : IBuyerService
    {
        private readonly IBuyerRepository _buyerRepository;

        public BuyerService(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public async Task<ICollection<Buyer>> GetBuyersAsync()
        {
            return await _buyerRepository.GetBuyersAsync();
        }

        public async Task<Buyer> GetBuyerAsync(int id) 
        {
            return await _buyerRepository.GetBuyerAsync(id);
        }
        public async Task<bool> CreateBuyerAsync(Buyer buyer) 
        {
            return await _buyerRepository.CreateBuyerAsync(buyer);
        }
        public async Task<bool> UpdateBuyerAsync() 
        {
            return await _buyerRepository?.UpdateBuyerAsync();
        }
        public async Task<bool> EditBuyerAsync(Buyer buyer) 
        {
            return await _buyerRepository.EditBuyerAsync(buyer);
        }
        public async Task<bool> DeleteBuyerAsync(int id) 
        {
            return await _buyerRepository.DeleteBuyerAsync(id);
        }
    }
}
