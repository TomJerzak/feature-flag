using Microsoft.Extensions.Configuration;

namespace FeatureFlag.Web.FeatureFlags
{
    public static class FeatureFlagWrapper
    {
        public static readonly HelloWorldFeature HelloWorldFeature = new HelloWorldFeature(false);
        public static readonly CalendarFeature CalendarFeature = new CalendarFeature(false);

        public static void LoadFeatureFlags(IConfiguration configuration, string featureFlagSectionName)
        {
            HelloWorldFeature.SetFeatureEnabled(configuration.GetSection($"{featureFlagSectionName}:{nameof(HelloWorldFeature)}"));
            CalendarFeature.SetFeatureEnabled(configuration.GetSection($"{featureFlagSectionName}:{nameof(CalendarFeature)}"));
        }
    }
}
