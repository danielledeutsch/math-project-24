
using System;
using System.Windows;
using System.Windows.Controls;

namespace YourNamespace
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            backgroundGif.MediaEnded += OnMediaEnded;
            backgroundGif.Play();
            backgroundMusic.Play();
        }
        private void OnMediaEnded(object sender, RoutedEventArgs e)
        {
            //ריסט לגיף כדי שלא להתנע ממסך שחור
            backgroundGif.Position = TimeSpan.FromMilliseconds(1);
            backgroundGif.Play();
        }
        private void GradeButton_Click(object sender, RoutedEventArgs e)
        {
            Button gradeButton = (Button)sender;

            int grade = int.Parse(gradeButton.Tag.ToString());

            // Open the GameWindow with the selected grade
            GameWindow gameWindow = new GameWindow(grade);
            gameWindow.Owner = this;
            gameWindow.ShowDialog();  // ShowDialog to wait for GameWindow to close


            this.Show();
        }
    }
}


