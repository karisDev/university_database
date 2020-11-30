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
        private void UpdateList()
        {
            profiles_list.ItemsSource = profiles;
            profiles_list.DisplayMemberPath = "full_info";

            int[] scores = new int[profiles.Count];
            for(int i = 0; i < profiles.Count; i++)
            {
                scores[i] = profiles[i].average_score;
            }
            biggest_score.Text = scores.Max().ToString();
            lowest_score.Text = scores.Min().ToString();
            average_score.Text = scores.Average().ToString();
            summary_score.Text = scores.Sum().ToString();
        }
        public ProfilesSQL()
        {
            InitializeComponent();
        }
        private void SortClick(Object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();
            profiles = db.ViewProfiles(sort_type.SelectedIndex, (bool)Ascending.IsChecked);
            UpdateList();
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            if(SearchFor.Text.Split('.').Length < 2 && search_type.SelectedIndex == 4 && SearchFor.Text.Length == 10)
            {
                MessageBox.Show("Неверный формат даты. Пример верной даты: 01.01.1970");
                return;
            }
            DataAccess db = new DataAccess();
            profiles = db.SearchProfiles(SearchFor.Text, search_type.SelectedIndex);
            UpdateList();

            if (profiles.Count == 0)
            {
                MessageBox.Show("No any profiles were found");
            }
        }

        private void NewProfile(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteProfile(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
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
