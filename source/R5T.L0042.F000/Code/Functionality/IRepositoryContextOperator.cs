using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;
using R5T.T0159;
using R5T.T0184;

using R5T.L0042.T000;


namespace R5T.L0042.F000
{
    [FunctionalityMarker]
    public partial interface IRepositoryContextOperator : IFunctionalityMarker
    {
        public Task In_RepositoryContext(
            IRepositoryName repositoryName,
            ITextOutput textOutput,
            IEnumerable<Func<IRepositoryContext, Task>> operations)
        {
            return Instances.ContextOperator.In_Context(
                Instances.RepositoryContextConstructors.Default(
                    repositoryName,
                    textOutput),
                operations,
                Instances.RepositoryContextDestructors.Default);
        }

        public Task In_RepositoryContext(
            IRepositoryName repositoryName,
            ITextOutput textOutput,
            params Func<IRepositoryContext, Task>[] operations)
        {
            return this.In_RepositoryContext(
                repositoryName,
                textOutput,
                operations.AsEnumerable());
        }
    }
}
