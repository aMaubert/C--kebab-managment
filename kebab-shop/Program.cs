/*
 *    First program in C# lang
 *    Cours Design  Patterns at ESGI
 *
 *     23/03/2020
 *
 *    Kebab Managment Program
 */

using System;
using System.Collections.Generic;

namespace kebab_shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Ingredient ingredient = new Ingredient("tomate", IngredientType.Tomate,true, false, 1);
            Ingredient ingredient2 = new Ingredient("oignon", IngredientType.Oignon,true, false, 1);
            Ingredient ingredient3 = new Ingredient("moule", IngredientType.Moule,true, true, 1);
            Ingredient ingredient4 = new Ingredient("fromage", IngredientType.Fromage,false, false, 1); 
            Ingredient[] listIngredients =
            {
                ingredient,
                ingredient2,
                ingredient3,
                ingredient4
            };
            
            Sauce sauceBarbecue = new Sauce("Barbecue");
            Sauce sauceAlgerian = new Sauce("Algerian");

            Sauce[] listSauces =
            {
                sauceBarbecue,
                sauceAlgerian
            };
            
            Kebab kebab = new Kebab(listIngredients, listSauces);
            
            Console.WriteLine("liste des ingredients du kebab : ");
            kebab.DisplayIngredients();
            Console.WriteLine("le kebab est végetarien : " +  kebab.HaveVegetarianIngredients());
            Console.WriteLine("le kebab est pescétarien : " +  kebab.HavePescetarienIngredients());
            Console.WriteLine("liste des sauces du kebab : ");
            kebab.DisplaySauces();
            Console.WriteLine();
            
            // on enlève les oignons
            kebab = kebab.SansOignons();
            Console.WriteLine("liste des ingredients du kebab (Sans oignons) : ");
            kebab.DisplayIngredients();
            Console.WriteLine();

            // on met un supplément fromage
            kebab = kebab.SupplementFromage();
            Console.WriteLine("liste des ingredients du kebab (Supplément fromage) : ");
            kebab.DisplayIngredients();
            Console.WriteLine();

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


        public Kebab SupplementFromage()
        {
            var listIngredients =  new List<Ingredient>(this.Ingredients);
            for( int i = 0; i < listIngredients.Count; i++)
            {
                if (listIngredients[i].Type == IngredientType.Fromage)
                {
                    listIngredients[i].DoubleQuantity();
                }
            }

            this.Ingredients = listIngredients.ToArray();
            return this;
        }
        
        public Kebab SansOignons()
        {
            var listIngredients =  new List<Ingredient>(this.Ingredients);
            for( int i = 0; i < listIngredients.Count; i++)
            {
                if (listIngredients[i].Type == IngredientType.Oignon)
                {
                    listIngredients.RemoveAt(i);
                    i--;
                }
            }

            this.Ingredients = listIngredients.ToArray();
            return this;
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
        
        public void DisplayIngredients()
        {
            foreach (var ingredient in this.Ingredients)
            {
                Console.WriteLine(ingredient.ToString());
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
        private int _quantity;
        private IngredientType _type;

        public Ingredient(String name, IngredientType ingredientType, bool isVegetarian, bool isPescetarien, int quantity)
        {
            this.Name = name;
            this.IsVegetarian = isVegetarian;
            this.IsPescetarien = isPescetarien;
            this.Quantity = quantity;
            this.Type = ingredientType;

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

        public int Quantity
        {
            get => _quantity;
            set => _quantity = value;
        }

        public IngredientType Type
        {
            get => _type;
            set => _type = value;
        }

        public override string ToString()
        {
            return "Ingredient: { name : " + this.Name +
                                ", isVegetarian: " + this.IsVegetarian +
                                ", isPescetarien : " + this.IsPescetarien +
                                ", quantity : " + this.Quantity +
                   " }" ;
        }

        public void DoubleQuantity()
        {
            this.Quantity *= 2;
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


    // I would like to make Ingredient type into an Enum
    enum IngredientType
    {
        Fromage,
        Salade,
        Tomate,
        Oignon,
        Moule
    }
}