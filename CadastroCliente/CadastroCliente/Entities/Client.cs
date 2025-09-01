namespace CadastroCliente.Entities;

public class Client
{
    public string? Name { get; set; }
    public string? Cpf { get; set; }

    public Client(string? name, string? cpf)
    {
        Name = name;
        Cpf = cpf;
    }

    public override string ToString()
    {
        return $"Nome: {Name} - CPF: {Cpf}";
    }
}