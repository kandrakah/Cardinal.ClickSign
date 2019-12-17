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

using Cardinal.ClickSign.Enumerators;
using Cardinal.ClickSign.Exceptions;
using Cardinal.ClickSign.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Tiny.RestClient;

namespace Cardinal.ClickSign
{
    /// <summary>
    /// Classe que atua como cliente para os serviços ClickSign.
    /// </summary>
    public class ClickSignClient
    {
        /// <summary>
        /// Chave de api usada na autenticação do serviço.
        /// </summary>
        private Guid ApiKey { get; }

        /// <summary>
        /// Cliente rest responsável pelo gerenciamento das requisições.
        /// </summary>
        private TinyRestClient Client { get; }

        /// <summary>
        /// Método construtor.
        /// </summary>
        /// <param name="apiKey">Chave de api usada na autenticação do serviço.</param>
        /// <param name="environment">Ambiente ao qual se destinarão as requisições. <see cref="ApiEnvironment"/></param>
        /// <param name="version">Versão da api de destino das requisições. <see cref="ApiVersion"/></param>
        public ClickSignClient(string apiKey, ApiEnvironment environment = ApiEnvironment.Sandbox, ApiVersion version = ApiVersion.V1) : this(Guid.Parse(apiKey), environment, version)
        {

        }

        /// <summary>
        /// Método construtor.
        /// </summary>
        /// <param name="apiKey">Chave de api usada na autenticação do serviço.</param>
        /// <param name="environment">Ambiente ao qual se destinarão as requisições. <see cref="ApiEnvironment"/></param>
        /// <param name="version">Versão da api de destino das requisições. <see cref="ApiVersion"/></param>
        public ClickSignClient(Guid apiKey, ApiEnvironment environment = ApiEnvironment.Sandbox, ApiVersion version = ApiVersion.V1)
        {
            this.ApiKey = apiKey;
            var uri = ClickSignConstants.GetBaseUri(environment, version);
            this.Client = new TinyRestClient(new HttpClient(), uri);
            this.Client.Settings.Formatters.OfType<JsonFormatter>().First().UseCamelCase();
        }

        /// <summary>
        /// Método que efetua o envio de um novo documento para assinatura no serviço.
        /// </summary>
        /// <param name="request">Requisição de upload de novo arquivo. <see cref="UploadRequest"/></param>
        /// <returns>Dados do documento criado no ambiente.</returns>
        public Document Upload(UploadRequest request)
        {
            var result = UploadAsync(request).Result;
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
            try
            {
                var uploadRequest = new InternalUploadRequest(request);
                var result = await this.Client.PostRequest($"documents", uploadRequest)
                    .AddQueryParameter("access_token", this.ApiKey.ToString())
                    .ExecuteAsync<InternalResponse>(cancellationToken)
                    .ConfigureAwait(false);

                return result.Document;
            }
            catch (HttpException ex)
            {
                throw new ClickSignRequestException(ex.Content);
            }
            catch (Exception ex)
            {
                throw new ClickSignException(ex.Message);
            }
        }

        /// <summary>
        /// Método que efetua a busca de todos os documentos.
        /// </summary>
        /// <returns>Lista contendo os dados de todos os documentos do serviço.</returns>
        public IEnumerable<Document> Get()
        {
            var result = GetAsync().Result;
            return result;
        }

        /// <summary>
        /// Método que efetua a busca de todos os documentos de forma assíncrona.
        /// </summary>
        /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
        /// <returns>Lista contendo os dados de todos os documentos do serviço.</returns>
        public async Task<IEnumerable<Document>> GetAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await this.Client.GetRequest($"documents")
                    .AddQueryParameter("access_token", this.ApiKey.ToString())
                    .ExecuteAsync<InternalResponse>(cancellationToken)
                    .ConfigureAwait(false);

