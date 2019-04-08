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

        private List<int> listaToken = Form1.listId;
        private int cont = 1;
        public int preanalisis;
        private int posicionAnalizar = 0;
        public static int contErrorSintactico = 0;

        private void parea(int token) {
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

        private void reportarError()
        {
            contErrorSintactico++;
            Console.WriteLine("Error + " + preanalisis);
        }

        public int nextToken()
        {
            int id = listaToken[cont];
            cont++;
            return id;
        }
        public void iniciarAnalisis() {
            preanalisis = listaToken[posicionAnalizar];
            posicionAnalizar++;
            bloqueInstrs();
        }

        private void bloqueInstrs() {
            switch (preanalisis) {
                case 30:
                    parea(30);
                    instrs();
                    bloqueInstrs();
                    break;
            }
        }

        private void instrs()
        {
            switch (preanalisis) {
                case 10:
                    parea(10);
                    bloque();
                    parea(20);
                    break;
            }
        }

        private void bloque()
        {
            switch (preanalisis)
            {
                case 30:
                    parea(30);
                    llamada();
                    bloque();
                    break;
                case 110:
                    //Console.WriteLine("Variables correcta");
                    variable();
                    parea(70);
                    parea(30);
                    declaracion();
                    parea(60);
                    bloque();
                    break;
                case 130:
                    parea(130);
                    inicio();
                    param();
                    inicio();
                    parea(140);
                    parea(60);
                    bloque();
                    break;
                case 180:
                    parea(180);
                    parea(160);
                    param();
                    parea(160);
                    parea(180);
                    bloque();
                    break;
                case 100:
                    parea(100);
                    bloque();
                    break;
                case 190:
                    parea(190);
                    parea(60);
                    bloque();
                    break;
                default:

                    break;
            }
        }

        private void llamada()
        {
            switch (preanalisis) {
                case 40:
                    parea(40);
                    expre();
                    parea(50);
                    parea(60);
                    break;
                case 130:
                    parea(130);
                    param();
                    parea(140);
                    break;
            }
        }
    

        private void inicio()
        {
            switch (preanalisis) {
                case 150:
                    parea(150);
                    break;
                case 160:
                    parea(160);
                    break;
            }
        }

        private void declaracion()
        {
            switch (preanalisis) {
                case 90:
                    parea(90);
                    param();
                    break;
            }
        }

        private void variable()
        {
            param();
            variablePrima();
        }

        private void variablePrima()
        {
            switch (preanalisis)
            {
                case 80:
                    parea(80);
                    param();
                    variablePrima();
                    break;
                default:
                    break;
            }
        }

        private void expre()
        {
           paramss();
        }

        private void paramss()
        {
            param();
            paramPrima();
        }

        private void paramPrima()
        {
            switch (preanalisis) {
                case 80:
                    parea(80);
                    param();
                    paramPrima();
                    break;
                default:
                    break;
            }
        }
        private void param()
        {
            switch (preanalisis)
            {
                case 110:
                    //Console.WriteLine("Hola1");
                    parea(110);
                    break;
                case 100:
                    //Console.WriteLine("Hola2");
                    parea(100);
                    break;
                case 120:
                    //Console.WriteLine("Hola3");
                    parea(120);
                    break;
                default:
                    reportarError();
                    break;
            }
        }

        public void limpiarVariables() {
            listaToken.Clear();
            cont = 1;
            posicionAnalizar = 0;
            contErrorSintactico = 0;
        }
    }
}
