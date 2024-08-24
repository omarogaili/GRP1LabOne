namespace BruteForceExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Password (max 6 letters, recommended 4): ");
            String password = Console.ReadLine();

            String current = "";

            int[] pos = { 0, 0, 0, 0, 0, 0 };

            String[] alphabet = {"", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "å", "ä", "ö" };

            int count = 0;

            while (!current.Equals(password))
            {
                for (int i = 0; i < pos.Length; i++)
                {
                    if (pos[i] == alphabet.Length)
                    {
                        pos[i] = 0;
                        pos[i + 1]++;
                    }
                }

                current = (alphabet[pos[5]] + alphabet[pos[4]] + alphabet[pos[3]] + alphabet[pos[2]] + alphabet[pos[1]] + alphabet[pos[0]]).ToString();

                if (count %100 == 0) Console.WriteLine(current);
                pos[0]++;
                count++;
            }

            Console.WriteLine($"Hittat password: {current}");




        }
    }
}