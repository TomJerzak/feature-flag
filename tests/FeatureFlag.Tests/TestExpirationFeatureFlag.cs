using System;

namespace FeatureFlag.Tests
{
    public class TestExpirationFeatureFlag : ExpirationFeatureFlag
    {
        public TestExpirationFeatureFlag(DateTime expirationDate) : base(expirationDate)
        {
        }
    }
}