using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System;
using Xunit.Sdk;

namespace Cardinal.ClickSign.Tests
{
    [TestClass]
    public class DocumentsTests
    {
        private ClickSignClient Client { get; }

        public DocumentsTests()
        {
            var apiKey = Guid.Empty;
            this.Client = new ClickSignClient(apiKey);
        }

        [TestMethod]
        public async Task GetAllTest()
        {
            var result = await this.Client.GetAsync();
            Assert.IsNull(result, "Nenhum documento encontrado!");
        }
    }
}
