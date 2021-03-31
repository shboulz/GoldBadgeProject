using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneRepository
{
    public class MenuRepo
    {
        protected readonly List<Menu> _menuDatabase = new List<Menu>();

        int _Count = 0;

        public bool AddNewMenuItem(Menu menu)
        {
            _Count++;
            menu.MealNumber = _Count;
            _menuDatabase.Add(menu);
            return true;
        }

        public List<Menu> GetMenu()
        {
            return _menuDatabase;
        }
        
        public Menu GetMealByNumber(int mealNumber)
        {
            foreach (Menu menu in _menuDatabase)
            {
                if (menu.MealNumber == mealNumber)
                {
                    return menu;
                }
            }
            return null;
        }

        public bool DeleteMenuItem(int mealNumber)
        {
            foreach (Menu menu in _menuDatabase)
            {
                if (menu.MealNumber == mealNumber)
                {
                    _menuDatabase.Remove(menu);
                    return true;
                }
            }
            return false;
        }

        
    }
}
