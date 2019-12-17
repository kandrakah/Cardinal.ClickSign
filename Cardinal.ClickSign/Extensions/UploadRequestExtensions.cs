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

using Cardinal.ClickSign.Models;
using Cardinal.ClickSign.Utils;
using System;
using System.IO;

namespace Cardinal.ClickSign.Extensions
{
    /// <summary>
    /// Classe de extensões para <see cref="UploadRequest"/>.
    /// </summary>
    public static class UploadRequestExtensions
    {
        /// <summary>
        /// Método que define o conteúdo da requisição com base no endereço de um arquivo.
        /// </summary>
        /// <param name="request">Instância do objeto.</param>
        /// <param name="path">Nome do arquivo completo para adição à requisição.</param>
        /// <returns>Instância do objeto.</returns>
        public static UploadRequest SetContent(this UploadRequest request, string path)
        {
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return SetContent(request, stream);
            }
        }

        /// <summary>
        /// Método que define o conteúdo da requisição com base no fluxo de dados de um arquivo.
        /// </summary>
        /// <param name="request">Instância do objeto.</param>
        /// <param name="stream">Fluxo de dados à ser adicionado à requisição.</param>
        /// <returns>Instância do objeto.</returns>
        public static UploadRequest SetContent(this UploadRequest request, Stream stream)
        {
            stream.Position = 0;
            var streamBytes = stream.ToByteArray();
            stream.Position = 0;
            var base64Data = Convert.ToBase64String(streamBytes);
            var mimeType = MimetypeDetector.DetectMimeType(stream);
            request.Content = $"data:{mimeType};base64,{base64Data}";
            return request;
        }
    }
}
