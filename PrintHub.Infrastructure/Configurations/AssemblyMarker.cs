using System.Reflection;

namespace PrintHub.Infrastructure.Configurations;

public abstract class AssemblyMarker
{
    public static readonly Assembly Assembly = typeof(AssemblyMarker).Assembly;
}