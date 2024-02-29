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

namespace курсовая
{
    /// <summary>
    /// Логика взаимодействия для ОкноПреподавателя.xaml
    /// </summary>
    public partial class ОкноПреподавателя : Window
    {
        public static ОкноПреподавателя Window;
        Entities1 entities = new Entities1();
        public ОкноПреподавателя()
        {
            InitializeComponent();
            Window = this; 
            foreach (var q in entities.Предметы)
            {
                ListBox1.Items.Add(q);
            }
            foreach (var q in entities.Оценки)
            {
                ListBox2.Items.Add(q);
            }
           
            foreach (var q in entities.Предметы)
            {
                CmBox1.Items.Add(q);
            }
            foreach (var q in entities.Студенты)
            {
                if (q.idРоли != 2)
                {
                     CmBox2.Items.Add(q);
                }
            }
        }

        private void MovingWindow(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                ОкноПреподавателя.Window.DragMove();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            Application.Current.Shutdown();
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var q = ListBox1.SelectedItem as Предметы;
            if (q != null)
            {
                TextBox1.Text = q.НазваниеПредмета;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            try
            {
                var q = ListBox1.SelectedItem as Предметы;
                if (TextBox1.Text == "")
                {
                    MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK,
                     MessageBoxImage.Error);
                }
                else
                {
                    if (q == null)
                    {
                        q = new Предметы();
                        entities.Предметы.Add(q);
                        ListBox1.Items.Add(q);
                    }
                    q.НазваниеПредмета = TextBox1.Text;
                    entities.SaveChanges();
                    ListBox1.Items.Refresh();
                    CmBox1.Items.Add(q);
                    CmBox1.Items.Refresh();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK,
                     MessageBoxImage.Error);
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            var res = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                var q = ListBox1.SelectedItem as Предметы;
                if (q != null)
                {
                    try
                    {
                        entities.Предметы.Remove(q);
                        entities.SaveChanges();
                        TextBox1.Clear();
                        ListBox1.Items.Remove(q);
                        MessageBox.Show("Удаление прошло успешно", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = "";
            ListBox1.SelectedIndex = -1;
        }

        private void ListBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var q = ListBox2.SelectedItem as Оценки;
            if (q != null)
            {
                TextBox2.Text = q.Оценка;
                CmBox1.SelectedItem = q.Предметы;
                CmBox2.SelectedItem = q.Студенты;
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            TextBox2.Text = "";
            ListBox2.SelectedIndex = -1;
            CmBox1.SelectedIndex = -1;
            CmBox2.SelectedIndex = -1;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            var q = ListBox2.SelectedItem as Оценки;
            if (TextBox2.Text == "" || CmBox1.SelectedIndex == -1 || CmBox2.SelectedIndex == -1 )
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK,
                 MessageBoxImage.Error);
            }
            else
            {
                if (q == null)
                {
                    q = new Оценки();
                    entities.Оценки.Add(q);
                    ListBox2.Items.Add(q);
                }
                q.Оценка = TextBox2.Text;
                q.Предметы = CmBox1.SelectedItem as Предметы;
                q.Студенты = CmBox2.SelectedItem as Студенты;
                entities.SaveChanges();
                ListBox2.Items.Refresh();
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            var w = entities.Предметы.Where(p => !entities.Оценки.Any(c => c.Id == p.Id)).Select(p => p.Id);
            if (w.Any())
            {
                var q = ListBox2.SelectedItem as Оценки;
                if (q != null)
                {
                    entities.Оценки.Remove(q);
                    entities.SaveChanges();
                    TextBox2.Clear();

                    ListBox2.Items.Remove(q);
                    CmBox1.SelectedIndex -= 1;
                    CmBox2.SelectedIndex -= 1;
                }
                else
                {
                    MessageBox.Show("Нет", "Ошибка", MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Нельзя удалить данные родительской таблицы, пока в ней есть дочерние", "Ошибка", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }

        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] numbers = TextBox2.Text.Split(',');

                double average = 0;
                foreach (string number in numbers)
                {
                    average += double.Parse(number);
                }
                average /= numbers.Length;

                TextBox2_Копировать.Text = average.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Неверный тип полей", "Ошибка", MessageBoxButton.OK,
                  MessageBoxImage.Warning);
            }
            
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            Close();
            window.ShowDialog();
        }

        
    }
}
