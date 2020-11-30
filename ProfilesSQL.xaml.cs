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

namespace university_database
{
    
    public partial class ProfilesSQL : Window
    {
        List<Profile> profiles = new List<Profile>();
        void UpdateList()
        {
            profiles_list.ItemsSource = profiles;
            profiles_list.DisplayMemberPath = "full_info";
        }
        public ProfilesSQL()
        {
            InitializeComponent();

            UpdateList();
        }
        public void SortClick(Object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();
            profiles = db.ViewProfiles(sort_type.SelectedIndex, (bool)Ascending.IsChecked);
            MessageBox.Show(sort_type.SelectedIndex.ToString() + " " + Ascending.IsChecked);
            UpdateList();
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();
            if(SearchFor.Text.Split('.').Length < 2 && search_type.SelectedIndex == 2)
            {
                MessageBox.Show("Неверный формат даты. Пример верной даты: 01.01.1970");
            }
            profiles = db.SearchProfiles(SearchFor.Text, search_type.SelectedIndex);
            UpdateList();

            if (profiles.Count == 0)
            {
                MessageBox.Show("No any profiles were found");
            }
        }
    }
}

/*
            FlowDocument doc = new FlowDocument();
            Paragraph p = new Paragraph(new Run("Hello, world!"))
            {
                FontSize = 36
            };
            doc.Blocks.Add(p);

            p = new Paragraph(new Run("The ultimate programming greeting!"))
            {
                FontSize = 14,
                FontStyle = FontStyles.Italic,
                TextAlignment = TextAlignment.Left,
                Foreground = Brushes.Gray
            };
            doc.Blocks.Add(p);
            fd_viewer.Document = doc;
            */
