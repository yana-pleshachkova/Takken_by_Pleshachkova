using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taken
{
    public class Game3 : Game2
    {
        private Logger Log = new Logger(); // Для вывода информации на экран консоли
        private Checker Check = new Checker();

        public Game3(string path) : base(path) { }

        public override void Shift(int value)
        {
            var coord = GetLocation(value);

            if (Check.CheckField(coord))
            {
                int path = (int)Math.Sqrt(Math.Abs(Math.Pow(coord[0] - this.ZeroX, 2) + Math.Pow(coord[1] - this.ZeroY, 2)));

                if (path == 1)
                {
                    var copyArea = this.Area;
                    copyArea[this.ZeroX, this.ZeroY] = value;
                    copyArea[coord[0], coord[1]] = 0;

                    int[] arr = new int[this.Len * this.Len];
                    int k = 0;

                    for (int i = 0; i < this.Len; i++)
                    {
                        for (int j = 0; j < this.Len; j++)
                        {
                            arr[k] = copyArea[i, j];
                            k++;
                        }
                    }

                    this.Init(arr);

                    copyArea = null;
                    arr = null;

                    Log.Message("Фишка перемещена");
                    Log.SaveAction("Фишка со значением " + value + ", перемещена на  (" + this.ZeroX +  ", " + this.ZeroY + ")");
                }
                else
                {
                    // если все четрые соседние клетки не пустые
                    Log.Message("Невозможно совершить перемещение. Рядом нет пустой клетки.");
                    Log.SaveAction("Невозможно совершить перемещение. Рядом нет пустой клетки.");
                }
            }
        }

        public void PrintLogActions()
        {
            foreach (var item in Log.GetActions())
            {
                Console.WriteLine("Шаг {0}: {1}", item.Key, item.Value);
            }
        }
    }
}
