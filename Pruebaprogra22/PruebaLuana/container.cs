using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLuana
{
    internal class container
    {


        //Atributos
        private string codigo;
        private string marca;
        private int capacidadMaxima;
        private byte tamano; //20 o 40 pies
        private bool esRefrigerado;
        private int pesoActual; //Mayor a 0
        private buque Buque;

        //Getter y Setter

        public string Codigo { get; set; }
        public string Marca { get; set; }
        public int CapacidadMaxima { get; set; }
        public int PesoActual { get; set; }
        public byte Tamano { get; set; }
        public bool EsRefrigerado { get; set; }
        public buque buque { get; set; }



        //Constructor
        public container(string codigo, string marca, int capacidadMaxima, byte tamano, bool esRefrigerado, int pesoActual, buque buque)
        {
            this.codigo = codigo;
            this.marca = marca;
            this.capacidadMaxima = capacidadMaxima;
            this.tamano = tamano;
            this.esRefrigerado = esRefrigerado;
            this.pesoActual = pesoActual;
            this.buque = buque;
            buque.SubirContainer(this);

        }


        //ToString
        public string toString()
        {
            return "Codigo: " + this.codigo + ", Marca: " + this.marca + ", Capacidad Maxima: " + this.capacidadMaxima + ", Tamaño : " + this.tamano + ", ¿Es refrigerado?: " + this.esRefrigerado + ", Peso Actual: " + this.pesoActual + ".";
        }

        //Metodos particulares


        //Cequear que el container no sobrepase el limite de peso del buque
        public bool puedeSubir(container con)
        {
            bool puede = false; //Variable controladora 

            if (con.pesoActual <= capacidadMaxima)
            {
                puede = true;
            }


            return puede;
        }
        public bool puedeSubirExtra(int peso)
        {
            bool puede = false; //Variable controladora 

            if (pesoActual + peso <= capacidadMaxima)
            {
                puede = true;
            }


            return puede;
        }


        /// <summary>
        /// Calcular Gasto de Envío: Cada buque tiene un gasto de transporte hasta el siguiente puerto el cual debe 
       // ser dividido por la cantidad de containers que puede cargar.La cantidad máxima de containers está definida
        //en containers de 20 pies, si subes containers de 40 pies ocupas el doble de espacio. Adicionalmente se le
        //debe agregar un valor de 3500 pesos si es un container de 20 pies o 9000 pesos si es de 40 pies, esto para
        //pagar los gastos de aduana.
        /// </summary>
        public int calcularGastoEnvio()
        {
            int gastoEnvio = 0;
            int cantCont20 = 0;
            int cantCont40 = 0;

            bool tipo = false; //Si es true=20 y si false=40 

            foreach (var a in buque.ListaContainers)
            {
                if (a.tamano == 20)
                {
                    cantCont20++;
                }
                else if (a.tamano == 40)
                {
                    cantCont40++;
                }
            }

            buque bu = this.buque;
            //sacar porcenrtaje de uso según tipo de container para 
            // int largomax = bu.CantidadContainers * 20;
            //int porcentaje20 = (100 * cantCont20) / largomax;
            //int porcentaje40 = (100 * cantCont40) / largomax;

            if (tipo)
            {
                //  gastoEnvio = ((Buque.GastoTransporte * porcentaje20) * 3500);
                gastoEnvio = ((buque.GastoTransporte + cantCont20) * 3500);
            }
            else
            {

                //gastoEnvio =  ((Buque.GastoTransporte * porcentaje40) * 9000);
                gastoEnvio = ((buque.GastoTransporte + cantCont40) * 9000);
            }
            return gastoEnvio;
        }

        /// <summary>
        /// /// Calcular valor por inspección: La aduana ha determinado que todos los containers deben ser 
        ///inspeccionados, para esto se asigna personal que debe revisar el contenido del container.Programe un
        ///método que permita calcular el valor a pagar por la inspección si se sabe que el precio que se cobra es de 5 
        ///pesos por kilo de carga revisado.
        /// </summary>
        /// <returns></returns>
        /*public int valorPagoInspeccion()
        {
            int valorInspeccion = 0;
            int totalkilos = 0;

            //guardamos totodos los kilos que están siendo usados
            foreach(var a in Buque.ListaContainers)
            {
                totalkilos =+ a.pesoActual;
            }

            valorInspeccion = totalkilos * 5;



            return  valorInspeccion;
        }*/

        public int valorPagoInspeccion()
        {
            int valorInspeccion = 0;


            valorInspeccion = pesoActual * 5;

            return valorInspeccion;
        }


        /// <summary>
        /*Sacar Peso: este método elimina una cierta cantidad de peso del container, se sacan kilos de peso, el valor 
         no puede ser negativo.
         */
        /// </summary>
        public void sacarPeso(int pesoQuitar)
        {
            if (pesoActual-pesoQuitar >= 0)
            {
                pesoActual = pesoActual - pesoQuitar;
                Console.WriteLine("Peso actual: " + pesoActual);
            }
            else
            {
                Console.WriteLine("Imposible hacer operación."+ "Peso actual: " + pesoActual);
               
            }
        }
    }
}
