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
    /// Classe que representa os dados de um evento.
    /// </summary>
    public class EventData
    {
        /// <summary>
        /// Dados do usuário do sistema.
        /// </summary>
        [JsonProperty("user")]
        public EventUser User { get; set; }

        /// <summary>
        /// Dados da conta do sistema.
        /// </summary>
        [JsonProperty("account")]
        public EventAccount Account { get; set; }

        /// <summary>
        /// Dados do assinante.
        /// </summary>
        [JsonProperty("signer")]
        public EventSigner Signer { get; set; }

        /// <summary>
        /// Dados de versão do log.
        /// </summary>
        [JsonProperty("log_version")]
        public string LogVersion { get; set; }

        /// <summary>
        /// Indica que o documento será fechado após a assinatura de todos os assinantes.
        /// </summary>
        [JsonProperty("auto_close")]
        public bool AutoClose { get; set; }

        /// <summary>
        /// Data limite para assinaturas ao documento.
        /// </summary>
        [JsonProperty("deadline_at")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss")]
        public DateTime Deadline { get; set; }

        /// <summary>
        /// Lista contendo assinantes.
        /// </summary>
        public IEnumerable<EventSigner> Signers { get; set; }

        /// <summary>
        /// Localização do documento.
        /// </summary>
        [JsonConverter(typeof(LocalesConverter))]
        [JsonProperty("locale")]
        public Locales Locale { get; set; }

        /// <summary>
        /// Método que traz uma cadeia de caracteres que representa o objeto atual.
        /// </summary>
        /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
        public override string ToString()
        {
            return $"[LOG.VERSION:{this.LogVersion}][AUTO.CLOSE:{this.AutoClose}][LOCALE:{this.Locale}][DEADLINE:{this.Deadline.ToString("yyyy-MM-ddTHH:mm:ss")}]";
        }
    }
}
