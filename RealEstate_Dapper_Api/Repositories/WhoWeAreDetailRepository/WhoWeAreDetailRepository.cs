using Dapper;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreDetailRepository
{
    public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
    {
        private readonly Context _context;

        public WhoWeAreDetailRepository(Context context)
        {
            _context = context;
        }
        public async void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            string query = "insert into Tbl_WhoWeAreDetail (WhoWeAreTitle,WhoWeAreSubTitle,WhoWeAreDescription1,WhoWeAreDescription2) " +
                "values (@whoWeAreTitle,@whoWeAreSubTitle,@whoWeAreDescription1,@whoWeAreDescription2)";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreTitle", createWhoWeAreDetailDto.WhoWeAreTitle);
            parameters.Add("@whoWeAreSubTitle", createWhoWeAreDetailDto.WhoWeAreSubTitle);
            parameters.Add("@whoWeAreDescription1", createWhoWeAreDetailDto.WhoWeAreDescription1);
            parameters.Add("@whoWeAreDescription2", createWhoWeAreDetailDto.WhoWeAreDescription1);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteWhoWeAreDetail(int id)
        {
            string query = "Delete From Tbl_WhoWeAreDetail Where WhoWeAreID=@whoWeAreID";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
        {
            string query = "Select * From Tbl_WhoWeAreDetail";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
                return values.ToList();
            }
        }

        public  async Task<GetByIDWhoWeAreDetailDto> GetWhoWeAreDetail(int id)
        {
            string query = "Select * From Tbl_WhoWeAreDetail Where WhoWeAreID=@whoWeAreID";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDWhoWeAreDetailDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            string query = "Update Tbl_WhoWeAreDetail Set WhoWeAreTitle=@whoWeAreTitle,WhoWeAreSubTitle=@whoWeAreSubTitle,WhoWeAreDescription1=@whoWeAreDescription1,WhoWeAreDescription2=@whoWeAreDescription2 WHERE WhoWeAreID=@whoWeAreID";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreTitle", updateWhoWeAreDetailDto.WhoWeAreTitle);
            parameters.Add("@whoWeAreSubTitle", updateWhoWeAreDetailDto.WhoWeAreSubTitle);
            parameters.Add("@whoWeAreDescription1", updateWhoWeAreDetailDto.WhoWeAreDescription1);
            parameters.Add("@whoWeAreDescription2", updateWhoWeAreDetailDto.WhoWeAreDescription1);
            parameters.Add("@whoWeAreID", updateWhoWeAreDetailDto.WhoWeAreID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
