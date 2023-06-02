using System;

using R5T.T0131;

using R5T.L0042.T000;


namespace R5T.L0042.F000
{
    [ValuesMarker]
    public partial interface IRepositoryContextDestructors : IValuesMarker
    {
        public Action<IRepositoryContext> Default => Instances.ActionOperations.DoNothing_Synchronous;
    }
}
