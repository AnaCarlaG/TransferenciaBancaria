using System;
using System.Collections.Generic;

namespace Banco
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcao = ObterOpcaoUsuario();

            while (opcao.ToUpper() != "X")
            {
                switch (opcao)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor a ser depositado");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].DepositarDinheiro(valorDeposito);
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o número da conta de origem: ");
            int contaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta de destino: ");
            int contaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser tranferido");
            int valorTransferencia = int.Parse(Console.ReadLine());

            listaContas[contaOrigem].Transferir(valorTransferencia, listaContas[contaDestino]);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor do saque");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].SacarDinheiro(valorSaque);
        }


        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }
            for (int i = 0; i < listaContas.Count; i++)
            {
                Console.WriteLine("#{0} - ", i);
                Console.WriteLine(listaContas[i]);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Insira o tipo de conta:\n1 - Pessoa Fisica\n2 - Pessoa Juridica");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Insita o nome do cliente");
            string nomeCliente = Console.ReadLine();

            Console.WriteLine("Digite seu saldo inicial");
            double saldoInicial = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite seu crédito inicial");
            double creditoInicial = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)tipoConta,
                                        saldo: saldoInicial,
                                        credito: creditoInicial,
                                        nome: nomeCliente);
            listaContas.Add(novaConta);
        }
        public static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Banco BB ao seu dispor!!!");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 -Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }
    }
}

