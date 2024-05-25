using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Лаба_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ans; // номер действия, которое выбирает пользователь
            int[] arr = new int[0]; // основной массив
            do
            {
                bool isConvertAns;
                Console.WriteLine("1) Сформировать массив самостоятельно");
                Console.WriteLine("2) Сформировать массив при помощи ДСЧ");
                Console.WriteLine("3) Распечатать массив");
                Console.WriteLine("4) Удалить минимальный элемент массива");
                Console.WriteLine("5) Переставить K элементов в конец массива");
                Console.WriteLine("6) Циклически сдвинуть массив на М клеток вправо");
                Console.WriteLine("7) Найти первый отрицательный элемент в массиве и посчитать, сколько нужно было сделать сравнений, чтобы его найти");
                Console.WriteLine("8) Выполнить сортировку массива простым выбором");
                Console.WriteLine("9) Выполнить поиск элемента, который вводит пользователь с клавиатуры, в отсортированном массиве и подсчитать количество сравнений, необходимых для поиска нужного элемента.");
                Console.WriteLine("10) Гномья сортировка)");
                Console.WriteLine("11) Выход");
                do
                {
                    isConvertAns = int.TryParse(Console.ReadLine(), out ans);
                    if (!isConvertAns)
                    {
                        Console.WriteLine("Неправильно введено число, \nпопробуйте ещё раз");
                    }
                } while (!isConvertAns);
                switch (ans)
                {
                    case 1: //формирование массива вручную
                        {

                            int len;
                            int element;
                            bool isLenCorrest;
                            bool isElCorrect;
                            Console.WriteLine("Введите длину массива:");
                            do
                            {
                                isLenCorrest = int.TryParse(Console.ReadLine(), out len);
                                if (!isLenCorrest | len < 0)
                                {
                                    Console.WriteLine("Введите, пожалуйста, положительное число (длину):");
                                }
                            } while (!isLenCorrest | len < 0);
                            arr = new int[len];
                            for (int i = 0; i < len; i++)
                            {
                                do
                                {
                                    Console.WriteLine($"Введите элемент массива {i + 1}: ");
                                    isElCorrect = int.TryParse(Console.ReadLine(), out element);
                                    if (!isElCorrect)
                                    {

                                        Console.WriteLine("Введите корректный элемент последовательности:");
                                    }
                                } while (!isElCorrect);
                                arr[i] = element;
                            }
                            Console.WriteLine("Массив сформирован");
                            break;
                        }
                    case 2: //формирование массива при помощи ДСЧ
                        {
                            int len;
                            bool isLenCorrest;
                            Console.WriteLine("Введите длину массива:");
                            do
                            {
                                isLenCorrest = int.TryParse(Console.ReadLine(), out len);
                                if (!isLenCorrest | len <= 0)
                                {
                                    Console.WriteLine("Введите, пожалуйста, положительное число (длину):");
                                }
                            } while (!isLenCorrest | len <= 0);

                            Random rnd = new Random();
                            int[] temp = new int[len];
                            for (int i = 0; i < len; i++)
                            {
                                temp[i] = rnd.Next(-100, 100);
                            }
                            Console.WriteLine("Массив сформирован");
                            arr = temp;
                            break;
                        }
                    case 3: //печать массива
                        {
                            if (arr.Length == 0)
                            {
                                Console.WriteLine("Массив пуст");
                                break;
                            }
                            foreach (int item in arr)
                                Console.Write($"{item} ");
                            Console.WriteLine();
                            break;
                        }
                    case 4: //удаление минимального элемента
                        {
                            if (arr.Length == 0)
                            {
                                Console.WriteLine("Массив пуст");
                                break;
                            }
                            int j = 0; //индекс минимального элемента
                            int l = 0; //счётчик в temp
                            int min = 1000; //значение минимума
                            int[] temp = new int[arr.Length - 1];
                            for (int i = 0; i < arr.Length; i++)
                                if (arr[i] < min)
                                {
                                    min = arr[i];
                                }
                            for (int i = 0; i < arr.Length; i++)
                            {
                                if (arr[i] == min)
                                {
                                    j = i; break;
                                }
                            }
                            for (int i = 0; i < arr.Length; i++)
                            {
                                if (i != j)
                                {
                                    temp[l] = arr[i];
                                    l++;
                                }
                            }
                            arr = temp;
                            Console.WriteLine($"Минимальный элемент удалён");
                            break;
                        }
                    case 5: //добавление элементов в массив
                        {
                            if (arr.Length == 0)
                            {
                                Console.WriteLine("Массив пуст");
                                break;
                            }
                            int count; //добавляемое количество элементов 
                            int element;
                            bool isCountCorrect;
                            bool isElCorrect;
                            int[] temp = new int[0]; //вспомогательный массив
                            if (arr.Length == 0)
                            {
                                Console.WriteLine("Массив пуст");
                                break;
                            }
                            Console.WriteLine("Введите К (количество элементов, которое хотите добавить):");
                            do
                            {
                                isCountCorrect = int.TryParse(Console.ReadLine(), out count);
                                if (!isCountCorrect | count < 0)
                                {
                                    Console.WriteLine("Введите, пожалуйста, целое положительное число (количество элементов):");
                                }
                            } while (!isCountCorrect | count < 0);
                            temp = new int[count];
                            for (int i = 0; i < count; i++)
                            {
                                do
                                {
                                    Console.WriteLine($"Введите элемент массива {i + 1}: ");
                                    isElCorrect = int.TryParse(Console.ReadLine(), out element);
                                    if (!isElCorrect)
                                    {

                                        Console.WriteLine("Введите корректный элемент последовательности:");
                                    }
                                } while (!isElCorrect);
                                temp[i] = element;
                            }
                            arr = arr.Concat(temp).ToArray(); //добавление чисел в конец массива 
                            Console.WriteLine("Добавление произошло");
                            break;
                        }
                    case 6://сдвиг циклически на М элементов
                        {
                            int l = 0;
                            int j = arr.Length - 1; //индекс последнего элемента
                            int[] temp = new int[arr.Length - 1];
                            if (arr.Length == 0)
                            {
                                Console.WriteLine("Массив пуст");
                                break;
                            }
                            int num; //количество элементов, на которое циклически сдвигается массив
                            bool isNumCorrect;
                            Console.WriteLine("Введите количство элементов, на которое хотите сдвинуть массив:");
                            do
                            {
                                isNumCorrect = int.TryParse(Console.ReadLine(), out num);
                                if (!isNumCorrect | num < 0 | num > arr.Length)
                                {
                                    Console.WriteLine($"Введите, пожалуйста, положительное целое число (количество элементов), меньше или равно: {arr.Length} (длине массива):");
                                }
                            } while (!isNumCorrect | num < 0 | num > arr.Length);
                            for (int t = 0; t < num; t++)
                            {
                                int[] p = new int[1] { arr[arr.Length - 1] }; //массив из последнего элемента
                                for (int i = 0; i < (arr.Length - 1); i++)
                                {
                                    temp[i] = arr[i];
                                }
                                arr = p.Concat(temp).ToArray();
                            }
                            Console.WriteLine("Массив сдвинут");
                            break;
                        }
                    case 7: //поиск первого отрицательного элемента
                        {
                            if (arr.Length == 0)
                            {
                                Console.WriteLine("Массив пуст");
                                break;
                            }
                            int count = 0;
                            int index = -1;
                            for (int i = 0; i < arr.Length; i++)
                            {
                                if (arr[i] < 0)
                                {
                                    index = i;
                                    break;
                                }
                                count++;
                            }
                            if (index < 0)
                            {
                                Console.WriteLine("Отрицательных элементов в массиве нет");
                            }
                            else
                            {
                                Console.WriteLine($"Первое отрицательное число находится в массиве под номером: {index + 1}");
                                Console.WriteLine($"Количество сравнений: {count + 1}");
                            }
                            break;
                        }
                    case 8: //сортировка массива простым выбором
                        {
                            if (arr.Length == 0)
                            {
                                Console.WriteLine("Массив пуст");
                                break;
                            }
                            int min; //индекс минимального числа
                            int temp; //вспомогательная переменная 
                            for (int i = 0; i < arr.Length; i++)
                            {
                                min = i;
                                for (int j = i + 1; j < arr.Length; j++)
                                {
                                    if (arr[j] < arr[min])
                                    {
                                        min = j;
                                    }
                                }
                                temp = arr[min];
                                arr[min] = arr[i];
                                arr[i] = temp;
                            }
                            Console.WriteLine("Сортировка массива простым выбором выполнена");
                            break;
                        }
                    case 9: //поиск элемента в массиве
                        {
                            if (arr.Length == 0)
                            {
                                Console.WriteLine("Массив пуст");
                                break;
                            }
                            int min; //сортировка массива
                            int temp;
                            for (int i = 0; i < arr.Length; i++)
                            {
                                min = i;
                                for (int j = i + 1; j < arr.Length; j++)
                                {
                                    if (arr[j] < arr[min])
                                    {
                                        min = j;
                                    }
                                }
                                temp = arr[min];
                                arr[min] = arr[i];
                                arr[i] = temp;
                            }
                            int left = 0; //индекс нижней границы массива
                            int mid = 0; //индекс элемента в середине массива
                            int right = arr.Length - 1; //индекс верхней границы массива
                            int find; //перменная, которую надо найти
                            int count = 0; //счётчик количества операций
                            bool isItemCorrect;
                            Console.WriteLine("Введите элемент, который хотите найти в массиве");
                            do
                            {
                                isItemCorrect = int.TryParse(Console.ReadLine(), out find);
                                if (!isItemCorrect | find > arr[arr.Length - 1] | find < arr[0])
                                {
                                    Console.WriteLine($"Введите, пожалуйста, число. Оно должно быть >= {arr[0]} и <= {arr[arr.Length - 1]}");
                                }
                            } while (!isItemCorrect | find > arr[arr.Length - 1] | find < arr[0]);
                            do
                            {
                                mid = (left + right) / 2;
                                if (arr[mid] < find) left = mid + 1;
                                else right = mid;
                                count++;
                            } while (left != right);
                            if (arr[left] == find)
                            {
                                Console.WriteLine($"Номер элемента {find} равен: {left + 1}");
                                Console.WriteLine($"Количество операций: {count}");
                            }
                            else Console.WriteLine("Элемент не найден");
                            break;
                        }
                    case 10:
                        {
                            int index = 1;
                            int temp = 0;
                            int nextindex = index + 1; //индекс, на котором оборвалась сортировка в процессе
                            while (index < arr.Length)
                            {
                                if (arr[index - 1] < arr[index])
                                {
                                    index = nextindex;
                                    nextindex++;
                                }
                                else
                                {
                                    temp = arr[index - 1]; 
                                    arr[index - 1] = arr[index]; 
                                    arr[index] = temp; 
                                    index--;
                                    if (index == 0)
                                    {
                                        index = nextindex;
                                        nextindex++;
                                    }
                                }
                            }
                            Console.WriteLine("Гномы отсортировали массив!");
                            break;
                        }
                    case 11: //конец работы
                        {
                            Console.WriteLine("Работа завершена");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Неправильно задан пункт меню");
                            break;
                        }
                }
            } while (ans != 11);
        }
    }
}

       