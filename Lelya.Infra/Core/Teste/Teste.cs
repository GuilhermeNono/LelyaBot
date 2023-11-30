using Lelya.Domain.Core;

namespace Lelya.Infra.Core.Teste;

public class Teste: ITest
{
    public void InjectionTest()
    {
        Console.WriteLine("Injeção funcionado corretamente.");
    }
}