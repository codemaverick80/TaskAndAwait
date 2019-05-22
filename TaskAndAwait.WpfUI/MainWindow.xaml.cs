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
using TaskAndAwait.Library;
using TaskAndAwait.Shared;

namespace TaskAndAwait.WpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PersonRepository repository = new PersonRepository();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FetchWithTaskButton_Click(object sender, RoutedEventArgs e)
        {
            ClearListBox();
            Task<List<Person>> peopleTask = repository.Get();
            peopleTask.ContinueWith(FillListBox,
                TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void FillListBox(Task<List<Person>> peopleTask)
        {
            List<Person> people = peopleTask.Result;
            foreach (var person in people)
                PersonListBox.Items.Add(person);
        }

        private void FetchWithAwaitButton_Click(object sender, RoutedEventArgs e)
        {
            ClearListBox();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearListBox();
        }

        private void ClearListBox()
        {
            PersonListBox.Items.Clear();
        }
    }
}
