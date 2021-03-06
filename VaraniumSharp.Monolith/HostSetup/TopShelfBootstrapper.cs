﻿using System;
using System.Linq;
using Topshelf;
using VaraniumSharp.Attributes;
using VaraniumSharp.Enumerations;
using VaraniumSharp.Monolith.Extensions;
using VaraniumSharp.Monolith.Interfaces;

namespace VaraniumSharp.Monolith.HostSetup
{
    /// <summary>
    /// Runner for ITopShelfService
    /// </summary>
    [AutomaticContainerRegistration(typeof(TopShelfBootstrapper), ServiceReuse.Singleton)]
    public class TopShelfBootstrapper
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Service implementing <see cref="ITopShelfService"/></param>
        public TopShelfBootstrapper(ITopShelfService service)
        {
            SetupTopshelfHost(service);
        }

        #endregion

        #region Properties

        /// <summary>
        /// TopShelf Host
        /// </summary>
        public Host TopShelfHost { get; private set; }

        #endregion

        #region Private Methods

        /// <summary>
        /// Invokes HostFactory.Run on the injected <see cref="ITopShelfService"/>
        /// </summary>
        /// <returns></returns>
        private void SetupTopshelfHost(ITopShelfService service)
        {
            TopShelfHost = HostFactory.New(x =>
            {
                x.ApplyValidCommandLine(Environment.GetCommandLineArgs().ToList());
                x.UseSerilog();
                x.Service<ITopShelfService>(s =>
                {
                    s.ConstructUsing(name => service);
                    s.WhenStarted(tService => service.Start());
                    s.WhenStopped(tService => service.Stop());
                });
                x.RunAsLocalService();

                var serviceConfiguration = service.TopShelfConfiguration;
                x.SetDescription(serviceConfiguration.Name);
                x.SetDisplayName(serviceConfiguration.DisplayName);
                x.SetServiceName(serviceConfiguration.Name);
            });
        }

        #endregion
    }
}