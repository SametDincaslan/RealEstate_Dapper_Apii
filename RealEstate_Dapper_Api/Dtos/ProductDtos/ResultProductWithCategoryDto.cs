﻿namespace RealEstate_Dapper_Api.Dtos.ProductDtos
{
    public class ResultProductWithCategoryDto
    {
        public int ProductID { get; set; }
        public string ProductTitle { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCity { get; set; }
        public string ProductDistrict { get; set; }
        public string CategoryName { get; set; }
        public string ProductCoverImage { get; set; }
        public string ProductType { get; set; }
        public string ProductAddress { get; set; }
        public bool DealOfTheDay { get; set; }
    }
}
