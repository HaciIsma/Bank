using System;

namespace ATM
{
    public class DataBaseManager
    {
        public void AddDataForBase(string dataForBase)
        {
            string[] temp = new string[++size];
            if (datas != null)
            {
                for (int i = 0; i < size - 1; i++)
                {
                    temp[i] = datas[i];
                }
            }
            temp[size - 1] = DateTime.Now.ToString() + " --> " + dataForBase;
            datas = temp;
        }
        public void ShowAllData()
        {
            if (datas == null)
            {
                Console.WriteLine("Hec bir emeliyyat edilmeyib");
                return;
            }
            foreach (var data in datas)
            {
                Console.WriteLine(data);
            }
        }
        string[] datas = null;
        int size = 0;
    }
}