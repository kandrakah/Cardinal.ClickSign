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
    /// Classe de modelo de requisição de criação de assinante.
    /// </summary>
    public class CreateSignerRequest
    {
        /// <summary>
        /// Nome do assinante.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Endereço de email do assinante.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Indica se o assinante possui documento associado.
        /// </summary>
        [JsonProperty("has_documentation")]
        public bool HasDocumentation { get; set; }

        /// <summary>
        /// Número do documento do assinante.
        /// </summary>
        [JsonProperty("documentation")]
        public string Documentation { get; set; }

        /// <summary>
        /// Data de aniversário do assinante.
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        [JsonProperty("birthday")]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Número de telefone do assinante.
        /// </summary>
        [JsonProperty("phone_number")]
        public string Phone { get; set; }

        /// <summary>
        /// Tipo de autenticação à ser utilizada pelo assinante.
        /// </summary>
        [JsonProperty("auths", ItemConverterType = typeof(AuthTypesConverter))]
        public ICollection<AuthType> Auths { get; set; }

        /// <summary>
        /// Método construtor.
        /// </summary>
        public CreateSignerRequest()
        {
            this.Auths = new List<AuthType>() { AuthType.Email };
        }

        /// <summary>
        /// Método que traz uma cadeia de caracteres que representa o objeto atual.
        /// </summary>
        /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
        public override string ToString()
        {
            if (this.HasDocumentation)
            {
                return $"[NAME:{this.Name}][DOCUMENT:{this.Documentation}][BIRTHDAY:{this.Birthday.ToString("yyyy-MM-dd")}][EMAIL:{this.Email}][PHONE:{this.Phone}]";
            }
            else
            {
                return $"[NAME:{this.Name}][BIRTHDAY:{this.Birthday.ToString("yyyy-MM-dd")}][EMAIL:{this.Email}][PHONE:{this.Phone}]";
            }
        }
    }
}
