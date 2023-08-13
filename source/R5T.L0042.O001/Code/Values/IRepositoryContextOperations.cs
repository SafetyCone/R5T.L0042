using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.L0047.T000;
using R5T.T0131;
using R5T.T0184;
using R5T.T0186;
using R5T.T0186.Extensions;
using R5T.T0222;

using R5T.L0042.T000;

namespace R5T.L0042.O001
{
    [ValuesMarker]
    public partial interface IRepositoryContextOperations : IValuesMarker
    {
        /// <inheritdoc cref="IRepositoryContextOperator.In_CreateRepositoryContext{TRepositoryContext}(TRepositoryContext, Func{TRepositoryContext, Task}[])"/>
        public Func<TRepositoryContext, Task> In_CreateRepositoryContext<TRepositoryContext>(
            IEnumerable<Func<TRepositoryContext, Task>> operations = default)
            where TRepositoryContext : IRepositoryContext
            =>
                context => Instances.RepositoryContextOperator.In_CreateRepositoryContext(
                    context,
                    operations);

        /// <inheritdoc cref="IRepositoryContextOperator.In_CreateRepositoryContext{TRepositoryContext}(TRepositoryContext, Func{TRepositoryContext, Task}[])"/>
        public Func<TRepositoryContext, Task> In_CreateRepositoryContext<TRepositoryContext>(
            params Func<TRepositoryContext, Task>[] operations)
            where TRepositoryContext : IRepositoryContext
            =>
                context => Instances.RepositoryContextOperator.In_CreateRepositoryContext(
                    context,
                    operations);

        /// <inheritdoc cref="IRepositoryContextOperator.Verify_DoesNotAlreadyExist(IRepositoryContext, IRepositoryOwnerName)"/>
        public Func<IRepositoryContext, Task> Verify_DoesNotAlreadyExist(IRepositoryOwnerName ownerName)
        {
            return context => Instances.RepositoryContextOperator.Verify_DoesNotAlreadyExist(
                context,
                ownerName);
        }

        public Func<IRepositoryContext, Task> Verify_DoesNotAlreadyExist(
            IOrganizationName organizationName)
        {
            return context => Instances.RepositoryContextOperator.Verify_DoesNotAlreadyExist(
                context,
                organizationName);
        }

        public Func<IRepositoryContext, Task> In_GitHubRepositoryContext(
            IGitHubRepositoryName repositoryName,
            IGitHubRepositoryOwnerName ownerName,
            params Func<L0036.T000.N001.IGitHubRepositoryContext, Task>[] operations)
            =>
                context => Instances.GitHubRepositoryContextOperator.In_GitHubRepositoryContext(
                    repositoryName,
                    ownerName,
                    context.TextOutput,
                    operations);

        public Func<IRepositoryContext, Task> In_GitHubRepositoryContext(
            IGitHubRepositoryOwnerName ownerName,
            params Func<L0036.T000.N001.IGitHubRepositoryContext, Task>[] operations)
            =>
                context => Instances.GitHubRepositoryContextOperator.In_GitHubRepositoryContext(
                    context.RepositoryName.Value.ToGitHubRepositoryName(),
                    ownerName,
                    context.TextOutput,
                    operations);

        public Func<IRepositoryContext, Task> In_GitHubRepositoryContext(
            IOrganizationName organizationName,
            params Func<L0036.T000.N001.IGitHubRepositoryContext, Task>[] operations)
        {
            Task Internal(IRepositoryContext context)
            {
                var gitHubRepositoryName = context.RepositoryName.ToGitHubRepositoryName();
                var gitHubRepositoryOwnerName = Instances.OrganizationNameOperator.Get_GitHubRepositoryOwnerName(organizationName);

                return Instances.GitHubRepositoryContextOperator.In_GitHubRepositoryContext(
                    gitHubRepositoryName,
                    gitHubRepositoryOwnerName,
                    context.TextOutput,
                    operations);
            }

            return Internal;
        }

        public Func<IRepositoryContext, Task> In_LocalGitRepositoryContext(
            IGitHubRepositoryName repositoryName,
            IGitHubRepositoryOwnerName ownerName,
            params Func<ILocalGitRepositoryContext, Task>[] operations)
            =>
                context => Instances.LocalGitRepositoryContextOperator.In_LocalGitRepositoryContext(
                    context,
                    repositoryName,
                    ownerName,
                    operations);

        public Func<IRepositoryContext, Task> In_LocalGitRepositoryContext(
            IOrganizationName organizationName,
            params Func<ILocalGitRepositoryContext, Task>[] operations)
        {
            Task Internal(IRepositoryContext context)
            {
                var gitHubRepositoryName = context.RepositoryName.ToGitHubRepositoryName();
                var gitHubRepositoryOwnerName = Instances.OrganizationNameOperator.Get_GitHubRepositoryOwnerName(organizationName);

                return Instances.LocalGitRepositoryContextOperator.In_LocalGitRepositoryContext(
                    context,
                    gitHubRepositoryName,
                    gitHubRepositoryOwnerName,
                    operations);
            }

            return Internal;
        }

        public Func<IRepositoryContext, Task> In_LocalGitRepositoryContext(
            IGitHubRepositoryOwnerName gitHubRepositoryOwnerName,
            params Func<ILocalGitRepositoryContext, Task>[] operations)
        {
            Task Internal(IRepositoryContext context)
            {
                var gitHubRepositoryName = context.RepositoryName.ToGitHubRepositoryName();

                return Instances.LocalGitRepositoryContextOperator.In_LocalGitRepositoryContext(
                    context,
                    gitHubRepositoryName,
                    gitHubRepositoryOwnerName,
                    operations);
            }

            return Internal;
        }
    }
}
