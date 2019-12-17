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

using Cardinal.ClickSign.Enumerators;
using Newtonsoft.Json;
using System;

namespace Cardinal.ClickSign.Models
{
    /// <summary>
    /// Classe de modelo de requisição de notificação de assinatura.
    /// </summary>
    public class NotificationRequest
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("request_signature_key")]
        public Guid SignatureKey { get; set; }

        /// <summary>
        /// Mensagem à ser enviada ao assinante.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Url de assinatura.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Canal de assinatura. Veja <see cref="NotificationType"/>.
        /// </summary>
        [JsonIgnore]
        public NotificationType Type { get; set; }

        /// <summary>
        /// Método construtor.
        /// </summary>
        public NotificationRequest()
        {
            this.Type = NotificationType.Email;
        }

        /// <summary>
        /// Método que traz uma cadeia de caracteres que representa o objeto atual.
        /// </summary>
        /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
        public override string ToString()
        {
            return $"[KEY:{this.SignatureKey}][TYPE:{this.Type}][MESSAGE:{this.Message}]";
        }
    }
}
