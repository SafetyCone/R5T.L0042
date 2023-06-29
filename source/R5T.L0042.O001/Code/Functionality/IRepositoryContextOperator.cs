using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;
using R5T.T0184;

using R5T.L0042.T000;


namespace R5T.L0042.O001
{
    [FunctionalityMarker]
    public partial interface IRepositoryContextOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Verifies that a repository name is available on both GitHub and in the local file system.
        /// </summary>
        public async Task Verify_DoesNotAlreadyExist(
            IRepositoryContext context,
            IRepositoryOwnerName ownerName)
        {
            // GitHub.
            var gettingExistsOnGitHub = Instances.GitHubOperator.RepositoryExists(
                ownerName.Value,
                context.RepositoryName.Value);

            // Local.
            var existsInLocal = Instances.LocalRepositoryOperator.RepositoryExists(
                ownerName.Value,
                context.RepositoryName.Value);

            var existsOnGitHub = await gettingExistsOnGitHub;

            var exists = existsOnGitHub || existsInLocal;
            if (exists)
            {
                throw new Exception($"{ownerName.Value}/{context.RepositoryName.Value}: GitHub repository already exists.");
            }
        }

        /// <summary>
        /// Wraps operations in output messages indicating that a repository is being created.
        /// </summary>
        public Task In_CreateRepositoryContext<TRepositoryContext>(
            TRepositoryContext repositoryContext,
            IEnumerable<Func<TRepositoryContext, Task>> operations = default)
            where TRepositoryContext : IRepositoryContext
        {
            return Instances.ActionOperator.Run(
                repositoryContext,
                    // Need to handle default (null) value for the input, since prepend will require a non-null value.
                    Instances.EnumerableOperator.EmptyIfNull(operations)
                    .Prepend(
                        _ =>
                        {
                            repositoryContext.TextOutput.WriteInformation($"Creating repository {repositoryContext.RepositoryName}...");

                            return Task.CompletedTask;
                        })
                    .Append(
                        _ =>
                        {
                            repositoryContext.TextOutput.WriteInformation($"Created repository {repositoryContext.RepositoryName}.");

                            return Task.CompletedTask;
                        }));
        }

        /// <inheritdoc cref="In_CreateRepositoryContext{TRepositoryContext}(TRepositoryContext, IEnumerable{Func{TRepositoryContext, Task}})"/>
        public Task In_CreateRepositoryContext<TRepositoryContext>(
            TRepositoryContext repositoryContext,
            params Func<TRepositoryContext, Task>[] operations)
            where TRepositoryContext : IRepositoryContext
        {
            return this.In_CreateRepositoryContext(
                repositoryContext,
                operations.AsEnumerable());
        }
    }
}
