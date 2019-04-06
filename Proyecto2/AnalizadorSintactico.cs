using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    class AnalizadorSintactico
    {
        private static List<int> listaToken = Form1.listId;
        private static int cont = 1;
        public static  int preanalisis;
        private static int posicionAnalizar = 0;

        private static void parea(int token) {
            if (token == preanalisis)
            {
                if (cont < listaToken.Count)
                {
                    preanalisis = nextToken();
                }
                else {
                    Console.WriteLine("Se termino el analisis");
                }
               
            }
            else {
                reportarError();
            }
        }

        private static void reportarError()
        {
            Console.WriteLine("Error + " + preanalisis);
        }

        public static int nextToken()
        {
            int id = listaToken[cont];
            cont++;
            return id;
        }
        public static void inicarAnalisis() {
            preanalisis = listaToken[posicionAnalizar];
            posicionAnalizar++;
            llamada();
        }
        public static void llamada() {
            switch (preanalisis) {
                case 110:
                    parea(110);
                    llamada();
                    break;
                case 40:
                    parea(40);
                    parea(110);
                    parea(50);
                    parea(60);
                    break;
                default:
                    inicarAnalisis(); 
                    break;
            }
        }
    }
}
