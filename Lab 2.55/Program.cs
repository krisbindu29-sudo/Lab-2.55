using System;

namespace Lab2_Task5
{
   
    class Program
    {
        
        static void ProcessAndPrintRowsWithZeros(int[,] matrix, int n, int m)
        {
           
            Console.WriteLine("РЕЗУЛЬТАТ ОБРОБКИ МАТРИЦІ:");
            Console.WriteLine("Рядки, що містять хоча б один нульовий елемент:");
          

            bool zeroFound = false; // Прапорець наявності хоча б одного нуля у всій матриці

            // Прохід по всіх рядках матриці (від 0 до n-1)
            for (int i = 0; i < n; i++)
            {
                bool hasZeroInRow = false; // Прапорець для поточного i-го рядка

                // Прохід по всіх стовпчиках поточного рядка (від 0 до m-1)
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        hasZeroInRow = true; // Знайшли нуль
                        break; // Далі перевіряти елементи цього рядка немає потреби
                    }
                }

                // Якщо в рядку знайдено нуль — виводимо його номер та всі елементи
                if (hasZeroInRow)
                {
                    zeroFound = true;
                    Console.Write($"Рядок №{i} (порядок {i + 1}): ");
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write($"{matrix[i, j],5} "); // Форматоване виведення
                    }
                    Console.WriteLine(); // Перехід на новий рядок
                }
            }

            // Якщо у матриці взагалі не було нулів
            if (!zeroFound)
            {
                Console.WriteLine("У даній матриці немає жодного рядка з нульовими елементами.");
            }
        }

        // Спосіб А: Заповнення матриці з клавіатури користувачем
        static void RunManualInputMode()
        {
            Console.WriteLine("\n--- СПОСІБ А: ВВЕДЕННЯ МАТРИЦІ З КЛАВІАТУРИ ---");

            Console.Write("Введіть кількість рядків n: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("\nПомилка! Кількість рядків має бути цілим додатним числом.");
                return;
            }

            Console.Write("Введіть кількість стовпчиків m: ");
            if (!int.TryParse(Console.ReadLine(), out int m) || m <= 0)
            {
                Console.WriteLine("\nПомилка! Кількість стовпчиків має бути цілим додатним числом.");
                return;
            }

            int[,] matrix = new int[n, m];

            Console.WriteLine($"\nВведіть елементи матриці розмірністю {n}x{m}:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    while (true)
                    {
                        Console.Write($"A[{i},{j}] = ");
                        if (int.TryParse(Console.ReadLine(), out matrix[i, j]))
                        {
                            break; // Введення коректне — переходимо далі
                        }
                        Console.WriteLine("\nНекоректне значення! Введіть ціле число.");
                    }
                }
            }

            // Друк введеної матриці для наочності
            Console.WriteLine("\nВведена матриця:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],5} ");
                }
                Console.WriteLine();
            }

            // Виклик загального методу обробки
            ProcessAndPrintRowsWithZeros(matrix, n, m);
        }

        // Спосіб Б: Заповнення матриці генератором випадкових чисел [-100; 100]
        static void RunRandomInputMode()
        {
            Console.WriteLine("\n--- СПОСІБ Б: ГЕНЕРАЦІЯ ВИПАДКОВИХ ЧИСЕЛ [-100; 100] ---");

            Console.Write("Введіть кількість рядків n: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("\nПомилка! Кількість рядків має бути цілим додатним числом.");
                return;
            }

            Console.Write("Введіть кількість стовпчиків m: ");
            if (!int.TryParse(Console.ReadLine(), out int m) || m <= 0)
            {
                Console.WriteLine("\nПомилка! Кількість стовпчиків має бути цілим додатним числом.");
                return;
            }

            int[,] matrix = new int[n, m];
            Random rnd = new Random();

            Console.WriteLine("\nЗгенерована матриця:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    // Генерація випадкового цілого числа від -100 до 100 включно
                    matrix[i, j] = rnd.Next(-100, 101);
                    Console.Write($"{matrix[i, j],5} ");
                }
                Console.WriteLine();
            }

            // Виклик загального методу обробки
            ProcessAndPrintRowsWithZeros(matrix, n, m);
        }

       
        static void Main(string[] args)
        {
            // Налаштування UTF-8 для української мови у консолі
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {

                Console.WriteLine(" ЗАВДАННЯ 5 ");
                
                Console.WriteLine("1 - Виконати способом А (введення з клавіатури)");
                Console.WriteLine("2 - Виконати способом Б (генератор випадкових чисел)");
                Console.WriteLine("0 - Вийти з програми");
                Console.Write("\nОберіть варіант виконання: ");

                string choice = Console.ReadLine();

                if (choice == "0")
                {
                    Console.WriteLine("\nЗавершення роботи програми.");
                    break;
                }
                else if (choice == "1")
                {
                    RunManualInputMode();
                }
                else if (choice == "2")
                {
                    RunRandomInputMode();
                }
                else
                {
                    Console.WriteLine("\nНевідома команда! Будь ласка, оберіть 1, 2 або 0.");
                }
            }
        }
    }
}