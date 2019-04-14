using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    class GenerarDocumento
    {
        private string interlineado="",nombreArchivo="",tamanioletra="",dirArchivo="";
        private string path = "", tamaniox = "", tmanioy = "";
        private string textoNegrita = "",textoSubrayado="";
        private string variable = "", valor = "";
        private string var = "";
        private int opcion=0;
        private int contComa=0;

        public void generarPdf(string texto) {
            int inicio;
            char letra;
            string palabra = "";
            for (inicio=0;inicio<texto.Length;inicio++) {
                letra = texto[inicio];
                palabra += letra;
                 if (palabra.Equals("\n") || palabra.Equals("\r") || palabra.Equals("\t") || palabra.Equals("\f") || palabra.Equals(" ") || palabra.Equals("{")
                    || palabra.Equals("}") || palabra.Equals("instrucciones") || palabra.ToLower().Equals("texto"))
                {
                    palabra = "";
                }
                switch (opcion) {
                    case 0:
                        switch (palabra.ToLower()) {
                            case "interlineado":
                                opcion = 1;
                                palabra = "";
                                break;
                            case "nombre_archivo":
                                opcion = 2;
                                palabra = "";
                                break;
                            case "tamanio_letra":
                                opcion = 3;
                                palabra = "";
                                break;
                            case "direccion_archivo":
                                opcion = 4;
                                palabra = "";
                                break;
                            case "imagen":
                                opcion = 5;
                                palabra = "";
                                break;
                            case "[+":
                                opcion = 6;
                                palabra = "";
                                break;
                            case "[*":
                                opcion = 7;
                                palabra = "";
                                break;
                            case "var":
                                opcion = 8;
                                palabra = "";
                                break;
                            case "asignar":
                                opcion = 9;
                                palabra = "";
                                break;
                        }
                        break;
                    case 1:
                        if (letra == ';')
                        {
                            palabra = "";
                            opcion = 0;
                            Console.WriteLine(interlineado);
                            interlineado = "";
                        }
                        else if (letra == '(' | letra == ')')
                        {
                            
                        }
                        else {
                            interlineado += letra;
                        }
                        break;
                    case 2:
                        if (letra == ';')
                        {
                            palabra = "";
                            opcion = 0;
                            Console.WriteLine(nombreArchivo);
                            nombreArchivo = "";
                        }
                        else if (letra == '(' | letra == ')' | letra == '"')
                        {

                        }
                        else
                        {
                            nombreArchivo += letra;
                        }
                        break;
                    case 3:
                        if (letra == ';')
                        {
                            palabra = "";
                            opcion = 0;
                            Console.WriteLine(tamanioletra);
                            tamanioletra = "";
                        }
                        else if (letra == '(' | letra == ')')
                        {

                        }
                        else
                        {
                            tamanioletra += letra;
                        }
                        break;
                    case 4:
                        if (letra == ';')
                        {
                            palabra = "";
                            opcion = 0;
                            Console.WriteLine(dirArchivo);
                            dirArchivo = "";
                        }
                        else if (letra == '(' | letra == ')' | letra == '"')
                        {

                        }
                        else
                        {
                            dirArchivo += letra;
                        }
                        break;
                    case 5:
                        if (letra == ';')
                        {
                            palabra = "";
                            opcion = 0;
                            contComa = 0;
                            Console.WriteLine(path);
                            path = "";
                            Console.WriteLine(tamaniox);
                            tamaniox = "";
                            Console.WriteLine(tmanioy);
                            tmanioy = "";
                        } else if (letra == ',') {
                            contComa++;
                        }
                        else if (letra == '(' | letra == ')' | letra == '"')
                        {

                        }
                        else
                        {
                            if (contComa == 1)
                            {
                                tamaniox += letra;
                            }
                            else if (contComa == 2)
                            {
                                tmanioy += letra;
                            }
                            else if(contComa == 0) {
                                path += letra;
                            }
                        }
                        break;
                    case 6:
                        if (letra == ';')
                        {
                            palabra = "";
                            opcion = 0;
                            Console.WriteLine(textoNegrita);
                            textoNegrita = "";
                        }
                        else if (letra == '+' | letra == ']')
                        {

                        }
                        else
                        {
                            textoNegrita += letra;
                        }
                        break;
                    case 7:
                        if (letra == ';')
                        {
                            palabra = "";
                            opcion = 0;
                            Console.WriteLine(textoSubrayado);
                            textoSubrayado = "";
                        }
                        else if (letra == '*' | letra == ']')
                        {

                        }
                        else
                        {
                            textoSubrayado += letra;
                        }
                        break;
                    case 8:
                        if (letra == ']')
                        {
                            palabra = "";
                            opcion = 0;
                            Console.WriteLine(var);
                            var = "";
                        }
                        else if (letra == '[')
                        {

                        }
                        else
                        {
                            var += letra;
                        }
                        break;
                    case 9:
                        if (letra == ';')
                        {
                            palabra = "";
                            opcion = 0;
                            contComa = 0;
                            Console.WriteLine(variable);
                            variable = "";
                            Console.WriteLine(valor);
                            valor = "";
                        }
                        else if (letra == ',')
                        {
                            contComa++;
                        }
                        else if (letra == '(' | letra == ')' | letra == '"')
                        {

                        }
                        else
                        {
                            if (contComa == 1)
                            {
                                valor += letra;
                            }
                            else if (contComa == 0)
                            {
                                variable += letra;
                            }
                        }
                        break;
                }         
            }
        }
         
    }
}





 