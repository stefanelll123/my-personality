using System.Collections.Generic;
using MyPersonality.Identity.Domain;
using MyPersonality.Identity.Domain.ValueObjects;

namespace MyPersonality.Identity.DataAccess.Adapters;

internal sealed class DatabaseContext
{
    public List<User> Users { get; }
    
    public DatabaseContext()
    {
        var user1 = new User("Stefan", "Turcu",
            new Email("stefan", "gmail.com"), "stefan", "ecd71870d1963316a97e3ac3408c9835ad8cf0f3c1bc703527c30265534f75ae");
        
        Users = new List<User> {user1};
    }
}