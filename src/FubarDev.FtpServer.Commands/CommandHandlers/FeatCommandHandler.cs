//-----------------------------------------------------------------------
// <copyright file="FeatCommandHandler.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using FubarDev.FtpServer.Commands;

using Microsoft.Extensions.DependencyInjection;

namespace FubarDev.FtpServer.CommandHandlers
{
    /// <summary>
    /// Implements the <c>FEAT</c> command.
    /// </summary>
    [FtpCommandHandler("FEAT", isLoginRequired: false)]
    public class FeatCommandHandler : FtpCommandHandler
    {
        private readonly IFeatureInfoProvider _featureInfoProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatCommandHandler"/> class.
        /// </summary>
        /// <param name="featureInfoProvider">Provider for feature information.</param>
        public FeatCommandHandler(
            IFeatureInfoProvider featureInfoProvider)
        {
            _featureInfoProvider = featureInfoProvider;
        }

        /// <inheritdoc/>
        public override Task<IFtpResponse?> Process(FtpCommand command, CancellationToken cancellationToken)
        {
            var loginStateMachine = FtpContext.ConnectionServices.GetRequiredService<IFtpLoginStateMachine>();
            var isAuthorized = loginStateMachine.Status == SecurityStatus.Authorized;
            var features = _featureInfoProvider.GetFeatureInfoItems()
               .Where(x => IsFeatureAllowed(x, isAuthorized))
               .SelectMany(BuildInfo)
               .Distinct(StringComparer.OrdinalIgnoreCase)
               .OrderBy(x => x, StringComparer.OrdinalIgnoreCase)
               .ToList();

            if (features.Count == 0)
            {
                return Task.FromResult<IFtpResponse?>(new FtpResponse(211, T("No extensions supported")));
            }

            return Task.FromResult<IFtpResponse?>(
                new FtpResponseList(
                    211,
                    T("Extensions supported:"),
                    T("END"),
                    features.Distinct(StringComparer.OrdinalIgnoreCase).ToList()));
        }

        private IEnumerable<string> BuildInfo(FoundFeatureInfo foundFeatureInfo)
        {
            if (foundFeatureInfo.IsCommandHandler)
            {
                return foundFeatureInfo.FeatureInfo.BuildInfo(foundFeatureInfo.CommandHandlerInfo.Type, FtpContext);
            }

            if (foundFeatureInfo.IsExtension)
            {
                return foundFeatureInfo.FeatureInfo.BuildInfo(foundFeatureInfo.ExtensionInfo.Type, FtpContext);
            }

            if (foundFeatureInfo.IsAuthenticationMechanism)
            {
                return foundFeatureInfo.FeatureInfo.BuildInfo(foundFeatureInfo.AuthenticationMechanism.GetType(), FtpContext);
            }

            throw new NotSupportedException("Unknown feature source.");
        }

        private bool IsFeatureAllowed(FoundFeatureInfo foundFeatureInfo, bool isAuthorized)
        {
            if (foundFeatureInfo.IsCommandHandler)
            {
                return isAuthorized || !foundFeatureInfo.CommandHandlerInfo.IsLoginRequired;
            }

            if (foundFeatureInfo.IsExtension)
            {
                return isAuthorized || !foundFeatureInfo.ExtensionInfo.IsLoginRequired;
            }

            if (foundFeatureInfo.IsAuthenticationMechanism)
            {
                return true;
            }

            throw new NotSupportedException("Unknown feature source.");
        }
    }
}
