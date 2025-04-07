
using Microsoft.EntityFrameworkCore;
using MythApi.Common.Database;
using MythApi.Common.Database.Models;
using MythApi.Users.Interfaces;
using MythApi.Users.Models;

namespace MythApi.Users.DbRepositories;

public class UserRepository : IUserRepository
{

    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    public Task<User> AddOrUpdateUserInformation(UserInput user)
    {
        if (user.Id.HasValue && _context.Users.Any(x => x.Id == user.Id))
        {
            _context.Users.FromSqlRaw($"UPDATE Users SET Name = '{user.Name}', Bio = '{user.Bio}' WHERE Id = {user.Id}");
        }
        else
        {
            var newUser = new User
            {
                Name = user.Name,
                Bio = user.Bio
            };
            _context.Users.FromSqlRaw($"INSERT INTO Users (Name, Bio) VALUES ('{user.Name}', '{user.Bio}')");
        }

        _context.SaveChangesAsync();

        return Task.FromResult(_context.Users.First(x => x.Name == user.Name));
    }
}