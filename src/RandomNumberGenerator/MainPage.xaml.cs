using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RandomNumberGenerator
{
    public class Team {
        public Team(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }

    public partial class MainPage : ContentPage
    {
        private List<Team> teams = new List<Team>{
            new Team("Team Logic"),
            new Team("Vegas Killer B's"),
            new Team("Team StrotKamp"),
            new Team("Team Courtney"),
            new Team("Team Conner"),
            new Team("Team Pitts"),
            new Team("Dubtown Gunslingers"),
            new Team("Oakland Raiders"),
            new Team("Team Thomas"),
            new Team("Team Geide")
        };

        private ObservableCollection<Team> usedTeams = new ObservableCollection<Team>();

        private List<int> usedValues = new List<int>();

        public MainPage()
        {
            InitializeComponent();
            lstDraftOrder.ItemsSource = usedTeams;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            btnNewNumber.IsEnabled = false;

            usedTeams.Clear();
            usedValues.Clear();

            while (usedTeams.Count() < teams.Count)
            {
                var randomNumber = GenerateRandomNumber();
                AddToUsedValues(randomNumber);
            }

            btnNewNumber.IsEnabled = true;
        }

        private void AddToUsedValues(int value)
        {
            usedValues.Add(value);
            usedTeams.Add(teams[value - 1]);
        }

        private int GenerateRandomNumber()
        {
            var random = new Random(new Random().Next());
            var ran = random.Next(1, teams.Count + 1);

            if (usedValues.Any(X => X == ran))
            {
                return GenerateRandomNumber();
            }

            return ran;
        }
    }
}
