namespace RealEstate_Dapper_Api.Dtos.ContactDtos
{
    public class GetByIDContactDto
    {
        public int ContactID { get; set; }
        public string ContactName { get; set; }
        public string ContactSubject { get; set; }
        public string ContactEmail { get; set; }
        public string ContactMessage { get; set; }
        public DateTime ContactSendDate { get; set; }
    }
}
