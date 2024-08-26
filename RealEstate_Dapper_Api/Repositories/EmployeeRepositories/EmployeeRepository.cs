using Dapper;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }
        public async void CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            string query = "insert into Tbl_Employee(EmployeeName,EmployeeTitle,EmployeeMail,EmployeePhoneNumber,EmployeeImageUrl,EmployeeStatus) values" +
                "(@employeeName,@employeeTitle,@employeeMail,@employeePhoneNumber,@employeeImageUrl,@employeeStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeName", createEmployeeDto.EmployeeName);
            parameters.Add("@employeeTitle", createEmployeeDto.EmployeeTitle);
            parameters.Add("@employeeMail", createEmployeeDto.EmployeeMail);
            parameters.Add("@employeePhoneNumber", createEmployeeDto.EmployeePhoneNumber);
            parameters.Add("@employeeImageUrl", createEmployeeDto.EmployeeImageUrl);
            parameters.Add("@employeeStatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteEmployee(int id)
        {
            string query = "Delete From Tbl_Employee Where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
        {
            string query = "Select * From Tbl_Employee";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDEmployeeDto> GetEmployee(int id)
        {
            string query = "Select * From Tbl_Employee Where EmployeeID=@EmployeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@EmployeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDEmployeeDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            string query = "Update Tbl_Employee Set EmployeeName=@employeeName,EmployeeTitle=@employeeTitle,EmployeeMail=@employeeMail,EmployeePhoneNumber=@employeePhoneNumber," +
                "EmployeeImageUrl=@employeeImageUrl,EmployeeStatus=@employeeStatus where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeName", updateEmployeeDto.EmployeeName);
            parameters.Add("@employeeTitle", updateEmployeeDto.EmployeeTitle);
            parameters.Add("@employeeMail", updateEmployeeDto.EmployeeMail);
            parameters.Add("@employeePhoneNumber", updateEmployeeDto.EmployeePhoneNumber);
            parameters.Add("@employeeImageUrl", updateEmployeeDto.EmployeeImageUrl);
            parameters.Add("@employeeStatus", updateEmployeeDto.EmployeeStatus);
            parameters.Add("@employeeID", updateEmployeeDto.EmployeeID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
