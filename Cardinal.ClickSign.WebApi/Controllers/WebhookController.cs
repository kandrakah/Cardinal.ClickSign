/*
The MIT License (MIT)

Copyright (c) 2019 - Marcelo O. Mendes

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

using Cardinal.ClickSign.Exceptions;
using Cardinal.ClickSign.Extensions;
using Cardinal.ClickSign.Models;
using Cardinal.ClickSign.Security;
using Cardinal.ClickSign.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Cardinal.ClickSign.Controllers
{
    /// <summary>
    /// Classe de controle para atendimento de requisições de webhook.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WebhookController : ControllerBase
    {
        /// <summary>
        /// Instância do serviço de webhook.
        /// </summary>
        private IWebhookService Service { get; }

        /// <summary>
        /// Chave HMAC para validação da requisição webhook.
        /// </summary>
        private string HMacKey { get; }

        /// <summary>
        /// Método construtor.
        /// </summary>
        /// <param name="services">Instância do container de serviços.</param>
        /// <param name="configuration">Instância do container de configurações.</param>
        public WebhookController(IServiceProvider services, IConfiguration configuration)
        {
            this.HMacKey = configuration.GetSection("ClickSign").GetSettings<ClickSignSettings>().WebhookKey;
            try
            {
                this.Service = services.GetService<IWebhookService>() ?? new DefaultWebhookService();
            }
            catch
            {
                this.Service = new DefaultWebhookService();
            }
        }

        /// <summary>
        /// Método que receberá as requisições do webhook.
        /// </summary>
        /// <param name="request">Dados da requisição.</param>
        /// <returns>Resposta da requisição. Veja <see cref="IActionResult"/></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(WebhookRequest request)
        {
            try
            {
                var data = this.HttpContext.Request.GetWebhookData();
                await HmacSignatureValidator.Validate(data, this.HMacKey);
                this.Service.Handle(request);
                return Ok();
            }
            catch (WebhookNotEnabledException ex) // Caso o serviço não tenha sido ativado.
            {
                return this.BadRequest(ex.Message);
            }
            catch (WebhookUnauthorizedException ex) // Caso a validação falhe.
            {
                return this.Unauthorized(ex.Message);
            }
            catch (ArgumentNullException ex) // Caso a chave HMAC esteja ausente.
            {
                return this.BadRequest(ex.Message);
            }
            catch (Exception ex) // Erro geral.
            {
                return this.StatusCode(500, ex.GetBaseException().Message);
            }
        }
    }
}
