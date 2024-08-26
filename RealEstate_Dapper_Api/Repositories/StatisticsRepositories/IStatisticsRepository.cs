namespace RealEstate_Dapper_Api.Repositories.StatisticsRepositories
{
    public interface IStatisticsRepository
    {
        int CategoryCount();
        int ActiveCategoryCount();
        int ActiveEmployeeCount();
        int PassiveCategoryCount();
        int ProductCount();
        int ApartmentCount();
        string EmployeeNameByMaxProductCount();
        decimal AverageProductPriceByRent();
        decimal AverageProductPriceBySale();
        int AverageRoomCount();
        string CityNameByMaxProductCount();
        int DifferentCityCount();
        decimal LastProductPrice();
        int NewstBuildingYear();
        int OldersBuildingYear();
        string CategoryNameByMaxProductCount();



    }
}
