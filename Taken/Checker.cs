using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taken
{
    class Checker
    {
        private Logger Log = new Logger();

        public bool CheckField(int[] coord)
        {
            if (coord[0] == -1 || coord[1] == -1) //проверяем, что точка в пределах поля
            {
                Log.Message("Невозможно совершить перемещение. Такой фишки на поле не существует.");

                return false;
            }

            return true;
        }
    }
}
