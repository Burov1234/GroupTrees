﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Практика
{
    public partial class Form1 : Form
    {
        public string filename;
        public string[] myfile;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = Convert.ToString(myfile.Length);
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog() { Filter = "Текстовые файлы(*.txt)|*.txt" };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                myfile = File.ReadAllLines(filename);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int[] arr;
            arr = Funck(10);
        }
        public static int[] Funck(int N) //функцию для подсчета времени 
        {
            int[] Arr = new int[N]; // создаем массив под значения времени 
            for (int j = 0; j < N; j++) // пускаем цикл 
            {
                System.Diagnostics.Stopwatch watch; // объявляем метод 
                long elapsedMs; // объявляем переменную 
                watch = System.Diagnostics.Stopwatch.StartNew(); // запускаем таймер 
                var obj = new DictionaryTree();
                string input_text = System.IO.File.ReadAllText(@"big.txt");
                string str = "";
                foreach (var i in input_text)
                {
                    if (i >= 'a' && i <= 'z' || i >= 'A' && i <= 'Z' || i == '\'')
                        str += i;
                    else if (str.Length > 0)
                    {
                        if (obj.ContainsKey(str))
                            ++obj[str];
                        else
                            obj.Add(str, 1);
                        str = "";
                    }
                }
                watch.Stop(); // останавливаем таймер 
                elapsedMs = watch.ElapsedMilliseconds; // присваиваем значение времени 
                Arr[j] = (int)elapsedMs; // добавляем в массив

            }
            return Arr; // возвращаем массив
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var obj = new DictionaryTree(); // создаем объект класса 
            string input_text = System.IO.File.ReadAllText(@"big.txt"); // 
            string str = ""; // создаем пустую строку
            foreach (var i in input_text) // перебираем файл по буквам 
            {
                if (i >= 'a' && i <= 'z' || i >= 'A' && i <= 'Z' || i == '\'') // проверяем входит ли i в диапазон символов
                    str += i; // добавляем символ в строку 
                else if (str.Length > 0) // если строка не пустая 
                {
                    if (obj.ContainsKey(str)) // проверяем есть ли слово в списке дочерних узлов 
                        ++obj[str]; // добавляем слово в список
                    else
                        obj.Add(str, 1); // добавляем слово в список
                    str = ""; // обнуляем строку
                }
            }
            label2.Text = Convert.ToString(obj.InternalNodeCount);
        }
    }
}
