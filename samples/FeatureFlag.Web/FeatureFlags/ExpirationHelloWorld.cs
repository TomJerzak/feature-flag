using System;

namespace FeatureFlag.Web.FeatureFlags
{
    public class ExpirationHelloWorld : ExpirationFeatureFlag
    {
        public ExpirationHelloWorld(DateTime expirationDate) : base(expirationDate)
        {
        }
    }
}