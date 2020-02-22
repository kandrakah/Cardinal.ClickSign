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

using Cardinal.ClickSign.Exceptions;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cardinal.ClickSign.Security
{
    /// <summary>
    /// Classe responsável pela validação de assinatura de dados vindos de uma requisição Webhook do serviço.
    /// </summary>
    public static class HmacSignatureValidator
    {
        /// <summary>
        /// Método que efetua a validação do conteúdo da mensagem de acordo com a assinatura Hmac.
        /// </summary>
        /// <param name="data">dados da requisição à serem validados.</param>
        /// <param name="hmacKey">Chave HMAC para validação.</param>
        public static async Task Validate(WebhookData data, string hmacKey)
        {
            if (string.IsNullOrEmpty(hmacKey))
            {
                throw new ArgumentNullException("A chave HMAC não foi informada!");
            }

            using (var stream = new StreamReader(data.Body))
            {
                var bodyString = await stream.ReadToEndAsync();
                var bodySha256 = GenerateHmacSignature(bodyString, hmacKey);
                var result = string.IsNullOrEmpty(data.Signature) ? false : data.Signature.Equals(bodySha256);
                if (!result)
                {
                    throw new WebhookUnauthorizedException("Assinatura de requisição não validada!");
                }
            }
        }

        /// <summary>
        /// Método que efetua a validação do conteúdo da mensagem de acordo com a assinatura Hmac.
        /// </summary>
        /// <param name="body">Conteúdo à ser validado.</param>
        /// <param name="requestHmac">HMAC enviado juntamente com o conteúdo.</param>
        /// <param name="hmacKey">Chave HMAC para validação.</param>
        public static void Validate(string body, string requestHmac, string hmacKey)
        {
            if (string.IsNullOrEmpty(hmacKey))
            {
                throw new ArgumentNullException("A chave HMAC não foi informada!");
            }

            var bodySha256 = GenerateHmacSignature(body, hmacKey);
            var result = string.IsNullOrEmpty(requestHmac) ? false : requestHmac.Equals(hmacKey);
            if (!result)
            {
                throw new WebhookUnauthorizedException("Assinatura de requisição não validada!");
            }
        }

        /// <summary>
        /// Método que faz a geração do valor Hmac de um conjunto de dados.
        /// </summary>
        /// <param name="value">Dados à terem seu valor Hmac gerado.</param>
        /// <param name="key">Chave de criação.</param>
        /// <returns>Assinatura Hmac gerada.</returns>
        public static string GenerateHmacSignature(string value, string key)
        {
            var encoding = new UTF8Encoding();
            var textBytes = encoding.GetBytes(value);
            var keyBytes = encoding.GetBytes(key);
            var hashBytes = default(byte[]);
            using (var hash = new HMACSHA256(keyBytes))
            {
                hashBytes = hash.ComputeHash(textBytes);
            }
            var result = BitConverter.ToString(hashBytes);
            return result.Replace("-", string.Empty).ToLower();
        }
    }
}
