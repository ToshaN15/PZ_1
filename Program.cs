using System;
using System.Collections;
using System.Diagnostics;

namespace PZ_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = new int[10001];               //Создание массива
            Random rnd = new Random();
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = rnd.Next(15000);
            }


            TimingAlg objT = new TimingAlg();
            Stopwatch stpWatch = new Stopwatch();
            objT.StartTime();                           //Задание 1
            stpWatch.Start();                           //StopWatch: 00:00:00.0005853 
            SortInsertion(myArray);                     //Timing: 00:00:00
            stpWatch.Stop();
            objT.StopTime();
            Console.WriteLine("Сортировка вставками");
            Console.WriteLine("StopWatch: " + stpWatch.Elapsed.ToString());
            Console.WriteLine("Timing: " + objT.Result().ToString());

            objT.StartTime();
            stpWatch.Start();                           //StopWatch: 00:00:00.8857159 
            BubleSort(myArray);                         //Timing: 00:00:00.0156250    
            stpWatch.Stop();
            objT.StopTime();
            Console.WriteLine("Сортировка простым обменом");
            Console.WriteLine("StopWatch: " + stpWatch.Elapsed.ToString());
            Console.WriteLine("Timing: " + objT.Result().ToString());

            objT.StartTime();
            stpWatch.Start();                           //StopWatch: 00:00:00.8884120
            SortBinInsert(myArray);                     //Timing: 00:00:00.0156250
            stpWatch.Stop();
            objT.StopTime();
            Console.WriteLine("Сортировка бинарными включениями");
            Console.WriteLine("StopWatch: " + stpWatch.Elapsed.ToString());
            Console.WriteLine("Timing: " + objT.Result().ToString());

            objT.StartTime();                           //Задание 2
            stpWatch.Start();                           //StopWatch: 00:00:00.8889268 
            SimpleSearch(myArray, 13);                  //Timing: 00:00:00.0156250 
            stpWatch.Stop();
            objT.StopTime();
            Console.WriteLine("Прямой поиск");
            Console.WriteLine("StopWatch: " + stpWatch.Elapsed.ToString());
            Console.WriteLine("Timing: " + objT.Result().ToString());

            objT.StartTime();
            stpWatch.Start();                           //StopWatch: 00:00:00.8893733 
            SearchBinary(myArray, 15);                  //Timing: 00:00:00.0156250
            stpWatch.Stop();
            objT.StopTime();
            Console.WriteLine("Поиск бинарный");
            Console.WriteLine("StopWatch: " + stpWatch.Elapsed.ToString());
            Console.WriteLine("Timing: " + objT.Result().ToString());

            Hashtable myHashtable = new Hashtable();    //Задание 3
            for (int i = 0; i < 10000; i++)             //Заполнение таблицы значениями
            {               
                myHashtable.Add("Число" + (i+1), rnd.Next(15000));
            }
            objT.StartTime();
            stpWatch.Start();                           //StopWatch: 00:00:00.8639424 
            int myValue = 8512;                         //Timing: 00:00:00.0312500
            Console.WriteLine("The value \"{0}\" is {1}.", myValue, myHashtable.ContainsValue(myValue) ? "in the Hashtable" : "NOT in the Hashtable");
            stpWatch.Stop();
            objT.StopTime();
            Console.WriteLine("Поиск элемента");
            Console.WriteLine("StopWatch: " + stpWatch.Elapsed.ToString());
            Console.WriteLine("Timing: " + objT.Result().ToString());         
        }


        static public void SortInsertion(int[] myArray)       //Сортировка вставками      
        {
            int tmp = myArray[0];
            int N = myArray.Length;
            for (int i = 1; i < N; i++)
            {
                int j = i - 1;
                while (j >= 0 & tmp < myArray[j])
                    myArray[j + 1] = myArray[j--];
                myArray[j + 1] = tmp;
            }

        }
        static public void BubleSort(int[] a)                   //Сортировка простым обменом 
        {
            int N = a.Length;
            for (int i = 1; i < N; i++)
                for (int j = N - 1; j >= i; j--)
                    if (a[j - 1] > a[j])
                    {
                        int t = a[j - 1];
                        a[j - 1] = a[j];
                        a[j] = t;
                    }

        }
        static public void SortBinInsert(int[] a)               //Сортировка бинарными включениями
        {
            int N = a.Length;
            for (int i = 1; i <= N - 1; i++)
            {
                int tmp = a[i], left = 1, right = i - 1;
                while (left <= right)
                {
                    int m = (left + right) / 2;
                    //определение индекса среднего элемента
                    if (tmp < a[m])
                        right = m - 1; // сдвиг правой или
                    else left = m + 1; // левой границы
                }

                for (int j = i - 1; j >= left; j--)
                    a[j + 1] = a[j]; // сдвиг элементов
                                     // размещение элемента в нужном месте
                a[left] = tmp;
            }
        }
        static int SimpleSearch(int[] a, int x)                 //Простой поиск
        {
            int i = 0;
            // с проверкой выхода за границу массива 
            while (i < a.Length && a[i] != x)
                i++;
            if (i < a.Length)
            // если элемент найден, возвращаем его индекс
                return i;
            else
            // если элемент не найден, возвращаем -1
                return -1;
        }
        static int SearchBinary(int[] a, int x)                 //Бинарный поиск
        {
            int middle, left = 0, right = a.Length - 1;
            do
            {
                middle = (left + right) / 2;
                if (x > a[middle])
                    left = middle + 1;
                else
                    right = middle - 1;
            }
            while ((a[middle] != x) && (left <= right)); 
                if (a[middle] == x)
                    return middle;
                else
                    return -1;
        }
    }
}
