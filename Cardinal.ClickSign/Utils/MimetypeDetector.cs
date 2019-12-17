using Cardinal.ClickSign.Extensions;
using Cardinal.ClickSign.Utils.Mimetype;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cardinal.ClickSign.Utils
{
    /// <summary>
    /// Classe estática para detecção do mimetype de arquivos de acordo com a assinatura.
    /// </summary>
    public static class MimetypeDetector
    {
        /// <summary>
        /// Método que identifica o mimetype de um fluxo de dados.
        /// </summary>
        /// <param name="stream">Fluxo de dados do arquivo à ser analizado.</param>
        /// <returns></returns>
        internal static string DetectMimeType(Stream stream)
        {
            var sniffer = new Sniffer();
            var records = new List<Record>()
            {
                new Record("pdf", "25 50 44 46"),
                new Record("doc", "D0 CF 11 E0 A1 B1 1A E1"),
                new Record("docx", "50,4b,03,04"),
                new Record("docx", "50,4b,07,08"),
                new Record("docx", "50,4b,05,06"),
            };
            sniffer.Populate(records);

            string mimeType;
            try
            {
                var head = stream.ToByteArray().Take(20).ToArray();
                var results = sniffer.Match(head);
                mimeType = MimeTypes.GetMimeType(results.First());
            }
            catch
            {
                mimeType = "application/octet-stream";
            }

            return mimeType;
        }
    }
}
