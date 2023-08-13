using System;


namespace R5T.L0042.O001
{
    public class RepositoryContextOperationSets : IRepositoryContextOperationSets
    {
        #region Infrastructure

        public static IRepositoryContextOperationSets Instance { get; } = new RepositoryContextOperationSets();


        private RepositoryContextOperationSets()
        {
        }

        #endregion
    }
}