                return result.Documents;
            }
            catch (HttpException ex)
            {
                throw new ClickSignRequestException(ex.Content);
            }
            catch (Exception ex)
            {
                throw new ClickSignException(ex.Message);
            }
        }

        /// <summary>
        /// Método que efetua a busca de um documento previamente cadastrado no serviço.
        /// </summary>
        /// <param name="key">Chave única do documento.</param>
        /// <returns>Dados do documento associado à chave informada. <see cref="Document"/></returns>
        public Document Get(Guid key)
        {
            var result = this.GetAsync(key).Result;
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
            try
            {
                var result = await this.Client.GetRequest($"documents/{key}")
                    .AddQueryParameter("access_token", this.ApiKey.ToString())
                    .ExecuteAsync<InternalResponse>(cancellationToken)
                    .ConfigureAwait(false);

                return result.Document;
            }
            catch (HttpException ex)
            {
                throw new ClickSignRequestException(ex.Content);
            }
            catch (Exception ex)
            {
                throw new ClickSignException(ex.Message);
            }
        }

        /// <summary>
        /// Método que efetua a finalização de um documento ativo.
        /// </summary>
        /// <param name="key">Chave única do documento.</param>
        /// <returns>Dados do documento associado à chave informada. <see cref="Document"/></returns>
        public Document Finalize(Guid key)
        {
            var result = this.FinalizeAsync(key).Result;
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
            try
            {
                var result = await this.Client.PatchRequest($"documents/{key}/finish")
                    .AddQueryParameter("access_token", this.ApiKey.ToString())
                    .ExecuteAsync<InternalResponse>(cancellationToken)
                    .ConfigureAwait(false);

                return result.Document;
            }
            catch (HttpException ex)
            {
                throw new ClickSignRequestException(ex.Content);
            }
            catch (Exception ex)
            {
                throw new ClickSignException(ex.Message);
            }
        }

        /// <summary>
        /// Método que efetua o cancelamento de um documento ativo.
        /// </summary>
        /// <param name="key">Chave única do documento.</param>
        /// <returns>Dados do documento associado à chave informada. <see cref="Document"/></returns>
        public Document Cancel(Guid key)
        {
            var result = this.CancelAsync(key).Result;
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
            try
            {
                var result = await this.Client.PatchRequest($"documents/{key}/cancel")
                    .AddQueryParameter("access_token", this.ApiKey.ToString())
                    .ExecuteAsync<InternalResponse>(cancellationToken)
                    .ConfigureAwait(false);

                return result.Document;
            }
            catch (HttpException ex)
            {
                throw new ClickSignRequestException(ex.Content);
            }
            catch (Exception ex)
            {
                throw new ClickSignException(ex.Message);
            }
        }

        /// <summary>
        /// Método que efetua a duplicação de um documento ativo.
        /// </summary>
        /// <param name="key">Chave única do documento.</param>
        /// <returns>Dados do documento duplicado. <see cref="Document"/></returns>
        public Document Duplicate(Guid key)
        {
            var result = this.DuplicateAsync(key).Result;
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
            try
            {
                var result = await this.Client.PostRequest($"documents/{key}/duplicate")
                    .AddQueryParameter("access_token", this.ApiKey.ToString())
                    .ExecuteAsync<InternalResponse>(cancellationToken)
                    .ConfigureAwait(false);

                return result.Document;
            }
            catch (HttpException ex)
            {
                throw new ClickSignRequestException(ex.Content);
            }
            catch (Exception ex)
            {
                throw new ClickSignException(ex.Message);
            }
        }

        /// <summary>
        /// Método que traz os dados de um determinado assinante.
        /// </summary>
        /// <param name="key">Chave única do assinante.</param>
        /// <returns>Dados do assinante referentes à chave informada. <see cref="Signer"/></returns>
        public Signer GetSigner(Guid key)
        {
            var result = this.GetSignerAsync(key).Result;
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
            try
            {
                var result = await this.Client.GetRequest($"signers/{key}")
                    .AddQueryParameter("access_token", this.ApiKey.ToString())
                    .ExecuteAsync<InternalResponse>(cancellationToken)
                    .ConfigureAwait(false);

                return result.Signer;
            }
            catch (HttpException ex)
            {
                throw new ClickSignRequestException(ex.Content);
            }
            catch (Exception ex)
            {
                throw new ClickSignException(ex.Message);
            }
        }

        /// <summary>
        /// Método que efetua o cadastro de um novo assinante.
        /// </summary>
        /// <param name="request">Dados de requisição de criação do novo assinante. <see cref="CreateSignerRequest"/></param>
        /// <returns>Dados do assinante recém criado. <see cref="Signer"/></returns>
        public Signer CreateSigner(CreateSignerRequest request)
        {
            var result = this.CreateSignerAsync(request).Result;
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
            try
            {
                var createRequest = new InternalCreateSignerRequest(request);
                var result = await this.Client.PostRequest($"signers", createRequest)
                    .AddQueryParameter("access_token", this.ApiKey.ToString())
                    .ExecuteAsync<InternalResponse>(cancellationToken)
                    .ConfigureAwait(false);

                return result.Signer;
            }
            catch (HttpException ex)
            {
                throw new ClickSignRequestException(ex.Content);
            }
            catch (Exception ex)
            {
                throw new ClickSignException(ex.Message);
            }
        }

        /// <summary>
        /// Método que efetua a associação de um assinante à um documento à ser assinado.
        /// </summary>
        /// <param name="request">Dados da requisição de adição de assinante ao documento. <see cref="AddSignerRequest"/></param>
        /// <returns>Resposta da adição do assinante ao documento. <see cref="AddSignerResponse"/></returns>
        public AddSignerResponse AddSignerToDocument(AddSignerRequest request)
        {
            var result = this.AddSignerToDocumentAsync(request).Result;
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
            try
            {
                var addRequest = new InternalAddSignerDocumentRequest(request);
                var result = await this.Client.PostRequest($"lists", addRequest)
                    .AddQueryParameter("access_token", this.ApiKey.ToString())
                    .ExecuteAsync<InternalResponse>(cancellationToken)
                    .ConfigureAwait(false);

                return result.List;
            }
            catch (HttpException ex)
            {
                throw new ClickSignRequestException(ex.Content);
            }
            catch (Exception ex)
            {
                throw new ClickSignException(ex.Message);
            }
        }

        /// <summary>
        /// Método que efetua a remoção de um assinante de um documento.
        /// </summary>
        /// <param name="key">Chave da associação do assinante ao documento.</param>
        public void RemoveSignerFromDocument(Guid key)
        {
            this.RemoveSignerFromDocumentAsync(key).Wait();
        }

        /// <summary>
        /// Método que efetua a remoção de um assinante de um documento de forma assíncrona. 
        /// </summary>
        /// <param name="key">Chave da associação do assinante ao documento.</param>
        /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
        /// <returns>Tarefa assíncrona.</returns>
        public async Task RemoveSignerFromDocumentAsync(Guid key, CancellationToken cancellationToken = default)
        {
            try
            {
                await this.Client.DeleteRequest($"lists/{key}")
                    .AddQueryParameter("access_token", this.ApiKey.ToString())
                    .ExecuteAsync(cancellationToken)
                    .ConfigureAwait(false);

            }
            catch (HttpException ex)
            {
                throw new ClickSignRequestException(ex.Content);
            }
            catch (Exception ex)
            {
                throw new ClickSignException(ex.Message);
            }
        }

        /// <summary>
        /// Método que cria uma assinatura em lotes de documentos com um assinante em comum.
        /// </summary>
        /// <param name="request">Dados da requisição de criação da assinatura em lotes. Veja <see cref="BatchRequest"/></param>
        /// <returns>Dados da assinatura em lotes criada. Veja <see cref="BatchResponse"/>.</returns>
        public BatchResponse CreateBatch(BatchRequest request)
        {
            var result = CreateBatchAsync(request).Result;
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
            try
            {
                var batchRequest = new InternalBatchRequest(request);
                var result = await this.Client.PostRequest($"batches", batchRequest)
                    .AddQueryParameter("access_token", this.ApiKey.ToString())
                    .ExecuteAsync<BatchResponse>()
                    .ConfigureAwait(false);

                return result;
            }
            catch (HttpException ex)
            {
                throw new ClickSignRequestException(ex.Content);
            }
            catch (Exception ex)
            {
                throw new ClickSignException(ex.Message);
            }
        }

        /// <summary>
        /// Método que efetua o envio de um lembrete de assinatura de um documento.
        /// </summary>
        /// <param name="request">Dados da requisição de envio de notificação. Veja <see cref="NotificationRequest"/>.</param>
        public void SendNotification(NotificationRequest request)
        {
            SendNotificationAsync(request).Wait();
        }

        /// <summary>
        /// Método que efetua o envio de um lembrete de assinatura de um documento de forma assíncrona.
        /// </summary>
        /// <param name="request">Dados da requisição de envio de notificação. Veja <see cref="NotificationRequest"/>.</param>
        /// <param name="cancellationToken">Token de notificação de cancelamento de threads gerenciadas.</param>
        /// <returns>Tarefa assíncrona.</returns>
        public async Task SendNotificationAsync(NotificationRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var path = request?.Type == NotificationType.Email ? "notifications" : "notify_by_sms";
                await this.Client.PostRequest($"{path}", request)
                    .AddQueryParameter("access_token", this.ApiKey.ToString())
                    .ExecuteAsync(cancellationToken)
                    .ConfigureAwait(false);

            }
            catch (HttpException ex)
            {
                throw new ClickSignRequestException(ex.Content);
            }
            catch (Exception ex)
            {
                throw new ClickSignException(ex.Message);
            }
        }
    }
}
