using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

namespace CryptoAnalizerAI
{

    public class LoaderAndSaver<T> where T : class
    {
        private string saveDestination;
        private string saveFileName;
        public LoaderAndSaver(string saveDestination, string saveFileName)
        {
            this.saveDestination = Directory.GetCurrentDirectory() + "\\" + saveDestination;
            this.saveFileName = saveFileName;
        }


        public void Save(T objectToSave)
        {

            if (!File.Exists(saveDestination))
            {
                Directory.CreateDirectory(saveDestination);
            }
            string json = JsonSerializer.Serialize(objectToSave);

            string path = Path.Combine(saveDestination, saveFileName);
            StreamWriter writer = new StreamWriter(path, false, System.Text.Encoding.Default);
            
            writer.WriteLine(json);
            writer.Close();
        }

        public T loadObject()
        {
            string path = Path.Combine(saveDestination, saveFileName);
            if (!File.Exists(path)) return null;
            StreamReader reader = new StreamReader(path);
            string content = reader.ReadToEnd();
            reader.Close();

            T result = JsonSerializer.Deserialize<T>(content);
            return result;
        }
    }
}
