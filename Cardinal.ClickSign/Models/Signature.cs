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
    /// Classe de modelo com os dados de uma assinantura.
    /// </summary>
    public class Signature
    {
        /// <summary>
        /// Nome do assinante.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Email do assinante.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Data de nascimento do assinante.
        /// </summary>
        [JsonProperty("birthday")]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Número do documento do assinante.
        /// </summary>
        [JsonProperty("documentation")]
        public string Documentation { get; set; }

        /// <summary>
        /// Endereço IP do assinante.
        /// </summary>
        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }

        /// <summary>
        /// Data de assinatura.
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
        [JsonProperty("signed_at")]
        public DateTime SignedAt { get; set; }

        /// <summary>
        /// A que título será realizada a assinatura. Veja <see cref="SignType"/>.
        /// </summary>
        [JsonConverter(typeof(SignTypeConverter))]
        [JsonProperty("sign_as")]
        public SignType SignAs { get; set; }

        /// <summary>
        /// Dados de validação do assinante.
        /// </summary>
        [JsonProperty("validation")]
        public SignatureValidation Validation { get; set; }

        /// <summary>
        /// Método que traz uma cadeia de caracteres que representa o objeto atual.
        /// </summary>
        /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
        public override string ToString()
        {
            return $"[NAME:{this.Name}][DOCUMENTATION:{this.Documentation}][IP:{this.IpAddress}][SIGN.AS:{this.SignAs}][SIGNED.AT:{this.SignedAt}][STATUS:{this.Validation?.Status}]";
        }
    }
}
