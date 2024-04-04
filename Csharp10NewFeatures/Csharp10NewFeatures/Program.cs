// See https://aka.ms/new-console-template for more information

#region top-level statement ve global (implicitly) usings
using Csharp10NewFeatures;
using Csharp10NewFeatures.Services;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

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


#region Karmaşık Tanımlama, deconstructions ve elbette bunların Tuple'a yansıması:


Tuple<int, int> bolmeIslemi(int a, int b)
{
    //kalan = a % b;
    var tuple = Tuple.Create(a / b, a % b);
    return tuple;
}

(int sonuc, int kalan) tupleOlmadanBolmeIslemi(int a, int b)
{
    //kalan = a % b;
    return (a / b, a % b);
}


var value = bolmeIslemi(13, 5);
Console.WriteLine(value.Item2);

int num1, num2;
(num1, num2) = (-5, 4);
(string name, string lastName, int age) = ("Türkay", "Ürkmez", 44);
(num1, bool olurMu) = (92, false);
(int bolumSonucu, int kalan) = bolmeIslemi(13, 5);
(int bolumSonucu2, int kalan2) = tupleOlmadanBolmeIslemi(13, 5);















#endregion

#region Caller Argument Expression geldi. Hayırlı olsun :)

void ConditionChecker(bool condition, [CallerArgumentExpression(nameof(condition))] string? message = null)
{
    //Console.WriteLine($"{message} koşulunun sonucu: {condition}");
    if (!condition)
    {
        throw new ArgumentException($"{message} koşulunun sonucu: {condition}");
    }

}
(int a1, int b1) = (5, 3);
ConditionChecker(a1 > b1);
ConditionChecker(3 > 5);
string company = "Halkbank";
ConditionChecker(company.StartsWith("H"));


#endregion

#region Exception Guards
void saveProduct(Product product)
{
    ArgumentNullException.ThrowIfNull(nameof(product));

}
#endregion













class BolmeSonucu
{
    public int Sonuc { get; set; }
    public int Kalan { get; set; }
}