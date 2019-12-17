using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Cardinal.ClickSign.Tests
{
    [TestClass]
    public class SignersTests
    {
        private ClickSignClient Client { get; }

        public SignersTests()
        {
            var apiKey = Guid.Empty;
            this.Client = new ClickSignClient(apiKey);
        }
    }
}
