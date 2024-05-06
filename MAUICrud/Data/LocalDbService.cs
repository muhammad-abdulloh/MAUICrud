﻿using MAUICrud.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUICrud.Data
{
    public class LocalDbService
    {
        private const string DB_NAME = "demo_db.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));

            Console.WriteLine(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));

            _connection.CreateTableAsync<Customer>();
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _connection.Table<Customer>().ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _connection.Table<Customer>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(Customer customer)
        {
            await _connection.InsertAsync(customer);
        }

        public async Task Update(Customer customer)
        {
            await _connection.UpdateAsync(customer);
        }

        public async Task Delete(Customer customer)
        {
            await _connection.DeleteAsync(customer);
        }


    }
}
