using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;
using DataGrid = System.Windows.Controls.DataGrid;
using System.Diagnostics;
using TextBox = System.Windows.Controls.TextBox;
using Application = System.Windows.Application;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data;
using DataTable = Microsoft.Office.Interop.Excel.DataTable;
using System.Collections;
using System.Runtime.InteropServices;

namespace курсовая
{
    public partial class ОкноСтудента : System.Windows.Window
    {
        Entities1 entities = new Entities1();
        public static ОкноСтудента Window;
        public ОкноСтудента(int Id, string ФИО)
        {
            InitializeComponent();
            Window = this;
            TextBox.Text = ФИО;


            var query = from table1 in entities.Оценки
                        where table1.idСтудента == Id
                        join table2 in entities.Предметы on table1.idПредмета equals table2.Id
                        select new
                        {
                            idПредмета = table2.НазваниеПредмета,
                            Оценка = table1.Оценка

                        };

            var result = query.ToList();

            foreach (var item in query)
            {
                dataGrid.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExportToExcel(TextBox, dataGrid, "E:\\,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,\\Курсовая\\курсовая\\NewFolder1\\Отчёт.xlsx");


        }

        public static void ExportToExcel(TextBox textBox, DataGrid dataGrid, string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

             
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = dataGrid.Columns[i].Header;
                }

                for (int i = 0; i < dataGrid.Items.Count; i++)
                {
                    for (int j = 0; j < dataGrid.Columns.Count; j++)
                    {
                        var cellValue = (dataGrid.Items[i] as dynamic).GetType().GetProperty(dataGrid.Columns[j].SortMemberPath).GetValue(dataGrid.Items[i]);
                        worksheet.Cells[i + 2, j + 1].Value = cellValue;
                    }
                }

                FileInfo excelFile = new FileInfo(filePath);
                excelPackage.SaveAs(excelFile);

                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MovingWindow(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                ОкноСтудента.Window.DragMove();
            }
        }

        public void UpdateService()
        {
            int Id = 1;
            var res = from table1 in entities.Оценки
                      where table1.idСтудента == Id
                      join table2 in entities.Предметы on table1.idПредмета equals table2.Id
                      select new
                      {
                          idПредмета = table2.НазваниеПредмета,
                          Оценка = table1.Оценка

                      };
            int count = 0;
            StringBuilder notFoundMsg = new StringBuilder();
            dataGrid.Items.Clear();
            foreach (var user in res)
            {
                if (user.idПредмета.ToLower().IndexOf(tb_search.Text.ToLower()) >= 0)
                {
                    dataGrid.Items.Add(user);
                    count++;
                }
            }
        }
        private void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateService();

        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            Close();
            window.ShowDialog();
        }
    }
}
