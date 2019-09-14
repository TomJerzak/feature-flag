namespace FeatureFlag.Web.FeatureFlags
{
    public class HelloWorldFeature : SimpleFeatureFlag
    {
        public HelloWorldFeature(bool featureEnabled) : base(featureEnabled)
        {
        }
    }
}