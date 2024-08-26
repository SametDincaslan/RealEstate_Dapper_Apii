using Dapper;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync()
        {
            string query = "Select * From Tbl_PopularLocation";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDto>(query);
                return values.ToList();
            }
        }
        public async void CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            string query = "insert into Tbl_PopularLocation (PopularLocationCityName,PopularLocationImageUrl ) values (@popularLocationCityName,@popularLocationImageUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("@popularLocationCityName", createPopularLocationDto.PopularLocationCityName);
            parameters.Add("@popularLocationImageUrl",createPopularLocationDto.PopularLocationImageUrl);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeletePopularLocation(int id)
        {
            string query = "Delete From Tbl_PopularLocation Where PopularLocationID=@popularLocationID";
            var parameters = new DynamicParameters();
            parameters.Add("@popularLocationID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultPopularLocationDto>> GetResultPopularLocationDtosAsync()
        {
            string query = "Select * From Tbl_PopularLocation";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDto>(query);
                return values.ToList();
            }
        }
        public async Task<GetByPopularLocationDto> GetByPopularLocationDto(int id)
        {
            string query = "Select * From Tbl_PopularLocation Where PopularLocationID=@PopularLocationID";
            var parameters = new DynamicParameters();
            parameters.Add("@popularLocationID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByPopularLocationDto>(query, parameters);
                return values;
            }
        }

        public async void UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            string query = "Update Tbl_PopularLocation Set PopularLocationCityName=@popularLocationCityName,PopularLocationImageUrl=@PopularLocationImageUrl WHERE PopularLocationID=@popularLocationID";
            var parameters = new DynamicParameters();
            parameters.Add("@popularLocationCityName", updatePopularLocationDto.PopularLocationCityName);
            parameters.Add("@popularLocationImageUrl", updatePopularLocationDto.PopularLocationImageUrl);
            parameters.Add("@popularLocationID", updatePopularLocationDto.PopularLocationID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
