namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductTitle { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCity { get; set; }
        public string ProductDistrict { get; set; }
        public string CategoryID { get; set; }
        public string ProductCoverImage { get; set; }
        public string ProductType { get; set; }
        public string ProductAddress { get; set; }
    }
}
