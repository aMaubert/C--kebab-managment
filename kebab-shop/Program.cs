using System;

namespace kebab_shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Ingredient ingredient = new Ingredient("tomate", true, false);
            Ingredient ingredient2 = new Ingredient("oignon", true, false);
            Ingredient ingredient3 = new Ingredient("moule", true, true); 
            Ingredient[] listIngredients =
            {
                ingredient,
                ingredient2,
                ingredient3
            };
            Kebab kebab = new Kebab(listIngredients);
            Console.WriteLine("le kebab est végetarien : " +  kebab.HaveVegetarianIngredients());
            Console.WriteLine("le kebab est pescétarien : " +  kebab.HavePescetarienIngredients());
        }
    }

    class Kebab
    {
        private Ingredient[] _ingredients;

        public Kebab(Ingredient[] ingredients)
        {
            this.Ingredients = ingredients;
        }

        public bool HaveVegetarianIngredients()
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
        
        public bool HavePescetarienIngredients()
        {
            foreach (Ingredient eachIngredient in this.Ingredients)
            {
                if ( !eachIngredient.IsPescetarien)
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
        private bool _isPescetarien;

        public Ingredient(String name, bool isVegetarian, bool isPescetarien)
        {
            this.Name = name;
            this.IsVegetarian = isVegetarian;
            this.IsPescetarien = isPescetarien;
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
        public bool IsPescetarien
        {
            get => _isPescetarien;
            set
            {
                if (this.IsVegetarian)
                {
                    _isPescetarien = value;   
                }
            }
        }
    }
}