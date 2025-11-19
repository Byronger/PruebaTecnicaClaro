using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PruebaTecnica.Controllers
{
    public class PalindromosController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string texto)
        {
            var palindromos = ObtenerPalindromos(texto);
            ViewBag.Resultado = palindromos;
            ViewBag.Cantidad = palindromos.Count;

            return View();
        }

        private List<string> ObtenerPalindromos(string texto)
        {
            var lista = new List<string>();

            for (int i = 0; i < texto.Length; i++)
            {
                for (int j = i + 1; j <= texto.Length; j++)
                {
                    var sub = texto.Substring(i, j - i);

                    if (EsPalindromo(sub))
                        lista.Add(sub);
                }
            }

            return lista;
        }

        private bool EsPalindromo(string s)
        {
            if (s.Length <= 1)
                return false; // No contamos espacios solos u otros solos

            var rev = new string(s.Reverse().ToArray());
            return s == rev;
        }
    }
}