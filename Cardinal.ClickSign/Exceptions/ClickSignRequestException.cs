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
using System;
using System.Collections.Generic;

namespace Cardinal.ClickSign.Exceptions
{
    /// <summary>
    /// Classe container de mensagens de erro reportadas pelo serviço.
    /// </summary>
    public class ClickSignErrors
    {
        /// <summary>
        /// Lista de erros reportados pelo serviço.
        /// </summary>
        [JsonProperty("errors")]
        public IEnumerable<string> Errors { get; set; }

        /// <summary>
        /// Método construtor.
        /// </summary>
        public ClickSignErrors()
        {
            this.Errors = new List<string>();
        }

        /// <summary>
        /// Método que transforma o objeto em sua representação textual (string).
        /// </summary>
        /// <returns>Representação textual do objeto.</returns>
        public override string ToString()
        {
            return string.Join("; ", this.Errors);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ClickSignRequestException : ClickSignException
    {
        /// <summary>
        /// Erros reportados pelo serviço.
        /// </summary>
        public ClickSignErrors Errors { get; set; }

        /// <summary>
        /// Método construtor.
        /// </summary>
        public ClickSignRequestException() : base()
        {

        }

        /// <summary>
        /// Método construtor.
        /// </summary>
        /// <param name="message">Mensagem à ser definida na excessão.</param>
        public ClickSignRequestException(string message) : base(GetClickSignErrors(message))
        {
            try
            {
                this.Errors = JsonConvert.DeserializeObject<ClickSignErrors>(message);
            }
            catch
            {
                
            }
        }

        /// <summary>
        /// Método construtor.
        /// </summary>
        /// <param name="innerException">Excessão que causou a falha.</param>
        public ClickSignRequestException(Exception innerException) : base(innerException.Message)
        {

        }

        /// <summary>
        /// Método construtor.
        /// </summary>
        /// <param name="message">Mensagem à ser definida na excessão.</param>
        /// <param name="innerException">Excessão que causou a falha.</param>
        public ClickSignRequestException(string message, Exception innerException) : base(message, innerException)
        {

        }

        /// <summary>
        /// Método estático que transforma a mensagem retornada pelo serviço em uma 
        /// lista de excessões. Caso não possa ser convertido, será exibida a mensagem de erro padrão.
        /// </summary>
        /// <param name="message">Mensagem de excessão.</param>
        /// <returns></returns>
        private static string GetClickSignErrors(string message)
        {
            try
            {
                var errors = JsonConvert.DeserializeObject<ClickSignErrors>(message);
                return errors.ToString();
            }
            catch
            {
                return message;
            }
        }

        /// <summary>
        /// Método que transforma o objeto em sua representação textual (string).
        /// </summary>
        /// <returns>Representação textual do objeto.</returns>
        public override string ToString()
        {
            return this.Errors != null ? this.Errors.ToString() : this.Message;
        }
    }
}
