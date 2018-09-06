namespace FeatureFlag
{
    public interface IFeatureFlag
    {
        bool FeatureEnabled { get; }
    }
}
