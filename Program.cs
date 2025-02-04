using KajakKenu;
using System.Text;

List<Kolcsonzes> kolcsonzesek = new();
using (StreamReader be = new(path: @"..\..\..\src\kolcsonzes.txt", encoding: Encoding.UTF8)) 
{
    _ = be.ReadLine();
    while (!be.EndOfStream)
    {
        Kolcsonzes kolcsonzes = new(be.ReadLine());
        kolcsonzesek.Add(kolcsonzes);
    }
}

//Console.WriteLine($"4. feladat: {kolcsonzesek.Count} kölcsönzés adatai találhatók a forrásállományban!");

//Console.Write("5. feladat: Kérem adja meg a nevet: ");
//string nev = Console.ReadLine();
//bool volt = false;
//foreach (Kolcsonzes kolcsonzes in kolcsonzesek)
//{
//    if (kolcsonzes.Nev == nev)
//    {
//        Console.WriteLine($"\t{kolcsonzes.Hajoid}\t {kolcsonzes.Elvitelora}:{kolcsonzes.Elvitelperc} - {kolcsonzes.Visszahozatalora}:{kolcsonzes.Visszahozatalperc}");
//        volt = true;
//    }
//}
//if (!volt)
//{
//    Console.WriteLine("Nem volt ilyen nevű kölcsönző!");
//}


// Console.WriteLine($"6. feladat: Magyar vendégek: {kolcsonzesek.DistinctBy(x => x.Nev).Where(x=> !x.Nev.Contains(',')).Count()} fő\n\tKülföldi vendégek: {kolcsonzesek.DistinctBy(x => x.Nev).Where(x => x.Nev.Contains(',')).Count()} fő");



// Feladat 1

Console.Write("Írjon be egy hajótípust: ");
string hajotipus = Console.ReadLine();
int db = 0;
foreach (Kolcsonzes kolcsonzes in kolcsonzesek)
{
    if (kolcsonzes.Hajotipus == hajotipus)
    {
        db++;
    }
}
Console.WriteLine($"1. feladat: {db} db {hajotipus} típusú hajót vettek ki aznap");

// Feladat 2

var magyarok = kolcsonzesek.Count(x => !x.Nev.Contains(','));
var kulfoldiek = kolcsonzesek.Count() - magyarok;

Console.WriteLine($"2. feladat: Csoportonként kikölcsönöztek\n Magyar: {magyarok} \n Külföldi: {kulfoldiek}");


// Feladat 4

StreamWriter streamWriter = new(path: @"..\..\..\src\fajl.txt", append: false, encoding: Encoding.UTF8);
foreach (Kolcsonzes kolcsonzes in kolcsonzesek)
{
    if ((int)kolcsonzes.Szemelyekszama > 2)
    {
        streamWriter.WriteLine(kolcsonzes.ToString());
    }
}
streamWriter.Close();

