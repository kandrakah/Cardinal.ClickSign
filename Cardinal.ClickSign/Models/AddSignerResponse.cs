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
    /// Classe de modelo de resposta de adição de um assinante à um documento.
    /// </summary>
    public class AddSignerResponse
    {
        /// <summary>
        /// Chave da associação do assinante ao documento.
        /// </summary>
        [JsonProperty("key")]
        public Guid Key { get; set; }

        /// <summary>
        /// Chave de requisição de assinatura.
        /// </summary>
        [JsonProperty("request_signature_key")]
        public Guid SignatureKey { get; set; }

        /// <summary>
        /// Chave de do documento.
        /// </summary>
        [JsonProperty("document_key")]
        public Guid DocumentKey { get; set; }

        /// <summary>
        /// Chave do assinante.
        /// </summary>
        [JsonProperty("signer_key")]
        public Guid SignerKey { get; set; }

        /// <summary>
        /// Atributo que define o tipo de assinatura que o assinante fará ao documento. <see cref="SignType"/>
        /// </summary>
        [JsonConverter(typeof(SignTypeConverter))]
        [JsonProperty("sign_as")]
        public SignType SignAs { get; set; }

        /// <summary>
        /// Data de criação da associação de assinatura.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Data de atualização da associação de assinatura.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime Updated { get; set; }

        /// <summary>
        /// Url de assinatura do documento.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Método que traz uma cadeia de caracteres que representa o objeto atual.
        /// </summary>
        /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
        public override string ToString()
        {
            return $"[KEY:{this.Key}][SIGNATURE.KEY:{this.SignatureKey}][DOCUMENT.KEY:{this.DocumentKey}][SIGNAS:{this.SignAs}][CREATED:{this.Created.ToString("yyyy-MM-ddTHH:mm:ss")}]";
        }
    }
}
