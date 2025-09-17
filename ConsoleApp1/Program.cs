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

    Console.WriteLine($"Den store starka {p1} möter den coola snabba {p2}");
    while (p1hp <= 0 && p2hp <= 0)
    {
       
    }

}


static void damage()
{
    int dmg = Random.Shared.Next(0, 20);
    
}
 
