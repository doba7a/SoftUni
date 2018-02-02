namespace TheHeiganDance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Coordinates
    {
        public int Row { get; set; }
        public int Column { get; set; }
    }

    public class TheHeiganDance
    {
        public static void Main()
        {
            int playerHealth = 18500;
            double heiganHealth = 3000000;

            double damageToHeiganEachTurn = double.Parse(Console.ReadLine());
            List<Coordinates> damagedCells = new List<Coordinates>();
            string lastSpell = string.Empty;
            Coordinates playerCoordinates = new Coordinates
            {
                Row = 7,
                Column = 7

            };

            while (playerHealth > 0 && heiganHealth > 0)
            {
                heiganHealth -= damageToHeiganEachTurn;

                if (lastSpell == "Plague Cloud")
                {
                    if (SpellHit(damagedCells, ref playerCoordinates))
                    {
                        playerHealth -= 3500;

                        if (playerHealth <= 0)
                        {
                            break;
                        }
                    }
                }

                if (heiganHealth <= 0)
                {
                    break;
                }

                string[] heiganSpellData = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string heiganSpell = heiganSpellData[0];
                Coordinates spellCoordinates = new Coordinates
                {
                    Row = int.Parse(heiganSpellData[1]),
                    Column = int.Parse(heiganSpellData[2])
                };
                damagedCells = DamagedCells(spellCoordinates);

                switch (heiganSpell)
                {
                    case "Cloud":
                        lastSpell = "Plague Cloud";
                        if (SpellHit(damagedCells, ref playerCoordinates))
                        {
                            playerHealth -= 3500;
                        }
                        break;
                    case "Eruption":
                        lastSpell = "Eruption";
                        if (SpellHit(damagedCells, ref playerCoordinates))
                        {
                            playerHealth -= 6000;
                        }
                        break;
                }
            }

            PrintOutput(heiganHealth, playerHealth, lastSpell, playerCoordinates);
        }

        public static bool SpellHit(List<Coordinates> damagedCells, ref Coordinates playerCoordinates)
        {
            int playerRow = playerCoordinates.Row;
            int playerColumn = playerCoordinates.Column;

            if (damagedCells.Any(x => x.Row == playerRow) 
                && damagedCells.Any(x => x.Column == playerColumn))
            {
                int tempRowUp = Math.Max(0, playerRow - 1);

                if (damagedCells.Any(x => x.Row == tempRowUp) 
                    && damagedCells.Any(x => x.Column == playerColumn))
                {
                    int tempColumnRight = Math.Min(14, playerColumn + 1);

                    if (damagedCells.Any(x => x.Row == playerRow) 
                        && damagedCells.Any(x => x.Column == tempColumnRight))
                    {
                        int tempRowDown = Math.Min(14, playerRow + 1);

                        if (damagedCells.Any(x => x.Row == tempRowDown)
                            && damagedCells.Any(x => x.Column == playerColumn))
                        {
                            int tempColumnLeft = Math.Max(0, playerColumn - 1);

                            if (damagedCells.Any(x => x.Row == playerRow)
                                && damagedCells.Any(x => x.Column == tempColumnLeft))
                            {
                                return true;
                            }
                            else
                            {
                                playerCoordinates.Column = tempColumnLeft;
                            }
                        }
                        else
                        {
                            playerCoordinates.Row = tempRowDown;
                        }
                    }
                    else
                    {
                        playerCoordinates.Column = tempColumnRight;
                    }
                }
                else
                {
                    playerCoordinates.Row = tempRowUp;
                }
            }

            return false;
        }

        public static List<Coordinates> DamagedCells(Coordinates spellCoordinates)
        {
            List<Coordinates> damagedCells = new List<Coordinates>();

            int startingRow = spellCoordinates.Row - 1;
            int endingRow = spellCoordinates.Row + 1;
            int startingColumn = spellCoordinates.Column - 1;
            int endingColumn = spellCoordinates.Column + 1;

            for (int row = startingRow; row <= endingRow; row++)
            {
                for (int column = startingColumn; column <= endingColumn; column++)
                {
                    if (row >= 0 && row < 15 && column >= 0 && column < 15)
                    {
                        Coordinates damagedCellCoordinates = new Coordinates
                        {
                            Row = row,
                            Column = column
                        };

                        damagedCells.Add(damagedCellCoordinates);
                    }
                }
            }

            return damagedCells;
        }

        public static void PrintOutput(double heiganHealth, int playerHealth, string lastSpell, Coordinates playerCoordinates)
        {
            if (heiganHealth <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heiganHealth:F2}");
            }

            if (playerHealth <= 0)
            {
                Console.WriteLine($"Player: Killed by {lastSpell}");
            }
            else
            {
                Console.WriteLine($"Player: {playerHealth}");
            }

            Console.WriteLine($"Final position: {playerCoordinates.Row}, {playerCoordinates.Column}");
        }
    }
}
