﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    class ErrorToken
    {
        int no;
        string tokens;
        string tipo;
        string lexema;
        int fila;
        int columna;
        int pos;

        public int No { get => no; set => no = value; }
        public string Tokens { get => tokens; set => tokens = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Lexema { get => lexema; set => lexema = value; }
        public int Fila { get => fila; set => fila = value; }
        public int Columna { get => columna; set => columna = value; }
        public int Pos { get => pos; set => pos = value; }

        public ErrorToken()
        {
        }
        public ErrorToken(int no, string tokens,string tipo, string lexema, int fila, int columna, int pos)
        {
            this.no = no;
            this.tokens = tokens;
            this.tipo = tipo;
            this.lexema = lexema;
            this.fila = fila;
            this.columna = columna;
            this.pos = pos;
        }
    }
}
