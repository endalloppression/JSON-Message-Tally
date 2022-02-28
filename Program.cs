using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using static JSON_Message_Tally.TempMessage;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace JSON_Message_Tally
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string root = @"C:\JSON Message Tally\logs";
            string fileNameSuffix = @"\logs_";
            // If directory does not exist, don't even try   
            if (Directory.Exists(root))
            {
                Console.WriteLine("directory does exist!");
                //Directory.Delete(root);
                //Open directory files one at a time
                //Open the stream and read it back.
                //Create Access denied exception here
                var keyValuePairs = new Dictionary<string, Dictionary<string, int>>();
                for(int i = 0; i < 50; i++) 
                { 
                    using (FileStream fs = File.Open(root + fileNameSuffix + i +".json", FileMode.Open))
                    {
                        byte[] b = new byte[(int)fs.Length];
                        UTF8Encoding temp = new UTF8Encoding(true);

                        while (fs.Read(b, 0, b.Length) > 0)
                        {
                            var deserializedJson = JsonSerializer.Deserialize<TempMessage.Root>(temp.GetString(b));
                            var tally = 1;

                            var tempMessage = new Dictionary<string, int>();
                            for (int j = 0; j < deserializedJson.logs.Count; j++)
                            {
                                var email1 = deserializedJson.logs[j].email;
                                tempMessage.TryAdd(email1, tally);
                                keyValuePairs.TryAdd("tally", tempMessage);

                                tally++;
                            }
                       
                            Console.WriteLine(deserializedJson.id);
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("directory does not exist!");
            }
        }
    }
}
