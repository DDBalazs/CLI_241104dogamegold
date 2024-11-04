using CLI_241104;
using System.Security.Claims;
using System.Text;

List<Versenyzo> versenyzok = [];

using StreamReader sr = new("..\\..\\..\\src\\forras.txt",Encoding.UTF8);
while (!sr.EndOfStream) versenyzok.Add(new(sr.ReadLine()));

Console.WriteLine($"Versenyzők száma: {versenyzok.Count}");

var f1 = versenyzok.Count(v => v.Kategoria == "25-29");
Console.WriteLine($"20-29 kategóriában a versenyzők szma: {f1}");

var f2 = versenyzok.Average(v => 2014 - v.SzulEv);
Console.WriteLine($"A versenyzők átlagéletkora: {f2}");

var f3 = versenyzok.Sum(v => v.Idok["úszás"].TotalHours);
Console.WriteLine($"Úszással töltött összes idő: {f3}");

var f4 = versenyzok
    .Where(v => v.Kategoria == "elit")
    .Average(v => v.Idok["úszás"].TotalMinutes);
Console.WriteLine(f4);

var f5 = versenyzok.Where(v => v.Neme)
    .MinBy(v => v.OsszIdo);
Console.WriteLine($"győztes fárfi: {f5}");

var f6 = versenyzok.GroupBy(v => v.Kategoria).GroupBy(g => g.Key);
Console.WriteLine("Kategoriánként a versenyt befejezők száma: ");
foreach (var grp in f6)
{
    Console.WriteLine($"\t{grp.Key,11}: {grp.Count(),2}");
}

var f7 = versenyzok
    .GroupBy(v => v.Kategoria)
    .ToDictionary(g => g.Key, g => g.Average(v =>
    v.Idok["I. depó"].TotalMinutes +
    v.Idok["II. depó"].TotalMinutes))
    .OrderBy(kvp => kvp.Key);

Console.WriteLine("Kategoriánként az átlagos idő a depóban: ");
foreach (var kvp in f7)
{
    Console.WriteLine($"\t{kvp.Key} {kvp.Value:0.00}");
}