using System;
using System.Threading.Tasks;

using R5T.T0010;


namespace R5T.D0036
{
    public interface ISourceControlOperator
    {
        /// <summary>
        /// Gets the remote repository URL for a file or directory path within a local repository.
        /// </summary>
        Task<RemoteRepositoryUrl> GetRemoteRepositoryUrlAsync(LocalRepositoryContainedPath path);

        /// <summary>
        /// Gets the latest revision for the local repository containing the file or directory path, *not* the file or directory itself.
        /// </summary>
        Task<RevisionIdentity> GetLatestLocalRepositoryRevision(LocalRepositoryContainedPath path);

        /// <summary>
        /// Determines whether a local copy of a repository has changes that have not been added to the remote repository.
        /// This could happen due to:
        /// * Untracked local files.
        /// * Unstaged or uncommitted changes.
        /// * Committed changes, but committed changes that have not been pushed to the remote repository.
        /// </summary>
        Task<bool> HasLocalChangesNotInRemote(LocalRepositoryDirectoryPath repositoryDirectoryPath);

        /// <summary>
        /// Determines whether a local copy of a repository is missing changes that exist in the remote repository.
        /// </summary>
        Task<bool> HasRemoteChangesNotInLocal(LocalRepositoryDirectoryPath repositoryDirectoryPath);
    }
}
