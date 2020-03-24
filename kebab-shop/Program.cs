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
            
            Sauce sauceBarbecue = new Sauce("Barbecue");
            Sauce sauceAlgerian = new Sauce("Algerian");

            Sauce[] listSauces =
            {
                sauceBarbecue,
                sauceAlgerian
            };
            
            Kebab kebab = new Kebab(listIngredients, listSauces);
            Console.WriteLine("le kebab est végetarien : " +  kebab.HaveVegetarianIngredients());
            Console.WriteLine("le kebab est pescétarien : " +  kebab.HavePescetarienIngredients());
            Console.WriteLine("liste des sauces du kebab : ");
            kebab.DisplaySauces();
        }
    }

    class Kebab
    {
        private Ingredient[] _ingredients;
        private Sauce[] _sauces;

        public Kebab(Ingredient[] ingredients, Sauce[] sauces)
        {
            this.Ingredients = ingredients;
            this.Sauces = sauces;
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


        public void DisplaySauces()
        {
            foreach (var sauce in this.Sauces)
            {
                Console.WriteLine(sauce.ToString());
            }
        }
        
        public Ingredient[] Ingredients
        {
            get => _ingredients;
            set => _ingredients = value;
        }
        
        public Sauce[] Sauces
        {
            get => _sauces;
            set => _sauces = value;
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

    class Sauce
    {
        private string _name;

        public Sauce(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public override string ToString()
        {
            return "Sauce : { name : " + this.Name +" }";
        }
    }
}