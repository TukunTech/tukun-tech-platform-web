using System.Text.Json.Serialization;

namespace tukun_tech_platform.IAM.Domain.Model.Aggregates;

public class User (string username, string passwordHash)
{
    public User() : this(string.Empty, string.Empty) { }
    
    public int Id { get; }
    public string Username { get; private set; } = username;

    [JsonIgnore] public string PasswordHash { get; private set; } = passwordHash;

    public User UpdateUsername(string newUsername)
    {
        Username = username;
        return this;
    }

    public User UpdatePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
        return this;
    }
}