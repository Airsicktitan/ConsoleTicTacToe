namespace ConsoleApp7
{
    internal class Program
    {
        public enum Shapes
        {
            X,
            O
        }

        public static bool player1Turn { get; set; }
        public static bool player2Turn { get; set; }
        static void Main(string[] args)
        {
            string[,] squares =
            {
                { "1", "2", "3" },
                { "4", "5", "6" },
                { "7", "8", "9" }
            };

            Console.WriteLine($"Player One: {Shapes.X}\nPlayer Two: {Shapes.O}\n\n");
            DrawBoard(squares);
            Console.WriteLine("\nPlayer One goes first\n");
            player1Turn = true;
            player2Turn = false;

            bool winner = false;

            while (!winner)
            {
                Console.WriteLine(player1Turn
                    ? "Player 1, choose a square (1-9):"
                    : "Player 2, choose a square (1-9):");

                _ = int.TryParse(Console.ReadLine(), out int playerMove);

                switch (playerMove)
                {
                    case 1:
                        if (squares[0, 0] == Shapes.X.ToString() || squares[0, 0] == Shapes.O.ToString()) Console.WriteLine("Square is already taken");
                        else squares[0, 0] = PlayerMove();

                        DrawBoard(squares);
                        break;
                    case 2:
                        if (squares[0, 1] == Shapes.X.ToString() || squares[0, 1] == Shapes.O.ToString()) Console.WriteLine("Square is already taken");
                        else squares[0, 1] = PlayerMove();

                        DrawBoard(squares);
                        break;
                    case 3:
                        if (squares[0, 2] == Shapes.X.ToString() || squares[0, 2] == Shapes.O.ToString()) Console.WriteLine("Square is already taken");
                        else squares[0, 2] = PlayerMove();

                        DrawBoard(squares);
                        break;
                    case 4:
                        if (squares[1, 0] == Shapes.X.ToString() || squares[1, 0] == Shapes.O.ToString()) Console.WriteLine("Square is already taken");
                        else squares[1, 0] = PlayerMove();

                        DrawBoard(squares);
                        break;
                    case 5:
                        if (squares[1, 1] == Shapes.X.ToString() || squares[1, 1] == Shapes.O.ToString()) Console.WriteLine("Square is already taken");
                        else squares[1, 1] = PlayerMove();

                        DrawBoard(squares);
                        break;
                    case 6:
                        if (squares[1, 2] == Shapes.X.ToString() || squares[1, 2] == Shapes.O.ToString()) Console.WriteLine("Square is already taken");
                        else squares[1, 2] = PlayerMove();

                        DrawBoard(squares);
                        break;
                    case 7:
                        if (squares[2, 0] == Shapes.X.ToString() || squares[2, 0] == Shapes.O.ToString()) Console.WriteLine("Square is already taken");
                        else squares[2, 0] = PlayerMove();

                        DrawBoard(squares);
                        break;
                    case 8:
                        if (squares[2, 1] == Shapes.X.ToString() || squares[2, 1] == Shapes.O.ToString()) Console.WriteLine("Square is already taken");
                        else squares[2, 1] = PlayerMove();

                        DrawBoard(squares);
                        break;
                    case 9:
                        if (squares[2, 2] == Shapes.X.ToString() || squares[2, 2] == Shapes.O.ToString()) Console.WriteLine("Square is already taken");
                        else squares[2, 2] = PlayerMove();

                        DrawBoard(squares);
                        break;

                    default:
                        Console.WriteLine("Square not valid");
                        break;
                }

                if (CheckWinner(squares))
                {
                    string winnerName = player1Turn ? "Player 2" : "Player 1";
                    Console.WriteLine($"{winnerName} has won the game!");
                    break;
                }
            }

        }

        private static void DrawBoard(string[,] squares)
        {
            for (int i = 0; i < squares.GetLength(0); i++)
            {
                for (int j = 0; j < squares.GetLength(1); j++)
                {
                    Console.Write($"{squares[i, j]}");
                    if (j < squares.GetLength(1) - 1)
                        Console.Write(" | ");
                }

                Console.WriteLine("");

                if(i < squares.GetLength(0) - 1)
                    Console.WriteLine("---------");
            }
            
        }

        private static string PlayerMove()
        {
            if (player1Turn)
            {
                (player1Turn, player2Turn) = PlayerTurn(player1Turn, player2Turn);
                return Shapes.X.ToString();
            }
            else
            {
                (player1Turn, player2Turn) = PlayerTurn(player1Turn, player2Turn);
                return Shapes.O.ToString();
            }
        }

        private static (bool, bool) PlayerTurn(bool player1Turn, bool player2Turn)
        {
            if(player1Turn)
            {
                player1Turn = false;
                player2Turn = true;
            }
            else
            {
                player1Turn = true;
                player2Turn = false;
            }

            return (player1Turn, player2Turn);
        }

        private static bool CheckWinner(string[,] shapes)
        {
            // Rows
            for (int i = 0; i < 3; i++)
            {
                if (shapes[i, 0] == shapes[i, 1] && shapes[i, 1] == shapes[i, 2])
                {
                    if (shapes[i, 0] == Shapes.X.ToString() || shapes[i, 0] == Shapes.O.ToString())
                        return true;
                }
            }

            // Columns
            for (int j = 0; j < 3; j++)
            {
                if (shapes[0, j] == shapes[1, j] && shapes[1, j] == shapes[2, j])
                {
                    if (shapes[0, j] == Shapes.X.ToString() || shapes[0, j] == Shapes.O.ToString())
                        return true;
                }
            }

            // Diagonal (top-left to bottom-right)
            if (shapes[0, 0] == shapes[1, 1] && shapes[1, 1] == shapes[2, 2])
            {
                if (shapes[0, 0] == Shapes.X.ToString() || shapes[0, 0] == Shapes.O.ToString())
                    return true;
            }

            // Diagonal (top-right to bottom-left)
            if (shapes[0, 2] == shapes[1, 1] && shapes[1, 1] == shapes[2, 0])
            {
                if (shapes[0, 2] == Shapes.X.ToString() || shapes[0, 2] == Shapes.O.ToString())
                    return true;
            }

            return false;
        }
    }
}
