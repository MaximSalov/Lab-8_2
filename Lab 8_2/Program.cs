using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab8._2
{
    class Program
    {
        /* Программно создать файл и записать в него 10 случайных чисел.
         * Затем программно открыть созданный файл, рассчитать сумму чисел в нем, ответ вывести в консоль */
        static void Main(string[] args)
        {
            string path = "log.txt";
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            #region Запись данных в файл
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                int n = 10;
                Random random = new Random();
                int[] arrayWrite = new int[n];
                for (int i = 0; i < n; i++)
                {
                    arrayWrite[i] = random.Next(-50, 50);
                    sw.Write(arrayWrite[i] + " ");
                }
            }
            #endregion
            #region Чтение и обработка данных из файла
            using (StreamReader sr = new StreamReader(path))
            {
                double sum = 0;
                string[] arrayRead = sr.ReadToEnd().Split(' ');
                for (int i = 0; i < (arrayRead.Length - 1); i++)    
                {                                                   
                    Console.WriteLine(arrayRead[i]);                                  
                    sum += Convert.ToDouble(arrayRead[i]);          
                }
                Console.WriteLine("Сумма чисел = {0}", sum);
            }
            #endregion
            Console.WriteLine("Для завершения нажмите любую клавишу");
            Console.ReadKey();
        }
    }
}