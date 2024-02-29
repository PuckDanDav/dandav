using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace курсовая
{
    /// <summary>
    /// Логика взаимодействия для СтраницаРегистрации.xaml
    /// </summary>
    public partial class СтраницаРегистрации : Page
    {  
        Entities1 entities = new Entities1();
        public СтраницаРегистрации()
        {
            InitializeComponent();
            foreach (var entity in entities.Группа)
            {
                ComboBox.Items.Add(entity);
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var q = new Студенты();
            entities.Студенты.Add(q);
            q.Логин = TextBox1.Text;
            q.Пароль = TextBox2.Text;   
            q.ФИО = TextBox3.Text;
            q.Группа = ComboBox.SelectedItem as Группа;
            q.idРоли = 5;
            entities.SaveChanges();
            MessageBox.Show("Регистрация прошла успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
