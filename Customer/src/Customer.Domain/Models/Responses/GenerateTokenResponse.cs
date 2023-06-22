namespace Customer.Domain.Models.Responses;

public class GenerateTokenResponse
{
    public string Token { get; set; }
    public DateTime TokenExpireDate { get; set; }
}