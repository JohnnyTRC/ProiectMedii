using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using ProiectMobile.Models;

namespace ProiectMobile.Data
{
    public class OrderListDatabase
    {
            readonly SQLiteAsyncConnection _database;
        public OrderListDatabase(string dbPath)
            {
                _database = new SQLiteAsyncConnection(dbPath);
                _database.CreateTableAsync<OrderList>().Wait();
        }
        public Task<List<OrderList>> GetOrderListsAsync()
            {
                return _database.Table<OrderList>().ToListAsync();
            }
            public Task<OrderList> GetOrderListAsync(int id)
            {
                return _database.Table<OrderList>()
                .Where(i => i.ID == id)
               .FirstOrDefaultAsync();
            }
            public Task<int> SaveOrderListAsync(OrderList olist)
            {
                if (olist.ID != 0)
                {
                    return _database.UpdateAsync(olist);
                }
                else
                {
                    return _database.InsertAsync(olist);
                }
            }
            public Task<int> DeleteOrderListAsync(OrderList olist)
            {
                return _database.DeleteAsync(olist);
            }
    }
}

