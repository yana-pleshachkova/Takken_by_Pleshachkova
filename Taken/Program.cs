using System;
using System.Collections.Generic;

namespace Taken
{
    class Program
    {
        static void Main(string[] args)
        {
            string PATH_TO_GAME = "C:\\Users\\acer\\Documents\\visual studio 2015\\Projects\\Taken\\Game.txt";
            Game game = new Game(PATH_TO_GAME); // создали экземпляр класса с полем 3*3

            game.Shift(0); // Попробуем переместить пустую клетку

            game.Shift(8); // Переместим фишку рядом с пустой (справа)
            game.Shift(8); // Еще раз переместим эту же фишку (слева)

            game.Shift(6); // Переместим фишку над пустой клетко (наверх)
            game.Shift(6); // Переместим еще раз эту же фишку (вниз)

            game.Shift(10); // Если фишки не существует

            game.Shift(1); // Рядом с фишкой нет пустой клетки

            Console.ReadLine();

            //================== Проверяем Game 2
            Game2 game2 = new Game2(PATH_TO_GAME); // Создаем новую игру

            for (int i = 0; i < game2.Len; i++) // Выводим на консоль исходную последовательность
            {
                for (int j = 0; j < game2.Len; j++)
                {
                    Console.Write(game2.Area[i, j] + " ");
                }
            }

            Console.WriteLine();
            Console.WriteLine(game2.IsEndGame()); // Проверяем, что позиция выйгрышная - True

            game2.RandomizeStartArea(); // Рандомизируем последовательность
            Console.WriteLine();

            for (int i = 0; i < game2.Len; i++) // Выводим на консоль рандомизированную последовательность
            {
                for (int j = 0; j < game2.Len; j++)
                {
                    Console.Write(game2.Area[i, j] + " ");
                }
            }

            Console.WriteLine();
            Console.WriteLine(game2.IsEndGame()); // Проверяем, что позиция выйгрышная - False

            Console.ReadLine();

            //================== Проверяем Game 3
            Game3 game3 = new Game3(PATH_TO_GAME); // Создаем новую игру

            for (int i = 0; i < game3.Len; i++) // Выводим на консоль исходную последовательность
            {
                for (int j = 0; j < game3.Len; j++)
                {
                    Console.Write(game3.Area[i, j] + " ");
                }
            }

            Console.WriteLine();
            Console.WriteLine(game3.IsEndGame()); // Проверяем, что позиция выйгрышная - True и работает наследование 

            game3.Shift(0); // Попробуем переместить пустую клетку

            game3.Shift(8); // Переместим фишку рядом с пустой (слева)
            game3.Shift(8); // Еще раз переместим эту же фишку (справа)

            game3.Shift(6); // Переместим фишку над пустой клетко (наверх)
            game3.Shift(6); // Переместим еще раз эту же фишку (вниз)

            game3.Shift(10); // Если фишки не существует

            game3.Shift(1); // Рядом с фишкой нет пустой клетки

            Console.WriteLine();
            game3.PrintLogActions();

            Console.ReadLine();
        }
    }
}
