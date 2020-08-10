using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D0037;

using R5T.Dacia;


namespace R5T.D0036.D0037
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="GitBasedSourceControlOperator"/> implementation of <see cref="ISourceControlOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddGitBasedSourceControlOperator(this IServiceCollection services,
            IServiceAction<IGitOperator> gitOperatorAction)
        {
            services
                .AddSingleton<ISourceControlOperator, GitBasedSourceControlOperator>()
                .Run(gitOperatorAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="GitBasedSourceControlOperator"/> implementation of <see cref="ISourceControlOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ISourceControlOperator> AddGitBasedSourceControlOperatorAction(this IServiceCollection services,
            IServiceAction<IGitOperator> gitOperatorAction)
        {
            var serviceAction = ServiceAction.New<ISourceControlOperator>(() => services.AddGitBasedSourceControlOperator(
                gitOperatorAction));

            return serviceAction;
        }
    }
}
