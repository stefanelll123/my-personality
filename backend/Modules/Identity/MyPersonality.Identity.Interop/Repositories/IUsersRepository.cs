using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MyPersonality.Identity.Domain;

namespace MyPersonality.Identity.Interop.Repositories;

public interface IUsersRepository
{
    Task<Maybe<User?>> GetUser(string email, string passwordHash);
}