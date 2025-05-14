using System;
using System.Linq;

class Task4
{
    static void HexString()
    {
        var input = input4.input;

        var result = 0;
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                var toHash = input + i;
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(toHash);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                var hexString = Convert.ToHexString(hashBytes);

                // part 1 start with 5 0s, part 2 start with 6 0s
                if (hexString.StartsWith("000000"))
                {
                    result = i;
                    break;
                }
            }
        }
        Console.WriteLine(result);

    }
}