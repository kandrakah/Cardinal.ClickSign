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

using Cardinal.ClickSign.Enumerators;
using Newtonsoft.Json;
using System;

namespace Cardinal.ClickSign.Converters
{
    /// <summary>
    /// Classe para conversão do enumerador <see cref="SignatureValidationStatus"/> para json e vice-versa.
    /// </summary>
    public class SignatureValidationConverter : JsonConverter
    {
        /// <summary>
        /// Método que valida se o tipo informado pode ser convertido.
        /// </summary>
        /// <param name="objectType">Tipo do objeto à ser convertido.</param>
        /// <returns>Verdadeiro caso o objeto possa ser convertido e falso caso contrário.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        /// <summary>
        /// Método que transforma o valor json no objeto referente.
        /// </summary>
        /// <param name="reader">Leitor do arquivo json.</param>
        /// <param name="objectType">tipo do objeto à ser convertido.</param>
        /// <param name="existingValue">Valor existente.</param>
        /// <param name="serializer">Serializador json.</param>
        /// <returns>Objeto referente ao valor informado.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = (string)reader.Value;

            switch (value)
            {
                case "conferred":
                    return SignatureValidationStatus.Conferred;
                case "cpf_not_found":
                    return SignatureValidationStatus.CpfNotFound;
                case "divergent":
                    return SignatureValidationStatus.Divergent;
                default:
                    return SignatureValidationStatus.Unknow;
            }
        }

        /// <summary>
        /// Método que transforma o objeto em sua representação json referente.
        /// </summary>
        /// <param name="writer">Escritor do arquivo json.</param>
        /// <param name="value">Objeto à ser traduzido.</param>
        /// <param name="serializer">Serializador json.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var authType = (SignatureValidationStatus)value;
            switch (authType)
            {
                case SignatureValidationStatus.Conferred:
                    writer.WriteValue("conferred");
                    break;
                case SignatureValidationStatus.CpfNotFound:
                    writer.WriteValue("cpf_not_found");
                    break;
                case SignatureValidationStatus.Divergent:
                    writer.WriteValue("divergent");
                    break;
                default:
                    writer.WriteValue("unknow");
                    break;
            }
        }
    }
}
