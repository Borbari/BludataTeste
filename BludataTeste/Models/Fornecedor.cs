using BludataTeste.Models;
using System;

namespace Bludata.Models
{
    public class Fornecedor : BaseModel
    {
        public long? EmpresaID { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string RG { get; set; }
        public DateTime DataNasc { get; set; }

    }
}
