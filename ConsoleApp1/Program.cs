using System.Formats.Asn1;
using System.Security.Cryptography;
static void Namn()
{
    int player1Score = 0;
    int player2Score = 0;
    string player1Name;
    string player2Name;
    int totalDamagePlayer1 = 0;
    int totalDamagePlayer2 = 0;

    Console.WriteLine("Vad vill ni hetta");
    Console.WriteLine("spelare ett:");
    player1Name = Console.ReadLine();
    Console.WriteLine("spelare två:");
    player2Name = Console.ReadLine();

    if (player1Name == player2Name)
    {
        Console.WriteLine("spelare ett får inte hetta samma som spelare två");
        Namn();
    }
    else
    {
        Start(player1Name, player2Name, player1Score, player2Score, totalDamagePlayer1, totalDamagePlayer2);
    }
}

Console.WriteLine("välkomen till mitt slå spel");
Namn();


static void Start(string player1Name, string player2Name, int player1Score, int player2Score, int totalDamagePlayer1, int totalDamagePlayer2)
{
    int player1HP = 100;
    int player2HP = 100;
    int roundCounter = 1;
    int damageOnP2;
    int damageOnP1;

    Console.WriteLine($"Den store starka {player1Name} möter den coola snabba {player2Name}");
    while (player1HP > 0 && player2HP > 0)
    {

        Console.WriteLine($"\nRunda {roundCounter}");
        damageOnP2 = Damage();
        damageOnP1 = Damage();
        totalDamagePlayer1 += damageOnP2;
        totalDamagePlayer2 += damageOnP1;

        if (damageOnP2 > player2HP && damageOnP1 > player1HP)
        {
             Console.WriteLine($"{player1Name} och {player2Name} slog varandra satidigt så hårt att båda dog!");
            player2HP -= damageOnP2;
            player1HP -= damageOnP1;
        }
        else if (damageOnP2 > player2HP)
        {
            damageOnP2 = player2HP;
            player2HP -= damageOnP2;
            player1Score++;
            Console.WriteLine($"\n{player1Name} slog på {player2Name} och gjorde {damageOnP2} i skada och i ju med det döda {player2Name} och van!!");
        }
        else if (damageOnP1 > player1HP)
        {
            damageOnP1 = player1HP;
            player1HP -= damageOnP1;
            player2Score++;
            Console.WriteLine($"\n{player2Name} slog på {player1Name} och gjorde {damageOnP1} i skada och i ju med det döda {player1Name} och van!!");
        }
        else
        {
            player2HP -= damageOnP2;
            Console.WriteLine($"\n{player1Name} slog på {player2Name} och gjorde {damageOnP2} i skada, nu har {player2Name} {player2HP}HP kvar");
            player1HP -= damageOnP1;
            Console.WriteLine($"\n{player2Name} slog på {player1Name} och gjorde {damageOnP1} i skada, nu har {player1Name} {player1HP}HP kvar");
        }
        roundCounter++;
        Console.ReadLine();

    }
    Restarter(player1Name, player2Name, player1Score, player2Score, totalDamagePlayer1, totalDamagePlayer2);
}

static void Restarter(string player1Name, string player2Name, int player1Score, int player2Score, int totalDamagePlayer1, int totalDamagePlayer2)
{
    Console.WriteLine("tack för att ni körda mitt lila spel hoppas ni har haft det kul, vil ni köra igen?");
    Console.WriteLine("skriv nej för att avlusta eller skriv omstart för att börja om helt, (din poäng försviner) eller poäng för att se poäng");
    Console.WriteLine("tryck enter för att starta om med samma namn");
    string restart = Console.ReadLine();
    if (restart == "omstart")
    {
        Namn();
    }
    if (restart == "poäng")
    {
        ScoreCounter(player1Name, player2Name, player1Score, player2Score, totalDamagePlayer1, totalDamagePlayer2);
    }
    else if (restart == "")
    {
        Start(player1Name, player2Name, player1Score, player2Score, totalDamagePlayer1, totalDamagePlayer2);
    }
    else if (restart == "nej")
    {
    }
    else
    {
        Console.WriteLine("Du måste välja poäng, omstart, nej eller tyrcka enter");
        Restarter(player1Name, player2Name, player1Score, player2Score, totalDamagePlayer1, totalDamagePlayer2);
    }
    
}

static int Damage()
{
    int damage = Random.Shared.Next(21);
    return damage;
}

static void ScoreCounter(string player1Name, string player2Name, int player1Score, int player2Score, int totalDamagePlayer1, int totalDamagePlayer2)
{
    Console.WriteLine($"\nSpelare\tvinster\tdamage");
    Console.WriteLine($"{player1Name}\t{player1Score}\t{totalDamagePlayer1}");
    Console.WriteLine($"{player2Name}\t{player2Score}\t{totalDamagePlayer2}");
    Console.ReadLine();
    Restarter(player1Name, player2Name, player1Score, player2Score, totalDamagePlayer1, totalDamagePlayer2);
}