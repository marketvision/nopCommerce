using System.Collections.Generic;
using System.Linq;
using Nop.Web.Framework.Models;

namespace Nop.Web.Models.Catalog
{
    public class CategorySimpleModel : BaseNopEntityModel
    {
        public CategorySimpleModel()
        {
            SubCategories = new List<CategorySimpleModel>();
        }

        public string Name { get; set; }

        public string SeName { get; set; }

        public int? NumberOfProducts { get; set; }

        public bool IncludeInTopMenu { get; set; }

        public List<CategorySimpleModel> SubCategories { get; set; }

        public bool HaveSubCategories { get; set; }

        public string Route { get; set; }
    }

    public static class CategoryModelExtensions
    {
        public static bool ShowCategory(this CategorySimpleModel category)
        {
            return
                category.NumberOfProducts.HasValue && category.NumberOfProducts > 0 ||
                category.SubCategories?.Sum(sc => sc.NumberOfProducts ?? 0) > 0;
        }
    }
}