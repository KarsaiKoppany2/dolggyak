using dolggyak;
using System.ComponentModel.Design;

List<Konyv> konyvek = new List<Konyv>();

if (File.Exists("konyvek.txt"))
{
    foreach (string aktsor in File.ReadAllLines("konyvek.txt")) 
    {
        string[] adatok = aktsor.Split(';');
        if (int.TryParse(adatok[3], out int ar) && int.TryParse(adatok[4], out int raktarKeszlet)) 
        {
            if (!string.IsNullOrWhiteSpace(adatok[0])) 
            {
                Konyv aktualis = new Konyv(adatok[0], adatok[1], adatok[2], ar, raktarKeszlet);
                konyvek.Add(aktualis);
            }
        }
        else Console.WriteLine($"[HIBA] A(z) {adatok[0]} azonosítójú sor adata hibás, átugorva!\n");
    }
}
Console.WriteLine("=== BEOLVASOTT KÖNYVEK ===");
foreach (Konyv aktkonyv in konyvek) Console.WriteLine(aktkonyv.ToString());
Console.WriteLine($"\nRegisztrált könyvek száma a rendszerben: {Konyv.OsszesRegisztraltKonyv} db");
double nettoErtek = 0;
foreach (Konyv aktkonyv in konyvek) nettoErtek += aktkonyv.Ar * aktkonyv.RaktarKeszlet;
Console.WriteLine($"A raktárkészlet teljes bruttó értéke (5% ÁFA-val): {Penzugy.BruttoArSzamitas(nettoErtek)} Ft");
Konyv legolcsobb = konyvek[0];
foreach ( Konyv aktkonyv in konyvek) 
{
    if (aktkonyv.Ar < legolcsobb.Ar) legolcsobb = aktkonyv;
}
Console.WriteLine($"Legolcsóbb könyv: {legolcsobb.Cim} ({legolcsobb.Ar} Ft)");