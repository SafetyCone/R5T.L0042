using System;


namespace R5T.L0042.O001
{
    public static class Instances
    {
        public static F0000.IActionOperator ActionOperator => F0000.ActionOperator.Instance;
        public static F0041.IGitHubOperator GitHubOperator => F0041.GitHubOperator.Instance;
        public static L0036.IGitHubRepositoryContextOperator GitHubRepositoryContextOperator => L0036.GitHubRepositoryContextOperator.Instance;
        public static F0042.ILocalRepositoryOperator LocalRepositoryOperator => F0042.LocalRepositoryOperator.Instance;
        public static L0047.F000.ILocalGitRepositoryContextOperator LocalGitRepositoryContextOperator => L0047.F000.LocalGitRepositoryContextOperator.Instance;
        public static IRepositoryContextOperator RepositoryContextOperator => O001.RepositoryContextOperator.Instance;
    }
}