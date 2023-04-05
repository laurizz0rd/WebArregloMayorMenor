using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebArregloMayorMenor.Models;

namespace WebArregloMayorMenor.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Create()
        {
            
            return View();
        }

        public ActionResult CreatePost(string nombre, string datos)
        {
           EntResultado r = PDatos(datos);
        
            return View("Create",r);
        }

        public EntResultado PDatos(string dat)
        {
            string arreglo = "";
            string[] datos = dat.Split(' '); // Convertir la cadena de entrada en un arreglo de strings
            int cantidad = datos.Length; // Obtener la cantidad de elementos en el arreglo
            int[] vec = new int[cantidad]; // Crear un arreglo de enteros con la cantidad de elementos obtenidos
            int[] vecDes = new int[cantidad];
            for (int i = 0; i < cantidad; i++) // Corregir el índice del bucle
            {
                vec[i] = int.Parse(datos[i]); // Convertir cada string a entero y asignarlo al arreglo
            }
           vec= vec.OrderByDescending(c => c).ToArray();
            int mayor = vec[0]; // Inicializar mayor y menor con el primer elemento del arreglo
            int menor = vec[0];
            for (int i = 0; i <= cantidad-1; i++) // Corregir el índice del bucle
            {
                if (vec[i] > mayor)
                {
                    mayor = vec[i];
                   
                }

                if (vec[i] < menor)
                {
                    menor = vec[i];
                    
                }
                arreglo += vec[i].ToString() + ",";
            }
            string msjMayor = $"Mayor: {mayor}"; //Mover los mensajes de retorno fuera del bucle
            string msjMenor = $"Menor: {menor}";
            arreglo = arreglo.TrimEnd(',');

            EntResultado r = new EntResultado();
            r.NumeroMinimo = msjMenor;
            r.NumeroMaximo= msjMayor;
            r.Arreglo = arreglo;

            return r; // Retornar ambos mensajes en una sola cadena


        }
    }
}