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
    /// Objeto com os dados de upload de um documento.
    /// </summary>
    public class UploadRequest
    {
        /// <summary>
        /// Diretório onde o documento deve ser armazenado.
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }

        /// <summary>
        /// Conteúdo do documento.
        /// </summary>
        [JsonProperty("content_base64")]
        public string Content { get; set; }

        /// <summary>
        /// Data limite para efetuar assinaturas no documento.
        /// </summary>
        [JsonProperty("deadline_at")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
        public DateTime Deadline { get; set; }

        /// <summary>
        /// Indica que o documento deve ser fechado logo após a última assinatura.
        /// </summary>
        [JsonProperty("auto_close")]
        public bool AutoClose { get; set; }

        /// <summary>
        /// Localização do documento.
        /// </summary>
        [JsonConverter(typeof(LocalesConverter))]
        [JsonProperty("locale")]
        public Locales Locale { get; set; } 

        /// <summary>
        /// Método construtor.
        /// </summary>
        public UploadRequest()
        {
            var now = DateTime.Now;
            this.Deadline = now.AddDays(30);
            this.AutoClose = true;
            this.Locale = Locales.PtBR;
        }

        /// <summary>
        /// Método que traz uma cadeia de caracteres que representa o objeto atual.
        /// </summary>
        /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
        public override string ToString()
        {
            return $"[PATH:{this.Path}][DEADLINE:{this.Deadline.ToString("yyyy-MM-ddTHH:mm:ss")}][LOCALE:{this.Locale}][AUTOCLOSE:{this.AutoClose}]";
        }
    }
}
