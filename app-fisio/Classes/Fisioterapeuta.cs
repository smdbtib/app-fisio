using System;

namespace EvoluçãoPacientes 
{
    public class Fisioterapeuta : EntidadeBase
    {
        //Atributos

        private string nome {get; set; }
        private Especialidade especialidade { get; set; }
        private int idade {get; set; }
        private bool excluido {get; set;}
        
        //Métodos

        public Fisioterapeuta(int id, string nome, Especialidade especialidade, int idade)
        {
            this.Id = id;
            this.nome = nome; 
            this.especialidade = especialidade;
            this.idade = idade;
            this.excluido = false;

        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Nome: " + this.nome + Environment.NewLine;
            retorno += "especialidade: " + this.especialidade + Environment.NewLine; 
            retorno += "idade: " + this.idade + Environment.NewLine; 
            retorno += "excluido: " + this.excluido; 
            return retorno;
        }
        public string retornaNome()
        {
            return this.nome;
        }
        internal int retornaId()
        {
            return this.Id;
        }

        internal bool retornaExcluido()
        {
            return this.excluido;
        }
        public void excluir(){
            this.excluido = true;
        }
    }

}