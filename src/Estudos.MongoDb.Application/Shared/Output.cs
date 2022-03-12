namespace Estudos.MongoDb.Application.Shared;

public class Output
{
    public Output()
    {
        Erros = new List<string>();
    }

    public Output(object result)
    {
        Result = result;
        Erros = new List<string>();
    }

    public Output(List<string> erros)
    {
        Erros = new List<string>();
        AddErros(erros);
    }

    public Output(string erro)
    {
        Erros = new List<string>();
        AddErro(erro);
    }

    public object Result { get; private set; }

    public List<string> Erros { get; }
    public bool IsValid => Erros.Any();
    public bool IsInvalid => !IsValid;

    public void AddResult(object result)
    {
        Result = result;
    }

    public void AddErro(string erro)
    {
        Erros.Add(erro);
    }

    public void AddErros(List<string> erros)
    {
        Erros.AddRange(erros);
    }

    public void ClearErros()
    {
        Erros.Clear();
    }
}