"# GoldBadgeProject" 

I dont know if this is what the readme should look like. but i figured I would try to describe what is going on. SORRY! 

ChallengeOne Komodo Cafe
User Menu includes the following options
1. Add a new menu item - this option will allow the user to name, describe, price , and add ingredients To create a new menu item. The Combo number will be assigned automatically.
2. Delete a menu item - this option will list the menu items with combo numbers to allow the user to view the menu item and select it by the Combo number to be removed.
3. List of all menu items - this option will show every item on the menu it will list Meal number, meal name, meal description, meal price, and meal ingredients. 
4. Exit - allows user to exit the menu.


Methods used 
1. AddNewMenuItem - is adding user created meals and adding them to the menu constructor that was created in our menu class. it is also auto-assigning meal numbers by 1 for each new meal that was created.
2. List<Menu> GetMenu - is bringing all the information that we stored in the Menu list that we created in the Repo under List<Menu> _menuDatabase. displaying it every time GetMenu is being called.
3. GetMealByNumber - is comparing assigned Meal Number to input number and if the result comes back matching one in the _menuDatabase list it will display that meal combo. if user inputs a non-existing meal number it wont bring up anything.
4. DeleteMenuItem - is comparing chosen meal number to _menuDatabase if input matches it will remove the meal from the list


ChallengeTwo Komodo Claims Department
User Menu includes the folowing options
1. See all claims - this option will display all claims created in the queue that havent been pulled.
2. Take care of next claim - This will display the claim that is next in queue and give the user the option to pull out of queue to be worked on. if user selects yes it will pull claim out of the queue and remove it from the List above. if user selects no the user will be taken back to the main menu.
3. End a new claim - this option will allow the user to create a whole new claim by prompts. the following will be prompted. claimID, ClaimType( an enum was created to allow user to select from limited choices, Car, Home, Theft), Description, ClaimAmount, DateOfIncident, DateOfClaim, IsValid (here its checking if the date of the claim is less than or equal to 30 days of the date of Accident. if the claim was created within 30 days of the accident it will be a valid claim, however if it came back more than 30 days it will show a not valid claim.)
4. Exit Application - allows user to exit the menu

Methods used
1. AddClaimToQueue - is taking all user created claim info and inserting it into (_claimDirectory) and entering it into the queue.
2. GetClaimsInQueue - is diplaying all claims in the (_claimDirectory) the ones that havent been pulled out yet.
3. NextClaimInQueue - is diplaying the claim that is next in line to be worked on in _claimDirectory.
4. GetClaimByID - is comparing user selected ID to the _claimDirectory and if it matches it will display the selected claim by the assigned ID.
5. PullClaim - this method is used in our TakeCareOfNextClaim in the UI, if user decided to edit the claim that was next in line it will remove it from the Queue and allow the user to work on the claim.


ChallengeThree Komodo Insurance

User Menu includes the following options
1. Add a badge - This option allows the user to create a new badge.
2. Edit a badge - This option allows the user to edit information within selected badge. it will also display all badges for the user to select from.
3. List all badges - This option will display every badge thats in the system
4. Exit - allows user to exit the menu.

Methods used
1. ShowAllBadges - will allow the ListAllBadges to display all badges in _badgesDictionary. in the system.
2. AddNewBadge - This will add user created badges to the directory along with assign a key to the new badge. the key is incremented by 1 for each new badge created.
3. GetBadgeByKey - allows the user to select badges by their unique Key that was assigned to them when created. 
4. UpdateBadgeByKey - Here when the user selected a badge to edit all new infromation will replace old information on the badge when it comes to Door access.


