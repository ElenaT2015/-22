using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_22
{
    class Program
    {
        static void arraysumm1(object a)
        {
            int[] array = (int[])a;
            int s = 0;
            Console.WriteLine(" Метод 1.  Определение суммы чисел массива - начал работу");
            for (int i = 0; i < array.Length; i++)
            {
                s += array[i];
            }
            Console.WriteLine(" Сумма массива = {0}", s);
            Console.WriteLine(" Метод 1.  Закончил работу");
        }

        static void arraymax2(Task task, object a)
        {
            int[] array = (int[])a;
            int max = 0;
            Console.WriteLine(" Метод 2.  Определение max числа массива - начал работу");
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            Console.WriteLine(" Мax число массива = {0}", max);
            Console.WriteLine(" Метод 2.  Закончил работу");
        }
        static void Main(string[] args)
        {
            Console.WriteLine(" Введите размерность массива с целыми числами");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            Random random = new Random();
            Console.WriteLine(" Сформирован массив случайных чисел");
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 50);
                Console.Write(" {0,4} ", array[i]);
            }

            Action<object> action = new Action<object>(arraysumm1);
            Task task = new Task(action, array);

            Action<Task, object> actionTask = new Action<Task, object>(arraymax2);
            Task task1 = task.ContinueWith(actionTask, array);

            task.Start();

            Console.WriteLine();
            Console.WriteLine(" Метод Main  - закончил работу");
            Console.ReadKey();
        }
    }
}
