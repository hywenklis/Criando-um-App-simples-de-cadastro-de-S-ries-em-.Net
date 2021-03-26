using System;

namespace DIO.SERIES
{
    class Program
    {
        static SerieRepositorio repositório = new SerieRepositorio();
        static void Main(string[] args)
        {
           
            string OpUser = ObOpUser();
            while (OpUser.ToUpper() != "S")
            {
                
                try
                {
                    switch (OpUser)
                    {
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "L":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                    }
                    Console.WriteLine();
                    OpUser = ObOpUser();
                    
                }

                catch (FormatException)
                {
                    Console.WriteLine("Opção inválida");
                    Console.WriteLine();
                    
                }
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine();
        }

        private static void ListarSerie()
        {
            Console.WriteLine("Listar Series");

            var lista = repositório.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var exc = serie.retornaExc();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (exc ? "Excluído" : ""));
            }

        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir uma nova Série");

            foreach (int i in Enum.GetValues(typeof(Gene)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Gene), i));
            }

            Console.Write("Digite o Gênero entre as opções acima: ");
            int entradaGene = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();
            
            Console.Write("Digite o ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescrição = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositório.ProximoId(),
                                        gene: (Gene)entradaGene,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descri: entradaDescrição);
            repositório.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Gene)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Gene), i));
            }

            Console.Write("Digite o Gênero entre as opções acima: ");
            int entradaGene = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();
            
            Console.Write("Digite o ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescrição = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        gene: (Gene)entradaGene,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descri: entradaDescrição);
            repositório.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositório.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositório.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static string ObOpUser()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir nova Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("L - Limpar tela");
            Console.WriteLine("S - Sair");
            Console.WriteLine();

            string OpUser = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpUser;

        }
    }
}
