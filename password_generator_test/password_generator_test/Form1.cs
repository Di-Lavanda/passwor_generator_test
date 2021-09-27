using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace password_generator_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        private void button1_Click(object sender, EventArgs e) //основная функция в программе, можно вынести в отдельный блок, но пока работает через кнопку
        {
            Random rnd = new Random();
            
            string undercaseletters = "abcdefghijklmnopqrstuvwxyz"; //пароль не может быть пустым поэтому буквы нижнего регистра используются как основа
            char tempstr;   //временная переменная
            string result = ""; //результат
            int lenght = 0;     //длина пароля
            if (string.IsNullOrEmpty(textBoxLenght.Text))   //проверка не пустое ли поле с занчением длины
                MessageBox.Show("Введите длину");
            else
            {
                lenght = Convert.ToInt32(textBoxLenght.Text);
                for (int i = 1; i <= lenght; i++)   //основной цикл функции
                {
                    int a = rnd.Next(0, 25);
                    tempstr = undercaseletters[a];
                    result += tempstr;
                    if ((checkBox1.Checked) && (i < lenght)) //вторая проверка необходима для паролей нечетной длины
                    {
                        a = rnd.Next(0, 9);
                        result += numbersFunction(a);   //включает цифры в пароль
                        i++;
                    }
                    if ((checkBox2.Checked) && (i < lenght))
                    {
                        a = rnd.Next(0, 25);
                        result += uppercaseFunction(a); //включает заглавные буквы в пароль
                        i++;
                    }
                    if ((checkBox3.Checked) && (i < lenght))
                    {
                        a = rnd.Next(0, 9);
                        result += punctuationFunction(a);   //вкулючает знаки пукнтуации в пароль
                        i++;
                    }
                    if (!(string.IsNullOrEmpty(specSymboltextBox.Text)))
                    {
                        int lenghtSpecSymbol = (specSymboltextBox.Text).Length;
                        a = rnd.Next(0, lenghtSpecSymbol);
                        result += specSymbolFunction(a);    //включает спецсимволы в пароль
                        i++;
                    }
                }
                textBox3.Text = result;
            }
        }       //фнукции со словарями
        public char uppercaseFunction(int a)
        {           
            string uppercaseletters = "ABCDEFGHIJKLMNOPQRSTUVQXYZ";
            return uppercaseletters[a];
        }
        public char numbersFunction(int a)
        {
            string uppercaseletters = "0123456789";
            return uppercaseletters[a];
        }
        public char punctuationFunction(int a)
        {
            string uppercaseletters = ".,?!;:-()'";
            return uppercaseletters[a];
        }
        public char specSymbolFunction(int a)
        {
            string specSymbol = (specSymboltextBox.Text);
            return specSymbol[a];
        }
    }
}
