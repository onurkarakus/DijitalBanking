namespace DigitalBanking.Common.Interfaces.Entity;

/// <summary>Entity Interface</summary>
/// <typeparam name="TId">The type of the identifier.</typeparam>
public interface IEntity<TId> : IEntity
{
    public TId Id { get; set; }
}

/// <summary>Entity Interface</summary>
public interface IEntity
{

}
