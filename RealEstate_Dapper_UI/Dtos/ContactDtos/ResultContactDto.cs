﻿namespace RealEstate_Dapper_UI.Dtos.ContactDtos
{
    public class ResultContactDto
    {
        public int ContactID { get; set; }
        public string ContactName{ get; set; }
        public string ContactSubject { get; set; }
        public string ContactEmail{ get; set; }
        public string ContactMessage{ get; set; }
        public DateTime ContactSendDate { get; set; }
    }
}
