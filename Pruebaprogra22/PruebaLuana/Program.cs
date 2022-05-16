using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLuana
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //public buque(string codigo, string nombre,string  pais, int cantidadContainers,int cantidadContainersCargados,int gastoTransporte)

            //Instanciar buques
            buque buque1 = new buque("35899", "b1", "chile", 3, 0, 3100);
            buque buque2 = new buque("35877", "b2", "chile", 5, 0, 3200);
            buque buque3 = new buque("35866", "b3", "chile", 1, 1, 3300);

            //Intanciar containers

            container container1 = new container("a", "marca1", 100, 20, true, 500, buque1);
            container container2 = new container("b", "marca2", 500, 20, false, 50, buque2);
            container container3 = new container("c", "marca3", 200, 40, false, 60, buque1);
            container container4 = new container("d", "marca1", 100, 20, true, 100, buque2);


            //Listar datos de container en el buque
            //Voy a listar los del 1
            Console.WriteLine();
            Console.WriteLine("Listar datos de los containers del buque 1");
            foreach(var a in buque1.listaContainers)
            {
                Console.WriteLine(a.toString());
                Console.WriteLine();
            }
            Console.ReadKey();
            //Valor a pagar por inspeccion para container 
            Console.WriteLine();
            Console.WriteLine("INSPECCION");
            Console.WriteLine("El valor ha pagar por inspección para el contenedor 3 es : $" + container3.valorPagoInspeccion());
            Console.ReadKey();
            //Mostrar el valor que debe pagar cada uno de los containers creados por conceptos de gastos de envío.
            Console.WriteLine();
            Console.WriteLine("GASTOS DE ENVIO");
            Console.WriteLine(" Valor a pagar container1 " + container1.calcularGastoEnvio());
            Console.WriteLine(" Valor a pagar container2 " + container2.calcularGastoEnvio());
            Console.WriteLine(" Valor a pagar container3 " + container3.calcularGastoEnvio());
            Console.WriteLine(" Valor a pagar container4 " + container4.calcularGastoEnvio());

            Console.ReadKey();
            //Mostrar si al container 4 puedo subir una caja con mercadería que pesa 2000 kilos. (10 puntos)
            Console.WriteLine();
            Console.WriteLine("Agregar 2000k de peso");
            bool puede = container4.puedeSubirExtra(2000);
            if (!puede)
            {
                Console.WriteLine("No se puede realizar la operación. Ya se alcanzó el máximo");
            }
            Console.ReadKey();
            //Quitar 200 kilos de peso desde el primero de los containers y mostrar el peso actual. 
            Console.WriteLine();
            Console.WriteLine("Quitar 200k de peso");

            Console.WriteLine("Container 1: "); container1.sacarPeso(200);
            Console.WriteLine("Container 2: "); container2.sacarPeso(200);
            Console.WriteLine("Container 3: "); container3.sacarPeso(200);
            Console.WriteLine("Container 4: "); container4.sacarPeso(200);
          
            Console.ReadKey();
            
        }
    }
}
