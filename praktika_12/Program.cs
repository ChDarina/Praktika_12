using System;
using System.Collections;

namespace praktika_12
{
    class Program
    {
        public static int count_compare = 0;
        public static int count_changed = 0;
        public static int[] IntCopy(int[] sourse, int sourse_index, int length)
        {
            int[] ans = new int[length];
            Array.Copy(sourse, sourse_index, ans, 0, length);
            return ans;
        }
        public static int[] RadixSorting(int[] arr, int range, int length)
        {
            ArrayList[] lists = new ArrayList[range];
            for (int i = 0; i < range; ++i)
                lists[i] = new ArrayList();
            for (int step = 0; step < length; ++step)
            {
                //распределение по спискам
                for (int i = 0; i < arr.Length; ++i)
                {
                    int temp = (arr[i] % (int)Math.Pow(range, step + 1)) /
                                                  (int)Math.Pow(range, step);
                    lists[temp].Add(arr[i]);
                    count_changed++;
                }
                //сборка
                int k = 0;
                for (int i = 0; i < range; ++i)
                {
                    for (int j = 0; j < lists[i].Count; ++j)
                    {
                        arr[k++] = (int)lists[i][j];
                    }
                }
                for (int i = 0; i < range; ++i)
                    lists[i].Clear();
            }
            return arr;
        }
        public static int[] MergeSort(int[] arr)
        {
            int[] ans = IntCopy(arr, 0, arr.Length);
            if (ans.Length > 1)
            {
                int index = ans.Length / 2;
                int[] arr1 = MergeSort(IntCopy(ans, 0, index));
                int[] arr2 = MergeSort(IntCopy(ans, index, ans.Length - index));

                int count1 = 0, count2 = 0, i = 0;
                for (i = 0; count1 != arr1.Length && count2 != arr2.Length; i++)
                {
                    if (arr1[count1] > arr2[count2]) ans[i] = arr2[count2++];
                    else ans[i] = arr1[count1++];
                    count_compare++;
                    count_changed++;
                }
                while (count1 != arr1.Length) { ans[i++] = arr1[count1++]; count_compare++; count_changed++; }
                while (count2 != arr2.Length) { ans[i++] = arr2[count2++]; count_compare++; count_changed++; }
            }
            return ans;
        }

        public static int[] StartMergeSort(int[] arr)
        {
            count_changed = 0;
            count_compare = 0;
            return MergeSort(arr);
        }
        public static int[] StartRadixSorting(int[] arr)
        {
            count_changed = 0;
            count_compare = 0;
            return RadixSorting(arr,10,1);
        }

        public static string ArrToString(int[] arr)
        {
            string str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                str += arr[i] + " ";
            }
            return str.Trim();
        }

        static void Main(string[] args)
        {
            int[] arr1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9};
            int[] arr2 = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] arr3 = new int[] { 4, 5, 1, 2, 6, 7, 9, 8, 3 };

            Console.WriteLine($"Упорядоченный по возрастанию массив: {ArrToString(arr1)}");
            Console.WriteLine($"Упорядоченный по убыванию массив: {ArrToString(arr2)}");
            Console.WriteLine($"Неупорядоченный массив: {ArrToString(arr3)}");

            Console.WriteLine($"\nУпорядоченный по возрастанию массив. Сортировка слияниями.\n{ArrToString(StartMergeSort(arr1))}\nКоличество пересылок: {count_changed}. Количество сравнений: {count_compare}");
            Console.WriteLine($"\nУпорядоченный по убыванию массив. Сортировка слияниями.\n{ArrToString(StartMergeSort(arr2))}\nКоличество пересылок: {count_changed}. Количество сравнений: {count_compare}");
            Console.WriteLine($"\nНеупорядоченный массив. Сортировка слияниями.\n{ArrToString(StartMergeSort(arr3))}\nКоличество пересылок: {count_changed}. Количество сравнений: {count_compare}");

            Console.WriteLine($"\nУпорядоченный по возрастанию массив. Поразрядная сортировка.\n{ArrToString(StartRadixSorting(arr1))}\nКоличество пересылок: {count_changed}. Количество сравнений: {count_compare}");
            Console.WriteLine($"\nУпорядоченный по убыванию массив. Поразрядная сортировка.\n{ArrToString(StartRadixSorting(arr2))}\nКоличество пересылок: {count_changed}. Количество сравнений: {count_compare}");
            Console.WriteLine($"\nНеупорядоченный массив. Поразрядная сортировка.\n{ArrToString(StartRadixSorting(arr3))}\nКоличество пересылок: {count_changed}. Количество сравнений: {count_compare}");

            Console.ReadKey();
        }
    }
}
