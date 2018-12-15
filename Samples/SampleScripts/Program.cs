using System;
using System.IO;
using System.Reflection;

namespace Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                String fileName = args[0];
                if (File.Exists(fileName) == false)
                {
                    Console.WriteLine("File is not exist:" + fileName);
                    return;
                }

                var it = File.ReadLines(fileName).GetEnumerator();
                if (it.MoveNext())
                {
                    String line = it.Current;
                    line = line.Trim();
                    if (line.StartsWith("//RUN:"))
                    {
                        line = line.Substring(6);
                        line = line.Replace(";", "");
                        line = line.Trim();
                        Eval(line);
                    }
                    else
                    {
                        Console.WriteLine("Can not find method to run.");
                    }
                }
                else
                    Console.WriteLine("Can not find method: " + fileName);
            }
            else
            {
                 Console.WriteLine("Running script file is not set, please change launch.json");
            }
        }

        static void Eval(String cmd)
        {
            Console.WriteLine("[Invoke]:" + cmd);
            int lastIdx = cmd.LastIndexOf('.');
            String typeName = cmd.Substring(0, lastIdx);
            String methodName = cmd.Substring(lastIdx + 1);
            try
            {
                var type = Type.GetType(typeName);
                if (type != null)
                {
                    var method = type.GetMethod(methodName);
                    if (method != null)
                    {
                        method.Invoke(null, null);
                        return;
                    }
                }
                Console.WriteLine("Can not find method: " + cmd);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
