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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PeterButton
{
    /// The primary window of Peter's Button
    /// Interaction logic for MainWindow.xaml
    /// Author: Brandon Yip
    public partial class MainWindow : Window
    {

        Storyboard s;
        cloud cloud;
        cloud cloud2;
        cloud cloud3;
        public MainWindow()
        {
            InitializeComponent();
            this.KeyUp += Escape;

            var sb = this.Resources["ClassroomStoryboard"];
            s = sb as Storyboard;
            s.Begin();
            makeCloud();
        }


        //Event: Escape KeyUp causes application to close
        private void Escape(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                Application.Current.Shutdown();
            }
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            s.Seek(TimeSpan.Zero);
        }

        public void makeCloud()
        {
            
            DoubleAnimation da = new DoubleAnimation(-100, 800, new Duration(new TimeSpan(0, 0, RandomIntGenerator(3))));
            Storyboard story = new Storyboard { /*RepeatBehavior = RepeatBehavior.Forever*/ };
            Storyboard.SetTargetProperty(da, new PropertyPath("(Canvas.Left)"));
            story.Children.Add(da);

            cloud = new cloud();
            try {
                picSelector(RandomIntGenerator(2));
            }
            catch (Exception e) { }
            int y = RandomIntGenerator(1);
            Canvas.SetTop(cloud, y);
            Container.Children.Add(cloud);
            story.Completed += Completed;
            
            cloud.BeginStoryboard(story);
            
        }


        //Selects which picture to be used as the cloud
        public void picSelector(int i)
        {
            switch(i)
            {
                case 1:
                    cloud.Img.Source = new BitmapImage(new Uri(@"C:\Users\Brandon\Documents\Visual Studio 2015\Projects\PeterButton\PeterButton\cat.jpg"));
                    break;
                case 2:
                    cloud.Img.Source = new BitmapImage(new Uri(@"C:\Users\Brandon\Documents\Visual Studio 2015\Projects\PeterButton\PeterButton\cat.jpg"));
                    break;
                case 3:
                    cloud.Img.Source = new BitmapImage(new Uri(@"C:\Users\Brandon\Documents\Visual Studio 2015\Projects\PeterButton\PeterButton\cat.jpg"));
                    break;

            } 
        }

        public int RandomIntGenerator(int i)
        {
            Random rnd = new Random();
            int num = 0;
            if (i == 1)
            {
                num = rnd.Next(0, 300);
            }
            if (i == 2)
            {
                num = rnd.Next(1, 3);
            }
            if (i == 3)
            {
                num = rnd.Next(8, 20);
            }
            return num;
        }
        private void Completed(object sender, EventArgs e)
        {
            Container.Children.Remove(cloud);
            makeCloud();
        }
    }
}
