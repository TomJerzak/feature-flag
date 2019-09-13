using System;
using Microsoft.Extensions.Configuration;

namespace FeatureFlag
{
    public abstract class SimpleFeatureFlag : IFeatureFlag
    {
        private const string ArgumentExceptionMessage = "Defined FeatureFlags must have a value of boolean type.";

        public bool FeatureEnabled { get; private set; }

        protected SimpleFeatureFlag(bool featureEnabled)
        {
            FeatureEnabled = featureEnabled;
        }

        public void SetFeatureEnabled(IConfigurationSection configurationSection)
        {
            if (configurationSection.Exists())
                if (bool.TryParse(configurationSection.Value, out var featureEnabled))
                    FeatureEnabled = featureEnabled;
                else
                    throw new ArgumentException(ArgumentExceptionMessage);
        }
    }
}
