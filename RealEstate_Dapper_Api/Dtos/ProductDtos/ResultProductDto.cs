using System.Reflection.Metadata.Ecma335;

namespace RealEstate_Dapper_Api.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public int ProductID { get; set; }
        public string ProductTitle { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCity { get; set; }
        public string ProductDistrict { get; set; }
        public int ProductCategory{ get; set; }
        public string ProductCoverImage { get; set; }
        public string ProductType { get; set; }
        public string ProductAddress { get; set; }
    }
}
