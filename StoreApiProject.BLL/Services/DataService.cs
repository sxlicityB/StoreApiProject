using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApiProject.BLL.Interfaces;
using StoreApiProject.Domain.Models;
using StoreApiProject.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace StoreApiProject.BLL.Services
{
    internal class DataService : IDataService
    {
        private readonly IDataRepository _dataRepository;
        public DataService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task GenerateOrderAsync()
        {
            await _dataRepository.GenerateOrderAsync();
        }
        public async Task GenerateBuyerAsync()
        {
            await _dataRepository.GenerateBuyerAsync();
        }
        public async Task GenerateProductAsync()
        {
            await _dataRepository.GenerateProductAsync();
        }
        public async Task GenerateDataAsync()
        {
            await _dataRepository.GenerateDataAsync();
        }
        public async Task ResetDatabaseAsync()
        {
            await _dataRepository.ResetDatabaseAsync();
        }
    }

}

