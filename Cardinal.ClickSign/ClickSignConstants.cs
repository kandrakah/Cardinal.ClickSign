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
using System.Runtime.CompilerServices;

namespace Cardinal.ClickSign
{
    /// <summary>
    /// Classe de constantes da biblioteca.
    /// </summary>
    internal class ClickSignConstants
    {
        /// <summary>
        /// URL padrão do serviço de sandbox.
        /// </summary>
        private const string SANDBOX_BASE_URL = "https://sandbox.clicksign.com";

        /// <summary>
        /// Url padrão do serviço de produção.
        /// </summary>
        private const string PRODUCTION_BASE_URL = "https://app.clicksign.com";

        /// <summary>
        /// Método que traz a url correta de acordo com a versão e ambiente definidos.
        /// </summary>
        /// <param name="environment">Ambiente de execução. <see cref="ApiEnvironment"/></param>
        /// <param name="version">Versão da api do serviço. <see cref="ApiVersion"/></param>
        /// <returns></returns>
        internal static string GetBaseUri(ApiEnvironment environment = ApiEnvironment.Sandbox, ApiVersion version = ApiVersion.V1)
        {
            switch (environment)
            {
                case ApiEnvironment.Sandbox:
                    return $"{SANDBOX_BASE_URL}/api/{version.ToString().ToLower()}/";
                case ApiEnvironment.Production:
                    return $"{PRODUCTION_BASE_URL}/api/{version.ToString().ToLower()}/";
                default:
                    return $"{SANDBOX_BASE_URL}/api/{version.ToString().ToLower()}/";
            }
        }
    }
}
