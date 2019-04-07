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

        private  List<int> listaToken = Form1.listId;
        private  int cont = 1;
        public   int preanalisis;
        private  int posicionAnalizar = 0;

        private  void parea(int token) {
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

        private  void reportarError()
        {
            Console.WriteLine("Error + " + preanalisis);
        }

        public  int nextToken()
        {
            int id = listaToken[cont];
            cont++;
            return id;
        }
        public  void iniciarAnalisis() {
            preanalisis = listaToken[posicionAnalizar];
            posicionAnalizar++;
            bloqueInstr();
        }
        private  void bloqueP() {
            bloqueInstr();
            preanalisis = 30;
        }
        private  void bloqueInstr() {
            switch (preanalisis) {
                case 30:
                    parea(30);
                    bloqueInstr();
                    bloqueP();
                    break;
                case 10:
                    parea(10);
                    llamada();
                    parea(20);
                    break;
                default:
                    break;
            }
        }
        public  void llamada() {
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
                    //inicarAnalisis(); 
                    break;
            }
        }
        public void limpiarVariables() {
            listaToken.Clear();
            cont = 1;
            posicionAnalizar = 0;
    }
    }
}
