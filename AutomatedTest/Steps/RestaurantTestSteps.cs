using NUnit.Framework;
using RestaurantTill;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AutomatedTest.Steps
{ 
    [Binding]
    public class RestaurantTestSteps
    {
        private List<Item> Till;


        [Given(@"I add the items to a till")]
        public void GivenIHaveTheFollowingItems(Table table)
        {
            var tillAction = new Actions();

            Till = tillAction.AddItemToCart(table);
        
        }

        [Given(@"I verify the items were added")]
        [When(@"I verify the items were added")]
        public void WhenIVerifyTheItemsWereAdded()
        {
            Assert.IsNotNull(Till);
        }
        
        [Then(@"I get the total cost of the items")]
        public void ThenIGetTheTotalCostOfTheItems()
        {
            var tillAction = new Actions();

            var cost = tillAction.CalculateCost(Till);
            Console.WriteLine($"Your total cost is £{cost}");
        }

        [When(@"I update the item (.*),(.*)")]
        public void WhenIUpdateTheItem(int itemId, string newItem)
        {
            var tillAction = new Actions();
            tillAction.UpdateItem(Till, itemId, newItem);
        }

        [When(@"I verify the item is updated (.*),(.*)")]
        public void ThenIVerifyTheItemIsUpdated(string itemId, string newItem)
        {
            Assert.IsTrue(Till.Any(x => x.Name == newItem), $"{newItem } was not added successfully!");
            foreach (var item in Till)
            {
                Console.WriteLine(item.Name);
            }
            
        }

        [When(@"I delete an item (.*)")]
        public void WhenIDeleteAnItem(int itemId)
        {
            var tillAction = new Actions();
            tillAction.DeleteAnItemFromCart(Till, itemId);
        }

        [When(@"I verify that the item is deleted (.*)")]
        public void ThenIVerifyThatTheItemIsDeleted(int itemId)
        {
            Assert.IsFalse(Till.Any(x => x.Id == itemId), $"Item with id: {itemId} was not deleted successfully!");
        }


    }
}
