using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace YourSpace.Modules.Cloner
{
    public static class Cloner
    {
        public static T BinaryDeepClone<T>(this T obj)
        {
            if(!obj.GetType().IsSerializable)
            {
                throw new Exception("Object should be serializable for cloning");
            }

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            object newObject = null;
            using (MemoryStream memory = new MemoryStream())
            {
                binaryFormatter.Serialize(memory, obj);
                memory.Position = 0;
                newObject = binaryFormatter.Deserialize(memory);
            }
            return (T) newObject;
        }

    }
}
