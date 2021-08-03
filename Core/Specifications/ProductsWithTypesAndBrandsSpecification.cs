using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddIclude(x => x.ProductType);
            AddIclude(x => x.ProductBrand);
        }


        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.ID == id)
        {

            AddIclude(x => x.ProductType);
            AddIclude(x => x.ProductBrand);

        }
    }

}