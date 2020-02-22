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
    /// Classe para conversão do enumerador <see cref="EventType"/> para json e vice-versa.
    /// </summary>
    public class EventTypeConverter : JsonConverter
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
                case "upload":
                    return EventType.Upload;
                case "add_signer":
                    return EventType.AddSigner;
                case "remove_signer":
                    return EventType.RemoveSigner;
                case "sign":
                    return EventType.Sign;
                case "close":
                    return EventType.Close;
                case "auto_close":
                    return EventType.AutoClose;
                case "deadline":
                    return EventType.Deadline;
                case "cancel":
                    return EventType.Cancel;
                case "update_deadline":
                    return EventType.UpdateDeadline;
                case "update_auto_close":
                    return EventType.UpdateAutoClose;
                default:
                    return EventType.Unknow;
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
            var locale = (EventType)value;
            switch (locale)
            {
                case EventType.Upload:
                    writer.WriteValue("upload");
                    break;
                case EventType.AddSigner:
                    writer.WriteValue("add_signer");
                    break;
                case EventType.RemoveSigner:
                    writer.WriteValue("remove_signer");
                    break;
                case EventType.Sign:
                    writer.WriteValue("sign");
                    break;
                case EventType.Close:
                    writer.WriteValue("close");
                    break;
                case EventType.AutoClose:
                    writer.WriteValue("auto_close");
                    break;
                case EventType.Deadline:
                    writer.WriteValue("deadline");
                    break;
                case EventType.Cancel:
                    writer.WriteValue("cancel");
                    break;
                case EventType.UpdateDeadline:
                    writer.WriteValue("update_deadline");
                    break;
                case EventType.UpdateAutoClose:
                    writer.WriteValue("update_auto_close");
                    break;
                default:
                    writer.WriteValue("unknow");
                    break;
            }
        }
    }
}
