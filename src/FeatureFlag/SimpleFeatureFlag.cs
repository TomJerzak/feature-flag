namespace FeatureFlag
{
    public abstract class SimpleFeatureFlag : IFeatureFlag
    {
        public bool FeatureEnabled { get; }

        protected SimpleFeatureFlag(bool featureEnabled)
        {
            FeatureEnabled = featureEnabled;
        }
    }
}
