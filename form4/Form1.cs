using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace form4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<City> citys = new List<City>();
        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text.Replace(" ", ""), out int rez))
            {
                int n = int.Parse(textBox1.Text.Replace(" ", ""));
                var sort = citys.Where(c => c.Population > n)
                                       .OrderBy(c => c.Name.Length)
                                       .ToList();

                listBox2.Items.Clear();
                foreach (City cit in sort)
                {
                    listBox2.Items.Add(cit.Name + " " + cit.Population);
                }
            }
            else MessageBox.Show("введите численность", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            if (File.Exists("file1.txt"))
            {
              
                string[] fromfile = File.ReadAllLines("file1.txt");
                foreach (string ff in fromfile)
                {
                    char num = ff.First(c => char.IsDigit(c));
                    string[] part = ff.Split(num);
                    string name = part[0];
                    string popul = num + part[1];
                    int population = int.Parse(popul.Replace(" ", ""));
                    citys.Add(new City(name, population));
                }
                var sort2 = citys.OrderBy(c => c.Name.Length);
                listBox1.Items.Clear();
                foreach (City cc in sort2)
                {
                    listBox1.Items.Add(cc.Name + " " + cc.Population);
                }
            }
            else MessageBox.Show("Файл не найден", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
