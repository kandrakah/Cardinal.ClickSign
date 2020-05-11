using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xunit.Sdk;
using Cardinal.ClickSign.Models;

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

        [TestMethod]
        public void CreateSigner()
        {
            var signerReq = new CreateSignerRequest();
            signerReq.Birthday = new DateTime(1988, 10, 1);
            signerReq.HasDocumentation = true;
            signerReq.Documentation = "45450931085";
            signerReq.Email = "signer@dev.com.br";
            signerReq.Name = "Teste ClickSign User";
            signerReq.Phone = "3298000000";
            var result = this.Client.CreateSigner(signerReq);
        }

        [TestMethod]
        public void AddSignerToDoc()
        {
            var docId = Guid.Parse("0c2dec3b-89ab-4ff7-9fd2-58fbc20f6d9a");
            var signerId = Guid.Parse("c1e553de-7b5f-4a2b-9b87-0f573d704dfa");
            var addSigner = new AddSignerRequest();
            addSigner.DocumentKey = docId;
            addSigner.SignerKey = signerId;

            var result = this.Client.AddSignerToDocument(addSigner);

        }
    }
}
