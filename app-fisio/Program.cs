using System;

namespace EvoluçãoPacientes
{
    class Program
    {

        static FisioterapeutaRepositorio repositorio = new FisioterapeutaRepositorio();
        static void Main(string[] args)
        {            
            string opcaoUsuario = obterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        listarFisioterapeuta();
                        break;
                    case "2":
                        inserirFisioterapeuta();
                        break;
                    case "3":
                        atualizarFisioterapeuta();
                        break;
                    case "4":
                        excluirFisioterapeuta();
                        break;
                    case "5":
                        visualizarFisioterapeuta();
                        break;
                    default:
                        //
                        break;
                }

                opcaoUsuario = obterOpcaoUsuario();
            }


        }

        private static string obterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("SMDB Técnologia e Inovação");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Listar Fisioterapeuta");
            Console.WriteLine("2- Inserir novo Fisioterapeuta");
            Console.WriteLine("3- Atualizar Fisioterapeuta");
            Console.WriteLine("4- Excluir Fisioterapeuta");
            Console.WriteLine("5- Visualizar Fisioterapeuta");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void listarFisioterapeuta()
        {
            Console.WriteLine("Listar Fisioterapeutas");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhum fisioterapeuta encontrado.");
                return;
            }

            foreach (var fisioterapeuta in lista)
            {
                var excluido = fisioterapeuta.retornaExcluido();

                Console.WriteLine("#ID {0}:  -  {1} - {2}", fisioterapeuta.retornaId(), fisioterapeuta.retornaNome(), (excluido ? "*Excluído*" : "" ));
            }
        }

        private static void inserirFisioterapeuta()
        {
            Console.WriteLine("Inserir novo Fisioterapeuta");
            Console.WriteLine();
            foreach (int i in Enum.GetValues(typeof(Especialidade)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Especialidade),i));
            }

            Console.WriteLine();
            Console.WriteLine("Digite a especialidade conforme opções acima: ");
            int entradaEspecialidade = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Digite o nome do Fisioterapeuta: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Digite a Idade do Fisioterapeuta: ");
            int entradaIdade = int.Parse(Console.ReadLine());

            Fisioterapeuta novoFisio = new Fisioterapeuta (id: repositorio.proximoId(),
                                                            especialidade: (Especialidade) entradaEspecialidade,
                                                            nome: entradaNome,
                                                            idade: entradaIdade);   
                                                            
            repositorio.insere(novoFisio);                                                         
        }

    private static void atualizarFisioterapeuta()
    {
        Console.Write("Digite o ID do Fisioterapeuta: ");
        int indiceFisio = int.Parse(Console.ReadLine());
        

        foreach (int i in Enum.GetValues(typeof(Especialidade)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Especialidade),i));
            }

            Console.WriteLine();
            Console.WriteLine("Digite a especialidade conforme opções acima: ");
            int entradaEspecialidade = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Digite o nome do Fisioterapeuta: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Digite a Idade do Fisioterapeuta: ");
            int entradaIdade = int.Parse(Console.ReadLine());

            Fisioterapeuta atualizaFisio = new Fisioterapeuta (id: indiceFisio,
                                                            especialidade: (Especialidade) entradaEspecialidade,
                                                            nome: entradaNome,
                                                            idade: entradaIdade);

        repositorio.atualiza(indiceFisio, atualizaFisio);                                                            
    }

    private static void excluirFisioterapeuta()
    {
        Console.Write("Digite o ID do Fisioterapeuta: ");
        int indiceFisio = int.Parse(Console.ReadLine());
        // Melhoria implementar confirmação de exclusão 

        repositorio.excluir(indiceFisio);
    }

    private static void visualizarFisioterapeuta()
    {
        Console.Write("Digite o ID do Fisioterapeuta: ");
        int indiceFisio = int.Parse(Console.ReadLine());

        var fisio = repositorio.retornaPorId(indiceFisio); 
        
       Console.WriteLine(fisio);
    }

    }
}
