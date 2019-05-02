using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace JSON_Prob
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BttnClickMe_Click(object sender, RoutedEventArgs e)
        {
            //Create a WPF application that will call a web - service and answer a few questions for the user.  \
            //It is up to you to create an appropriate WPF interface (e.g.GUI), however, you need to have a button for the user to click to start the process, 
            //each question should be displayed with the answer next to it where the user cannot change the answer(don’t want them faking the results!).  

            //Anytime that there is a movie title in the answer, it should link to the IMDB link associated with it.
            //The URL for the webservice is http://pcbstuou.w27.wh-2.com/webservices/3033/api/Movies?number=100 (Links to an external site.)Links to an external site. .  
            //Note, there is an URL parameter (e.g. query string) with 100.  
            //This limits the results to 100 so that it is faster, you can move it up and down based upon your connection, it should not affect your code at all.

            //The questions your application need to answer for the user, are as follows:

            //List all of the different genres for the movies
            //Which movie has the highest IMDB score?
            //List all of the different movies that have a number of voted users with 350000 or more
            //How many movies where Anthony Russo is the director?//How many movies where Robert Downey Jr. is the actor 1?

            using (HttpClient client = new HttpClient())

            {
                var movieInfo = client.GetAsync($"http://pcbstuou.w27.wh-2.com/webservices/3033/api/Movies?number=100").Result;
            }
        }
    }
}
