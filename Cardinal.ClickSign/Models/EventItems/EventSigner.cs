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
using System.Collections.Generic;

namespace Cardinal.ClickSign.Models
{
    /// <summary>
    /// Evento do assinante.
    /// </summary>
    public class EventSigner
    {
        /// <summary>
        /// Id do assinante.
        /// </summary>
        public Guid Key { get; set; }

        /// <summary>
        /// Nome do assinante.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Número do documento do assinante.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// Data de nascimento do assinante.
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Endereço do assinante.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Email do assinante.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Indica se o assinate possui documentação.
        /// </summary>
        public bool HasDocumentation { get; set; }

        /// <summary>
        /// Data de criação do assinante.
        /// </summary>
        [JsonProperty("created_at")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
        public DateTime Creation { get; set; }

        /// <summary>
        /// A que título será realizada a assinatura. Veja <see cref="SignType"/>.
        /// </summary>
        [JsonConverter(typeof(SignTypeConverter))]
        [JsonProperty("sign_as")]
        public SignType SignAs { get; set; }

        /// <summary>
        /// Método de autenticação do assinante.
        /// </summary>
        [JsonProperty("auths", ItemConverterType = typeof(AuthTypesConverter))]
        public ICollection<AuthType> Auths { get; set; }

        /// <summary>
        /// Url de assinatura do documento.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Método que traz uma cadeia de caracteres que representa o objeto atual.
        /// </summary>
        /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
        public override string ToString()
        {
            if (this.HasDocumentation)
            {
                return $"[KEY:{this.Key}][NAME:{this.Name}][DOCUMENTATION:{this.Documentation}][SIGNAS:{this.SignAs}]";
            }
            else
            {
                return $"[KEY:{this.Key}][NAME:{this.Name}][SIGNAS:{this.SignAs}]";
            }
        }
    }
}
