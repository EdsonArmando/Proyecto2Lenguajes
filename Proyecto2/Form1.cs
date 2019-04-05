using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = iTextSharp.text.Font;

namespace Proyecto2
{
    public partial class Form1 : Form
    {
        private string textAnalizar;
        private ArrayList listaToken = new ArrayList();
        private int no = 1;
        private string[] palabras = { "INSTRUCCIONES","VARIABLES","TEXTO", "Interlineado", "Nombre_archivo" ,"tamanio_letra","direccion_archivo","imagen","Numeros", "Linea_en_blanco","var","promedio"
        ,"suma","asignar"};
        public Form1()
        {

            InitializeComponent();
        }

        private void analizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            analizadorLexico();
            generarPDF();
        }
        private void analizadorLexico() {
            textAnalizar = idTexto.Text;
            int estadoInicial = 0;
            int fila = 1;
            int columna = 1;
            string token = "";
            char cadena;
            int estado = 0;
            for (estadoInicial = 0; estadoInicial < textAnalizar.Length; estadoInicial++)
            {
                cadena = textAnalizar[estadoInicial];
                switch (estado)
                {
                    case 0:
                        switch (cadena)
                        {
                            case ' ':
                            case '\r':
                            case '\t':
                            case '\f':
                                estado = 0;
                                break;
                            case '\n':
                                fila++;
                                columna = 1;
                                estado = 0;
                                break;
                            case '{':
                                token += cadena;
                                estado = 1;
                                estadoInicial = estadoInicial - 1;
                                break;
                            case '}':
                                token += cadena;
                                estado = 1;
                                estadoInicial = estadoInicial - 1;
                                break;
                            case '(':
                                token += cadena;
                                estado = 1;
                                estadoInicial = estadoInicial - 1;
                                break;
                            case ')':
                                token += cadena;
                                estado = 1;
                                estadoInicial = estadoInicial - 1;
                                break;
                            case ';':
                                token += cadena;
                                estado = 1;
                                estadoInicial = estadoInicial - 1;
                                break;
                            case ':':
                                token += cadena;
                                estado = 1;
                                estadoInicial = estadoInicial - 1;
                                break;
                            case '=':
                                token += cadena;
                                estado = 1;
                                estadoInicial = estadoInicial - 1;
                                break;
                            case ',':
                                token += cadena;
                                estado = 1;
                                estadoInicial = estadoInicial - 1;
                                break;
                            case '[':
                                token += cadena;
                                estado = 1;
                                estadoInicial = estadoInicial - 1;
                                break;
                            case ']':
                                token += cadena;
                                estado = 1;
                                estadoInicial = estadoInicial - 1;
                                break;
                            case '"':
                                token += cadena;
                                estado = 3;
                                break;
                            case '*':
                                token += cadena;
                                estado = 6;
                                break;
                            case '+':
                                token += cadena;
                                estado = 8;
                                break;
                            case '/':
                                token += cadena;
                                estado = 10;
                                break;
                            default:
                                if (Char.IsLetter(cadena))
                                {
                                    token += cadena;
                                    estado = 2;
                                }
                                else if (Char.IsDigit(cadena)) {
                                    token += cadena;
                                    estado = 5;
                                }
                                else  {
                                    columna++;
                                }
                                break;
                        }
                        break;
                    /*Estado de aceptacion */
                    case 1:
                        if (token.Equals("{")) {
                            verificarToken(token, fila, columna, "CORCHETE APERTURA", estadoInicial);
                            columna++;
                            token = "";
                            estado = 0;
                        } else if (token.Equals("}")) {
                            verificarToken(token, fila, columna, "CORCHETE CIERRE", estadoInicial);
                            columna++;
                            token = "";
                            estado = 0;
                        }
                        else if (token.Equals("]"))
                        {
                            verificarToken(token, fila, columna, "LLAVE CIERRE", estadoInicial);
                            columna++;
                            token = "";
                            estado = 0;
                        }
                        else if (token.Equals("["))
                        {
                            verificarToken(token, fila, columna, "LLAVE APERTURA", estadoInicial);
                            columna++;
                            token = "";
                            estado = 0;
                        }
                        else if (token.Equals("("))
                        {
                            verificarToken(token, fila, columna, "PARENTESIS APERTURA", estadoInicial);
                            columna++;
                            token = "";
                            estado = 0;
                        }
                        else if (token.Equals(")"))
                        {
                            verificarToken(token, fila, columna, "PARENTESIS CIERRE", estadoInicial);
                            columna++;
                            token = "";
                            estado = 0;
                        }
                        else if (token.Equals(";"))
                        {
                            verificarToken(token, fila, columna, "PUNTO Y COMA", estadoInicial);
                            columna++;
                            token = "";
                            estado = 0;
                        }
                        else if (token.Equals(":"))
                        {
                            verificarToken(token, fila, columna, "DOS PUNTOS", estadoInicial);
                            columna++;
                            token = "";
                            estado = 0;
                        }
                        else if (token.Equals(","))
                        {
                            verificarToken(token, fila, columna, "COMA", estadoInicial);
                            columna++;
                            token = "";
                            estado = 0;
                        }
                        else if (token.Equals("="))
                        {
                            verificarToken(token, fila, columna, "IGUAL", estadoInicial);
                            columna++;
                            token = "";
                            estado = 0;
                        }
                        break;
                    case 2:
                        if (Char.IsLetterOrDigit(cadena) | cadena=='_') {
                            columna++;
                            token += cadena;
                            estado = 2;
                        }
                        else {
                            analizarReservada(token, fila, columna, "RESERVADA", estadoInicial);
                            columna++;
                            token = "";
                            estado = 0;
                            estadoInicial = estadoInicial - 1;
                        }
                        break;
                    case 3:
                        if (cadena != '"')
                        {
                            columna++;
                            token += cadena;
                        }
                        else if (cadena == '"')
                        {
                            estadoInicial = estadoInicial - 1;
                            estado = 4;
                        }
                        break;
                    case 4:
                        verificarToken(token + "\"", fila, columna, "CADENA", estadoInicial);
                        columna++;
                        token = "";
                        estado = 0;
                        break;
                    case 5:
                        if (Char.IsDigit(cadena) | cadena == '.')
                        {
                            columna++;
                            token += cadena;
                            estado = 5;
                        }
                        else {
                            verificarToken(token, fila, columna, "DIGITO", estadoInicial);
                            columna++;
                            token = "";
                            estadoInicial = estadoInicial - 1;
                            estado = 0;
                        }
                        break;
                    case 6:
                        if (token.Equals("*"))
                        {
                            verificarToken(token, fila, columna, "OP *", estadoInicial);
                            columna++;
                            token = "";
                            estado = 6;
                        }
                        if (cadena != '*')
                        {
                            columna++;
                            token += cadena;
                            estado = 6;
                        }
                        else if (cadena == '*')
                        {
                            estadoInicial = estadoInicial - 1;
                            estado = 7;
                        }
                        break;
                    case 7:
                        verificarToken(token, fila, columna, "CADENA", estadoInicial);
                        columna++;
                        token = "";
                        estado = 0;
                        verificarToken(Char.ToString(cadena), fila, columna, "OP *", estadoInicial);
                        columna++;
                        break;
                    case 8:
                        if (token.Equals("+")) {
                            verificarToken(token, fila, columna, "OP +", estadoInicial);
                            columna++;
                            token = "";
                            estado = 8;
                        }
                        if (cadena != '+')
                        {
                            columna++;
                            token += cadena;
                            estado = 8;
                        }
                        else if (cadena == '+')
                        {
                            estadoInicial = estadoInicial - 1;
                            estado = 9;
                        }
                        break;
                    case 9:
                        verificarToken(token, fila, columna, "CADENA", estadoInicial);
                        columna++;
                        token = "";
                        estado = 0;
                        verificarToken(Char.ToString(cadena), fila, columna, "OP +", estadoInicial);
                        columna++;
                        break;
                    case 10:
                        if (cadena != '/')
                        {
                            columna++;
                            token += cadena;
                            estado = 10;
                        }
                        else if (cadena == '/')
                        {
                            estadoInicial = estadoInicial - 1;
                            estado = 11;
                        }
                        break;
                    case 11:
                        columna++;
                        verificarToken(token+"/", fila, columna, "COMENTARIO", estadoInicial);
                        columna++;
                        token = "";
                        estado = 0;
                        break;
                }

            }
        }
        private void analizarReservada(string token, int fila, int columna, string tipo, int posicion) {
            bool correcta = false;
            string comparaPalabra = "";
            for (int i=0;i<palabras.Length;i++) {
                comparaPalabra= palabras[i];
                if (comparaPalabra.ToLower().Equals(token.ToLower())) {
                    correcta = true;
                }
            }
            if (correcta == true)
            {
                verificarToken(token, fila, columna, "RESERVADA", posicion);
            }
            else {
                verificarToken(token, fila, columna, "IDENTIFICADOR", posicion);
                /*Error */
            }
        }
        private void verificarToken(string token, int fila, int columna, string tipo, int posicion)
        {
            if (tipo.Equals("CORCHETE APERTURA")) {
                listaToken.Add(new Token(no, 10, token, tipo, fila, columna, posicion));
                no++;
            } else if (tipo.Equals("CORCHETE CIERRE")) {
                listaToken.Add(new Token(no, 20, token, tipo, fila, columna, posicion));
                no++;
            }
            else if (tipo.Equals("RESERVADA"))
            {
                listaToken.Add(new Token(no, 30, token, tipo, fila, columna, posicion));
                no++;
            }
            else if (tipo.Equals("PARENTESIS APERTURA"))
            {
                listaToken.Add(new Token(no, 40, token, tipo, fila, columna, posicion));
                no++;
            }
            else if (tipo.Equals("PARENTESIS CIERRE"))
            {
                listaToken.Add(new Token(no, 50, token, tipo, fila, columna, posicion));
                no++;
            }
            else if (tipo.Equals("PUNTO Y COMA"))
            {
                listaToken.Add(new Token(no, 60, token, tipo, fila, columna, posicion));
                no++;
            }
            else if (tipo.Equals("DOS PUNTOS"))
            {
                listaToken.Add(new Token(no, 70, token, tipo, fila, columna, posicion));
                no++;
            }
            else if (tipo.Equals("COMA"))
            {
                listaToken.Add(new Token(no, 80, token, tipo, fila, columna, posicion));
                no++;
            }
            else if (tipo.Equals("IGUAL"))
            {
                listaToken.Add(new Token(no, 90, token, tipo, fila, columna, posicion));
                no++;
            }
            else if (tipo.Equals("CADENA"))
            {
                listaToken.Add(new Token(no, 100, token, tipo, fila, columna, posicion));
                no++;
            }
            else if (tipo.Equals("IDENTIFICADOR"))
            {
                listaToken.Add(new Token(no, 110, token, tipo, fila, columna, posicion));
                no++;
            }
            else if (tipo.Equals("DIGITO"))
            {
                listaToken.Add(new Token(no, 120, token, tipo, fila, columna, posicion));
                no++;
            }
            else if (tipo.Equals("LLAVE APERTURA"))
            {
                listaToken.Add(new Token(no, 130, token, tipo, fila, columna, posicion));
                no++;
            }
            else if (tipo.Equals("LLAVE CIERRE"))
            {
                listaToken.Add(new Token(no, 140, token, tipo, fila, columna, posicion));
                no++;
            }
            else if (tipo.Equals("OP +"))
            {
                listaToken.Add(new Token(no, 140, token, tipo, fila, columna, posicion));
                no++;
            }
            else if (tipo.Equals("OP *"))
            {
                listaToken.Add(new Token(no, 140, token, tipo, fila, columna, posicion));
                no++;
            }
            else if (tipo.Equals("COMENTARIO"))
            {
                listaToken.Add(new Token(no, 140, token, tipo, fila, columna, posicion));
                no++;
            }
        }
        private void generarPDF() {
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc,
                            new FileStream(Path.Combine(@"c:\Proyecto1\", "TablaSimbolos.pdf"), FileMode.Create));
            doc.Open();
            Paragraph titulo = new Paragraph("TABLA SIMBOLOS");
            titulo.Alignment = Element.ALIGN_CENTER;
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(@"c:\Proyecto1\logo.png");
           
            logo.Alignment = 6;
            doc.Add(logo);
            doc.Add(new Paragraph("Universidad de San Carlos de Guatemala"));
            doc.Add(new Paragraph("Facultad de Ingeniería"));
            doc.Add(new Paragraph("Escuela de Ciencias y Sistemas"));
            doc.Add(new Paragraph("Lenguajes Formales y de Programación"));
            doc.Add(new Paragraph("Catedrática: Inga Damaris Campos"));
            doc.Add(new Paragraph("Aux.: Aylin Aroche"));
            doc.Add(new Paragraph("Sección:  A-"));
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph(titulo));
            doc.Add(Chunk.NEWLINE);
            /*Tabla tokens*/


            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            PdfPTable tblPrueba = new PdfPTable(6);
            tblPrueba.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla
            PdfPCell no = new PdfPCell(new Phrase("No", _standardFont));
            no.BorderWidth = 0;
            no.BorderWidthBottom = 0.40f;

            PdfPCell idNo = new PdfPCell(new Phrase("IdToken", _standardFont));
            idNo.BorderWidth = 0;
            idNo.BorderWidthBottom = 0.40f;

            PdfPCell lexema = new PdfPCell(new Phrase("Lexema", _standardFont));
            lexema.BorderWidth = 0;
            lexema.BorderWidthBottom = 0.60f;

            PdfPCell tipo = new PdfPCell(new Phrase("Tipo", _standardFont));
            tipo.BorderWidth = 0;
            tipo.BorderWidthBottom = 0.40f;

            PdfPCell fila = new PdfPCell(new Phrase("Fila", _standardFont));
            fila.BorderWidth = 0;
            fila.BorderWidthBottom = 0.40f;

            PdfPCell columna = new PdfPCell(new Phrase("Columna", _standardFont));
            columna.BorderWidth = 0;
            columna.BorderWidthBottom = 0.40f;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(no);
            tblPrueba.AddCell(idNo);
            tblPrueba.AddCell(lexema);
            tblPrueba.AddCell(tipo);
            tblPrueba.AddCell(fila);
            tblPrueba.AddCell(columna);

            // Llenamos la tabla con información
            foreach (Token t in listaToken) {
                no = new PdfPCell(new Phrase(Convert.ToString(t.No), _standardFont));
                no.BorderWidth = 0;

                idNo = new PdfPCell(new Phrase(Convert.ToString(t.Tokens), _standardFont));
                idNo.BorderWidth = 0;

                lexema = new PdfPCell(new Phrase(t.Lexema, _standardFont));
                lexema.BorderWidth = 0;

                tipo = new PdfPCell(new Phrase(t.Tipo, _standardFont));
                tipo.BorderWidth = 0;

                fila = new PdfPCell(new Phrase(Convert.ToString(t.Fila), _standardFont));
                fila.BorderWidth = 0;

                columna = new PdfPCell(new Phrase(Convert.ToString(t.Columna), _standardFont));
                columna.BorderWidth = 0;

                // Añadimos las celdas a la tabla
                tblPrueba.AddCell(no);
                tblPrueba.AddCell(idNo);
                tblPrueba.AddCell(lexema);
                tblPrueba.AddCell(tipo);
                tblPrueba.AddCell(fila);
                tblPrueba.AddCell(columna);

            }
            doc.Add(tblPrueba);
            doc.Close();
            writer.Close();
            Process.Start(@"c:\Proyecto1\TablaSimbolos.pdf");
        }
    }
}
