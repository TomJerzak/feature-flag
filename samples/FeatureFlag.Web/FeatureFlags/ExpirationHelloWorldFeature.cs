using System;

namespace FeatureFlag.Web.FeatureFlags
{
    public class ExpirationHelloWorldFeature : ExpirationFeatureFlag
    {
        public ExpirationHelloWorldFeature(DateTime expirationDate) : base(expirationDate)
        {
        }
    }
}