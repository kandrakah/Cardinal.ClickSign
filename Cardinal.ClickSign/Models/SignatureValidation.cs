using Cardinal.ClickSign.Converters;
using Cardinal.ClickSign.Enumerators;
using Newtonsoft.Json;

namespace Cardinal.ClickSign.Models
{
    /// <summary>
    /// Classe de modelo com os dados da validação de uma assinatura.
    /// </summary>
    public class SignatureValidation
    {
        /// <summary>
        /// Status da validação.
        /// </summary>
        [JsonProperty("status", ItemConverterType = typeof(AuthTypesConverter))]
        public SignatureValidationStatus Status { get; set; }

        /// <summary>
        /// Nome validado.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Método que traz uma cadeia de caracteres que representa o objeto atual.
        /// </summary>
        /// <returns>Cadeia de caracteres que representa o objeto atual.</returns>
        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                return $"[STATUS:{this.Status}]";
            }
            else
            {
                return $"[NAME:{this.Name}][STATUS:{this.Status}]";
            }
        }
    }
}
