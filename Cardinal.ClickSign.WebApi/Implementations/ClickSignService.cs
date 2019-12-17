/*
The MIT License (MIT)

Copyright (c) Marcelo O. Mendes

All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using Cardinal.ClickSign.Settings;
using Cardinal.ClickSign.Extensions;
using Cardinal.ClickSign.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cardinal.ClickSign.Exceptions;

namespace Cardinal.ClickSign
{
    /// <summary>
    /// Implementação do serviço ClickSign.
    /// </summary>
    public class ClickSignService : IClickSignService
    {
        /// <summary>
        /// Client para os serviços ClickSign.
        /// </summary>
        private ClickSignClient Client { get; }

        /// <summary>
        /// Método construtor.
        /// </summary>
        /// <param name="configuration">Container de configurações da WebApi.</param>
        public ClickSignService(IConfiguration configuration)
        {
            if(configuration == null)
            {
                throw new ClickSignException("O container de configurações 'IConfiguration' é nulo!");
            }

            var settings = configuration.GetSection("ClickSign").GetSettings<ClickSignSettings>();
            this.Client = new ClickSignClient(settings.ApiKey, settings.Environment, settings.Version);
        }

        /// <summary>
        /// Método que efetua o envio de um novo documento para assinatura no serviço.
        /// </summary>
        /// <param name="request">Requisição de upload de novo arquivo. <see cref="UploadRequest"/></param>
        /// <returns>Dados do documento criado no ambiente.</returns>
        public Document Upload(UploadRequest request)
        {
            var result = this.Client.Upload(request);
            return result;
        }

        /// <summary>
        /// Método que efetua o envio de um novo documento para assinatura no serviço de forma assíncrona.
        /// </summary>
        /// <param name="request">Requisição de upload de novo arquivo. <see cref="UploadRequest"/></param>
        /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
        /// <returns>Dados do documento criado no ambiente.</returns>
        public async Task<Document> UploadAsync(UploadRequest request, CancellationToken cancellationToken = default)
        {
            var result = await this.Client.UploadAsync(request, cancellationToken);
            return result;
        }

        /// <summary>
        /// Método que efetua a busca de todos os documentos.
        /// </summary>
        /// <returns>Lista contendo os dados de todos os documentos do serviço.</returns>
        public IEnumerable<Document> Get()
        {
            var result = this.Client.Get();
            return result;
        }

        /// <summary>
        /// Método que efetua a busca de todos os documentos de forma assíncrona.
        /// </summary>
        /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
        /// <returns>Lista contendo os dados de todos os documentos do serviço.</returns>
        public async Task<IEnumerable<Document>> GetAsync(CancellationToken cancellationToken = default)
        {
            var result = await this.Client.GetAsync(cancellationToken);
            return result;
        }

        /// <summary>
        /// Método que efetua a busca de um documento previamente cadastrado no serviço.
        /// </summary>
        /// <param name="key">Chave única do documento.</param>
        /// <returns>Dados do documento associado à chave informada. <see cref="Document"/></returns>
        public Document Get(Guid key)
        {
            var result = this.Client.Get(key);
            return result;
        }

        /// <summary>
        /// Método que efetua a busca de um documento previamente cadastrado no serviço de forma assíncrona.
        /// </summary>
        /// <param name="key">Chave única do documento.</param>
        /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
        /// <returns>Dados do documento associado à chave informada. <see cref="Document"/></returns>
        public async Task<Document> GetAsync(Guid key, CancellationToken cancellationToken = default)
        {
            var result = await this.Client.GetAsync(key, cancellationToken);
            return result;
        }

        /// <summary>
        /// Método que efetua a finalização de um documento ativo.
        /// </summary>
        /// <param name="key">Chave única do documento.</param>
        /// <returns>Dados do documento associado à chave informada. <see cref="Document"/></returns>
        public Document Finalize(Guid key)
        {
            var result = this.Client.Finalize(key);
            return result;
        }

        /// <summary>
        /// Método que efetua a finalização de um documento ativo de forma assíncrona.
        /// </summary>
        /// <param name="key">Chave única do documento.</param>
        /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
        /// <returns>Dados do documento associado à chave informada. <see cref="Document"/></returns>
        public async Task<Document> FinalizeAsync(Guid key, CancellationToken cancellationToken = default)
        {
            var result = await this.Client.FinalizeAsync(key, cancellationToken);
            return result;
        }

        /// <summary>
        /// Método que efetua o cancelamento de um documento ativo.
        /// </summary>
        /// <param name="key">Chave única do documento.</param>
        /// <returns>Dados do documento associado à chave informada. <see cref="Document"/></returns>
        public Document Cancel(Guid key)
        {
            var result = this.Client.Cancel(key);
            return result;
        }

        /// <summary>
        /// Método que efetua o cancelamento de um documento ativo de forma assíncrona.
        /// </summary>
        /// <param name="key">Chave única do documento.</param>
        /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
        /// <returns>Dados do documento associado à chave informada. <see cref="Document"/></returns>
        public async Task<Document> CancelAsync(Guid key, CancellationToken cancellationToken = default)
        {
            var result = await this.Client.CancelAsync(key, cancellationToken);
            return result;
        }

        /// <summary>
        /// Método que efetua a duplicação de um documento ativo.
        /// </summary>
        /// <param name="key">Chave única do documento.</param>
        /// <returns>Dados do documento duplicado. <see cref="Document"/></returns>
        public Document Duplicate(Guid key)
        {
            var result = this.Client.Duplicate(key);
            return result;
        }

        /// <summary>
        /// Método que efetua a duplicação de um documento ativo de forma assíncrona.
        /// </summary>
        /// <param name="key">Chave única do documento.</param>
        /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
        /// <returns>Dados do documento duplicado. <see cref="Document"/></returns>
        public async Task<Document> DuplicateAsync(Guid key, CancellationToken cancellationToken = default)
        {
            var result = await this.Client.DuplicateAsync(key, cancellationToken);
            return result;
        }

        /// <summary>
        /// Método que traz os dados de um determinado assinante.
        /// </summary>
        /// <param name="key">Chave única do assinante.</param>
        /// <returns>Dados do assinante referentes à chave informada. <see cref="Signer"/></returns>
        public Signer GetSigner(Guid key)
        {
            var result = this.Client.GetSigner(key);
            return result;
        }

        /// <summary>
        /// Método que traz os dados de um determinado assinante de forma assíncrona.
        /// </summary>
        /// <param name="key">Chave única do assinante.</param>
        /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
        /// <returns>Dados do assinante referentes à chave informada. Veja <see cref="Signer"/>.</returns>
        public async Task<Signer> GetSignerAsync(Guid key, CancellationToken cancellationToken = default)
        {
            var result = await this.Client.GetSignerAsync(key, cancellationToken);
            return result;
        }

        /// <summary>
        /// Método que efetua o cadastro de um novo assinante.
        /// </summary>
        /// <param name="request">Dados de requisição de criação do novo assinante. <see cref="CreateSignerRequest"/></param>
        /// <returns>Dados do assinante recém criado. <see cref="Signer"/></returns>
        public Signer CreateSigner(CreateSignerRequest request)
        {
            var result = this.CreateSigner(request);
            return result;
        }

        /// <summary>
        /// Método que efetua o cadastro de um novo assinante de forma assíncrona.
        /// </summary>
        /// <param name="request">Dados de requisição de criação do novo assinante. <see cref="CreateSignerRequest"/></param>
        /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
        /// <returns>Dados do assinante recém criado. <see cref="Signer"/></returns>
        public async Task<Signer> CreateSignerAsync(CreateSignerRequest request, CancellationToken cancellationToken = default)
        {
            var result = await this.CreateSignerAsync(request, cancellationToken);
            return result;
        }

        /// <summary>
        /// Método que efetua a associação de um assinante à um documento à ser assinado.
        /// </summary>
        /// <param name="request">Dados da requisição de adição de assinante ao documento. <see cref="AddSignerRequest"/></param>
        /// <returns>Resposta da adição do assinante ao documento. <see cref="AddSignerResponse"/></returns>
        public AddSignerResponse AddSignerToDocument(AddSignerRequest request)
        {
            var result = this.Client.AddSignerToDocument(request);
            return result;
        }

        /// <summary>
        /// Método que efetua a associação de um assinante à um documento à ser assinado de forma assíncrona.
        /// </summary>
        /// <param name="request">Dados da requisição de adição de assinante ao documento. <see cref="AddSignerRequest"/></param>
        /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
        /// <returns>Resposta da adição do assinante ao documento. <see cref="AddSignerResponse"/></returns>
        public async Task<AddSignerResponse> AddSignerToDocumentAsync(AddSignerRequest request, CancellationToken cancellationToken = default)
        {
            var result = await this.Client.AddSignerToDocumentAsync(request, cancellationToken);
            return result;
        }

        /// <summary>
        /// Método que efetua a remoção de um assinante de um documento.
        /// </summary>
        /// <param name="key">Chave da associação do assinante ao documento.</param>
        public void RemoveSignerFromDocument(Guid key)
        {
            this.Client.RemoveSignerFromDocument(key);
        }

        /// <summary>
        /// Método que efetua a remoção de um assinante de um documento de forma assíncrona. 
        /// </summary>
        /// <param name="key">Chave da associação do assinante ao documento.</param>
        /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
        /// <returns>Tarefa assíncrona.</returns>
        public async Task RemoveSignerFromDocumentAsync(Guid key, CancellationToken cancellationToken = default)
        {
            await this.Client.RemoveSignerFromDocumentAsync(key, cancellationToken);
        }

        /// <summary>
        /// Método que cria uma assinatura em lotes de documentos com um assinante em comum.
        /// </summary>
        /// <param name="request">Dados da requisição de criação da assinatura em lotes. Veja <see cref="BatchRequest"/></param>
        /// <returns>Dados da assinatura em lotes criada. Veja <see cref="BatchResponse"/>.</returns>
        public BatchResponse CreateBatch(BatchRequest request)
        {
            var result = this.Client.CreateBatch(request);
            return result;
        }

        /// <summary>
        /// Método que cria uma assinatura em lotes de documentos com um assinante em comum de forma assíncrona.
        /// </summary>
        /// <param name="request">Dados da requisição de criação da assinatura em lotes. Veja <see cref="BatchRequest"/>.</param>
        /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
        /// <returns>Dados da assinatura em lotes criada. Veja <see cref="BatchResponse"/>.</returns>
        public async Task<BatchResponse> CreateBatchAsync(BatchRequest request, CancellationToken cancellationToken = default)
        {
            var result = await this.Client.CreateBatchAsync(request, cancellationToken);
            return result;
        }

        /// <summary>
        /// Método que efetua o envio de um lembrete de assinatura de um documento.
        /// </summary>
        /// <param name="request">Dados da requisição de envio de notificação. Veja <see cref="NotificationRequest"/>.</param>
        public void SendNotification(NotificationRequest request)
        {
            this.Client.SendNotification(request);
        }

        /// <summary>
        /// Método que efetua o envio de um lembrete de assinatura de um documento de forma assíncrona.
        /// </summary>
        /// <param name="request">Dados da requisição de envio de notificação. Veja <see cref="NotificationRequest"/>.</param>
        /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
        /// <returns>Tarefa assíncrona.</returns>
        public async Task SendNotificationAsync(NotificationRequest request, CancellationToken cancellationToken = default)
        {
             await this.Client.SendNotificationAsync(request, cancellationToken);
        }
    }
}
