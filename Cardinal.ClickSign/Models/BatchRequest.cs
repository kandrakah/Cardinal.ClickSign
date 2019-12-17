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
using System;
using System.Collections.Generic;

namespace Cardinal.ClickSign.Models
{
    /// <summary>
    /// Classe de modelo de requisição de criação de assinatura em lotes.
    /// </summary>
    [JsonObject(Title = "batch")]
    public class BatchRequest
    {
        /// <summary>
        /// Chave única do signatário dentro da Clicksign.
        /// </summary>
        [JsonProperty("signer_key")]
        public Guid SignerKey { get; set; }

        /// <summary>
        /// Lista de chaves dos documentos que farão parte da assinatura em lotes.
        /// </summary>
        [JsonProperty("document_keys")]
        public ICollection<Guid> DocumentKeys { get; set; }

        /// <summary>
        /// Atributo que indica se será apresentado um sumário com todos os documentos
        /// à serem assinados. Caso verdadeiro, o sumário será apresentado e todos os
        /// documentos serão assinados de uma única vez, do contrário serão assinados em
        /// sequência.
        /// </summary>
        public bool Summary { get; set; }

        /// <summary>
        /// Método construtor.
        /// </summary>
        public BatchRequest()
        {
            this.DocumentKeys = new List<Guid>();
        }

        /// <summary>
        /// Método que traz uma cadeia de caracteres que representa o objeto atual.
        /// </summary>
        /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
        public override string ToString()
        {
            return $"[SIGNER:{this.SignerKey}][SUMMARY:{this.Summary}][DOCUMENTS:{this.DocumentKeys.Count}]";
        }
    }
}
