using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bludata.Models;
using BludataTeste.BLL;
using BludataTeste.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BludataTeste.Pages.Fornecedores
{
    public class CreateModel : BaseModel
    {
        public readonly BludataTeste.Data.WebRMContext _context;
        public CreateModel(Data.WebRMContext context) : base(context)
        {
            _context = context;
        }
        [BindProperty]
        public Fornecedor Fornecedor { get; set; }
        public IList<Empresa> Empresas { get; set; }
        public void OnGet()
        {
            ViewData["EmpresaID"] = new SelectList(_context.Empresa, "ID", "Nome");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string validacao = new FornecedorBLL(_context).Validate(Fornecedor);

            if (!string.IsNullOrEmpty(validacao))
            {
                ViewData["EmpresaID"] = new SelectList(_context.Empresa, "ID", "Nome");
                ViewData["Alert"] = validacao;
                return Page();
            }
            Empresa empresa = await _context.Empresa.FirstOrDefaultAsync(w=>w.ID == Fornecedor.EmpresaID);
            if(empresa.UF == "PR")
            {
                var dateAtual = DateTime.Now.Year;
                var dateNasc = Fornecedor.DataNasc.Year;
                var idade = dateAtual - dateNasc;
                if (idade < 18)
                {
                    ViewData["EmpresaID"] = new SelectList(_context.Empresa, "ID", "Nome");
                    ViewData["Alert"] = "Idade para empresa do Paraná precisa ser maior que 18!";
                    return Page();
                }
            }

            try
            {
                Fornecedor.Create = DateTime.Now;
                Fornecedor.Change = DateTime.Now;
                await _context.Fornecedor.AddAsync(Fornecedor);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                ViewData["Alert"] = "Erro ao gravar no banco!";
            }
            return RedirectToPage("../Fornecedores/Create");
        }
    }
}