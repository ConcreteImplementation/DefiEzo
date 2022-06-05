
namespace Parseur
{
    public interface IErreurParseur
    {
        string Message { get;  }
        int Debut{ get; }
        int Fin { get; }
    }
}
