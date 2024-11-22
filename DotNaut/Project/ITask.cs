using DotNaut.Ontology;

namespace DotNaut.Project;

public interface ITask
    : INamed
{
	bool IsDone() => false;
}
