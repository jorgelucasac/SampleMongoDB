namespace Estudos.MongoDb.Application.UseCases.Shared;

public class Output
{
    public Output()
    {
        _erros = new List<string>();
    }

    public Output(object result)
    {
        Result = result;
        _erros = new List<string>();
    }

    public Output(List<string> _erros)
    {
        _erros = new List<string>();
        AddErros(_erros);
    }

    public Output(string erro)
    {
        _erros = new List<string>();
        AddErro(erro);
    }

    private readonly List<string> _erros;

    public object Result { get; private set; }
    public IReadOnlyCollection<string> Erros => _erros.AsReadOnly();
    public bool IsValid => !IsInvalid;
    public bool IsInvalid => _erros.Any();

    public void AddResult(object result)
    {
        Result = result;
    }

    public void AddErro(string erro)
    {
        _erros.Add(erro);
    }

    public void AddErros(List<string> erros)
    {
        _erros.AddRange(erros);
    }

    public void ClearErros()
    {
        _erros.Clear();
    }
}