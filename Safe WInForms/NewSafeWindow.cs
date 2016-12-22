using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mySafe;

namespace Safe_WInForms
{
     class NewSafeWindow:IDisposable
    {
        private Button[,] arrButton;
        private Form frm1;
        private int safeSize=0;
        private Safe safe;
       
        public NewSafeWindow(int iSze) // Создание нового сейфа
        {
            safeSize = iSze;
            frm1 = new Form(); // Создание формы
            frm1.Height = safeSize * 35 + 58;
            frm1.Width = safeSize * 35 + 35;
            frm1.BackColor = Color.White;
            frm1.Show();
            
            arrButton = new Button[safeSize,safeSize]; //Создание массива кнопок
            safe = new Safe(safeSize); 
            for (int i=0;i<safeSize; i++) 
                for (int j=0;j<safeSize;j++)
            {
                    arrButton[i, j] = new Button();
                    arrButton[i, j].Width = 35;
                    arrButton[i, j].Height = 35;
                    arrButton[i, j].Left = 10+35 * i;
                    arrButton[i, j].Top = 10+35 * j;
                    arrButton[i, j].Click += Safe_Click;
                    arrButton[i, j].Name = i + ":" + j;
                    arrButton[i, j].FlatStyle=FlatStyle.Flat;
                    arrButton[i, j].FlatAppearance.BorderSize = 0;
                    frm1.Controls.Add(arrButton[i, j]);
                    safe.safeArr[i, j] = false;
                }
            safe.Generate(); //Задаем начальное положение переключателей
            DrawSafe();
        }

        private void Safe_Click(object sender, EventArgs e) //Обработка нажатия на рычаг
        {
            string[] s = (sender as Button).Name.Split(new char[] { ':' });
            safe.SwitchLever(int.Parse(s[0]), int.Parse(s[1]));
            DrawSafe();
            if (safe.Check())
            { MessageBox.Show("Сейф открыт за "+safe.iIntr+" ходов !");
                Dispose();
            }
        }

        private void DrawSafe() // Вывод сейфа на форму 
        {
            for (int i = 0; i < safeSize; i++)
                for (int j = 0; j < safeSize; j++)
                    if (safe.safeArr[i, j])
                        arrButton[i, j].Image = Properties.Resources.on;
                    else
                        arrButton[i, j].Image = Properties.Resources.off;
                           
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                frm1.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
