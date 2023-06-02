using System;


namespace R5T.L0042.O001
{
    public class RepositoryContextOperator : IRepositoryContextOperator
    {
        #region Infrastructure

        public static IRepositoryContextOperator Instance { get; } = new RepositoryContextOperator();


        private RepositoryContextOperator()
        {
        }

        #endregion
    }
}
