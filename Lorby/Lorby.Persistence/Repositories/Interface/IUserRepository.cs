using System.Linq.Expressions;
using Domain.Entities;

namespace Persistence.Repositories.Interface;

public interface IUserRepository
{
    /// <summary>
    /// Retrieves a collection of products based on an optional predicate and query options.
    /// </summary>
    /// <param name="predicate">Optional predicate to filter products.</param>
    /// <param name="queryOptions">Query options for sorting, paging, etc.</param>
    /// <returns>An IQueryable representing the collection of products.</returns>
    IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default);

    /// <summary>
    /// Asynchronously retrieves a single product by its unique identifier.
    /// </summary>
    /// <param name="productId">The unique identifier of the product.</param>
    /// <param name="queryOptions">Query options for sorting, paging, etc.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation that yields the product, or null if not found.</returns>
    ValueTask<User?> GetByIdAsync(Guid productId,
                                      CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously retrieves a collection of products by their unique identifiers.
    /// </summary>
    /// <param name="ids">The unique identifiers of the products.</param>
    /// <param name="queryOptions">Query options for sorting, paging, etc.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation that yields the collection of products.</returns>
    ValueTask<IList<User>> GetByIdsAsync(IEnumerable<Guid> ids,
                                            CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously creates a new product in the repository.
    /// </summary>
    /// <param name="product">The product to be created.</param>
    /// <param name="commandOptions">Command options for the creation operation.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation that yields the created product.</returns>
    ValueTask<User> CreateAsync(User user,
                                    CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously updates an existing product in the repository.
    /// </summary>
    /// <param name="product">The product to be updated.</param>
    /// <param name="commandOptions">Command options for the update operation.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation that yields the updated product.</returns>
    ValueTask<User> UpdateAsync(User user,
                                    CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously deletes a product from the repository by its unique identifier.
    /// </summary>
    /// <param name="productId">The unique identifier of the product to be deleted.</param>
    /// <param name="commandOptions">Command options for the deletion operation.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation that yields the deleted product, or null if not found.</returns>
    ValueTask<User?> DeleteByIdAsync(Guid productId,
                                         CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously deletes a product from the repository.
    /// </summary>
    /// <param name="product">The product to be deleted.</param>
    /// <param name="commandOptions">Command options for the deletion operation.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation that yields the deleted product, or null if not found.</returns>
    ValueTask<User?> DeleteAsync(User user,
                                     CancellationToken cancellationToken = default);

}