using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    class GenerarDocumento
    {   
        private string interlineado="",nombreArchivo="",tamanioletra="",dirArchivo="";
        private string path = "", tamaniox = "", tmanioy = "";
        private string textoNegrita = "",textoSubrayado="",cadena="",numeros="";
        private string variable = "", valor = "";
        private string variables = "";
        private string varia = "",tipo="",valors="";
        private int contVariable;
        private string var = "";
        private int opcion=0;
        private int contComa=0;
        private string suma = "",promedio="";
        private Paragraph para1;
        private ArrayList variabl = new ArrayList();

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
                } else if (palabra.ToLower().Equals("variables") ) {
                    opcion = 12;
                    palabra = "";
                    letra = ' ';
                }
                else if (palabra.ToLower().Equals("texto"))
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
                            case "var[":
                                opcion = 8;
                                palabra = "";
                                break;
                            case "asignar":
                                opcion = 9;
                                palabra = "";
                                break;
                            case "linea_en_blanco;":
                                opcion = 0;
                                palabra = "";
                                break;
                            case "\"":
                                opcion = 10;
                                palabra = "";
                                break;
                            case "numeros":
                                opcion = 11;
                                palabra = "";
                                break;
                            case "suma":
                                opcion = 13;
                                palabra = "";
                                break;
                            case "promedio":
                                opcion = 13;
                                palabra = "";
                                break;
                        }
                        break;
                    case 1:
                        if (letra == ';')
                        {
                            palabra = "";
                            opcion = 0;
                        
                            //interlineado = "";
                        }
                        else if (letra == '(' | letra == ')')
                        {
                            palabra = "";
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
                            //Console.WriteLine(nombreArchivo);
                         
                        }
                        else if (letra == '(' | letra == ')' | letra == '"')
                        {
                            palabra = "";
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
                            //Console.WriteLine(tamanioletra);
                            //tamanioletra = "";
                        }
                        else if (letra == '(' | letra == ')')
                        {
                            palabra = "";
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
                            //Console.WriteLine(dirArchivo);
                            
                        }
                        else if (letra == '(' | letra == ')' | letra == '"')
                        {
                            palabra = "";
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
                            //Console.WriteLine(path);
                            path = "";
                            //Console.WriteLine(tamaniox);
                            tamaniox = "";
                            //Console.WriteLine(tmanioy);
                            tmanioy = "";
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
                                //tamaniox += letra;
                            }
                            else if (contComa == 2)
                            {
                                //tmanioy += letra;
                            }
                            else if (contComa == 0)
                            {
                                //path += letra;
                            }
                        }
                        break;
                    case 6:
                        if (letra == ';')
                        {
                            palabra = "";
                            opcion = 0;
                         
                            textoNegrita = "";
                        }
                        else if (letra == '+' | letra == ']')
                        {

                        }
                        else
                        {
                            //textoNegrita += letra;
                        }
                        break;
                    case 7:
                        if (letra == ';')
                        {
                            palabra = "";
                            opcion = 0;
                           
                            textoSubrayado = "";
                        }
                        else if (letra == '*' | letra == ']')
                        {

                        }
                        else
                        {
                            //textoSubrayado += letra;
                        }
                        break;
                    case 8:
                        if (letra == ']')
                        {
                            palabra = "";
                            opcion = 0;
                            //Console.WriteLine(var);
                            var = "";
                        }
                        else if (letra == '[')
                        {

                        }
                        else
                        {
                            //var += letra;
                        }
                        break;
                    case 9:
                        if (letra == ';')
                        {
                            palabra = "";
                            opcion = 0;
                            contComa = 0;
                            //Console.WriteLine(variable);
                            variable = "";
                            //Console.WriteLine(valor);
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
                                //valor += letra;
                            }
                            else if (contComa == 0)
                            {
                                //variable += letra;
                            }
                        }
                        break;
                        case 10:
                        if (letra == '"')
                        {
                            palabra = "";
                            opcion = 0;

                           
                        }
                        else if (letra == '+' | letra == ']')
                        {

                        }
                        else
                        {
                            //cadena += letra;
                        }
                        break;
                    case 11:
                        if (letra == ';')
                        {
                            palabra = "";
                            opcion = 0;
                            //Console.WriteLine(numeros);
                            numeros = "";
                        }
                        else if (letra == ')')
                        {

                        }
                        else
                        {
                            //numeros += letra;
                        }
                        break;
                    case 12:
                       if (letra == ':')
                        {
                            if (contVariable == 0) {
                                //Console.WriteLine(varia);
                                palabra = "";
                                opcion = 12;
                               
                                contVariable = 1;
                            } 
                    
                        } else if (letra == '=') {
                            if (contVariable == 1)
                            {
                                //Console.WriteLine(tipo);
                                palabra = "";
                                opcion = 12;
                          
                                contVariable = 2;
                            }
                        }
                        else if (letra == ';')
                        {
                            if (contVariable == 2)
                            {
                                //Console.WriteLine(valors);
                                string[] words = varia.Split(',');
                                for (int i = 0; i < words.Length; i++)
                                {
                                    Console.WriteLine(words[i] +" "+ tipo + " " + valors);
                                    variabl.Add(new Variable(words[i], tipo, valors));
                                }
                                varia = "";
                                tipo = "";
                                palabra = "";
                                opcion = 12;
                                valors = "";
                                contVariable = 0;
                            } else if (contVariable == 1) {
                                //Console.WriteLine(tipo);
                                string[] words = varia.Split(',');
                                for (int i = 0; i < words.Length; i++)
                                {
                                    variabl.Add(new Variable(words[i], tipo, valors));
                                }
                                varia = "";
                                tipo = "";
                                valors = "";
                                palabra = "";
                                opcion = 12;
                        
                                contVariable = 0;
                            }
                        }
                        else if (letra == ':' || letra == ' ' || letra == '\n' || letra == '\t' || letra == '\r' || letra == '{' || letra == '=')
                        {
                            palabra = "";
                        }
                        else if (letra == '}')
                        {
                            opcion = 0;
                            palabra = "";
                        }
                        else {
                            if (contVariable == 0) {
                                varia += letra;
                            } else if (contVariable == 1) {
                                tipo += letra;
                            }
                            else if (contVariable == 2)
                            {
                                valors += letra;
                            }
                        }
                        break;
                    case 13:
                        if (letra == ';')
                        {
                            palabra = "";
                            opcion = 0;
                            //Console.WriteLine(numeros);
                            suma = "";
                        }
                        else if (letra == ')')
                        {

                        }
                        else
                        {
                            //numeros += letra;
                        }
                        break;
                    case 14:
                        if (letra == ';')
                        {
                            palabra = "";
                            opcion = 0;
                            //Console.WriteLine(numeros);
                            promedio = "";
                        }
                        else if (letra == ')')
                        {

                        }
                        else
                        {
                            //numeros += letra;
                        }
                        break;
                }         
            }
        }
        public void documento(string texto) {
            int inicio;
            char letra;
            string palabra = "";
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc,
                           new FileStream(Path.Combine(dirArchivo, nombreArchivo), FileMode.Create));
            doc.Open();
            para1 = new Paragraph(Convert.ToSingle(Convert.ToDecimal(interlineado)) * 16);
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, Convert.ToInt32(tamanioletra));
            iTextSharp.text.Font negrita = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, Convert.ToInt32(tamanioletra), iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font subrayado = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, Convert.ToInt32(tamanioletra), iTextSharp.text.Font.DEFAULTSIZE);
            for (inicio = 0; inicio < texto.Length; inicio++)
            {
                letra = texto[inicio];
                palabra += letra;
               
                if (palabra.Equals("\n") || palabra.Equals("\r") || palabra.Equals("\t") || palabra.Equals("\f") || palabra.Equals(" ") || palabra.Equals("{")
                   || palabra.Equals("}") || palabra.Equals("instrucciones") || palabra.ToLower().Equals("texto"))
                {
                    palabra = "";
                }
                else if (palabra.ToLower().Equals("variables"))
                {
                    opcion = 12;
                    palabra = "";
                    letra = ' ';
                }
                else if (palabra.ToLower().Equals("texto"))
                {

                    palabra = "";
                   
                }
                switch (opcion)
                {
                    case 0:
                        switch (palabra.ToLower())
                        {
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
                            case "var[":
                                opcion = 8;
                                palabra = "";
                                break;
                            case "asignar":
                                opcion = 9;
                                palabra = "";
                                break;
                            case "linea_en_blanco;":
                                opcion = 0;
                                para1.Add(Chunk.NEWLINE);
                                palabra = "";
                                break;
                            case "\"":
                                opcion = 10;
                                palabra = "";
                                break;
                            case "numeros":
                                opcion = 11;
                                palabra = "";
                                break;
                            case "suma":
                                opcion = 13;
                                palabra = "";
                                break;
                            case "promedio":
                                opcion = 14;
                                palabra = "";
                                break;
                        }
                        break;
                    case 1:
                        if (letra == ';')
                        {
                            palabra = "";
                            opcion = 0;

                            //interlineado = "";
                        }
                        else if (letra == '(' | letra == ')')
                        {

                        }
                        else
                        {
                            //interlineado += letra;
                        }
                        break;
                    case 2:
                        if (letra == ';')
                        {
                            palabra = "";
                            opcion = 0;
                            //Console.WriteLine(nombreArchivo);

                        }
                        else if (letra == '(' | letra == ')' | letra == '"')
                        {

                        }
                        else
                        {
                            //nombreArchivo += letra;
                        }
                        break;
                    case 3:
                        if (letra == ';')
                        {
                            palabra = "";
                            opcion = 0;
                            //Console.WriteLine(tamanioletra);
                            //tamanioletra = "";
                        }
                        else if (letra == '(' | letra == ')')
                        {

                        }
                        else
                        {
                            //tamanioletra += letra;
                        }
                        break;
                    case 4:
                        if (letra == ';')
                        {
                            palabra = "";
                            opcion = 0;
                            //Console.WriteLine(dirArchivo);

                        }
                        else if (letra == '(' | letra == ')' | letra == '"')
                        {

                        }
                        else
                        {
                            //dirArchivo += letra;
                        }
                        break;
                    case 5:
                        if (letra == ';')
                        {
                            palabra = "";
                            opcion = 0;
                            contComa = 0;
                            para1.Add(Chunk.NEWLINE);
                            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(path);
                            logo.ScaleAbsolute(Convert.ToInt32(tamaniox), Convert.ToInt32(tmanioy));
                            para1.Add(logo);
                            path = "";
                            tamaniox = "";
                            tmanioy = "";
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
                                tamaniox += letra;
                            }
                            else if (contComa == 2)
                            {
                                tmanioy += letra;
                            }
                            else if (contComa == 0)
                            {
                                path += letra;
                            }
                        }
                        break;
                    case 6:
                        if (letra == ';')
                        {
                            palabra = "";
                            opcion = 0;
                            para1.Add(new Chunk(textoNegrita, negrita));
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
                            para1.Add(new Chunk(textoSubrayado, subrayado));
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
                            string vs = "";
                            //Console.WriteLine(var);
                            foreach (Variable v in variabl) {
                                if (v.Nombre.Equals(var)) {
                                    vs = v.Valor;
                                }
                            }
                            para1.Add(new Chunk(vs, _standardFont));
                            var = "";
                            vs = "";
                        }
                        else if (letra == '['| letra == ' ')
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
                            foreach (Variable v in variabl)
                            {
                                if (v.Nombre.Equals(variable))
                                {
                                    v.Valor = valor;
                                }
                            }
                            //Console.WriteLine(variable);
                            variable = "";
                            //Console.WriteLine(valor);
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
                    case 10:
                        if (letra == '"')
                        {
                            palabra = "";
                            opcion = 0;
                            para1.Add(new Chunk(cadena, _standardFont));
                            cadena = "";
                        }
                        else if (letra == '"')
                        {

                        }
                        else
                        {
                            cadena += letra;
                        }
                        break;
                    case 11:
                        if (letra == ';')
                        {
                            palabra = "";
                            opcion = 0;
                            string[] words = numeros.Split(',');
                            for (int i=0;i<words.Length;i++) {
                                para1.Add(Chunk.NEWLINE);
                                para1.Add(new Chunk((i+1)+". "+ words[i], _standardFont));
                            }
                            numeros = "";
                        }
                        else if (letra == ')'|letra == '('| letra == '"')
                        {

                        }
                        else
                        {
                            numeros += letra;
                        }
                        break;
                    case 12:
                        if (letra == ':')
                        {
                            if (contVariable == 0)
                            {
                                //Console.WriteLine(varia);
                                palabra = "";
                                opcion = 12;

                                contVariable = 1;
                            }

                        }
                        else if (letra == '=')
                        {
                            if (contVariable == 1)
                            {
                                //Console.WriteLine(tipo);
                                palabra = "";
                                opcion = 12;

                                contVariable = 2;
                            }
                        }
                        else if (letra == ';')
                        {
                            if (contVariable == 2)
                            {
                                //Console.WriteLine(valors);
                              
                                varia = "";
                                tipo = "";
                                palabra = "";
                                opcion = 12;
                                valors = "";
                                contVariable = 0;
                            }
                            else if (contVariable == 1)
                            {
                                //Console.WriteLine(tipo);
                                
                                varia = "";
                                tipo = "";
                                valors = "";
                                palabra = "";
                                opcion = 12;

                                contVariable = 0;
                            }
                        }
                        else if (letra == ':' || letra == ' ' || letra == '\n' || letra == '\t' || letra == '\r' || letra == '{' || letra == '=')
                        {
                            palabra = "";
                        }
                        else if (letra == '}')
                        {
                            opcion = 0;
                            palabra = "";
                        }
                        else
                        {
                            if (contVariable == 0)
                            {
                                //varia += letra;
                            }
                            else if (contVariable == 1)
                            {
                                //tipo += letra;
                            }
                            else if (contVariable == 2)
                            {
                                //valors += letra;
                            }
                        }
                        break;
                    case 13:
                        if (letra == ';')
                        {
                            palabra = "";
                            opcion = 0;
                            string[] words = suma.Split(',');
                            long sumatoria =0;
                            for (int i = 0; i < words.Length; i++)
                            {
                                if (esEntero(words[i]) == true)
                                {
                                    sumatoria += Convert.ToInt32(words[i]);
                                }
                                else {
                                    foreach (Variable v in variabl)
                                    {
                                        if (v.Nombre.Equals(words[i]))
                                        {
                                            sumatoria += Convert.ToInt32(v.Valor);
                                        }
                                    }
                                }
                               
                            }
                            para1.Add(Chunk.NEWLINE);
                            para1.Add(new Chunk(Convert.ToString(sumatoria), _standardFont));
                            suma = "";
                            sumatoria = 0;
                        }
                        else if (letra == ')' | letra == '(' | letra == '"')
                        {

                        }
                        else
                        {
                            suma += letra;
                        }
                        break;
                    case 14:
                        if (letra == ';')
                        {
                            palabra = "";
                            opcion = 0;
                            string[] words = promedio.Split(',');
                            long sumatoria = 0;
                            for (int i = 0; i < words.Length; i++)
                            {
                                if (esEntero(words[i]) == true)
                                {
                                    sumatoria += Convert.ToInt32(words[i]);
                                }
                                else
                                {
                                    foreach (Variable v in variabl)
                                    {
                                        if (v.Nombre.Equals(words[i]))
                                        {
                                            sumatoria += Convert.ToInt32(v.Valor);
                                        }
                                    }
                                }

                            }
                            sumatoria = sumatoria / words.Length;
                            para1.Add(Chunk.NEWLINE);
                            para1.Add(new Chunk(Convert.ToString(sumatoria), _standardFont));
                            promedio = "";
                            sumatoria = 0;
                        }
                        else if (letra == ')' | letra == '(' | letra == '"')
                        {

                        }
                        else
                        {
                            promedio += letra;
                        }
                        break;
                }
            }
            doc.Add(para1);
            doc.Close();
            writer.Close();
            dirArchivo = "";
            nombreArchivo = "";
            interlineado = "";
            tamanioletra = "";
        }
        private bool  esEntero(string valor)
        {
            long number1 = 0;
            bool canConvert = long.TryParse(valor, out number1);
            return canConvert;
        }
    }
  
}





 