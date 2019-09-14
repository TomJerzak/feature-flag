using FluentAssertions;
using Xunit;

namespace FeatureFlag.Tests
{
    public class SimpleFeatureFlagTests
    {
        [Fact]
        public void feature_should_be_enabled()
        {
            const bool featureEnabled = true;
            SimpleFeatureFlag simpleFeatureFlag = new TestSimpleFeature(featureEnabled);

            simpleFeatureFlag.FeatureEnabled.Should().BeTrue();
        }

        [Fact]
        public void feature_should_be_disabled()
        {
            const bool featureEnabled = false;
            SimpleFeatureFlag simpleFeatureFlag = new TestSimpleFeature(featureEnabled);

            simpleFeatureFlag.FeatureEnabled.Should().BeFalse();
        }
    }
}