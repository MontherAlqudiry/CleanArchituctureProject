namespace Application.Core.Features.ApplicationUserCore.Queries.Responses
{
    public class GetApplicationUserByIdResponse
    {
        public string Fullname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumer { get; set; }

    }
}
