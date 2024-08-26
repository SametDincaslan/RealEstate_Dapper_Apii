using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using Dapper;
namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepositroy : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepositroy(Context context)
        {
            _context = context;
        }

        public async void CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "insert into Tbl_Category(CategoryName,CategoryStatus) values(@categoryName,@categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);
            using (var connection = _context.CreateConnection())
            { 
                await connection.ExecuteAsync(query, parameters);            
            }

        }

        public async void DeleteCategory(int id)
        {
            string query = "Delete From Tbl_Category Where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID",id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From Tbl_Category";
            using (var connection = _context.CreateConnection())
            {
                var values=await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDCategoryDto> GetCategory(int id)
        {
            string query = "Select * From Tbl_Category Where CategoryID=@CategoryID";
            var parameters=new DynamicParameters();
            parameters.Add("@CategoryID",id);
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDCategoryDto>(query,parameters);
                return values;
            }

        }

        public async void UpdateCategory(UpdateCategoryDto categoryDto)
        {
            string query = "Update Tbl_Category Set CategoryName=@categoryName,CategoryStatus=@categoryStatus where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus",categoryDto.CategoryStatus);
            parameters.Add("@categoryID", categoryDto.CategoryID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters); 
            }
        }
    }
}
