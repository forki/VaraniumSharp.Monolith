﻿using VaraniumSharp.Monolith.Security;

namespace VaraniumSharp.Monolith.Enumerations
{
    /// <summary>
    /// Contains keys for reading configuration values from App.config
    /// </summary>
    public static class ConfigurationKeys
    {
        #region Variables

        /// <summary>
        /// Indicates if Hangfire should be enabled
        /// </summary>
        public const string HangfireEnabled = "hangfire.enabled";

        /// <summary>
        /// Indicate if the Hangfire dashboard should be enabled
        /// </summary>
        public const string HangfireEnableDashboard = "hangfire.dashboardenabled";

        /// <summary>
        /// Indicate if Hangfire Memory Storage provider should be used
        /// </summary>
        public const string HangfireMemoryStorageEnabled = "hangfire.memorystorage.enabled";

        /// <summary>
        /// Indicate if Hangfire Sql Stoage provider should be used
        /// </summary>
        public const string HangfireSqlStorageEnabled = "hangfire.sqlstorage.enabled";

        /// <summary>
        /// Connection string to use if the SqlServer Storage Engine is used
        /// </summary>
        public const string HangfireSqlConnectionString = "hangfire.sqlstorage.connectionstring";

        /// <summary>
        /// API key for Pushover
        /// </summary>
        public const string PushoverApiToken = "pushover.apitoken";

        /// <summary>
        /// Default device key for Pushover
        /// </summary>
        public const string PushoverDefaultSendKey = "pushover.defaultsendkey";

        /// <summary>
        /// Key indicating if Pushover is enabled
        /// </summary>
        public const string PushoverEnabled = "pushover.isenabled";

        /// <summary>
        /// Indicate if the <see cref="ValidationHandler"/> should be used
        /// </summary>
        public const string OAuthAuthenticationEnabled = "oauthvalidator.enabled";

        /// <summary>
        /// Type of authentication
        /// </summary>
        public const string OAuthAuthenticationType = "oauthvalidator.authenticationtype";

        /// <summary>
        /// The key of the claim that should be used for the user's role
        /// </summary>
        public const string OAuthClaimRepresentingRole = "oauthvalidator.claimrepresentingrole";

        /// <summary>
        /// The key of the claim that should be used for the user's username
        /// </summary>
        public const string OAuthClaimRepresetingUsername = "oauthvalidator.claimrepresentingusername";

        /// <summary>
        /// Indicate if the token must have an 'expiration' value
        /// </summary>
        public const string OAuthRequireExperationTime = "oauthvalidator.requireexpirationtime";

        /// <summary>
        /// The Url from where the Identity Server's public keys can be downloaded
        /// </summary>
        public const string OAuthSigningKeysUrl = "oauthvalidator.signingkeysurl";

        /// <summary>
        /// Valid audience that will be used to check against the token's audience
        /// </summary>
        public const string OAuthTargetAudiance = "oauthvalidator.targetaudience";

        /// <summary>
        /// Issuer that will be checked against the token's issuer
        /// </summary>
        public const string OAuthValidIssuer = "oauthvalidator.validissuer";

        /// <summary>
        /// Host address of the service
        /// </summary>
        public const string ServiceHost = "service.host";

        /// <summary>
        /// The port on which the service is hosted
        /// </summary>
        public const string ServicePort = "service.port";

        /// <summary>
        /// The name of the service as it is registered in the service control manager
        /// </summary>
        public const string ServiceName = "service.name";

        /// <summary>
        /// The display name of the service in the service control manager
        /// </summary>
        public const string ServiceDisplayName = "service.displayname";

        /// <summary>
        /// The description of the service in the service control manager
        /// </summary>
        public const string ServiceDescription = "service.description";

        /// <summary>
        /// Start mode to use when the service is installed
        /// </summary>
        public const string ServiceStartMode = "service.startmode";

        #endregion
    }
}