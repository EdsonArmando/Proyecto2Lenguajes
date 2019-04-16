using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    class Variable
    {
        string nombre;
        string tipo;
        string valor;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Valor { get => valor; set => valor = value; }
        public Variable(string nombre, string tipo,string valor) {
            this.nombre = nombre;
            this.tipo = tipo;
            this.valor = valor;
        }
    }
}
