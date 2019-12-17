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

namespace Cardinal.ClickSign.Models
{
    /// <summary>
    /// Classe que representa as urls de download de um documento.
    /// </summary>
    public class Download
    {
        /// <summary>
        /// Endereço de download do arquivo original.
        /// </summary>
        [JsonProperty("original_file_url")]
        public string OriginalUrl { get; set; }

        /// <summary>
        /// Endereço de download do arquivo assinado.
        /// </summary>
        [JsonProperty("signed_file_url")]
        public string SignedUrl { get; set; }

        /// <summary>
        /// endereço de download do arquivo .zip contendo o arquivo original e o assinado.
        /// </summary>
        [JsonProperty("ziped_file_url")]
        public string ZippedUrl { get; set; }

        /// <summary>
        /// Método que traz uma cadeia de caracteres que representa o objeto atual.
        /// </summary>
        /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
        public override string ToString()
        {
            return $"[ORIGINAL:{!string.IsNullOrEmpty(this.OriginalUrl)}][SIGNED:{!string.IsNullOrEmpty(this.SignedUrl)}][ZIPPED:{!string.IsNullOrEmpty(this.ZippedUrl)}]";
        }
    }
}
