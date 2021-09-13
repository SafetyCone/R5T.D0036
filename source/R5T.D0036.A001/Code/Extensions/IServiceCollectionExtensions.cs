using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Magyar;
using R5T.Suebia;

using R5T.D0036.D0037;
using R5T.D0037.A002;
using R5T.D0082.D001;


namespace R5T.D0036.A001
{
    public static class IServiceCollectionExtensions
    {
        public static ServiceAggregation AddGitBasedSourceControlOperatorServiceActions(this IServiceCollection services,
            IServiceAction<IGitHubAuthenticationProvider> gitHubAuthenticationProviderAction,
            IServiceAction<ISecretsDirectoryFilePathProvider> secretsDirectoryFilePathProviderAction)
        {
            var gitOperatorServices = services.AddGitOperatorServices(
                gitHubAuthenticationProviderAction,
                secretsDirectoryFilePathProviderAction);

            var sourceControlOperatorAction = services.AddGitBasedSourceControlOperatorAction(
                gitOperatorServices.GitOperatorAction);

            return new ServiceAggregation()
                .As<ServiceAggregation, IServiceAggregationIncrement>(increment =>
                {
                    increment.SourceControlOperatorAction = sourceControlOperatorAction;
                })
                .FillFrom(gitOperatorServices)
                ;
        }
    }
}
