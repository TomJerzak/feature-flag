using System;

namespace FeatureFlag
{
    public abstract class ExpirationFeatureFlag : IFeatureFlag
    {
        public DateTime ExpirationDate { get; }

        private bool _featureEnabled;

        public bool FeatureEnabled
        {
            get
            {
                SetFeatureEnabled(ExpirationDate);
                return _featureEnabled;
            }
        }

        protected ExpirationFeatureFlag(DateTime expirationDate)
        {
            ExpirationDate = expirationDate;
            SetFeatureEnabled(expirationDate);
        }

        private void SetFeatureEnabled(DateTime expirationDate)
        {
            _featureEnabled = expirationDate > DateTime.Now;
        }
    }
}