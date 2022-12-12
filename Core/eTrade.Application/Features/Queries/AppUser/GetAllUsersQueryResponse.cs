namespace eTrade.Application.Features.Queries.AppUser
{
    public class GetAllUsersQueryResponse
    {
        public object Users { get; set; }
        public int TotalUserCount { get; set; }
    }
}