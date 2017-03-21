using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taken
{
    public class Reader
    { 
        public static int[] FileReader(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);

            string[] array = lines[0].Split(','); //массив строк, каждое число - это строка

            int[] massiv = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                massiv[i] = int.Parse(array[i]);
            } 

            return massiv;
        }
    }
}
