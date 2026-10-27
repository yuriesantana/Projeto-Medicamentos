using System;

namespace ProjetoMedicamentos
{
    internal class Program
    {
        static Medicamentos cadastro = new Medicamentos();

        static void Main(string[] args)
        {
            int opcao = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("=======================================");
                Console.WriteLine("       CONTROLE DE MEDICAMENTOS       ");
                Console.WriteLine("=======================================");
                Console.WriteLine("0. Finalizar processo");
                Console.WriteLine("1. Cadastrar medicamento");
                Console.WriteLine("2. Consultar medicamento (sintético)");
                Console.WriteLine("3. Consultar medicamento (analítico)");
                Console.WriteLine("4. Comprar medicamento (cadastrar lote)");
                Console.WriteLine("5. Vender medicamento");
                Console.WriteLine("6. Listar medicamentos (sintético)");
                Console.WriteLine("=======================================");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    opcao = -1;
                }

                Console.WriteLine();

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Encerrando a aplicação...");
                        break;
                    case 1:
                        CadastrarMedicamento();
                        break;
                    case 2:
                        ConsultarSintetico();
                        break;
                    case 3:
                        ConsultarAnalitico();
                        break;
                    case 4:
                        ComprarMedicamento();
                        break;
                    case 5:
                        VenderMedicamento();
                        break;
                    case 6:
                        ListarSintetico();
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != 0);
        }

        static void CadastrarMedicamento()
        {
            Console.Write("ID do Medicamento: ");
            int id = int.Parse(Console.ReadLine());

            if (cadastro.Pesquisar(new Medicamento(id, "", "")).Id != 0)
            {
                Console.WriteLine("Já existe um medicamento cadastrado com este ID.");
                return;
            }

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Laboratório: ");
            string lab = Console.ReadLine();

            cadastro.Adicionar(new Medicamento(id, nome, lab));
            Console.WriteLine("Medicamento cadastrado com sucesso!");
        }

        static void ConsultarSintetico()
        {
            Console.Write("ID do Medicamento: ");
            int id = int.Parse(Console.ReadLine());

            Medicamento med = cadastro.Pesquisar(new Medicamento(id, "", ""));

            if (med.Id == 0)
            {
                Console.WriteLine("Medicamento não encontrado.");
            }
            else
            {
                Console.WriteLine($"Dados: {med.ToString()}");
            }
        }

        static void ConsultarAnalitico()
        {
            Console.Write("ID do Medicamento: ");
            int id = int.Parse(Console.ReadLine());

            Medicamento med = cadastro.Pesquisar(new Medicamento(id, "", ""));

            if (med.Id == 0)
            {
                Console.WriteLine("Medicamento não encontrado.");
            }
            else
            {
                Console.WriteLine($"Dados: {med.ToString()}");
                Console.WriteLine("--- Lotes Cadastrados ---");

                if (med.Lotes.Count == 0)
                {
                    Console.WriteLine("Nenhum lote disponível.");
                }
                else
                {
                    foreach (var lote in med.Lotes)
                    {
                        Console.WriteLine($"Lote: {lote.ToString()}");
                    }
                }
            }
        }

        static void ComprarMedicamento()
        {
            Console.Write("ID do Medicamento: ");
            int idMed = int.Parse(Console.ReadLine());

            Medicamento med = cadastro.Pesquisar(new Medicamento(idMed, "", ""));

            if (med.Id == 0)
            {
                Console.WriteLine("Medicamento não encontrado.");
                return;
            }

            Console.Write("ID do Lote: ");
            int idLote = int.Parse(Console.ReadLine());

            Console.Write("Quantidade: ");
            int qtde = int.Parse(Console.ReadLine());

            Console.Write("Data de Vencimento (dd/MM/yyyy): ");
            DateTime venc = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            med.Comprar(new Lote(idLote, qtde, venc));
            Console.WriteLine("Lote adicionado com sucesso!");
        }

        static void VenderMedicamento()
        {
            Console.Write("ID do Medicamento: ");
            int idMed = int.Parse(Console.ReadLine());

            Medicamento med = cadastro.Pesquisar(new Medicamento(idMed, "", ""));

            if (med.Id == 0)
            {
                Console.WriteLine("Medicamento não encontrado.");
                return;
            }

            Console.Write("Quantidade a vender: ");
            int qtde = int.Parse(Console.ReadLine());

            if (med.Vender(qtde))
            {
                Console.WriteLine("Venda realizada com sucesso!");
            }
            else
            {
                Console.WriteLine("Venda não realizada! Quantidade indisponível ou valor inválido.");
            }
        }

        static void ListarSintetico()
        {
            if (cadastro.ListaMedicamentos.Count == 0)
            {
                Console.WriteLine("Nenhum medicamento cadastrado.");
                return;
            }

            Console.WriteLine("--- Lista de Medicamentos ---");
            foreach (var med in cadastro.ListaMedicamentos)
            {
                Console.WriteLine(med.ToString());
            }
        }
    }
}
