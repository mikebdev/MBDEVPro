
namespace MBDEVpro.Common.Helper
{
    public static class JsonUtilities
    {
        /// <summary>
        /// Reads from json file.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonFilename">The json filename.</param>
        /// <param name="filePath">File Path.</param>
        /// <returns></returns>
        public static T ReadFromJsonFile<T>(string filePath, string jsonFilename) where T : new()
        {
            TextReader reader = null;
            try
            {
                // read file into a string
                reader = new StreamReader(GetJsonFilePath(filePath, jsonFilename));
                var fileContents = reader.ReadToEnd();

                // deserialize JSON to a type
                return JsonConvert.DeserializeObject<T>(fileContents);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        /// <summary>
        /// Gets the json file full path.
        /// </summary>
        /// <param name="jsonFilename">The json filename.</param>
        /// <param name="filePath">File Path.</param>
        /// <returns></returns>
        public static string GetJsonFilePath(string filePath, string jsonFilename)
        {
            // Get the Json file root directory path
            var basePath = Directory.GetCurrentDirectory();

            //Replaced bin folder path with empty string
            basePath = basePath.Replace(@"\bin\Debug", "");

            // Combine basePath and filename
            var filepath = Path.Combine(basePath, filePath, jsonFilename);

            // return the file path
            return filepath;
        }

        /// <summary>
        /// Reads the data from json file(s).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonFilename">The json filename.</param>
        /// <returns></returns>
        public static IEnumerable<T> ReadData<T>(string jsonFilename)
        {
            return ReadJSONData<T>(jsonFilename).AsQueryable();
        }

        /// <summary>
        /// Reads the json data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonFilename">The json filename.</param>
        /// <returns></returns>
        private static IEnumerable<T> ReadJSONData<T>(string jsonFilename)
        {
            // Get the Json file root directory path
            var basePath = Directory.GetCurrentDirectory();

            basePath = basePath.Replace(@"\bin\Debug", "");

            basePath = basePath.Replace(@"bin\Debug", "");

            // Combine basePath and filename
            var filepath = Path.Combine(basePath, "Mockdata", $"{jsonFilename}.json");

            // Read file into a string and deserialize JSON to a type
            var entities = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(filepath));

            return entities;
        }
    }
}
