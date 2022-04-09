using JUST;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace JSONTransformation
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await JSONTransformation();
        }


        static async Task JSONTransformation()
        {
            try
            {
                //JSON-Input
                string _jsonInputData = await File.ReadAllTextAsync(@"JSONFiles/sample1.json");

                //Transformation-Template
                string _jsonTransformer = await File.ReadAllTextAsync(@"JUSTTemplates/template1.json");

                //JSON-JSON-Transformation
                var result1 = new JsonTransformer().Transform(_jsonTransformer, _jsonInputData);

                Console.WriteLine(result1);

                WriteToFile(DateTime.Now.ToString("yyyyMMddHHmmssffff") + "_sample.json", result1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        static void WriteToFile(string fileName, string payload)
        {
            string rootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string directoryName = rootPath.Replace("\\bin\\Debug\\netcoreapp3.1", "\\Output");
            string outputfileName = Path.Combine(directoryName, fileName);

            if (!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);

            if (File.Exists(outputfileName))
                File.Delete(outputfileName);

            using var fs = new FileStream(outputfileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            using var writer = new StreamWriter(fs);
            writer.Write(payload);

            Console.WriteLine(Path.Combine(directoryName, fileName));
        }
    }
}
