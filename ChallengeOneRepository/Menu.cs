using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneRepository
{

    public class Menu
    {
        
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDiscription { get; set; }
        public double MealPrice { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();



        public Menu()
        {

        }

        public Menu(int mealNumber, string mealName, string mealDiscription, double mealPrice, List<string> ingredients)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDiscription = mealDiscription;
            MealPrice = mealPrice;
            Ingredients = ingredients;

        }

    }

    
}
