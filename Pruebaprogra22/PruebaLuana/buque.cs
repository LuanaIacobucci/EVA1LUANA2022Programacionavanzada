using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLuana
{
    internal class buque
    {


        //Atributos
        private string codigo; //min 5 caracteres
        private string nombre;
        private string pais;
        private int cantidadContainers; //maximo a cargar
        private int cantidadContainersCargados;
        private int gastoTransporte;
        public List<container> listaContainers = new List<container>();

        //Constructores
        public buque(string codigo)
        {
            this.codigo = codigo;

        }
        public buque(string codigo, string nombre, string pais, int cantidadContainers, int cantidadContainersCargados, int gastoTransporte)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.pais = pais;
            this.cantidadContainers = cantidadContainers;
            this.cantidadContainersCargados = cantidadContainersCargados;
            this.gastoTransporte = gastoTransporte;
            

        }


        //Getter y setter

        public string Codigo { get { return codigo; } set { if (value.Length <= 5) { codigo = value; }; } } //Validamos regla negocio de largo de codigo
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public int CantidadContainersCargados { get; set; }
        public int CantidadContainers { get; set; }
        public List<container> ListaContainers { get { return listaContainers; } }
        public int GastoTransporte { get { return gastoTransporte; } set { gastoTransporte = value; } }


        public string toStrig()
        {
            return "Codigo: " + codigo + " Nombre: " + nombre + " País: " + pais + " Cantidad Containers: " + cantidadContainers + " Cantidad Containers Cargados: " + cantidadContainersCargados + " Gasto Transporte: " + gastoTransporte + ".";
        }

        //Metodos personalizados 


        /// Subir Container: Cada vez que se cree un container y se asocie a un buque, se debe cambiar la cantidad de 
        ///containers cargados en el buque, teniendo la precaución de si el container es de 20 o 40 pies.
        ///

        public bool SubirContainer(container nuevoContainer)
        {
            //Tenemos que agregar un contanier pero priemro hay que saber si hay espacio en el buque
            bool agregado = espacioBuque();
            //Si es true se agregó, si es false no se agregó porque no hay más espacio
            if (agregado)
            {
                bool checkEspacioDisponibleTamano = chequearTamañoContainer(nuevoContainer); //Validamos si no sobrepasa el largo max 

                if (checkEspacioDisponibleTamano)
                {
                    listaContainers.Add(nuevoContainer);
                    cantidadContainersCargados++; //Actualizar la cantidad de containers que ya se han cargado 
                }
            }
            else
            {
                Console.WriteLine("Ya se ha alcanzado el límite de containers para este buque.");
            }
            return agregado;

        }

        public bool espacioBuque()
        {
            // saber si hay espacio en el buque
            bool agregado = false;

            if (cantidadContainersCargados < this.cantidadContainers)
            {
                agregado = true;
            }


            return agregado;
        }

        //Chequear que los cotenedores no superen los 20 pies 

        public bool chequearTamañoContainer(container con)
        {
            bool puede = false; //Variable controladora 
            int tamanoOcupado = 0;
            int tamanoMaximo = cantidadContainers * 20;

            //Sacamos pies ocupados
            foreach (var a in listaContainers)
            {
                tamanoOcupado = tamanoOcupado + a.Tamano;
            }

            //validamos si hay espacio
            if (tamanoOcupado < tamanoMaximo)
            {
                if (tamanoOcupado + con.Tamano <= tamanoMaximo) //Si le sumo este container ¿Sobrepasa el limite?
                {
                    puede = true;
                }
            }

            return puede;
        }

    }
}
