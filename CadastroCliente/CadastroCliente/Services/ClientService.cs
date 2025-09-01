using CadastroCliente.Entities;

namespace CadastroCliente.Services;

public class ClientService
{
    private string? _archive;
    
    public ClientService(string? archive)
    {
        _archive = archive;
    }
    
    
    //Salvar uma "LISTA" de clientes
    public void SaveCustomer(List<Client> clients)
    {
        using (StreamWriter sr = new StreamWriter(_archive))
        {
            foreach (Client client in clients)
            {
                sr.WriteLine($"{client.Name}; {client.Cpf}");
            }
        }
    }

    
    //Carregar a lista de clientes
    public List<Client> LoadCustomers()
    {
        var clients = new List<Client>();

        if (!File.Exists(_archive)) //Verificando se o arquivo existe
            return clients; // vai retornar um cliente salvo


        if (_archive != null)
        {
            using (StreamReader sr = new StreamReader(_archive))
            {
                string linha;
                while ((linha = sr.ReadLine()!) != null) // Se for, diferente de nulo tem alguma coisa ainda
                {
                    string[] fields = linha.Split(';');
                    string name = fields[0];
                    string cpf = fields[1];

                    clients.Add(new Client(name, cpf));
                }
            }
        }
        
        return clients;
    }


    public void CreateReport(string finalpath)
    {
        var clients = LoadCustomers();

        using (StreamWriter sw = new StreamWriter(finalpath))
        {
            sw.WriteLine("=============RELATÓRIO DOS CLIENTES=============");
            sw.WriteLine($"Gerado em: {DateTime.Now}");
            sw.WriteLine();

            foreach (var cliente in clients)
            {
                sw.WriteLine(cliente);
            }
            
            sw.WriteLine("=================================");
            sw.WriteLine($"Total de Clientes: {clients.Count}");
        }
    }
}