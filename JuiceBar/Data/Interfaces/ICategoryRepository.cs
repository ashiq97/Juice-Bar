using JuiceBar.Data.Models;
using System.Collections.Generic;

namespace JuiceBar.Data.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get;}
    }
}
