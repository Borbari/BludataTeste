using BludataTeste.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BludataTeste
{
    public class BaseModel : PageModel
    {
        public readonly WebRMContext _context;
        public BaseModel(WebRMContext context)
        {
            _context = context;
        }
    }
}
