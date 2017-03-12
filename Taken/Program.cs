using System;
using System.Collections.Generic;

namespace Taken
{
    class Game
    {
        private int[,] area = null; // Игровое поле
        private int? lenX = null; // Длина X
        private int? lenY = null; // Длина Y

        private Logger Log = new Logger(); // Для вывода информации на экран консоли
        private Checker Check = new Checker();

        private int zeroX, zeroY; // Для сохранения координат 0

        public Game(
            int i1, int i2, int i3,
            int i4, int i5, int i6,
            int i7, int i8, int i9) // Поле 3*3
        {
            area = new int[3, 3]; // Инициализируем поле (задаем размеры)

            area[0, 0] = i9;
            zeroX = 0;
            zeroY = 0;

            area[0, 1] = i1;
            area[0, 2] = i2;

            area[1, 0] = i3;
            area[1, 1] = i4;
            area[1, 2] = i5;

            area[2, 0] = i6;
            area[2, 1] = i7;
            area[2, 2] = i8;

            lenX = 3; // Длина X
            lenY = 3; // Длина Y
        }

        public Game(
            int i1, int i2, int i3, int i4,
            int i5, int i6, int i7, int i8,
            int i9, int i10, int i11, int i12,
            int i13, int i14, int i15, int i16) // Поле 4*4
        {
            area = new int[4, 4];

            area[0, 0] = i16;
            zeroX = 0;
            zeroY = 0;

            area[0, 1] = i1;
            area[0, 2] = i2;
            area[0, 3] = i3;

            area[1, 0] = i4;
            area[1, 1] = i5;
            area[1, 2] = i6;
            area[1, 3] = i7;

            area[2, 0] = i8;
            area[2, 1] = i9;
            area[2, 2] = i10;
            area[2, 3] = i11;

            area[3, 0] = i12;
            area[3, 1] = i13;
            area[3, 2] = i14;
            area[3, 3] = i15;

            lenX = 4;
            lenY = 4;
        }

        private int GetValue(int x, int y) // получить значение по координатам
        {
            if (x >= lenX || y >= lenY || x < 0 || y < 0)
            {
                return -1;
            }

            return area[x, y];
        }

        public int this[int x, int y] // Индексатор, который позволяет определить значение по координатам
        {
            get
            {
                return (GetValue(x, y));
            }
        }

        private int[] GetLocation(int value) // Получить координаты элемента
        {
            int[] a = new int[2];
            a[0] = -1;
            a[1] = -1;

            for (int i = 0; i < lenX; i++)
            {
                for (int j = 0; j < lenY; j++)
                {
                    if (area[i, j] == value)
                    {
                        a[0] = i;
                        a[1] = j;
                    }
                }
            }

            return a;
        }

        public void Shift(int value) // Перемешение фишки на свободное место
        {
            var coord = GetLocation(value);

            if (Check.CheckField(coord))
            {
                int path = (int)Math.Sqrt(Math.Abs(Math.Pow(coord[0] - zeroX, 2) + Math.Pow(coord[1] - zeroY, 2)));

                if (path == 1)
                {
                    area[zeroX, zeroY] = value; // пустой клетке присваиваем значение перемещаемой фишки
                    area[coord[0], coord[1]] = 0; // перемещаемую фишку делаем пустой, присваивая ноль

                    zeroX = coord[0]; // перезаписываем координаты 0
                    zeroY = coord[1];

                    Log.Message("Фишка перемещена");
                }
                else
                {
                    // если все четрые соседние клетки не пустые
                    Log.Message("Невозможно совершить перемещение. Рядом нет пустой клетки.");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(1, 2, 3, 4, 5, 6, 7, 8, 0); // создали экземпляр класса с полем 3*3

            game.Shift(0); // Попробуем переместить пустую клетку

            game.Shift(1); // Переместим фишку рядом с пустой (справа)
            game.Shift(1); // Еще раз переместим эту же фишку (слева)

            game.Shift(3); // Переместим фишку под пустой клетко (наверх)
            game.Shift(3); // Переместим еще раз эту же фишку (вниз)

            game.Shift(10); // Если фишки не существует

            game.Shift(8); // Рядом с фишкой нет пустой клетки

            Console.ReadLine();
        }
    }
}
