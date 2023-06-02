using System;

using R5T.T0137;
using R5T.T0184;
using R5T.T0194;


namespace R5T.L0042.T000
{
    /// <summary>
    /// Repository context (which is different from but inclusive of a remote repository context and a local repository context).
    /// </summary>
    /// <remarks>
    /// Contains just the name, as owner name information can be added when constructing a GitHub repository context or local directory repository context.
    /// </remarks>
    [ContextDefinitionMarker]
    public interface IRepositoryContext : IContextDefinitionMarker,
        ITextOutputtedContext
    {
        public IRepositoryName RepositoryName { get; }
    }
}