
public class VareAI {
    private static string apikey = "";
    private static string varenavn = "";
    private static string kategori = "";
    private static string noegleord = "";
    private static string outputfil = "";

    public static void Main(string[] args) {
        //Håndter argumenter - Brug CommandLineParser i stedet for dette
        for (int i = 0; i < args.Length; i++) {
            switch (args[i]) {
                case "-a":
                    apikey = args[i + 1];
                    break;
                case "-v":
                    varenavn = args[i + 1];
                    break;
                case "-k":
                    kategori = args[i + 1];
                    break;
                case "-n":
                    noegleord = args[i + 1];
                    break;
                case "-o":
                    outputfil = args[i + 1];
                    break;
                default:
                    break;
            }
        }
    }

    private static void MainMenu(string apikey, string varenavn, string kategori, string noegleord, string outputfil) {
        while (true) {
            Console.WriteLine("VareAI - Hovedmenu");
            Console.WriteLine("1. Generer beskrivelse");
            Console.WriteLine("2. Indstillinger");
            Console.WriteLine("3. Afslut program");
            Console.WriteLine("Indtast et tal for at vælge en mulighed.");
            string svar = Console.ReadLine();
            switch (svar) {
                case "1":
                    if (apikey == "" || varenavn == "" || kategori == "" || noegleord == "" || outputfil == "") {
                        Console.WriteLine("Du mangler at indtaste nogle af de nødvendige argumenter.");
                        continue;
                    }
                    else {
                        GenererBeskrivelse();
                    }
                    Environment.Exit(0);
                    break;
                case "2":
                    Indstillinger();
                    continue;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ugyldigt input.");
                    continue;
            }

        }
    }

    private static void Indstillinger() {
        Console.WriteLine("Indstillinger");
        Console.WriteLine("1. API-nøgle");
        Console.WriteLine("2. Varenavn");
        Console.WriteLine("3. Kategori");
        Console.WriteLine("4. Nøgleord");
        Console.WriteLine("5. Outputfil");
        Console.WriteLine("6. Tilbage");
        Console.WriteLine("Indtast et tal for at vælge en mulighed.");
        string svar = Console.ReadLine();
        string vaerdi;
        switch (svar) {
            case "1":
                Console.WriteLine("API-nøgle");
                Console.WriteLine("Nuværende værdi: " + apikey);
                Console.WriteLine("Indtast ny værdi, eller tryk enter for at bevare den nuværende værdi.");
                vaerdi = Console.ReadLine();
                if (vaerdi != "") {
                    apikey = vaerdi;
                }
                return;
            case "2":
                Console.WriteLine("Varenavn");
                Console.WriteLine("Nuværende værdi: " + varenavn);
                Console.WriteLine("Indtast ny værdi, eller tryk enter for at bevare den nuværende værdi.");
                vaerdi = Console.ReadLine();
                if (vaerdi != "") {
                    varenavn = vaerdi;
                }
                return;
            case "3":
                Console.WriteLine("Kategori");
                Console.WriteLine("Nuværende værdi: " + kategori);
                Console.WriteLine("Indtast ny værdi, eller tryk enter for at bevare den nuværende værdi.");
                vaerdi = Console.ReadLine();
                if (vaerdi != "") {
                    kategori = vaerdi;
                }
                return;
            case "4":
                Console.WriteLine("Nøgleord");
                Console.WriteLine("Nuværende værdi: " + noegleord);
                Console.WriteLine("Indtast ny værdi, eller tryk enter for at bevare den nuværende værdi.");
                vaerdi = Console.ReadLine();
                if (vaerdi != "") {
                    noegleord = vaerdi;
                }
                return;
            case "5":
                Console.WriteLine("Outputfil");
                Console.WriteLine("Nuværende værdi: " + outputfil);
                Console.WriteLine("Indtast ny værdi, eller tryk enter for at bevare den nuværende værdi.");
                vaerdi = Console.ReadLine();
                if (vaerdi != "") {
                    outputfil = vaerdi;
                }
                break;
            case "6":
                return;
            default:
                Console.WriteLine("Ugyldigt input.");
                return;
        }
    }

    private static void GenererBeskrivelse() {
        string Beskrivelse = "";
        //TODO: AI implementation
        Console.WriteLine("Beskrivelse af " + varenavn + ": " + Beskrivelse);
    }
}