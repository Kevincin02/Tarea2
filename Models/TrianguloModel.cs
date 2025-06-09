using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Tarea2.Models
{
    public class TrianguloModel
    {
        [Range(1, 100, ErrorMessage = "El numero no puede ser igual a 0")]
        public double a { get; set; }

        [Range(1, 100, ErrorMessage = "El numero no puede ser igual a 0")]
        public double b { get; set; }

        [Range(1, 100, ErrorMessage = "El numero no puede ser igual a 0")]
        public double c { get; set; }


        public double P { get; set; }
        public double S { get; set; }
        public double Area { get; set; }

        //Valores para calulo de angulos
        public double ValorA { get; set; }
        public double ValorB { get; set; }
        public double ValorC { get; set; }
        public double CosA { get; set; }
        public double CosB { get; set; }
        public double CosC { get; set; }



        //Calculo del perimetro
        public double CalcularPerimetro()
        {
            P = a + b + c;
            return P;
        }
        //Calculo del semiperimetro
        public double CalcularSemiPerimetro()
        {
            double S = (a+b+c)/2.0;
            return S;
        }
        //Calculo del Area
        public double CalcularArea()
        {
            double S = CalcularSemiPerimetro();
            return Math.Sqrt(S * (S - a) * (S - b) * (S - c));
        }
        //Se determina que tipo de triangulo es #Equilatero, Isosceles o Escaleno
        public String TipoTriangulo()
        {
            if(a==b && b==c)
            {
                return "Equilatero";
            }
            else if (a == b || a == c || b == c)
            {
                return "Isosceles";
            }
            else
            {
                return "Escaleno";
            }
        }
        //Calculo de angulo alfa
        public double CalcularAlfa()
        {
            ValorA = Math.Pow(a, 2);
            ValorB = Math.Pow(b, 2);
            ValorC = Math.Pow(c, 2);

            CosA= (ValorB + ValorC - ValorA) / (2 * b * c);

            double anguloRadianes = Math.Acos(CosA);
            double anguloGrados = anguloRadianes * (180 / Math.PI);
            return anguloGrados;
        }
        //Calculo de angulo beta
        public double CalcularBeta()
        {
            ValorA = Math.Pow(a, 2);
            ValorB = Math.Pow(b, 2);
            ValorC = Math.Pow(c, 2);

            CosB = (ValorA + ValorC - ValorB) / (2 * a * c);

            double anguloRadianes = Math.Acos(CosB);
            double anguloGrados = anguloRadianes * (180 / Math.PI);
            return anguloGrados;
        }
        //Calculo de angulo gamma
        public double CalcularGamma()
        {
            ValorA = Math.Pow(a, 2);
            ValorB = Math.Pow(b, 2);
            ValorC = Math.Pow(c, 2);

            CosC = (ValorA + ValorB - ValorC) / (2 * a * b);

            double anguloRadianes = Math.Acos(CosC);
            double anguloGrados = anguloRadianes * (180 / Math.PI);
            return anguloGrados;
        }

    }
}