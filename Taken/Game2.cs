using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taken
{
    public class Game2 : Game
    {
        public Game2(string path) : base(path)
        {

        }

        public void RandomizeStartArea()
        {
            int[] a = new int[this.Len * this.Len];
            int k = 0;
            for (int i = 0; i < this.Len; i++)
            {
                for (int j = 0; j < this.Len; j++)
                {
                    a[k] = this.Area[i, j];
                    k++;
                }
            }

            var r = new Random();
            for (int i = a.Length - 1; i > 0; i--)
            {
                int j = r.Next(i);
                var t = a[i];
                a[i] = a[j];
                a[j] = t;
            }

            this.Init(a);
        }


        public bool IsEndGame() // Определение выигрыша
        {
            int i, j, k = 1;

            for (i = 0; i < this.Len; i++)
            {
                for (j = 0; j < this.Len; j++)
                {
                    if (this.Area[this.Len - 1, this.Len - 1] == 0)
                    {
                        if (i == this.Len - 1 && j == this.Len - 1)
                        {
                            return true;
                        }
                        else
                        {
                            if (this.Area[i, j] != k)
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }

                    k++;
                }
            }

            return true;
        }
    }
}
