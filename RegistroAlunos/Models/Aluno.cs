﻿namespace RegistroAlunos.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Matricula { get; set; }
        public int NotaGlobal { get; set; }
        public bool Ativo { get; set; }
    }
}
