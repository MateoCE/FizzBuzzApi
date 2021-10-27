using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace FizzBuzzApi.Clases
{
    public class FizzBuzzer 
    {

        public String StartLoop(int n)
        {
            Log.Information("Calculando fizz buzz apartir de " + n);
            string result = "";
            try
            {
                int limit = n + 100;
                for (int i = n; i <= limit; i++)
                {
                    string output = getOutputForI(i);
                    result += output;
                }
            }catch(Exception e)
            {
                Log.Warning(e, e.Message);
            }
            Log.Information("String creado con exito");
            return result;
        }

        public string getOutputForI(int i)
        {
            string s = "";
            try
            {
                if (i % 15 == 0)
                    s += " FizzBuzz,";

                else if (i % 3 == 0)
                    s += " Fizz,";

                else if (i % 5 == 0)
                    s += " Buzz,";

                else
                    s += " " + i + ",";

            }
            catch (Exception e)
            {
                Log.Warning(e, e.Message);
            }


            return s;
        }

    }
}
