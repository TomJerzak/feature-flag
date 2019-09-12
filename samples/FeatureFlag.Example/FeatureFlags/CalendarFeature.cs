namespace FeatureFlag.Example.FeatureFlags
{
    public class CalendarFeature : SimpleFeatureFlag
    {
        public CalendarFeature(bool featureEnabled) : base(featureEnabled)
        {
        }
    }
}
