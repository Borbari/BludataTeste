using BludataTeste.Models;

namespace Bludata.Models
{
    public class Empresa : BaseModel
    {
        public string UF { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
    }
}
