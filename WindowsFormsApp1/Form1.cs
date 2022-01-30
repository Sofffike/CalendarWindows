using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;


namespace WindowsFormsApp1
{
   
    public partial class Form1 : Form
    {
        public int year;
        public int month;
    
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            dataGridView1.RowCount = 6;
            dataGridView1.ColumnCount = 7;

            dataGridView1.Columns[0].Name = ("Пн");
            dataGridView1.Columns[1].Name = ("Вт");
            dataGridView1.Columns[2].Name = ("Ср");
            dataGridView1.Columns[3].Name = ("Чт");
            dataGridView1.Columns[4].Name = ("Пт");
            dataGridView1.Columns[5].Name = ("Сб");
            dataGridView1.Columns[6].Name = ("Вс");

            dataGridView1.CellClick -= dataGridView1_CellClickmonth;
            dataGridView1.CellClick -= dataGridView1_CellClick2year;
          



            DateTime now = DateTime.Now;

            year = DateTime.Now.Year;
            month = DateTime.Now.Month;


            var startDate = new DateTime(year, month, 1);  //первый день месяца
            int sav = System.DateTime.DaysInMonth(startDate.Year, startDate.Month);  //кол-во дней в месяце, число

            startDate = startDate.AddMonths(1).AddDays(-1);   /// убавление дня
            int startDayOfWeek = (int)startDate.DayOfWeek;   // с какого дня недели

            monthbutton3.Text = startDate.AddMonths(0).ToString("MMMM");
            yearbutton5.Text = year.ToString();

            int today = now.Day;
         
           int m = 1;
            int helper = 0;
            for (int i = 0; i < 6; i++) /// i- неделя(строка)
            {

                for (int j = 0; j < 7; j++)   //j-день недели(столбец)
                {
                    if (helper == 0)
                    {
                        j = startDayOfWeek;
                        helper++;
                    }

                    if (m <= sav)
                    {

                        dataGridView1.Rows[i].Cells[j].Value = m;
                        m++;


                        if (m == today +1) 
                        {
                            dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[j];  //фокус на текущем
                        }
                    }

                    
                }
            }

        }


        private void subtractmonthbutton1_Click(object sender, EventArgs e)   // убавление месяца
        {
      
            dataGridView1.Rows.Clear();  //очистили
            dataGridView1.RowCount = 6;
            dataGridView1.ColumnCount = 7;
            dataGridView1.ClearSelection();
            DateTime now = DateTime.Now;

            if (month == 1)
            {
                year = year - 1;
                month = 12;
            }
            else { month = month - 1; }


            var startDate = new DateTime(year, month, 1);  //первый 
            startDate = startDate.AddDays(-1);
            monthbutton3.Text = startDate.AddMonths(1).ToString("MMMM");
            yearbutton5.Text = year.ToString();

            CompletionGrid();

        }

        private void addmonthbutton2_Click(object sender, EventArgs e)   //добавление месяца
        {
            dataGridView1.Rows.Clear();  //очистили
            dataGridView1.RowCount = 6;
            dataGridView1.ColumnCount = 7;
            dataGridView1.ClearSelection();
            DateTime now = DateTime.Now;

            if (month == 12)
            {
                year = year + 1;
                month = 1;

            }
            else { month = month + 1; }


            var startDate = new DateTime(year, month, 1);  //первый 
            startDate = startDate.AddDays(-1);
            monthbutton3.Text = startDate.AddMonths(1).ToString("MMMM");
            yearbutton5.Text =   year.ToString();

            CompletionGrid();
    
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");
            label2.Text = DateTime.Now.ToLongDateString();
           
        } 

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void monthbutton3_Click(object sender, EventArgs e)
        {
            dataGridView1.CellClick -= dataGridView1_CellClickmonth;
            dataGridView1.CellClick -= dataGridView1_CellClick2year;

            dataGridView1.CellClick += dataGridView1_CellClickmonth;


            dataGridView1.Rows.Clear();  //очистили
           dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowCount = 3;
            dataGridView1.ColumnCount = 4;
           dataGridView1.ClearSelection();

            dataGridView1.Rows[0].Cells[0].Value = ("Январь");
            dataGridView1.Rows[0].Cells[1].Value = ("Февраль");
            dataGridView1.Rows[0].Cells[2].Value = ("Март");
            dataGridView1.Rows[0].Cells[3].Value = ("Апрель");
            dataGridView1.Rows[1].Cells[0].Value = ("Май");
            dataGridView1.Rows[1].Cells[1].Value = ("Июнь");
            dataGridView1.Rows[1].Cells[2].Value = ("Июль");
            dataGridView1.Rows[1].Cells[3].Value = ("Август");
            dataGridView1.Rows[2].Cells[0].Value = ("Сентябрь");
            dataGridView1.Rows[2].Cells[1].Value = ("Октябрь");
            dataGridView1.Rows[2].Cells[2].Value = ("Ноябрь");
            dataGridView1.Rows[2].Cells[3].Value = ("Декабрь");
           

          // button3_Click + = new EventHandler( dataGridView1_CellContentClick);
         }

