using test.Models;

puissance4 p = new puissance4();

while (p.v_Winner == -1)
{
    p.grid.print();
    Console.Write("à joueur " + p.v_CurrentPlayer.ToString() + " de jouer > ");
    string ColIndex = Console.ReadLine();
    p.PlacePawn(Convert.ToInt32(ColIndex));
}

