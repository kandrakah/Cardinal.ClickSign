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

using Microsoft.Extensions.Configuration;
using System;

namespace Cardinal.ClickSign.Extensions
{
    /// <summary>
    /// Classe de extensões de <see cref="IConfigurationSection"/>.
    /// </summary>
    internal static partial class ConfigurationSectionExtensions
    {
        /// <summary>
        /// Método de extensão para obter um objeto de configurações.
        /// </summary>
        /// <typeparam name="T">Objeto de configurações desejado.</typeparam>
        /// <param name="section">Instância do container de configurações.</param>
        /// <returns>Objeto de configurações.</returns>
        internal static T GetSettings<T>(this IConfigurationSection section) where T : class
        {
            var settings = section.Get<T>();
            if (settings == null)
            {
                settings = Activator.CreateInstance<T>();
            }
            return settings;
        }
    }
}
