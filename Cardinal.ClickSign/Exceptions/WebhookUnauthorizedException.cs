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

using System;

namespace Cardinal.ClickSign.Exceptions
{
    /// <summary>
    /// Exceção ligada à não autorização do webhook.
    /// </summary>
    public class WebhookUnauthorizedException : ClickSignException
    {
        /// <summary>
        /// Método construtor.
        /// </summary>
        public WebhookUnauthorizedException() : base()
        {

        }

        /// <summary>
        /// Método construtor.
        /// </summary>
        /// <param name="message">Mensagem à ser definida na excessão.</param>
        public WebhookUnauthorizedException(string message) : base(message)
        {

        }

        /// <summary>
        /// Método construtor.
        /// </summary>
        /// <param name="innerException">Excessão que causou a falha.</param>
        public WebhookUnauthorizedException(Exception innerException) : base(innerException.Message)
        {

        }

        /// <summary>
        /// Método construtor.
        /// </summary>
        /// <param name="message">Mensagem à ser definida na excessão.</param>
        /// <param name="innerException">Excessão que causou a falha.</param>
        public WebhookUnauthorizedException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
