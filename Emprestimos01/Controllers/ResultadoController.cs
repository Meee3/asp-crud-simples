using Emprestimos01.Data;
using Emprestimos01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Emprestimos01.Controllers
{
  
    public class ResultadoController : Controller
    {
        //private readonly Emprestimos01Context _context;
        //ViewData["EmprestimoAtivo"] = new SelectList(_context.Empresa, "EmprestimoAtivo", "EmprestimoAtivo");
        //ViewData["EmprestimoAtivo"] = new SelectList();
        //public ResultadoController(ResultadoController context)
        //{
        //    _context = context;
        //}

        public IActionResult Index()
        {
            return View();
        }


        //// GET: Emprestimos
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Emprestimos.ToListAsync());
        //}


        public  void SomarSolicitados()
        {
            Emprestimos emprestimos = new Emprestimos();

            ViewBag.Emprestimos = emprestimos.valorSolicitado;


            List<Emprestimos> listaEmprestimosSomatorio = new List<Emprestimos>();
           // listaEmprestimosSomatorio.AddRange([ViewBag.Emprestimos]

        }
        
    }
}
