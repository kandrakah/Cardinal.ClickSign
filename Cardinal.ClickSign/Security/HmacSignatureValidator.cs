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

using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cardinal.ClickSign.Security
{
    /// <summary>
    /// Classe responsável pela validação de assinatura de um vetor de dados vindo de uma requisição Webhook do serviço.
    /// </summary>
    public static class HmacSignatureValidator
    {
        /// <summary>
        /// Método que efetua a validação do conteúdo da mensagem de acordo com a assinatura Hmac.
        /// </summary>
        /// <param name="request">Requisição à ser analizada.</param>
        /// <param name="hmacKey">Chave Hmac de validação.</param>
        /// <returns></returns>
        public static async Task<bool> ValidateWebHookRequest(HttpRequestMessage request, string hmacKey)
        {
            var builder = new StringBuilder();
            var content = await request.Content.ReadAsStreamAsync();
            using (var bodyStream = new StreamReader(content))
            {
                var bodyString = await bodyStream.ReadToEndAsync();
                var bodySha256 = HmacSha256(bodyString, hmacKey);
                var key = request.Headers.GetValues("Content-Hmac").FirstOrDefault()?.Replace("sha256=", string.Empty);                
                return string.IsNullOrEmpty(key) ? false : key.Equals(bodySha256);
            }
        }

        /// <summary>
        /// Método que faz a geração do valor Hmac de um conjunto de dados.
        /// </summary>
        /// <param name="text">Dados à terem seu valor Hmac gerado.</param>
        /// <param name="key">Chave de criação.</param>
        /// <returns>Assinatura Hmac gerada.</returns>
        public static string HmacSha256(string text, string key)
        {
            var encoding = new UTF8Encoding();
            var textBytes = encoding.GetBytes(text);
            var keyBytes = encoding.GetBytes(key);
            byte[] hashBytes;
            using (var hash = new HMACSHA256(keyBytes))
            {
                hashBytes = hash.ComputeHash(textBytes);
            }
            return BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLower();
        }
    }
}
