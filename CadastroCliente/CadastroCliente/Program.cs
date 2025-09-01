using CadastroCliente.Entities;
using CadastroCliente.Services;

namespace CadastroCliente;

public class Program
{
    static void Main(string[] args)
    {
        string path = @"C:\Users\gamer\OneDrive\Documentos\Curso C# POO UDEMY\Desafios para treinar\Cadastro-Cliente-Arquivo\CadastroCliente\Clientes.csv.txt";

        ClientService clientService = new ClientService(path);

        List<Client> clients = new List<Client>
        {
            new Client("João Silva", "12345678901"),
            new Client("Maria Souza", "98765432100"),
            new Client("Pedro Lima", "45678912300"),
            new Client("Luan Souza", "16497950761"),
            new Client("Jose Pereira", "381930231"),
            new Client("Matheus Fernandes", "123456789")
        };

        try
        {
            //Salvando todos no mesmo arquivo
            clientService.SaveCustomer(clients);
            Console.WriteLine("Clientes Salvos!");  
            
            
            //Le todas as linhas e cria objeto Client
            List<Client> carregados = clientService.LoadCustomers();
            Console.WriteLine("Cliente Carregado com Sucesso!");
            
            
            //Criando Arquivo novo.
            string finalpath =
                @"C:\Users\gamer\OneDrive\Documentos\Curso C# POO UDEMY\Desafios para treinar\Cadastro-Cliente-Arquivo\CadastroCliente\RelatorioCliente.csv";
            
            Console.WriteLine("Arquivo Criado com Sucesso!");
            clientService.CreateReport(finalpath);
            
            Console.WriteLine($"Relatório gerado em: {finalpath}");
        }
        catch (Exception e)
        {
            Console.WriteLine("Um erro Aconteceu: ");
            Console.WriteLine(e.Message);
        }
    }
}