using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tarea2.Models;

namespace Tarea2.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new TrianguloModel());
        }


        //Todas las validaciones y resultados
        [HttpPost]
        public ActionResult Index(TrianguloModel trianguloModel)
        {
            //Validacion de 0s, con el annotation range
            if (!ModelState.IsValid)
            {
                return View(trianguloModel);
            }
            //Validacion de desigualdad triangular
            if (trianguloModel.a >= trianguloModel.b + trianguloModel.c || 
                trianguloModel.b >= trianguloModel.a + trianguloModel.c ||
                trianguloModel.c >= trianguloModel.a + trianguloModel.b)
            {
                ModelState.AddModelError("", "Los valores no cumplen con la desigualdad triangular");
                return View(trianguloModel);
            }
            //Calculo del Perimetro
            ViewBag.Perimetro = trianguloModel.CalcularPerimetro();
            //Calculo del SemiPerimetro
            ViewBag.SemiPerimetro = trianguloModel.CalcularSemiPerimetro();
            //Calculo del Area
            ViewBag.Area = trianguloModel.CalcularArea();
            //Se determina el tipo de triangulo que es
            ViewBag.Tipo = trianguloModel.TipoTriangulo();
            //Se calcula el valor de alfa
            ViewBag.Alfa = trianguloModel.CalcularAlfa();
            //Se calcula el valor de beta
            ViewBag.Beta = trianguloModel.CalcularBeta();
            //Se calcula el valor de gamma
            ViewBag.Gamma = trianguloModel.CalcularGamma();





            return View(trianguloModel);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}