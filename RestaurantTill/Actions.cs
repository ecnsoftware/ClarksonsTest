using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestaurantTill
{
   public class Actions
    {
        public List<Item> AddItemToCart(Table table)
        {
            return table.CreateSet<Item>().ToList();
        }

        public List<Item> UpdateItem(List<Item> till, int itemId, string newItem)
        {
            var itemToUpdate = till.FirstOrDefault(x => x.Id == itemId);
            itemToUpdate.Name = newItem;
            return till;
        }

        public List<Item> DeleteAnItemFromCart(List<Item> till, int itemId)
        {
            var itemToRemove = till.FirstOrDefault(x => x.Id == itemId);
            till.Remove(itemToRemove);
            return till;
        }

        public decimal CalculateCost(List<Item> till)
        {
            return till.Sum(x => x.Price);
        }
    }
}
