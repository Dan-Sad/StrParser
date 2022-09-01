//"C:\temp\..\temp\.\.\text\..\test.txt"
//Результат:
//"C:\temp\test.txt" 

using System.Text;

namespace First
{
    class Program
    {
        static public string StrParser(string inputStr)
        {
            StringBuilder middleStr = new();
            List<string> outStr = new();

            for (int i = 0; i < inputStr.Length; i++)
            {
                var curSymbol = inputStr[i];
                if (curSymbol == '\\')
                {
                    if (middleStr.Length > 0)
                        outStr.Add(middleStr.ToString());

                    if (inputStr[i + 1] == '.' && inputStr[i + 2] == '\\')
                    {
                        i ++;
                    }
                    else if (inputStr[i + 1] == '.' && inputStr[i + 2] == '.')
                    {
                        outStr.Remove(outStr.Last());
                        i += 2;
                    }
                    else if (inputStr[i + 1] == '.')
                    {
                        i++;
                        outStr.Remove(outStr.Last());
                        middleStr.Append(inputStr[i]);
                    }

                    middleStr.Clear();
                }
                else
                {
                    middleStr.Append(inputStr[i]);
                }
            }
            outStr.Add(middleStr.ToString());

            return String.Join('\\', outStr);
        }

        static void Main()
        {
            Console.WriteLine(StrParser(@"C:\temp\..\temp\.\.\text\..\test.txt"));
        }
    }

}
