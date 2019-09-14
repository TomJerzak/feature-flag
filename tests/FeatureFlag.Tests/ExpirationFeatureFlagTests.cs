using System;
using FluentAssertions;
using Xunit;

namespace FeatureFlag.Tests
{
    public class ExpirationFeatureFlagTests
    {
        [Fact]
        public void feature_expiration_date_should_be_equal_variable()
        {
            var expirationDate = DateTime.Now.AddDays(1);
            ExpirationFeatureFlag expirationFeatureFlag = new TestExpirationFeatureFlag(expirationDate);

            expirationFeatureFlag.ExpirationDate.Should().Be(expirationDate);
        }

        [Fact]
        public void feature_should_be_enabled()
        {
            var expirationDate = DateTime.Now.AddDays(1);
            ExpirationFeatureFlag expirationFeatureFlag = new TestExpirationFeatureFlag(expirationDate);

            expirationFeatureFlag.FeatureEnabled.Should().BeTrue();
        }

        [Fact]
        public void feature_should_be_disabled()
        {
            var expirationDate = DateTime.Now;
            ExpirationFeatureFlag expirationFeatureFlag = new TestExpirationFeatureFlag(expirationDate);

            expirationFeatureFlag.FeatureEnabled.Should().BeFalse();
        }
    }
}