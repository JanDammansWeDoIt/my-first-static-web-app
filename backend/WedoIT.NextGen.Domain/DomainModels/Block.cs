using System.Collections.ObjectModel;

namespace WedoIT.NextGen.Domain.DomainModels;

public class Block : BaseDomainModel
{
    public string Name { get; set; } = null!;
    public string Command { get; set; } = null!;

}