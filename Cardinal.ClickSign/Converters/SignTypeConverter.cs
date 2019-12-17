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
    /// Classe para conversão do enumerador <see cref="SignType"/> para json e vice-versa.
    /// </summary>
    public class SignTypeConverter : JsonConverter
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
                case "sign":
                    return SignType.Sign;
                case "approve":
                    return SignType.Approve;
                case "party":
                    return SignType.Party;
                case "witness":
                    return SignType.Witness;
                case "interventing":
                    return SignType.Interventing;
                case "receipt":
                    return SignType.Receipt;
                case "endorser":
                    return SignType.Endorser;
                case "endorsee":
                    return SignType.Endorsee;
                case "administrator":
                    return SignType.Administrator;
                case "guarantor":
                    return SignType.Guarantor;
                case "transferor":
                    return SignType.Transferor;
                case "transferee":
                    return SignType.Transferee;
                case "contractor":
                    return SignType.Contractor;
                case "contractee":
                    return SignType.Contractee;
                case "joint_debtor":
                    return SignType.JointDebtor;
                case "issuer":
                    return SignType.Issuer;
                case "manager":
                    return SignType.Manager;
                case "buyer":
                    return SignType.Buyer;
                case "seller":
                    return SignType.Seller;
                case "attorney":
                    return SignType.Attorney;
                case "legal_representative":
                    return SignType.LegalRepresentative;
                case "co_responsible":
                    return SignType.CoResponsible;
                case "validator":
                    return SignType.Validator;
                default:
                    return SignType.Sign;
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
            var signType = (SignType)value;
            switch (signType)
            {
                case SignType.Sign:
                    writer.WriteValue("sign");
                    break;
                case SignType.Approve:
                    writer.WriteValue("approve");
                    break;
                case SignType.Party:
                    writer.WriteValue("party");
                    break;
                case SignType.Witness:
                    writer.WriteValue("witness");
                    break;
                case SignType.Interventing:
                    writer.WriteValue("interventing");
                    break;
                case SignType.Receipt:
                    writer.WriteValue("receipt");
                    break;
                case SignType.Endorser:
                    writer.WriteValue("endorser");
                    break;
                case SignType.Endorsee:
                    writer.WriteValue("endorsee");
                    break;
                case SignType.Administrator:
                    writer.WriteValue("administrator");
                    break;
                case SignType.Guarantor:
                    writer.WriteValue("guarantor");
                    break;
                case SignType.Transferor:
                    writer.WriteValue("transferor");
                    break;
                case SignType.Transferee:
                    writer.WriteValue("transferee");
                    break;
                case SignType.Contractor:
                    writer.WriteValue("contractor");
                    break;
                case SignType.Contractee:
                    writer.WriteValue("contractee");
                    break;
                case SignType.JointDebtor:
                    writer.WriteValue("joint_debtor");
                    break;
                case SignType.Issuer:
                    writer.WriteValue("issuer");
                    break;
                case SignType.Manager:
                    writer.WriteValue("manager");
                    break;
                case SignType.Buyer:
                    writer.WriteValue("buyer");
                    break;
                case SignType.Seller:
                    writer.WriteValue("seller");
                    break;
                case SignType.Attorney:
                    writer.WriteValue("attorney");
                    break;
                case SignType.LegalRepresentative:
                    writer.WriteValue("legal_representative");
                    break;
                case SignType.CoResponsible:
                    writer.WriteValue("co_responsible");
                    break;
                case SignType.Validator:
                    writer.WriteValue("validator");
                    break;
                default:
                    writer.WriteValue("sign");
                    break;
            }
        }
    }
}
