using Newtonsoft.Json;
using System;
using System.IO;
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
            ClearAll();
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



            List<MovieClass> MoviesNumberUsersVoted = new List<MovieClass>();
            List<MovieClass> movies;
            List<MovieClass> highestIMDBScores = new List<MovieClass>();

            using (var client = new HttpClient())

            {
                //GET ALL OF THE DATA WE NEED TO PERFORM THE ANALYTICS
                var response = client.GetAsync($"http://pcbstuou.w27.wh-2.com/webservices/3033/api/Movies?number=100").Result;
                var movieInfo = response.Content.ReadAsStringAsync().Result;
                movies = JsonConvert.DeserializeObject<List<MovieClass>>(movieInfo);


                //1) List all of the different genres for the movies
                foreach(var movie in movies)
                {
                    lbGenre.Items.Add(movie.genres);
                }

                //2) Which movie has the highest IMDB score?
                foreach (var movie in movies)
                {
                    if (highestIMDBScores.Count<1)
                    {
                        highestIMDBScores.Add(movie);
                    }
                    else
                    {
                        if(highestIMDBScores[0].imdb_score<movie.imdb_score)        //New highest imdb_score
                        {
                            highestIMDBScores.Clear();
                            highestIMDBScores.Add(movie);
                        }
                        else if(highestIMDBScores[0].//finish thissssss)
                    }
                }
                txtHighestIMDB.Text = highestIMDBScores[0].movie_title;


                //List all of the different movies that have a number of voted users with 350000 or more
                //How many movies where Anthony Russo is the director?//How many movies where Robert Downey Jr. is the actor 1?





                //I need to convert the data to instances

                //    List<MovieClass> information = JsonConvert.DeserializeObject<List<MovieClass>>(movieStuff);




                //    lbGenre.Items.Add("");
                //    txtHighestIMDB.Text = "";
                //    lbVote.Items.Add("");
                //    txtRusso.Text = "";
                //    txtDowney.Text = "";
                //}
            }

        }

            private void ClearAll()
            {
                txtRusso.Inlines.Clear();
                txtHighestIMDB.Inlines.Clear();
                txtDowney.Inlines.Clear();
                lbGenre.Items.Clear();
                lbVote.Items.Clear();
            }
    }
}
