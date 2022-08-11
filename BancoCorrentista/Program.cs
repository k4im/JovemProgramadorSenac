using System;
using System.Text.RegularExpressions;
using System.Linq;
using ConsoleTables;

namespace BancoCorrentista
{
    class Program
    {
        static void Main(string[] args)
        {                      
            int control = 0; // Controlador
            int qtd = 0; // quantidade de correntistas

            // Matrizes
            string [,] nomeSobrenomeEnderecoCPF = new string[qtd,4];
            double [,] rendaComprovada = new double[qtd,1];
            
            while (control != 5)
            {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine ("NESTA VERSÂO AINDA NAO RETORNA MSG DE CPF NAO ENCONTRADO.", Console.ForegroundColor); // Aviso sobre a versão
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Bem vindo ao Banco SHARP BETA 0.1");
            Console.WriteLine();
            
            painelCreate(); // ira criar o menu de opções
              
            try // Try | Catch para nao quebrar a aplicação 
            {
            switch(Int32.Parse(Console.ReadLine())) // Switch para verificar input. 
            {
                case 1: 
                    
                    Console.Write("Quantidade de correntista a ser criado: ");
                    qtd = Int32.Parse(Console.ReadLine());; // anexa o valor ao int qtd
                    string [,] tempMatriz = new string [qtd,4];
                    double [,] doubleTempMatriz = new double [qtd,1]; // cria uma tempMatriz
                    nomeSobrenomeEnderecoCPF = tempMatriz; // define a matriz principal com as caracteristicas da tempMatriz
                    rendaComprovada = doubleTempMatriz; // faz com que renda tenha as mesma caracteristicas de temp.

                    contaCreate(nomeSobrenomeEnderecoCPF, rendaComprovada, qtd);
                    break;
                case 2: 
                    updateCorrentista(nomeSobrenomeEnderecoCPF, rendaComprovada, qtd);
                    break;
                case 3: 
                    consultarCorrentista(nomeSobrenomeEnderecoCPF, rendaComprovada, qtd);
                    break;
                case 4:
                    deletarCorrentista(nomeSobrenomeEnderecoCPF, rendaComprovada, qtd);
                    break;
                case 5:
                    control += 5;
                    break;
                case 6 :
                    todosCorrentista(nomeSobrenomeEnderecoCPF, rendaComprovada, qtd);
                    break;
            }
            }
        
            catch (Exception) // Ira pegar qualquer excessão, não apenas uma especifica.
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine ("ERROR: POR FAVOR DIGITE UM DOS VALORES DESCRITOS!", Console.ForegroundColor);
                Console.ForegroundColor = ConsoleColor.White;
            }
            } // final do While loop.
        }
    
        // Metodo para consultar corrrentista.
        static void consultarCorrentista (string [,] personData, double [,] renda, int qqtd)
        {
            Console.Clear();

            Console.WriteLine("Para consultar um correntetista digite o CPF");
            Console.Write("CPF: ");
            var cpf = Console.ReadLine();
            string cpfLimpo = Regex.Replace(cpf, @"[^\d]", ""); // regex para validar CPF.
            
            for (int i = 0; i < qqtd; i++)
            {
                if (personData[i,2].Contains(cpfLimpo)) 
                {
                    Console.WriteLine("Correntista encontrado.");
                    Console.WriteLine();
                    Console.WriteLine($"O nome do correntista é: {personData[i,0]} {personData[i,1]}");
                    Console.WriteLine($"O CPF do correntista é: {personData[i,2]}");
                    Console.WriteLine($"O endereço do correntista é: {personData[i,3]}");
                    Console.WriteLine($"A renda do correntista é: R$ {renda[i,0]}");
                    break;
                }                
            }

            Console.ReadKey();
            Console.Clear();
        }

        // Metodo para criar um novo correntista.
        static void contaCreate (string [,] nomeSobrenome, double[,] renda, int qqtd)
        {
            Console.Clear();
            for (int i = 0; i < qqtd; i++)
            {
            Console.WriteLine ("Para cirar um novo Correntista Insira os seguintes dados.");
            Console.Write($"Primeiro nome do usuario [{i}]: ");
            var fNome = Console.ReadLine();
            nomeSobrenome[i,0] = fNome;
            
            Console.Write($"Sobrenome do usuario [{i}]: ");
            var sobreNome = Console.ReadLine();
            nomeSobrenome[i,1] = sobreNome;
            
            Console.Write($"CPF do usuario [{i}]: ");
            var cpf = Console.ReadLine();
            string cpfLimpo = Regex.Replace(cpf, @"[^\d]", ""); // regex para limpar CPF.
            nomeSobrenome[i,2] = cpfLimpo; // adiciona ao array.

            Console.Write($"Endereço do usuario [{i}]: ");
            var endereco = Console.ReadLine();
            nomeSobrenome[i,3] = endereco; // irá adicionar o endereço a array

            Console.Write($"Renda Comprovada do usuario [{i}]: R$ ");
            double rendaComp = double.Parse(Console.ReadLine());
            renda[i,0] = rendaComp; // ira adicionar o valor da renda
            
            Console.Clear();
            }
        }

