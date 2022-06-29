


MyApp app = new MyApp();


//Click wird simuliert.
app.Button_StarteLottoziehung();


//Eine Programm, kann auch Programm mit UI sein

delegate void AktuellGezogeneLottozahlenDelegate(int zahl);

delegate void GesamtERgebnisDerZiehungDelegate(GezogeneLottozahlen gezogeneLottozahlen);
public class MyApp
{
    private LottozahlenZiehungComponent lottozahlenZiehungComponent = new LottozahlenZiehungComponent();

    private AktuellGezogeneLottozahlenDelegate aktuellGezogeneLottozahlenDelegate;
    private GesamtERgebnisDerZiehungDelegate gesamtERgebnisDerZiehungDelegate;

    public MyApp()
    {
        aktuellGezogeneLottozahlenDelegate = new AktuellGezogeneLottozahlenDelegate(ZeigeAktuelleGezogeneLottozahlAn);
        gesamtERgebnisDerZiehungDelegate = new GesamtERgebnisDerZiehungDelegate(ZeigeAlleLottozahlenAn);
    }

    public void Button_StarteLottoziehung()
    {
        
        lottozahlenZiehungComponent.ZiehungDerLottozahlen(aktuellGezogeneLottozahlenDelegate, gesamtERgebnisDerZiehungDelegate);
    }


    public void ZeigeAktuelleGezogeneLottozahlAn(int gezogeneLottozahl)
    {
        Console.WriteLine($"Die gezogene Lottozahl ist die {gezogeneLottozahl}");
    }


    public void ZeigeAlleLottozahlenAn(GezogeneLottozahlen alleGezogenenZahlen)
    {
        Console.Write("Ziehung vom Samstag:");
        for (int i = 0; i < alleGezogenenZahlen.Lottozahlen.Length; i++)
            Console.Write(alleGezogenenZahlen.Lottozahlen[i]);
    }
}


class LottozahlenZiehungComponent
{
    public void ZiehungDerLottozahlen(AktuellGezogeneLottozahlenDelegate anzeigeDerLottozahlen, GesamtERgebnisDerZiehungDelegate gesamtERgebnisDerZiehung) //Delegate ist ein Callback und eine Methode gemappt die uns den Zwischenstand 
    {
        Random rnd = new Random();
        GezogeneLottozahlen gezogeneLottozahlen = new GezogeneLottozahlen();

        gezogeneLottozahlen.Lottozahlen[0] = rnd.Next(1, 50);
        anzeigeDerLottozahlen(gezogeneLottozahlen.Lottozahlen[0]); //rufe MyApp.ZeigeAktuelleGezogeneLottozahlAn(int gezogeneLottozahl) auf


        gezogeneLottozahlen.Lottozahlen[1] = rnd.Next(1, 50);
        anzeigeDerLottozahlen(gezogeneLottozahlen.Lottozahlen[1]);


        gezogeneLottozahlen.Lottozahlen[2] = rnd.Next(1, 50);
        anzeigeDerLottozahlen(gezogeneLottozahlen.Lottozahlen[2]);

        gezogeneLottozahlen.Lottozahlen[3] = rnd.Next(1, 50);
        anzeigeDerLottozahlen(gezogeneLottozahlen.Lottozahlen[3]);


        gezogeneLottozahlen.Lottozahlen[4] = rnd.Next(1, 50);
        anzeigeDerLottozahlen(gezogeneLottozahlen.Lottozahlen[4]);

        gezogeneLottozahlen.Lottozahlen[5] = rnd.Next(1, 50);
        anzeigeDerLottozahlen(gezogeneLottozahlen.Lottozahlen[5]);

        gezogeneLottozahlen.Lottozahlen[6] = rnd.Next(1, 50);
        anzeigeDerLottozahlen(gezogeneLottozahlen.Lottozahlen[6]);


        //Callback 
        gesamtERgebnisDerZiehung(gezogeneLottozahlen);
        //Rufe in der Application das Gesamtergebnis der Samstaziehung auf 
    }
}


public class GezogeneLottozahlen
{
    public int[] Lottozahlen = new int[7];
}