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
    /// Classe que representa um documento.
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Chave única do documento.
        /// </summary>
        [JsonProperty("key")]
        public Guid Key { get; set; }

        /// <summary>
        /// Caminho do documento.
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }

        /// <summary>
        /// Nome do arquivo.
        /// </summary>
        [JsonProperty("filename")]
        public string Filename { get; set; }

        /// <summary>
        /// Data de upload do documento.
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
        [JsonProperty("uploaded_at")]
        public DateTime Uploaded { get; set; }

        /// <summary>
        /// Data de atualização do documento.
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
        [JsonProperty("updated_at")]
        public DateTime Updated { get; set; }

        /// <summary>
        /// Data de finalização do documento.
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
        [JsonProperty("finished_at")]
        public DateTime? Finished { get; set; }

        /// <summary>
        /// Data limite de assinaturas do documento.
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
        [JsonProperty("deadline_at")]
        public DateTime Deadline { get; set; }

        /// <summary>
        /// Estado atual do documento.
        /// </summary>
        [JsonConverter(typeof(DocumentStatusConverter))]
        [JsonProperty("status")]
        public DocumentStatus Status { get; set; }

        /// <summary>
        /// Atributo que indica se o documento será finalizado após a última assinatura automaticamente.
        /// </summary>
        [JsonProperty("auto_close")]
        public bool AutoClose { get; set; }

        /// <summary>
        /// Atributo que define o idioma desejado para o documento.
        /// </summary>
        [JsonConverter(typeof(LocalesConverter))]
        [JsonProperty("locale")]
        public Locales Locale { get; set; }

        /// <summary>
        /// Atributo que contém os dados de download do documento. <see cref="Download"/>
        /// </summary>
        [JsonProperty("downloads")]
        public Download Downloads { get; set; }

        /// <summary>
        /// Lista contendo os assinantes do documento.
        /// </summary>
        [JsonProperty("signers")]
        public ICollection<DocumentSigner> Signers { get; set; }

        /// <summary>
        /// Lista contendo os eventos do documento.
        /// </summary>
        [JsonProperty("events")]
        public ICollection<Event> Events { get; set; }

        /// <summary>
        /// Método que traz uma cadeia de caracteres que representa o objeto atual.
        /// </summary>
        /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
        public override string ToString()
        {
            switch (this.Status)
            {
                case DocumentStatus.Running:
                    return $"[KEY:{this.Key}][FILENAME:{this.Filename}][STATUS:{this.Status}][DEADLINE:{this.Deadline.ToString("yyyy-MM-dd")}]";
                case DocumentStatus.Closed:
                    return $"[KEY:{this.Key}][FILENAME:{this.Filename}][STATUS:{this.Status}][FINISHED:{this.Finished.Value.ToString("yyyy-MM-dd")}]";
                default:
                    return $"[KEY:{this.Key}][FILENAME:{this.Filename}][STATUS:{this.Status}][FINISHED:{this.Finished.Value.ToString("yyyy-MM-dd")}]";
            }
        }
    }
}
