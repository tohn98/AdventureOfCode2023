using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Task15
{
    public static void Cookies()
    {
        var input = input15.input;
        var check = 0;

        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100-i; j++)
            {
                for (int k = 0; k < 100-i-j; k++)
                {
                    for (int l = 100 - k-j-i-1; l < 100-i-j-k; l++)
                    {

                    }
                }

            }

        }

    }
}