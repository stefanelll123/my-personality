using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MyPersonality.Identity.Domain;
using MyPersonality.Identity.Interop.Repositories;

namespace MyPersonality.Identity.DataAccess.Adapters.Repositories;

internal sealed class UsersRepository : IUsersRepository
{
    private readonly DatabaseContext _context;

    public UsersRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    public Task<Maybe<User?>> GetUser(string email, string passwordHash)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email.ToString() == email && u.PasswordHash == passwordHash);
        return Task.FromResult(Maybe<User?>.From(user));
    }
}