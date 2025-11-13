using System.Security.Cryptography;
static void Namn()
{
    string p1;
    string p2;

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
        start(p1, p2);
    }
}

Console.WriteLine("välkomen till mitt slå spel");
Namn();

    
        

static void start(string p1, string p2)
{
    int p1hp = 100;
    int p2hp = 100;
    int roundCounter = 1;
    int dmgOnP2;
    int dmgOnP1;

    Console.WriteLine($"Den store starka {p1} möter den coola snabba {p2}");
    while (p1hp >= 0 && p2hp >= 0)
    {
        
        dmgOnP2 = damage();
        dmgOnP1 = damage();
        if (dmgOnP2 > p2hp)
        {
        dmgOnP2 = p1hp;  
        Console.WriteLine($"\n\n{p1} slog på {p2} och gjorde {dmgOnP2} i skada och i ju med det solg ut {p2} och van");
        }
        p2hp -= dmgOnP2; 
        Console.WriteLine($"\n\n{p1} slog på {p2} och gjorde {dmgOnP2} i skada, nu har {p2} {p2hp}HP kvar");
        p1hp -= dmgOnP1;
        Console.WriteLine($"\n{p2} slog på {p1} och gjorde {dmgOnP2} i skada, nu har {p1} {p1hp}HP kvar");
        roundCounter++;
        Console.WriteLine($"\nRunda {roundCounter}");
        Console.ReadLine();
    }

}


static int damage()
{
    int dmg = Random.Shared.Next(21);
    return dmg;
}
 
Console.ReadLine();