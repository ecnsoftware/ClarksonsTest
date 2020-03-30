Feature: RestaurantTest

Scenario: Add items to till
Given I add the items to a till
| Id | Name           | Type     | Price |
| 1  | Noodles        | Mains    | 7.00  |
| 2  | Chicken Breast | Mains    | 7.00  |
| 3  | Wings          | Starters | 4.40  |
| 4  | Cheesy Nachos  | Starters | 4.40  |
When I verify the items were added
Then I get the total cost of the items


Scenario Outline: Update an item
Given I add the items to a till
| Id | Name           | Type     | Price |
| 1  | Noodles        | Mains    | 7.00  |
| 2  | Chicken Breast | Mains    | 7.00  |
| 3  | Wings          | Starters | 4.40  |
| 4  | Cheesy Nachos  | Starters | 4.40  |
And I verify the items were added
When I update the item <ItemId>,<NewItem>
And I verify the item is updated <ItemToUpdate>,<NewItem>
Then I get the total cost of the items
Examples: 
| ItemId | NewItem |
| 1      | Pasta   |

Scenario Outline: Delete an item
Given I add the items to a till
| Id | Name           | Type     | Price |
| 1  | Noodles        | Mains    | 7.00  |
| 2  | Chicken Breast | Mains    | 7.00  |
| 3  | Wings          | Starters | 4.40  |
| 4  | Cheesy Nachos  | Starters | 4.40  |
And I verify the items were added
When I delete an item <ItemId>
And I verify that the item is deleted <ItemId>
Then I get the total cost of the items
Examples: 
| ItemId |
| 2      |