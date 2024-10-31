namespace DotNaut.Data;

/// <summary>
/// Entity interface
/// </summary>
/// 
/// <typeparam name="TEntity">
/// The base entity type this representation relates to.
/// </typeparam>
/// 
/// <remarks>
/// <para>
///     Defines a contract for types that represent different views or forms of an entity
///     <paramref name="TEntity"/>. This interface is used to establish relationships
///     between domain entities and their corresponding DTOs, view models, or other
///     representations while maintaining type safety and explicit connection to the base
///     entity type.
/// </para>
/// 
/// TODO:Tools to implement mappings between different representations of the same entity.
/// </remarks>
/// 
/// <example>
/// <code>
/// public class User { }  // Domain entity
/// 
/// public class CreateUserRequest : IEntity&lt;User&gt;
/// {
///     public string Email { get; set; }
///     public string Password { get; set; }
/// }
/// 
/// public class UserProfileViewModel : IEntity&lt;User&gt;
/// {
///     public string DisplayName { get; set; }
///     public string Email { get; set; }
/// }
/// </code>
/// </example>
public interface IEntity<TEntity>
{
    
}
