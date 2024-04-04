// See https://aka.ms/new-console-template for more information

#region top-level statement ve global (implicitly) usings
using Csharp10NewFeatures;
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

#region Lambda fonksiyona dönüş değeri belirtme:

var result = object (bool isOk) => isOk ? 1 : "İşlem hatalı";

#endregion




#endregion


#region Record ve Record Structure kavramları

ProductRecord productRecord1 = new ProductRecord(1, "Çamaşır Makinası", 30000);
ProductRecord productRecord2 = new ProductRecord(3, "Çamaşır Makinası", 30000);

Console.WriteLine($"record1 == record2 karşılaştırma sonucu:{productRecord1 == productRecord2}");
Console.WriteLine($"record1.Equals(record2) karşılaştırma sonucu:{productRecord1.Equals(productRecord2)}");
Console.WriteLine($"record1.GetHashCode() == record2.GetHashCode()  karşılaştırma sonucu:{productRecord1.GetHashCode() == productRecord2.GetHashCode()}");

ProductRecord productRecord3 = productRecord1;

Point point = new Point();

List<Address> addresses = new()
{
    new("Eskişehir","Sümer","Türkiye"),
    new("İstanbul","Kartal","Türkiye"),

};

Address searchingAddress = new("Eskişehir", "Sümer", "Türkiye");
var isFind = addresses.Any(x => x == searchingAddress);
Console.WriteLine($"Adres içinde yer alıyor mu: {isFind}");

#endregion




