﻿/*
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

namespace Cardinal.ClickSign.Models
{
    /// <summary>
    /// Classe interna para requisição de criação de assinatura em lotes.
    /// </summary>
    internal class InternalBatchRequest
    {
        /// <summary>
        /// Dados da assinatura em lote à ser criada.
        /// </summary>
        [JsonProperty("batch")]
        internal BatchRequest Batch { get; set; }

        /// <summary>
        /// Método construtor.
        /// </summary>
        /// <param name="request">Dados da assinatura em lote à ser criada.</param>
        public InternalBatchRequest(BatchRequest request)
        {
            this.Batch = request;
        }

        /// <summary>
        /// Método que traz uma cadeia de caracteres que representa o objeto atual.
        /// </summary>
        /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
        public override string ToString()
        {
            return this.Batch?.ToString();
        }
    }
}
