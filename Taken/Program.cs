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

        public Game(string path) //будем передавать строку (path)
        {
            string[] lines = System.IO.File.ReadAllLines(path); 

            string[] array = lines[0].Split(','); //массив строк, каждое число - это строка

            if (!(Math.Sqrt(array.Length) % 1 == 0))
            {
                lenX = null;
                lenY = null;

                Log.Message("Задано некорректное поле для игры.");
            }
            else
            {
                lenX = lenY = (int)Math.Sqrt(array.Length); 

                Log.Message("Сторона игрового поля = " + lenX);

                area = new int[(int)lenX, (int)lenY]; // Инициализируем поле (задаем размеры)
                int k = 0;

                for (int i = 0; i < lenX; i++)
                {
                    for (int j = 0; j < lenY; j++)
                    {
                        area[i, j] = int.Parse(array[k]); //int.Parse - преобразует строчку в число

                        if (area[i, j] == 0)
                        {
                            zeroX = i;
                            zeroY = j;
                        }

                        k++;
                    }
                }
            }
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
            string PATH_TO_GAME = "C:\\Users\\acer\\Documents\\visual studio 2015\\Projects\\Taken\\Game.txt";
            Game game = new Game(PATH_TO_GAME); // создали экземпляр класса с полем 3*3

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
