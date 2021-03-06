﻿using FluentAssertions;
using Moq;
using NUnit.Framework;
using VaraniumSharp.Monolith.HostSetup;
using VaraniumSharp.Monolith.Interfaces;
using VaraniumSharp.Monolith.Interfaces.HostSetup;
using VaraniumSharp.Monolith.Tests.Helpers;

namespace VaraniumSharp.Monolith.Tests.HostSetup
{
    public class OwinTopShelfServiceTests
    {
        #region Public Methods

        [Test]
        public void ConfigurationsAreCorrectlyLoaded()
        {
            // arrange
            var fixture = new OwinHostTopShelfServiceFixture();
            var instance = fixture.Instance;

            // act
            // assert
            instance.TopShelfConfiguration.Should().Be(fixture.GetTopShelfConfiguration);
            instance.HostConfiguration.Should().Be(fixture.GetHostConfiguration);
        }

        [Test]
        public void WebappStartsCorrectly()
        {
            // arrange
            var loggerTuple = LoggerFixtureHelper.SetupLogCatcher();

            var fixture = new OwinHostTopShelfServiceFixture();
            fixture.HostConfigurationMock.Setup(t => t.HostUrl).Returns("http://127.0.0.1:5554");
            var instance = fixture.Instance;

            // act
            instance.Start();

            // asset
            loggerTuple.Item2.Verify(t => t.Information("Startup completed"));

            LoggerFixtureHelper.SwitchLogger(loggerTuple.Item1);
        }

        [Test]
        public void WebappStopsCorrectly()
        {
            // arrange
            var loggerTuple = LoggerFixtureHelper.SetupLogCatcher();

            var fixture = new OwinHostTopShelfServiceFixture();
            fixture.HostConfigurationMock.Setup(t => t.HostUrl).Returns("http://127.0.0.1:5554");
            var instance = fixture.Instance;
            instance.Start();

            // act
            instance.Stop();

            // asset
            loggerTuple.Item2.Verify(t => t.Information("Shutting down"));

            LoggerFixtureHelper.SwitchLogger(loggerTuple.Item1);
        }

        #endregion

        public class OwinHostTopShelfServiceFixture
        {
            #region Constructor

            public OwinHostTopShelfServiceFixture()
            {
                Instance = new OwinHostTopShelfService(GetTopShelfConfiguration, GetHostConfiguration, GetOwinStartup);
            }

            #endregion

            #region Properties

            public IHostConfiguration GetHostConfiguration => HostConfigurationMock.Object;
            public IOwinStartup GetOwinStartup => OwinStartupMock.Object;
            public ITopShelfConfiguration GetTopShelfConfiguration => TopShelfConfigurationMock.Object;
            public Mock<IHostConfiguration> HostConfigurationMock { get; } = new Mock<IHostConfiguration>();

            public OwinHostTopShelfService Instance { get; }
            public Mock<IOwinStartup> OwinStartupMock { get; } = new Mock<IOwinStartup>();
            public Mock<ITopShelfConfiguration> TopShelfConfigurationMock { get; } = new Mock<ITopShelfConfiguration>();

            #endregion
        }
    }
}