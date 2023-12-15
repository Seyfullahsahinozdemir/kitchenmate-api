using System.Collections.Generic;
using CleanArchitecture.Core.DTOs.Account;
using CleanArchitecture.Core.Wrappers;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);
        Task<Response<string>> ConfirmEmailAsync(string userId, string code);
        Task ForgotPassword(ForgotPasswordRequest model, string origin);
        Task<Response<string>> ResetPassword(ResetPasswordRequest model);
        Task<Response<string>> SetRoles(string userId, string role);
        Task<IList<GetAllAccountsResponse>> GetAllAccountsAsync();
        Task ChangeActivateUser(string userId); 
        Task UpdateUser(string userId, string firstName, string lastName, string email, string role);
    }
}
