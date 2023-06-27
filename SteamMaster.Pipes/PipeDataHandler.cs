using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SteamMaster.Pipes
{
    public static class PipeDataHandler
    {
        // Serialize into bytes 
        public static byte[] SerializeToBytes<T>(T source)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, source);
                return stream.ToArray();
            }
        }

        // Deserialize from bytes (BinaryFormatter)
        public static T DeserializeFromBytes<T>(byte[] source)
        {
            using (var stream = new MemoryStream(source))
            {
                var formatter = new BinaryFormatter();
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        // Same but we check if the deserialization was valid
        public static bool DeserializeFromBytes<T>(byte[] source, out T output)
        {
            try
            {
                using (var stream = new MemoryStream(source))
                {
                    var formatter = new BinaryFormatter();
                    stream.Seek(0, SeekOrigin.Begin);

                    try
                    {
                        object deserializedObject = formatter.Deserialize(stream);

                        if (typeof(T).IsEnum)
                        {
                            output = (T)Enum.ToObject(typeof(T), deserializedObject);
                        }
                        else
                        {
                            output = (T)deserializedObject;
                        }

                        return true;
                    }
                    catch
                    {
                        output = default(T);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during deserialization
                Console.WriteLine("Failed to deserialize: " + ex.Message);
                output = default(T);
                return false;
            }
            
        }
    }
}
