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

namespace Cardinal.ClickSign.Enumerators
{
    /// <summary>
    /// Enumerador com os tipos de assinatura disponíveis no serviço.
    /// </summary>
    public enum SignType
    {
        /// <summary>
        /// Assinante
        /// </summary>
        Sign,

        /// <summary>
        /// Assinar para aprovar
        /// </summary>
        Approve,

        /// <summary>
        /// Assinar como parte
        /// </summary>
        Party,

        /// <summary>
        /// Assinar como testemunha
        /// </summary>
        Witness,

        /// <summary>
        /// Assinar como interveniente
        /// </summary>
        Interventing,

        /// <summary>
        /// Assinar para acusar recebimento
        /// </summary>
        Receipt,

        /// <summary>
        /// Assinar como endorssante
        /// </summary>
        Endorser,

        /// <summary>
        /// Assinar como endorssattário
        /// </summary>
        Endorsee,

        /// <summary>
        /// Assinar como administrador
        /// </summary>
        Administrator,

        /// <summary>
        /// Assinar como avalista
        /// </summary>
        Guarantor,

        /// <summary>
        /// Assinar como cedente
        /// </summary>
        Transferor,

        /// <summary>
        /// Assinar como cessionário
        /// </summary>
        Transferee,

        /// <summary>
        /// Assinar como contratante
        /// </summary>
        Contractor,

        /// <summary>
        /// Assinar como contratada
        /// </summary>
        Contractee,

        /// <summary>
        /// Assinar como devedor solidário
        /// </summary>
        JointDebtor,

        /// <summary>
        /// Assinar como emitente
        /// </summary>
        Issuer,

        /// <summary>
        /// Assinar como gestor
        /// </summary>
        Manager,

        /// <summary>
        /// Assinar como compradora
        /// </summary>
        Buyer,

        /// <summary>
        /// Assinar como vendedora
        /// </summary>
        Seller,

        /// <summary>
        /// Assinar como procurador
        /// </summary>
        Attorney,

        /// <summary>
        /// Assinar como representante legal
        /// </summary>
        LegalRepresentative,

        /// <summary>
        /// Assinar como responsável solidário
        /// </summary>
        CoResponsible,

        /// <summary>
        /// Assinar como validador
        /// </summary>
        Validator
    }
}
