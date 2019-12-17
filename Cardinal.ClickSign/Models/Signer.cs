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
    /// Classe de modelo com os dados de um assinante.
    /// </summary>
    public class Signer
    {
        /// <summary>
        /// Chave do signatário. Essa chave é utilizada no Widget Embedded e na requisição para Remover Signatários.
        /// </summary>
        [JsonProperty("key")]
        public Guid Key { get; set; }

        /// <summary>
        /// Data de criação do signatário no documento.
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
        [JsonProperty("created_at")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Data de atualização do signatário no documento.
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
        [JsonProperty("updated_at")]
        public DateTime Updated { get; set; }

        /// <summary>
        /// Email do signatário que deverá assinar o documento.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Nome completo do signatário.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Não solicita os campos CPF e data de nascimento do signatário no momento da assinatura. Útil para signatários que não possuem CPF.
        /// </summary>
        [JsonProperty("has_documentation")]
        public bool HasDocumentation { get; set; }

        /// <summary>
        /// CPF do signatário.
        /// </summary>
        [JsonProperty("documentation")]
        public string Documentation { get; set; }

        /// <summary>
        /// Data de nascimento do signatário.
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        [JsonProperty("birthday")]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Número de telefone para o envio do SMS.
        /// </summary>
        [JsonProperty("phone_number")]
        public string Phone { get; set; }

        /// <summary>
        /// Tipo de autenticação para realizar assinatura.
        /// </summary>
        [JsonProperty("auths", ItemConverterType = typeof(AuthTypesConverter))]
        public ICollection<AuthType> Auths { get; set; }

        /// <summary>
        /// Método construtor.
        /// </summary>
        public Signer()
        {
            this.Auths = new List<AuthType>() { AuthType.Email };
        }

        /// <summary>
        /// Método que traz uma cadeia de caracteres que representa o objeto atual.
        /// </summary>
        /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
        public override string ToString()
        {
            return this.HasDocumentation ? $"[KEY:{this.Key}][NAME:{this.Name}][DOCUMENT:{this.Documentation}]" : $"[KEY:{this.Key}][NAME:{this.Name}]";
        }
    }
}
