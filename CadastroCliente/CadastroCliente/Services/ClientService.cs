using CadastroCliente.Entities;

namespace CadastroCliente.Services;

public class ClientService
{
    private string? _archive;
    
    public ClientService(string? archive)
    {
        _archive = archive;
    }
    
    
    //SAlvar uma "LISTA" de clientes
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

    public List<Client> LoadCustomers()
    {
        var client = new List<Client>();

        if (File.Exists(_archive))
            return client;

        using (StreamReader sr = new StreamReader(_archive))
        {
            string linha;
            while ((linha = sr.ReadLine()) != null)
            {
                string[] 
            }
        }
    }
}