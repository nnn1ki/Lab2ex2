using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecondLab2ex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //ввод переменных от пользователя
                string first = this.textFirst.Text;
                string second = this.textSecond.Text;
                
                Logic ans = new Logic(first, second);

                this.labelAnswer.Text = "Ответ: " + ans.search();
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный ввод", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }

        //TODO 
        //отремонтировать ввод через энтер

        private void Form1_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
    }

    public class Logic
    {

        private string first;
        private string second;

        public Logic(string ln1, string ln2)
        {
            first = ln1;
            second = ln2;

            first = deleteSimilar(first);
            second = deleteSimilar(second);
        }


        private string deleteSimilar(string line)
        {
            string ans = "";

            for (int i = 0; i < line.Length; i++)
            {
                bool inLine = false;

                for (int j = i + 1; j < line.Length; j++)
                {
                    if (line[i] == line[j])
                    {
                        inLine = true;
                        break;
                    }
                }

                if (inLine == false)
                {
                    ans += line[i];
                }
            }

            return ans;
        }

        public string search()
        {
            string ans = "";

            for (int i = 0; i < first.Length; i++)
            {
                bool included = false;

                for (int j = 0; j < second.Length; j++)
                {
                    if (first[i] == second[j])
                    {
                        included = true;
                        break;
                    }
                }

                ans += check(included);
            }

            return ans;
        }

        public string check(bool expression)
        {
            if (expression) return "да ";
            else return "нет ";
        }

    }


}
