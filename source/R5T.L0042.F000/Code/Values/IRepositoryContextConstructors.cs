using System;

using R5T.T0131;
using R5T.T0159;
using R5T.T0184;

using R5T.L0042.T000;


namespace R5T.L0042.F000
{
    [ValuesMarker]
    public partial interface IRepositoryContextConstructors : IValuesMarker
    {
        public Func<IRepositoryContext> Default(
            IRepositoryName repositoryName,
            ITextOutput textOutput)
        {
            return () => new RepositoryContext
            {
                RepositoryName = repositoryName,
                TextOutput = textOutput,
            };
        }
    }
}
