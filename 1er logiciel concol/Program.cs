using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace _1er_logiciel_concol;

class Program
{
    static void Main(string[] args)
    {
        string? s = null;
        Console.WriteLine("Valeur de s : " + s);

        var myArray = new[] {1,2,3,4,5,6,7,8,9,10};

        var myRange = myArray[4..^2];
        
        Console.WriteLine(string.Join(",",myRange));
    }
}

public interface ITest{
    void Test();
}