using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnketWinForm
{
    public class File
    {
        public static void JsonSerialize(User user, string name)
        { 
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter($"{name}.json",true))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, user);
                }
            }
        }

        public static User JsonDeserialize(string name)
        {
            User user = new User();
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader($"{name}.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    user = serializer.Deserialize<User>(jr);
                }
                //foreach (var item in users)
                //{
                //    Console.WriteLine(item);
                //}
            }

            return user;
        }


    }
}
