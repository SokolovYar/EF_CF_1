using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        AppContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new AppContext();
        }

        private void search_ByStr<T> (string str, string param) where T : class
        {
            List<T> data = db.Set<T>().ToList().Where(item =>
            {
                var property = item.GetType().GetProperty(param);
                if (property != null)
                {
                    var value = property.GetValue(item, null) as string;
                    return value != null && value.Contains(str);
                }
                return false;
            }).ToList();
            
            dGrid.ItemsSource = data;
        }

        private void search_ByDate<T>(DateTime date, string param) where T : class
        {
            List<T> data = db.Set<T>().ToList().Where(item =>
            {
                var property = item.GetType().GetProperty(param);
                if (property != null)
                {
                    if (property.PropertyType == typeof(DateTime)) 
                    {
                        var value = (DateTime)property.GetValue(item, null);
                        return value.Date == date.Date;// Сравниваем даты без учета времени
                    }
                }
                return false;
            }).ToList();

            dGrid.ItemsSource = data;

        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem? selectedItem = optionComboBox.SelectedItem as ComboBoxItem;
            try
            {
                switch (selectedItem?.Name)
                {
                    case "Name":
                        search_ByStr<Game>(taskTextBox.Text, "Name");
                        break;

                    case "Release":
                        search_ByDate<Game>(DateTime.Parse(taskTextBox.Text), "Release");
                        break;

                    case "Studio":
                        search_ByStr<Studio>(taskTextBox.Text, "Name");
                        break;

                    case "Style":
                        search_ByStr<Style>(taskTextBox.Text, "Name");
                        break;

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            var entities = dGrid.Items.OfType<Game>();

            foreach (var entity in entities)
            {
                // Проверяем, добавляется ли новая запись
                if (db.Entry(entity).State == EntityState.Added || db.Entry(entity).State == EntityState.Detached)
                {
                    // Проверяем, существует ли уже запись с таким же именем
                    var existingEntity = db.Games.FirstOrDefault(g => g.Name == entity.Name);
                    if (existingEntity != null)
                    {
                        // Если запись существует, пропускаем добавление новой записи
                        continue;
                    }
                }
                // Устанавливаем состояние сущности
                db.Entry(entity).State = EntityState.Modified;
            }
            db.SaveChanges();
        }

        private void tBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void optionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void taskTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}