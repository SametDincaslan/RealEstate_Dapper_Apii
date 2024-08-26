using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.StatisticsRepositories;
using System.Text.RegularExpressions;

namespace RealEstate_Dapper_Api.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly Context _context;

        public StatisticsRepository(Context context)
        {
            _context = context;
        }

        public int ActiveCategoryCount()
        {
            string query = "Select Count(*) From Tbl_Category where CategoryStatus=1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ActiveEmployeeCount()
        {
            string query = "Select Count(*) From Tbl_Employee where EmployeeStatus=1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ApartmentCount()//Daire isminde kaç tane veri olduğunu int cinsinden söyler
        {
            string query = "Select Count(*) From Tbl_Product where ProductTitle like '%Daire%'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public decimal AverageProductPriceByRent()//Kiralık isimli yerlerin ortalama fiyatını hesaplar (Swagger hata verirse Sql i yönetici olarak çalıştırıp Opsions lardan Turkish_CI_AS ı seç)
        {
            string query = "Select Avg(ProductPrice) From Tbl_Product where ProductType='Kiralık'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public decimal AverageProductPriceBySale()//Satılık isimli yerlerin ortalama fiyatını hesaplar
        {
            string query = "Select Avg(ProductPrice) From Tbl_Product where ProductType='Satılık'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public int AverageRoomCount()
        {
            string query = "Select Avg(RoomCount) From Tbl_ProductDetails";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }
        public int CategoryCount()
        {
            string query = "Select Count(*) From Tbl_Category"; 
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string CategoryNameByMaxProductCount()
        {
            string query = "Select top(1) CategoryName,Count(*) From Tbl_Product inner join Tbl_Category On Tbl_Product.ProductCategory = CategoryID Group By CategoryName order by Count(*) Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public string CityNameByMaxProductCount()
        {

            string query = "Select top(1) ProductCity,Count(*) as 'ilan_sayısı' From Tbl_Product Group By ProductCity order by ilan_sayısı Desc ";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public int DifferentCityCount()//Kaç farklı şehir olduğun sayı cinsinden gösterir
        {
            string query = "Select Count(Distinct(ProductCity)) From Tbl_Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string EmployeeNameByMaxProductCount()
        {
            string query = "Select EmployeeName,Count(*)'Product_Count' From Tbl_Product Inner Join Tbl_Employee On Tbl_Product.EmployeeID=Tbl_Employee.EmployeeID Group By EmployeeName Order By Product_Count Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public decimal LastProductPrice()
        {
            string query = "Select top(1) ProductPrice From Tbl_Product Order By ProductID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int NewstBuildingYear()
        {
            string query = "Select top(1) BuildYear From Tbl_ProductDetails Order By BuildYear Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int OldersBuildingYear()
        {
            string query = "Select top(1) BuildYear From Tbl_ProductDetails Order By BuildYear Asc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }
        public int PassiveCategoryCount()
        {
            string query = "Select Count(*) From Tbl_Category Where CategoryStatus = 0";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }
        public int ProductCount()
        {
            string query = "Select Count(*) From Tbl_Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

    }
}