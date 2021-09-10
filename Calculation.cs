using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class calculation
    {
        string readPath; //Путь читаемого файла
        string savingPath; //Путь файла, в который идёт запись
        int[,] matrix; //Матрица
        int count = 0; //Количество подходящих чисел
        List<int> neededNums = new List<int>(); //Список подходящих чисел

        public calculation(string readPath, string savingPath) //Конструктор класса
        {
            this.readPath = readPath;
            this.savingPath = savingPath;
        }

        void moving() 
        {  
            foreach(int num in matrix)
            {
                if(numsum(num) == true)
                {
                    count++;
                    neededNums.Add(num);
                }
            }
        }

        bool numsum(int num) 
        {
            int sum = 0, origNum = num;
            bool result = false;
            while (num > 0)
            {
                sum = sum + Convert.ToInt32(Math.Pow(num % 10,3));
                num = num / 10;
            }

            if (sum == origNum) result = true;

            return result;
        }

        public void classs() //Метод, вызывающий функционал класса, а также чтение и запись
        {
            writeread.ReadData(readPath, ref matrix);
            moving();
            writeread.WriteToFile(savingPath, neededNums, count);
        }
    }

}
