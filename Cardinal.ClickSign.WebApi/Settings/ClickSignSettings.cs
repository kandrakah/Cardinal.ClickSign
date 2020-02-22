/*
The MIT License (MIT)

Copyright (c) Marcelo O. Mendes

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

using Cardinal.ClickSign.Enumerators;
using System;

namespace Cardinal.ClickSign.Settings
{
    /// <summary>
    /// Classe com as configurações do serviço.
    /// </summary>
    public class ClickSignSettings
    {
        /// <summary>
        /// Chave de API para acesso ao serviço.
        /// </summary>
        public Guid ApiKey { get; set; }

        /// <summary>
        /// Ambiente à ser utilizado no serviço. Veja <see cref="ApiEnvironment"/>.
        /// </summary>
        public ApiEnvironment Environment { get; set; }

        /// <summary>
        /// Versão do serviço à ser utilizado. Veja <see cref="ApiVersion"/>.
        /// </summary>
        public ApiVersion Version { get; set; }

        /// <summary>
        /// Chave HMAC para validação webhook.
        /// </summary>
        public string WebhookKey { get; set; }

        /// <summary>
        /// Método construtor.
        /// </summary>
        public ClickSignSettings()
        {
            this.Environment = ApiEnvironment.Sandbox;
            this.Version = ApiVersion.V1;
            this.ApiKey = Guid.Empty;
        }

        /// <summary>
        /// Método que traz uma cadeia de caracteres que representa o objeto atual.
        /// </summary>
        /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
        public override string ToString()
        {
            return $"[KEY:{this.ApiKey}][ENVIRONMENT:{this.Environment}][VERSION:{this.Version}]";
        }
    }
}
