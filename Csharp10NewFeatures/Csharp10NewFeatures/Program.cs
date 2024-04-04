// See https://aka.ms/new-console-template for more information

#region top-level statement ve global (implicitly) usings
using System.Linq.Expressions;

void showSomething(string something)
{
    Console.WriteLine(something);
}

showSomething("Selam selam!");

DataTable dt = new DataTable();

#endregion

#region Anonim tipler ve lambda fonksiyonlarında iyileştirmeler.


#region anonim tipler, delege'leri kapsıyor:


var anonym = new { Name = "Türkay", Age = 44 };

Func<int, bool> isEven = n => n % 2 == 0;
var isEvenAnonym = (int n) => n % 2 == 0;
Delegate isOdd = (int n) => n % 2 == 1;
object isOddObject = (int n) => n % 2 == 1;
LambdaExpression isMultiplyThree = (int number) => number % 3 == 0;
#endregion

#region Delege metoda build-in fonksion atama:


Func<int> read = Console.Read;
//C# 10:
var read2 = Console.Read;

Action<string> write = Console.Write;
//var write = Console.Write; Çalışmaz. Çünkü hangi Write overload'u?
#endregion




#endregion


