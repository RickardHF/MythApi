using MythApi.Common.Database.Models;
using MythApi.Users.Models;

namespace MythApi.Users.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddOrUpdateUserInformation(UserInput userInput);
    }
}