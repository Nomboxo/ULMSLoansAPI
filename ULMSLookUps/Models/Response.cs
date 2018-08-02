using System.ComponentModel.DataAnnotations.Schema;

namespace ULMSLookUps.Models
{
    public class Response
    {
        [NotMapped]
        public int StatusCode { get; set; }
        [NotMapped]
        public string Message { get; set; }
    }
}
