using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System;
using Xunit.Sdk;
using Cardinal.ClickSign.Models;
using Cardinal.ClickSign.Extensions;
using Cardinal.ClickSign.Exceptions;
using System.IO;

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
        public void GetAllTest()
        {
            var result = this.Client.Get();
            Assert.IsNull(result, "Nenhum documento encontrado!");
        }

        [TestMethod]
        public void UploadFileTest()
        {
            var docFile = @"DOCUMENT.pdf";
            if (!File.Exists(docFile))
            {
                Assert.Fail("Arquivo de testes não localizado!");
            }
            var request = new UploadRequest();
            request.SetContent(docFile);
            request.Path = $"/DOCUMENT[{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}].pdf";
            //request.SequenceEnabled = true;

            try
            {
                var result = this.Client.Upload(request);
            }
            catch (ClickSignRequestException ex)
            {
                Assert.Fail(ex.ToString());
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.GetBaseException().Message);
            }
        }
    }
}
