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

using Cardinal.ClickSign.Converters;
using Cardinal.ClickSign.Enumerators;
using Newtonsoft.Json;
using System;

namespace Cardinal.ClickSign.Models
{
    /// <summary>
    /// Classe de modelo que representa um assinante de um documento.
    /// </summary>
    public class DocumentSigner : Signer
    {
        /// <summary>
        /// Id da associação do assinante ao documento.
        /// </summary>
        [JsonProperty("list_key")]
        public Guid ListKey { get; set; }

        /// <summary>
        /// Id da requisição de assinatura.
        /// </summary>
        [JsonProperty("request_signature_key")]
        public Guid RequestSignatureKey { get; set; }

        /// <summary>
        /// Tipo de assinatura do assinante ao documento. Veja <see cref="SignType"/>.
        /// </summary>
        [JsonConverter(typeof(SignTypeConverter))]
        [JsonProperty("sign_as")]
        public SignType SignAs { get; set; }

        /// <summary>
        /// Tipo de envio de notificação de assinatura ao assinante.
        /// </summary>
        [JsonConverter(typeof(DeliveryTypeConverter))]
        [JsonProperty("delivery")]
        public DeliveryType Delivery { get; set; }

        /// <summary>
        /// Método construtor.
        /// </summary>
        public DocumentSigner()
        {
            this.SignAs = SignType.Sign;
            this.Delivery = DeliveryType.Email;
        }

        /// <summary>
        /// Método que traz uma cadeia de caracteres que representa o objeto atual.
        /// </summary>
        /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
        public override string ToString()
        {
            return this.HasDocumentation ? $"[KEY:{this.Key}][NAME:{this.Name}][DOCUMENT:{this.Documentation}][SIGNAS:{this.SignAs}]" : $"[KEY:{this.Key}][NAME:{this.Name}][SIGNAS:{this.SignAs}]";
        }
    }
}
