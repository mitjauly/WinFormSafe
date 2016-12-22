using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Safe_WInForms
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
         
        }



        private void button2_Click(object sender, EventArgs e)
        {
            try // Если ведено целое значение - создаем новый сейф
            {
                int size = Convert.ToInt32(textBox1.Text);
                NewSafeWindow safe = new NewSafeWindow(size);
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат ввода размера сейфа");
            }
        }
    }
}