        private void yearbutton5_Click(object sender, EventArgs e)
        {
            dataGridView1.CellClick -= dataGridView1_CellClickmonth;
            dataGridView1.CellClick -= dataGridView1_CellClick2year;
            dataGridView1.CellClick += dataGridView1_CellClick2year;


            dataGridView1.Rows.Clear();  //очистили
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowCount = 20;
            dataGridView1.ColumnCount = 5;
            dataGridView1.ClearSelection();  //-фокус

            DateTime now = DateTime.Now;
            int m2 = 1971;
            int helper2 = 2071;
            int Year = now.Year;

            for (int i = 0; i < 20; i++) /// i- неделя(строка)
            {
                for (int j = 0; j < 5; j++)   //j-день недели(столбец)
                {

                    if (m2 <= helper2)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = m2;
                        m2++;
                    }
                    if (m2 == Year + 1)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[j];// ---текущий год 
                    }
                }
            }



        }
        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
          
        }

        private void CompletionGrid() 
        {
            var startDate = new DateTime(year, month, 1);  //первый 
            startDate = startDate.AddDays(-1);
            int startWeek = (int)startDate.DayOfWeek;
            int sav2 = DateTime.DaysInMonth(year, month); //перескакиваю на следующий месяц и узнаю кол-во дней


            int m = 1;
            int helper = 0;
            for (int i = 0; i < 6; i++) /// i- неделя(строка)
            {

                for (int j = 0; j < 7; j++)   //j-день недели(столбец)
                {
                    if (helper == 0)
                    {
                        j = startWeek;
                        helper++;
                    }

                    if (m <= sav2)
                    {

                        dataGridView1.Rows[i].Cells[j].Value = m;
                        m++;
                    }
                }
            }
            //////////////////////////////////////////////////////////
            dataGridView1.CellClick -= dataGridView1_CellClickmonth;
            dataGridView1.CellClick -= dataGridView1_CellClick2year;
        }

        private void CompletionGridforSwith()
        {
             dataGridView1.Rows.Clear();  //очистили
         
            dataGridView1.RowCount = 6;
            dataGridView1.ColumnCount = 7;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.Columns[0].Name = ("Пн");
            dataGridView1.Columns[1].Name = ("Вт");
            dataGridView1.Columns[2].Name = ("Ср");
            dataGridView1.Columns[3].Name = ("Чт");
            dataGridView1.Columns[4].Name = ("Пт");
            dataGridView1.Columns[5].Name = ("Сб");
            dataGridView1.Columns[6].Name = ("Вс");
           dataGridView1.ClearSelection(); // -фокус

            DateTime now = DateTime.Now;
            CompletionGrid();
            var startDate = new DateTime(year, month, 1);  //
            monthbutton3.Text = startDate.AddMonths(0).ToString("MMMM");
            yearbutton5.Text = year.ToString();
            ///////////////////////////////////////////////////////
            dataGridView1.CellClick -= dataGridView1_CellClickmonth;
            dataGridView1.CellClick -= dataGridView1_CellClick2year;
        }

        private void dataGridView1_CellClickmonth(object sender, DataGridViewCellEventArgs e)
        {
            // для кнопки месяца

            switch (dataGridView1.CurrentCell.Value.ToString())
            {
                case ("Январь"):
                    month = 1;
                    CompletionGridforSwith();
                    break;
                case ("Февраль"):
                    month = 2;
                    CompletionGridforSwith();
                    break;
                case ("Март"):
                    month = 3;
                    CompletionGridforSwith();
                    break;
                case ("Апрель"):
                    month = 4;
                    CompletionGridforSwith();
                    break;
                case ("Май"):
                    month = 5;
                    CompletionGridforSwith();
                    break;
                case ("Июнь"):
                    month = 6;
                    CompletionGridforSwith();
                    break;
                case ("Июль"):
                    month = 7;
                    CompletionGridforSwith();
                    break;
                case ("Август"):
                    month = 8;
                    CompletionGridforSwith();
                    break;
                case ("Сентябрь"):
                    month = 9;
                    CompletionGridforSwith();
                    break;
                case ("Октябрь"):
                    month = 10;
                    CompletionGridforSwith();
                    break;
                case ("Ноябрь"):
                    month = 11;
                    CompletionGridforSwith();
                    break;
                case ("Декабрь"):
                    month = 12;
                    CompletionGridforSwith();
                    break;
            }
        }

        private void dataGridView1_CellClick2year(object sender, DataGridViewCellEventArgs e)
        {
            /////////////для кнопки выбора года
            if (Int32.Parse(dataGridView1.CurrentCell.Value.ToString()) != year)
            {
                year = Int32.Parse(dataGridView1.CurrentCell.Value.ToString());

              
                monthbutton3_Click(sender, e);
             


            }

        }
    }
    }


