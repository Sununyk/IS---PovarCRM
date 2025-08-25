using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models;

namespace PovarCRM.Repositories.Interfaces.garbij
{
    internal interface IRecipeRepository
    {
        IEnumerable<Recipe> GetRecipes();
        Recipe GetRecipeByID(int recipeID);
        void InsertRecipe(Recipe recipe);
        void DeleteRecipe(int recipeID);
        void UpdateRecipe(Recipe recipe);
        void Save();
    }
}
