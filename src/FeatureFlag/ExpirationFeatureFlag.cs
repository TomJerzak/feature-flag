using System;
using Microsoft.Extensions.Configuration;

namespace FeatureFlag
{
    public abstract class ExpirationFeatureFlag : IFeatureFlag
    {
        private const string ArgumentExceptionMessage = "Defined FeatureFlags must have a value of DateTime type.";

        public DateTime ExpirationDate { get; private set; }

        private bool _featureEnabled;

        public bool FeatureEnabled
        {
            get
            {
                UpdateFeatureEnabled(ExpirationDate);
                return _featureEnabled;
            }
        }

        protected ExpirationFeatureFlag(DateTime expirationDate)
        {
            UpdateFeatureEnabled(expirationDate);
        }

        private void UpdateFeatureEnabled(DateTime expirationDate)
        {
            ExpirationDate = expirationDate;
            _featureEnabled = expirationDate > DateTime.Now;
        }

        public void SetFeatureEnabled(IConfigurationSection configurationSection)
        {
            if (configurationSection.Exists())
                if (DateTime.TryParse(configurationSection.Value, out var expirationDate))
                    UpdateFeatureEnabled(expirationDate);
                else
                    throw new ArgumentException(ArgumentExceptionMessage);
        }
    }
}