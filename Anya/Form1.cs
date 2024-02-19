using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Anya
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 100;
            if (progressBar1.Value == 100)
            {
                MessageBox.Show("Прогресс выполнен!");
            }
        }
        private void printDialog_PrinterSelected(object sender, EventArgs e)
        {

            PrinterSettings printerSettings = printDialog1.PrinterSettings;
            MessageBox.Show("Выбран принтер: " + printerSettings.PrinterName);
        }

        private void splitContainer1_SizeChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Размер SplitContainer изменился!");
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            MessageBox.Show("Граница SplitContainer перемещена!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Имя");
            dataTable.Columns.Add("Возраст");

            dataTable.Rows.Add("Анна", 25);
            dataTable.Rows.Add("Иван", 32);
            dataTable.Rows.Add("Мария", 19);

            dataGridView1.DataSource = dataTable; // присваиваем источник данных DataGridView
        }
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            // Получите графику для печати
            Graphics g = e.Graphics;

            // Определите шрифт и цвет для печатного текста
            Font font = new Font("Arial", 12);
            SolidBrush brush = new SolidBrush(Color.Black);

            // Определите текст для печати
            string text = "Пример текста для печати";

            // Определите местоположение для печати текста
            float x = 10;
            float y = 10;

            // Нарисуйте текст на печати
            g.DrawString(text, font, brush, x, y);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell selectedCell = dataGridView1[e.ColumnIndex, e.RowIndex];
            MessageBox.Show("Вы выбрали ячейку со значением: " + selectedCell.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(PrintPage);
                pd.Print();
            }
        }
    }
}
