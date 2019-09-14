using FluentAssertions;
using Xunit;

namespace FeatureFlag.Tests
{
    public partial class SimpleFeatureFlagTests
    {
        [Fact]
        public void feature_should_be_enabled()
        {
            const bool featureEnabled = true;
            SimpleFeatureFlag simpleFeatureFlag = new TestFeature(featureEnabled);

            simpleFeatureFlag.FeatureEnabled.Should().BeTrue();
        }

        [Fact]
        public void feature_should_be_disabled()
        {
            const bool featureEnabled = false;
            SimpleFeatureFlag simpleFeatureFlag = new TestFeature(featureEnabled);

            simpleFeatureFlag.FeatureEnabled.Should().BeFalse();
        }
    }
}