namespace FeatureFlag.Example.FeatureFlags
{
    public class HelloWorldFeature : SimpleFeatureFlag
    {
        public HelloWorldFeature(bool featureEnabled) : base(featureEnabled)
        {
        }
    }
}