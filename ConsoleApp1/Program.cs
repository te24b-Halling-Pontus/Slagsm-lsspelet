using System.Formats.Asn1;
using System.Security.Cryptography;
static void Namn()
{
    int p1Score = 0;
    int p2Score = 0;
    string p1;
    string p2;
    int totalDmgP1 = 0;
    int totalDmgP2 = 0;

    Console.WriteLine("Vad vill ni hetta");
    Console.WriteLine("spelare ett:");
    p1 = Console.ReadLine();
    Console.WriteLine("spelare två:");
    p2 = Console.ReadLine();

    if (p1 == p2)
    {
        Console.WriteLine("spelare ett får inte hetta samma som spelare två");
        Namn();
    }
    else
    {
        start(p1, p2, p1Score, p2Score, totalDmgP1, totalDmgP2);
    }
}

Console.WriteLine("välkomen till mitt slå spel");
Namn();


static void start(string p1, string p2, int p1Score, int p2Score, int totalDmgP1, int totalDmgP2)
{
    int p1hp = 100;
    int p2hp = 100;
    int roundCounter = 1;
    int dmgOnP2;
    int dmgOnP1;

    Console.WriteLine($"Den store starka {p1} möter den coola snabba {p2}");
    while (p1hp > 0 && p2hp > 0)
    {

        Console.WriteLine($"\nRunda {roundCounter}");
        dmgOnP2 = damage();
        dmgOnP1 = damage();
        totalDmgP1 += dmgOnP2;
        totalDmgP2 += dmgOnP1;

        if (dmgOnP2 > p2hp && dmgOnP1 > p1hp)
        {
            Console.WriteLine($"{p1} och {p2} slog varandra satidigt så hårt att båda dog!");
            p2hp -= dmgOnP2;
            p1hp -= dmgOnP1;
        }
        else if (dmgOnP2 > p2hp)
        {
            dmgOnP2 = p2hp;
            p2hp -= dmgOnP2;
            p1Score++;
            Console.WriteLine($"\n{p1} slog på {p2} och gjorde {dmgOnP2} i skada och i ju med det döda {p2} och van!!");
        }
        else if (dmgOnP1 > p1hp)
        {
            dmgOnP1 = p1hp;
            p1hp -= dmgOnP1;
            p2Score++;
            Console.WriteLine($"\n{p2} slog på {p1} och gjorde {dmgOnP1} i skada och i ju med det döda {p1} och van!!");
        }
        else
        {
            p2hp -= dmgOnP2;
            Console.WriteLine($"\n{p1} slog på {p2} och gjorde {dmgOnP2} i skada, nu har {p2} {p2hp}HP kvar");
            p1hp -= dmgOnP1;
            Console.WriteLine($"\n{p2} slog på {p1} och gjorde {dmgOnP1} i skada, nu har {p1} {p1hp}HP kvar");
        }
        roundCounter++;
        Console.ReadLine();

    }
    restarter(p1, p2, p1Score, p2Score, totalDmgP1, totalDmgP2);
}

static void restarter(string p1, string p2, int p1Score, int p2Score, int totalDmgP1, int totalDmgP2)
{
    Console.WriteLine("tack för att ni körda mitt lila spel hoppas ni har haft det kul, vil ni köra igen?");
    Console.WriteLine("skriv nej för att avlusta eller skriv omstart för att börja om helt, (din poäng försviner) eller poäng för att se poäng");
    Console.WriteLine("skriv något annat för att starta om med samma namn");
    string restart = Console.ReadLine();
    if (restart == "omstart")
    {
        Namn();
    }
    if (restart == "poäng")
    {
        scoreCounter(p1, p2, p1Score, p2Score, totalDmgP1, totalDmgP2);
    }
    else if (restart != "nej")
    {
        start(p1, p2, p1Score, p2Score, totalDmgP1, totalDmgP2);
    }
}

static int damage()
{
    int dmg = Random.Shared.Next(21);
    return dmg;
}

static void scoreCounter(string p1, string p2, int p1Score, int p2Score, int totalDmgP1, int totalDmgP2)
{
    Console.WriteLine($"\nSpelare\tvinster\tdamage");
    Console.WriteLine($"{p1}\t{p1Score}\t{totalDmgP1}");
    Console.WriteLine($"{p2}\t{p2Score}\t{totalDmgP2}");
    Console.ReadLine();
    restarter(p1, p2, p1Score, p2Score, totalDmgP1, totalDmgP2);
}