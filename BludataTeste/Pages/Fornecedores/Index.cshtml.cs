using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Bludata.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BludataTeste.Pages.Fornecedores
{
    public class IndexModel : BaseModel
    {
        private readonly BludataTeste.Data.WebRMContext _context;
        public IndexModel(Data.WebRMContext context) : base(context)
        {
            _context = context;
        }
        public IList<Fornecedor> Fornecedores { get; set; }
        public string buscar { get; set; }
        public DateTime date { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            Fornecedores = await _context.Fornecedor.ToListAsync();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string buscar, DateTime date)
        {

            if (buscar != null)
            {
                Fornecedores = await _context.Fornecedor.Where(w => w.Nome.Contains(buscar)).ToListAsync();
                if (Fornecedores.Count == 0)
                {
                    Fornecedores = await _context.Fornecedor.ToListAsync();
                    Fornecedores = await _context.Fornecedor.Where(w => w.CPF.Contains(buscar)).ToListAsync();

                    if (Fornecedores.Count == 0)
                    {
                        Fornecedores = await _context.Fornecedor.ToListAsync();
                        Fornecedores = await _context.Fornecedor.Where(w => w.CNPJ.Contains(buscar)).ToListAsync();
                    }
                }
            }
            if (date != null)
            {
                Fornecedores = await _context.Fornecedor.ToListAsync();
                Fornecedores = await _context.Fornecedor.Where(w => w.Create <= date).ToListAsync();
            }
            else
            {
                Fornecedores = await _context.Fornecedor.ToListAsync();
            }
            return Page();
        }
    }
}


