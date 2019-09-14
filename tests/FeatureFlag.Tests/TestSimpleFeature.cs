namespace FeatureFlag.Tests
{
    internal class TestSimpleFeature : SimpleFeatureFlag
    {
        public TestSimpleFeature(bool featureEnabled) : base(featureEnabled)
        {
        }
    }
}