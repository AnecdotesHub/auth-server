namespace Jevstafjev.Anecdotes.AuthServer.Domain.Base;

public class Identity : IHaveId
{
    public Guid Id { get; set; }
}
