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
    /// Enumerador com os tipos de eventos que podem ocorrer.
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// Ocorre quando o evento é desconhecido.
        /// </summary>
        Unknow,

        /// <summary>
        /// Ocorre quando é realizado o upload de um documento.
        /// </summary>
        Upload,

        /// <summary>
        /// Ocorre quando são adicionados signatários a um documento.
        /// </summary>
        AddSigner,

        /// <summary>
        /// Ocorre quando são removidos signatários de um documento.
        /// </summary>
        RemoveSigner,

        /// <summary>
        /// Ocorre quando um signatário assina um documento.
        /// </summary>
        Sign,

        /// <summary>
        /// Ocorre quando um documento é finalizado manualmente.
        /// </summary>
        Close,

        /// <summary>
        /// Ocorre quando um documento é finalizado automaticamente logo após a última assinatura.
        /// </summary>
        AutoClose,

        /// <summary>
        /// Ocorre quando a data limite de assinatura de um documento for atingida. Se o documento contiver ao menos uma assinatura, ele é finalizado. Caso contrário, o documento é cancelado.
        /// </summary>
        Deadline,

        /// <summary>
        /// Ocorre quando um documento é cancelado manualmente.
        /// </summary>
        Cancel,

        /// <summary>
        /// Ocorre quando a data limite de assinatura de um documento é alterada.
        /// </summary>
        UpdateDeadline,

        /// <summary>
        /// Ocorre quando a opção de finalização automática de um documento é alterada.
        /// </summary>
        UpdateAutoClose
    }
}
