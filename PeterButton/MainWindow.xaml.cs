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
        public MainWindow()
        {
            InitializeComponent();
            this.KeyUp += Escape;

            var sb = this.Resources["ClassroomStoryboard"];
            s = sb as Storyboard;
            s.Begin();
            //makeCloud();
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
            DoubleAnimation da = new DoubleAnimation(-300, 300, new Duration(new TimeSpan(0, 0, 15)));
            Storyboard story = new Storyboard { /*RepeatBehavior = RepeatBehavior.Forever*/ };
            Storyboard.SetTargetProperty(da, new PropertyPath("(Canvas.Left)"));
            story.Children.Add(da);

            cloud = new cloud();
            try {
                //cloud.Img.Source = new BitmapImage(new Uri(@"C:\Users\Brandon\Documents\Visual Studio 2015\Projects\PeterButton\PeterButton\cat.jpg"));
                cloud.Img.Source = new BitmapImage(new Uri(@"C:\Users\Brandon\Documents\Visual Studio 2015\Projects\PeterButton\PeterButton\comp.png"));
            }
            catch (Exception e) { }
            BG.Children.Add(cloud);
            story.Completed += Completed;
            
            cloud.BeginStoryboard(story);
            
        }

        private void Completed(object sender, EventArgs e)
        {
            Container.Children.Remove(cloud);
            makeCloud();
        }
    }
}
