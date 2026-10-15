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
        else Console.WriteLine($"[HIBA] A(z) {adatok[0]} azonosítójú sor adata hibás, átugorva!");
    }
}