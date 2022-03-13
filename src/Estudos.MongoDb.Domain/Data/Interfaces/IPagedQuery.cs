using Estudos.MongoDb.Domain.Enums;

namespace Estudos.MongoDb.Domain.Data.Interfaces;

public interface IPagedQuery
{
    public int Page { get; }

    public int Results { get; }

    public string OrderBy { get; }
    public string Filter { get; }

    public SortOrder SortOrder { get; }
}