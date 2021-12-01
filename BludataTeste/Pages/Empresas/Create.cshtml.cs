using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bludata.Models;
using BludataTeste.BLL;
using BludataTeste.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BludataTeste.Pages.Empresas
{
    public class CreateModel : BaseModel
    {
        public readonly BludataTeste.Data.WebRMContext _context;
        public CreateModel(Data.WebRMContext context) : base(context)
        {
            _context = context;
        }
        [BindProperty]
        public Empresa Empresa { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string validacao = new EmpresaBLL(_context).Validate(Empresa);

            if (!string.IsNullOrEmpty(validacao))
            {
                ViewData["Alert"] = validacao;
                return Page();
            }
            try
            {
                Empresa.Create = DateTime.Now;
                Empresa.Change = DateTime.Now;
                await _context.Empresa.AddAsync(Empresa);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                ViewData["Alert"] = "Erro ao gravar no banco!";
            }

            return RedirectToPage("../Empresas/Create");
        }
    }
}
