namespace CLI_241104;

internal class Versenyzo
{
    public string Nev { get; set; }
    public int SzulEv { get; set; }
    public int RajtSzam { get; set; }
    public bool Neme {  get; set; }
    public string Kategoria { get; set; }
    public Dictionary <string, TimeSpan> Idok {  get; set; }

    public override string ToString() => $"[{RajtSzam}] {Nev} ({Kategoria})";

    public int OsszIdo => (int)Idok.Values.Sum(x => x.TotalSeconds);
    public Versenyzo(string sor)
    {
        string[] v = sor.Split(';');

        Nev = v[0];
        SzulEv = int.Parse(v[1]);
        RajtSzam = int.Parse(v[2]);
        Neme = v[3] == "f";
        Kategoria = v[4];
        Idok = new()
        {
            {"úszás", TimeSpan.Parse(v[5])},
            {"I. depó", TimeSpan.Parse(v[6])},
            {"kerékpár", TimeSpan.Parse(v[7])},
            {"II. depó", TimeSpan.Parse(v[8])},
            {"futás", TimeSpan.Parse(v[9])},
        };
    }
}
