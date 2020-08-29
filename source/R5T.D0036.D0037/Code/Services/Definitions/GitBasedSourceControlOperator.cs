using System;
using System.Threading.Tasks;

using R5T.D0037;
using R5T.T0010;


namespace R5T.D0036.D0037
{
    public class GitBasedSourceControlOperator : ISourceControlOperator
    {
        private IGitOperator GitOperator { get; }


        public GitBasedSourceControlOperator(IGitOperator gitOperator)
        {
            this.GitOperator = gitOperator;
        }

        public Task<RevisionIdentity> GetLatestLocalRepositoryRevision(LocalRepositoryContainedPath path)
        {
            var gettingLatestLocalMasterRevision = this.GitOperator.GetLatestLocalMasterRevision(path);
            return gettingLatestLocalMasterRevision;
        }

        public Task<RemoteRepositoryUrl> GetRemoteRepositoryUrlAsync(LocalRepositoryContainedPath path)
        {
            var gettingOriginRepositoryUrl = this.GitOperator.GetOriginRepositoryUrlAsync(path);
            return gettingOriginRepositoryUrl;
        }

        public Task<bool> HasLocalChangesNotInRemote(LocalRepositoryDirectoryPath repositoryDirectoryPath)
        {
            var gettingHasUnpushedLocalChanges = this.GitOperator.HasUnpushedLocalChanges(repositoryDirectoryPath);
            return gettingHasUnpushedLocalChanges;
        }

        public Task<bool> HasRemoteChangesNotInLocal(LocalRepositoryDirectoryPath repositoryDirectoryPath)
        {
            // Perform a fetch first to ensure our local is actually aware of what has occurred remotely.
            this.GitOperator.Fetch(repositoryDirectoryPath);

            var gettingHasRemoteChangesNotInLocal = this.GitOperator.HasUnpulledOriginMasterChanges(repositoryDirectoryPath);
            return gettingHasRemoteChangesNotInLocal;
        }
    }
}
