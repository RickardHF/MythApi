
using System.Text.Encodings.Web;
using MythApi.Common.Database.Models;
using MythApi.Users.Interfaces;
using MythApi.Users.Models;

namespace MythApi.Endpoints.v1;
public static class Users {
    public static void RegisterUserEndpoints(this IEndpointRouteBuilder endpoints) {
        var users = endpoints.MapGroup("/api/v1/users");

        users.MapPost("", AddOrUpdateUserInformation);
    }
    public static Task<User> AddOrUpdateUserInformation(UserInput user, IUserRepository repository) {
        user.Name = HtmlEncoder.Default.Encode(user.Name);
        user.Bio = HtmlEncoder.Default.Encode(user.Bio);
        return repository.AddOrUpdateUserInformation(user);
    }
}