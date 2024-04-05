// See https://aka.ms/new-console-template for more information
using NewFeaturesOfNETSix;
using System.Text;
using System.Text.Json;

Console.WriteLine("Hello, World!");

#region .net 6.0 neden daha hızlı çalışıyor?
/* dynamic PGO (Profile-Guided Optimization) */
//1. Dosya okuma ve yazma (buffer ve stream vs.)
//2. JSON serileştirme - geri serileştirme
//3. Database işlemleri

#endregion

#region JsonSerializer, artık IAsyncEnumerable ile çalışabiliyor.
async IAsyncEnumerable<int> Show(int maxNumber)
{
    for (int i = 0; i < 10; i++)
    {
        yield return i;
    }
}

//await foreach (var item in Show(10))
//{
//    Console.WriteLine(item);
//}

using var stream = Console.OpenStandardOutput();
var data = new { values = Show(10) };
await JsonSerializer.SerializeAsync(stream, data);
Console.WriteLine();
Console.WriteLine("  Deserialization ");
var readableStream = new MemoryStream(Encoding.UTF8.GetBytes("[1,2,3,4,5]"));
await foreach (var item in JsonSerializer.DeserializeAsyncEnumerable<int>(readableStream))
{
    Console.Write(item + " - ");
}
Console.WriteLine();
#endregion

#region System.LINQ içerisinde neler var?


#region yeni fonksiyon: TryNonEnumeratedCount
var collection = Enumerable.Range(1, 15);
var totalCount = collection.Count(x => x % 3 == 0);
var countInCollection = collection.TryGetNonEnumeratedCount(out int count) ? count : 0;
Console.WriteLine($"Ara belleğe ALINMADAN elde edilen sonuç: {count}");
#endregion

#region ...By ile biten yeni fonksiyonlar!
var employees = new EmployeeService().GetEmployees();
var maxSalary = employees.Max(e => e.Salary);
var employee = employees.FirstOrDefault(e => e.Salary == maxSalary);
var sameResult = employees.MaxBy(e => e.Salary);
Console.WriteLine($" En fazla kazanan: {sameResult.FullName}");

Console.WriteLine("Distinct by ");

var cities = employees.DistinctBy(e => e.City);
foreach (var item in cities)
{
    Console.WriteLine(item.City);
}
#endregion

#region Chunk
var chunk = collection.Chunk(3);
foreach (var item in chunk)
{
    Console.WriteLine($"[{string.Join(",", item)}]");
}
#endregion

#region .NET 6.0'da Index ve Range objeleri var!
var lastNumber = collection.ElementAt(^1);
Console.WriteLine($"Son eleman:{lastNumber}");
Console.WriteLine($"ilk üç eleman:{string.Join(",", collection.Take(..3))}");
Console.WriteLine($"6. elemandan sonrası:{string.Join(",", collection.Take(6..))}");
Console.WriteLine($"son 4 eleman:{string.Join(",", collection.Take(^4..))}");
Console.WriteLine($"son 4 eleman:{string.Join(",", collection.Take(3..7))}");




#endregion

#region artık varsayılan değeri siz atayabilirsiniz:
var firstOrNegative = collection.FirstOrDefault(x => x > 15, -1);
var singleOrNegative = collection.SingleOrDefault(x => x > 10, -1);

#endregion



#endregion


#region Yeni tipler: DateOnly ve TimeOnly
DateOnly createdDate = new DateOnly(2024, 4, 5);
TimeOnly totalWaiting = new TimeOnly(17, 20, 35, 96);

#endregion