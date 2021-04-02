"# GoldBadgeProject" 
ChallengeOne Komodo Cafe
User Menu includes the following options
1. Add a new menu item - this option will allow the user to name, describe, price , and add ingredients To create a new menu item. The Combo number will be assigned automatically.
2. Delete a menu item - this option will list the menu items with combo numbers to allow the user to view the menu item and select it by the Combo number to be removed.
3. List of all menu items - this option will show every item on the menu it will list Meal number, meal name, meal description, meal price, and meal ingredients. 


Methods used 
1. AddNewMenuItem - is adding user created meals and adding them to the menu constructor that was created in our menu class. it is also auto-assigning meal numbers by 1 for each new meal that was created.
2. List<Menu> GetMenu - is bringing all the information that we stored in the Menu list that we created in the Repo under List<Menu> _menuDatabase. displaying it every time GetMenu is being called.
3. GetMealByNumber - is comparing assigned Meal Number to input number and if the result comes back matching one in the _menuDatabase list it will display that meal combo. if user inputs a non-existing meal number it wont bring up anything.
