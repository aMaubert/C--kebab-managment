using System;

namespace kebab_shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Ingredient ingredient = new Ingredient("tomate", true);
            Ingredient ingredient2 = new Ingredient("oignon", false);
            Ingredient[] listIngredients = {ingredient, ingredient2};
            Kebab kebab = new Kebab(listIngredients);
            Console.WriteLine("le kebab est végetarien : " +  kebab.HaveVegetableIngredients());
        }
    }

    class Kebab
    {
        private Ingredient[] _ingredients;

        public Kebab(Ingredient[] ingredients)
        {
            this.Ingredients = ingredients;
        }

        public bool HaveVegetableIngredients()
        {
            foreach (Ingredient eachIngredient in this.Ingredients)
            {
                if ( !eachIngredient.IsVegetarian)
                {
                    return false;
                }
            }
            return true;
        }
        
        public Ingredient[] Ingredients
        {
            get => _ingredients;
            set => _ingredients = value;
        }
    }

    internal class Ingredient
    {
        private string _name;
        private bool _isVegetarian;

        public Ingredient(String name, bool isVegetarian)
        {
            this.Name = name;
            this.IsVegetarian = isVegetarian;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public bool IsVegetarian
        {
            get => _isVegetarian;
            set => _isVegetarian = value;
        }
    }
}