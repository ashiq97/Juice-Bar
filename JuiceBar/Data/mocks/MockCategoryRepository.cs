using JuiceBar.Data.Interfaces;
using JuiceBar.Data.Models;
using System.Collections.Generic;

namespace JuiceBar.Data.mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                {
                    new Category{CategoryName="Alcoholic",Description="All alcoholic Juice"},
                    new Category{CategoryName="Non-alcoholic",Description="All Non-alcoholic Juice"}
                };
            }
        }
    }
}