        // Metodo para atualizar uma conta que já existe.
        static void updateCorrentista(string [,] personData, double[,] renda, int qqtd)
        {
            Console.Clear();
            Console.WriteLine("Para atualizar um correntista digite o CPF");
            Console.Write("CPF: ");
            var cpf = Console.ReadLine();
            
            if (cpf.Length < 1) // Ira quebrar o programa e forçar a ir até o painel principal.
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("DIGITE UM CPF. PARA TENTAR NOVAMENTE APERTE UMA TECLADA");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Int32.Parse(cpf);
            }

            string cpfLimpo = Regex.Replace(cpf, @"[^\d]", ""); // regex para validar CPF.
            
            
            for (int i = 0; i < qqtd; i++)
            {
                if (personData[i,2].Contains(cpfLimpo)) 
                {
                    for (int j = 0; j < 4; j++)
                    {   
                        switch(j) 
                        {
                            case 0: 
                                Console.WriteLine($"Primeiro Nome: {personData[i,j]}");
                                break;

                            case 1:
                                Console.WriteLine($"Sobrenome: {personData[i,j]}");    
                                break;

                            case 2:
                                Console.WriteLine($"CPF: {personData[i,j]}");    
                                break;

                            case 3:
                                Console.WriteLine($"Endereço: {personData[i,j]}");    
                                Console.WriteLine($"Renda: R$ {renda[i,0]}");    
                                break;
                        }
                    }
                    Console.WriteLine();
                    Console.Write("[0] Para atualizar o nome | [1] Para atualizar o sobre nome | [2] Para atualizar o endereço | [3] Para atualizar a renda: ");
                    var inp = Int32.Parse(Console.ReadLine());

                    switch(inp)
                    {
                        case 0:
                        Console.Write("Primeiro nome: ");
                        var nome = Console.ReadLine();
                        personData[i,0] = nome;   
                        break;

                        case 1:
                        Console.Write("Sobre nome: ");
                        var lastName = Console.ReadLine();
                        personData[i,1] = lastName;   
                        break;

                        case 2:
                        Console.Write("Endereço: ");
                        var endereco = Console.ReadLine();
                        personData[i,3] = endereco;    
                        break; 

                        case 3:
                        Console.Write("Renda: R$ ");
                        double rendaComprovada = double.Parse(Console.ReadLine());
                        renda[i,0] = rendaComprovada;
                        break;     
                    }                    
                    break;
                }                
            
            }
            
            Console.Clear();            
        }

        // Metodo para deletar um correntista. 
        static void deletarCorrentista (string[,] personData, double[,] renda, int qqtd)
        {
            Console.Clear();
            Console.WriteLine("Para deletar um correntista digite o CPF");
            
            Console.Write("CPF: ");
            var cpf = Console.ReadLine();
            string cpfLimpo = Regex.Replace(cpf, @"[^\d]", ""); // regex para validar CPF.
            
            for (int i = 0; i < qqtd; i++)
            {
            
                if (personData[i,2].Contains(cpfLimpo))
                {
                    for (int j = 0; j < 4; j++)
                    {
                        personData[i,j] = "";
                        renda[i,0] = 0;
                    }

                    Console.WriteLine("Correntista Deletado com sucesso aperte ENTER para continuar!");
                    Console.ReadKey();
                }
                
            }

            Console.Clear(); 
        }

        // Esse metodo cria o menu de opções.
        static void painelCreate ()

        {
            var table = new ConsoleTable("FUNÇÔES DO BANCO");
            table.AddRow("Para cirar uma conta [1]");
            table.AddRow("Para editar uma conta existente [2]");
            table.AddRow("Para consultar uma conta existente [3]");
            table.AddRow("Para deletar um correntista [4]");
            table.AddRow("Para sair [5]");
            table.AddRow("Para mostrar todos os correntistas [6]");
            
            table.Write();
            Console.Write("Por favor selecione uma opção: ");
            
        }    

        // Metodo que imprime todos os correntistas cadastrados.
        static void todosCorrentista (string [,] personData, double[,] renda, int qqtd)
        { 
            Console.Clear();
            
            for (int i = 0; i < qqtd; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    switch(j) 
                    {
                        case 0: 
                            Console.WriteLine($"Primeiro Nome: {personData[i,j]}");
                        break;

                        case 1:
                            Console.WriteLine($"Sobrenome: {personData[i,j]}");    
                        break;

                        case 2:
                            Console.WriteLine($"CPF: {personData[i,j]}");    
                        break;

                        case 3:
                            Console.WriteLine($"Endereço: {personData[i,j]}");    
                            Console.WriteLine($"Renda: R$ {renda[i,0]}");    
                        break;
                    }   


                }
            
                Console.WriteLine("---------------");
            }
            Console.ReadKey();
            Console.Clear();
        }   
    }
}