namespace FeatureFlag.Tests
{
    public partial class SimpleFeatureFlagTests
    {
        private class TestFeature : SimpleFeatureFlag
        {
            public TestFeature(bool featureEnabled) : base(featureEnabled)
            {
            }
        }
    }
}