using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace BruteForceExample
{
    internal class Program
    {
        static int failedAttempts = 0;
        static int failedCaptchaAttempts = 0;
        static int maxAttempts = 3;
        static TimeSpan lockoutDuration = TimeSpan.FromMinutes(5);
        static DateTime? lockoutEndTime = null;
        static int delay = 1000;
        static string salt = GenerateSalt();

        static void Main(string[] args)
        {
            Console.Write("Password (max 6 letters, recommended 4): ");
            string password = Console.ReadLine();

            string hashedPassword = HashPassword(password, salt);

            string current = "";
            int[] pos = { 0, 0, 0, 0, 0, 0 };
            string[] alphabet = { "", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "å", "ä", "ö" };
            int count = 0;

            while (!VerifyPassword(current, hashedPassword))
            {
                if (lockoutEndTime.HasValue && DateTime.Now < lockoutEndTime.Value)
                {
                    Console.WriteLine("Account is locked. Please try again later.");
                    return;
                }

                if (!ShowCaptcha())
                {
                    failedCaptchaAttempts++;
                    if (failedCaptchaAttempts >= maxAttempts)
                    {
                        Console.WriteLine("Too many failed CAPTCHA attempts. Account locked.");
                        return;
                    }
                    Console.WriteLine("CAPTCHA failed. Try again.");
                    continue;
                }

                for (int i = 0; i < pos.Length; i++)
                {
                    if (pos[i] == alphabet.Length)
                    {
                        pos[i] = 0;
                        if (i + 1 < pos.Length)
                        {
                            pos[i + 1]++;
                        }
                    }
                }

                current = (alphabet[pos[5]] + alphabet[pos[4]] + alphabet[pos[3]] + alphabet[pos[2]] + alphabet[pos[1]] + alphabet[pos[0]]).ToString();

                if (count % 100 == 0) Console.WriteLine(current);
                pos[0]++;
                count++;

                failedAttempts++;

                int remainingAttempts = maxAttempts - failedAttempts;
                if (remainingAttempts > 0)
                {
                    Console.WriteLine($"Incorrect password. You have {remainingAttempts} attempts left.");
                }

                if (failedAttempts >= maxAttempts)
                {
                    lockoutEndTime = DateTime.Now.Add(lockoutDuration);
                    Console.WriteLine($"Too many failed attempts. Account locked until {lockoutEndTime.Value}.");

                    
                    Thread.Sleep(2000); 
                    return;
                }

                Thread.Sleep(delay);
                delay *= 2;
            }

            Console.WriteLine($"Hittat password: {current}");
        }

        static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = password + salt;
                var saltedPasswordBytes = Encoding.UTF8.GetBytes(saltedPassword);
                var hashBytes = sha256.ComputeHash(saltedPasswordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        static bool VerifyPassword(string attemptedPassword, string hashedPassword)
        {
            string hashedAttemptedPassword = HashPassword(attemptedPassword, salt);
            return hashedAttemptedPassword == hashedPassword;
        }

        static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        static bool ShowCaptcha()
        {
            Random rand = new Random();
            int num1 = rand.Next(1, 10);
            int num2 = rand.Next(1, 10);

            Console.WriteLine($"CAPTCHA: What is {num1} + {num2}?");
            string response = Console.ReadLine();

            int expectedAnswer = num1 + num2;
            if (int.TryParse(response, out int userAnswer) && userAnswer == expectedAnswer)
            {
                return true;
            }

            return false;
        }
    }
}
