using Bludata.Models;
using BludataTeste.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BludataTeste.BLL
{
    public class EmpresaBLL
    {
        WebRMContext WebRMContext;

        public EmpresaBLL(WebRMContext webRMContext)
        {
            WebRMContext = webRMContext;
        }

        public string Validate(Empresa empresa)
        {
            StringBuilder validation = new StringBuilder();

            if (string.IsNullOrWhiteSpace(empresa.Nome))
                validation.Append("<br/> Nome é obrigatório. <br/>");
            if (string.IsNullOrWhiteSpace(empresa.CNPJ))
                validation.Append("<br/> CNPJ é obrigatório. <br/>");
            if (string.IsNullOrWhiteSpace(empresa.UF))
                validation.Append("<br/> Estado é obrigatório. <br/>");
            return validation.ToString();
        }

    }
}