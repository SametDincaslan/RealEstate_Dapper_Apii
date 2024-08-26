using Dapper;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }
        public async void CreateContact(CreateContactDto createContactDto)
        {
            string query = "insert into Tbl_Contact(ContactName,ContactSubject,ContactEmail,ContactMessage,ContactSendDate) values" +
                "(@ContactName,@ContactSubject,@contactEmail,@contactMessage,@contactSendDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@contactName", createContactDto.ContactName);
            parameters.Add("@contactSubject", createContactDto.ContactSubject);
            parameters.Add("@contactEmail", createContactDto.ContactEmail);
            parameters.Add("@contactMessage", createContactDto.ContactMessage);
            parameters.Add("@contactSendDate", createContactDto.ContactSendDate.ToString("dd-MMM-yyyy"));
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteContact(int id)
        {
            string query = "Delete From Tbl_Contact Where ContactID=@contactID";
            var parameters = new DynamicParameters();
            parameters.Add("@contactID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            string query = "Select * From Tbl_Contact";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultContactDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDContactDto> GetByIDContactDto(int id)
        {
            string query = "Select * From Tbl_Contact Where ContactID=@contactID";
            var parameters = new DynamicParameters();
            parameters.Add("@contactID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDContactDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<Last4ContactResultDto>> GetLast4Contact()
        {
            string query = "Select Top(4) * From Tbl_Contact Order By ContactID Desc     ";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<Last4ContactResultDto>(query);
                return values.ToList();
            }

        }
    }
}
