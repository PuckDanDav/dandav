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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace курсовая
{
    public partial class СтраницаВхода : Page
    {

        Entities1 entities = new Entities1();

        public СтраницаВхода()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string m_aut = "Аутентификация";
            string m_errorincor = "Ошибка! Проверьте правильность данных!";

            if (TextBox1.Text != "" && TextBox1.Text == null || TextBox2.Text != "" && TextBox2.Text != null)
            {
                string Login = TextBox1.Text;
                string Password = TextBox2.Text;

                bool flag = false;
                foreach (var q in entities.Студенты)
                {
                    if (TextBox1.Text == q.Логин)
                    {
                        if (TextBox2.Text == q.Пароль)
                        {
                            flag = true;
                            if (q.idРоли == 2)
                            {

                                var window = new ОкноПреподавателя();
                                MessageBox.Show("Вы вошли как преподаватель");
                                Application.Current.MainWindow.Close();
                                window.ShowDialog();
                            }
                            else
                            {
                                var window = new ОкноСтудента(q.Id, q.ФИО);
                                MessageBox.Show("Вы вошли как студент");
                                Application.Current.MainWindow.Close();
                                window.ShowDialog();
                            }
                            break;
                        }
                    }
                }
                if (!flag)
                {
                    MessageBox.Show(m_errorincor, m_aut, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                MessageBox.Show(m_errorincor, m_aut, MessageBoxButton.OK, MessageBoxImage.Error);

        }

    }
    
}
