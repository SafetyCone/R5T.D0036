using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D0036.D0037;
using R5T.D0037;
using R5T.D0037.Standard;
using R5T.D0038;
using R5T.D0046;

using R5T.Dacia;
using R5T.Polidea;


namespace R5T.D0036.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ISourceControlOperator"/> service.
        /// </summary>
        public static
            (
            IServiceAction<ISourceControlOperator> Main,
            (
            IServiceAction<IGitOperator> Main,
            IServiceAction<ILibGit2SharpOperator> libGit2SharpOperatorAction,
            (
            IServiceAction<IGitAuthenticationProvider> Main,
            IServiceAction<IGitHubAuthenticationProvider> gitHubAuthenticationProviderAction
            ) GitAuthenticationProviderAction
            ) GitOperatorAction
            )
        AddSourceControlOperatorAction(this IServiceCollection services)
        {
            var gitOperatorAction = services.AddGitOperatorAction();

            var sourceControlOperatorAction = services.AddGitBasedSourceControlOperatorAction(gitOperatorAction.Main);

            return
                (
                sourceControlOperatorAction,
                gitOperatorAction
                );
        }

        /// <summary>
        /// Adds the <see cref="ISourceControlOperator"/> service.
        /// </summary>
        public static IServiceCollection AddSourceControlOperator(this IServiceCollection services)
        {
            var sourceControlOperatorAction = services.AddSourceControlOperatorAction();

            services.Run(sourceControlOperatorAction.Main);

            return services;
        }
    }
}
