
public class VareAI {
    public static void Main(string[] args) {
        Console.WriteLine("Hello World!");

        string apikey = FaaDataFraBruger("Indtast API-nøgle:");
        string varenavn = FaaDataFraBruger("Indtast varenavn:");
        string kategori = FaaDataFraBruger("Indtast kategori:");
        string noegleord = FaaDataFraBruger("Indtast nøgleord:");
        string outputfil = FaaDataFraBruger("Indtast outputfil:");

        GenererBeskrivelse(apikey, varenavn, kategori, noegleord, outputfil);
    }

    private static string FaaDataFraBruger(string spoergsmaal) {
        string svar = "";
        do {
            Console.WriteLine(spoergsmaal + "\nEller skriv \"exit\" for at afslutte programmet.");
            svar = Console.ReadLine();
        } while (svar == "");

        if (svar == "exit") {
            Environment.Exit(0);
        }

        return svar;
    }

    private static void GenererBeskrivelse(string apikey, string varenavn, string kategori, string noegleord, string outputfil) {
        string Beskrivelse = "";
        //TODO: AI implementation
        Console.WriteLine("Beskrivelse af " + varenavn + ": " + Beskrivelse);
    }
}