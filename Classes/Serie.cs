using System;

namespace DIO.SERIES
{
    public class Serie : EntidadeBase
    {
        // Atributos
        private Gene Gene {get; set;}
        private string Titulo {get; set;}
        private string Descri {get; set;}
        private int Ano {get; set;}
        private bool Exc{get; set;}
    

        // Métodos
        public Serie(int id, Gene gene, string titulo, string descri, int ano)
        {
            this.Id = id;
            this.Gene = gene;
            this.Descri = descri;
            this.Ano = ano;
            this.Exc = false;
            this.Titulo = titulo;
        }

        public override string ToString()
        {
            // Environment.Newline https://docs.microsoft.com/en-us/dotnet/api/system.environmet.new
            string retorno = "";
            retorno += "Gênero: " + this.Gene + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descri + Environment.NewLine;
            retorno += "Ano de Inicio: " + this.Ano + Environment.NewLine;
            retorno += "Excluído: " + this.Exc;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public int retornaId()
        {
            return this.Id;
        }

         public bool retornaExc()
        {
            return this.Exc;
        }

        public void Excluir()
        {
            this.Exc = true;
        }


        
    }
}