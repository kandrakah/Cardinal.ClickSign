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

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Cardinal.ClickSign.Models
{
    /// <summary>
    /// Classe de resposta das requisições ao serviço.
    /// </summary>
    internal class InternalResponse
    {
        /// <summary>
        /// Documento criado ou retornado com base na chave informada.
        /// </summary>
        [JsonProperty("document")]
        internal Document Document { get; set; }

        /// <summary>
        /// Lista de documentos criados ou retornados.
        /// </summary>
        [JsonProperty("documents")]
        internal IEnumerable<Document> Documents { get; set; }

        /// <summary>
        /// Assinante criado ou retornado com base na chave informada.
        /// </summary>
        [JsonProperty("signer")]
        internal Signer Signer { get; set; }

        /// <summary>
        /// Dados da associação de um assinante à um documento.
        /// </summary>
        [JsonProperty("list")]
        internal AddSignerResponse List { get; set; }

        /// <summary>
        /// Dados de resposta à criação de uma assinatura em lotes.
        /// </summary>
        [JsonProperty("batch")]
        internal BatchResponse Batch { get; set; }

        /// <summary>
        /// Método que traz uma cadeia de caracteres que representa o objeto atual.
        /// </summary>
        /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
        public override string ToString()
        {
            if (this.Document != null)
            {
                return this.Document.ToString();
            }
            else if (this.Documents != null)
            {
                return this.Documents.Any() ? string.Join(string.Empty, this.Documents.Select(x => x.ToString())) : "[EMPTY RESPONSE]";
            }
            else if (this.Signer != null)
            {
                return this.Signer.ToString();
            }
            else if (this.List != null)
            {
                return this.List.ToString();
            }
            else if (this.Batch != null)
            {
                return this.Batch.ToString();
            }
            else
            {
                return "[EMPTY RESPONSE]";
            }
        }
    }
}
