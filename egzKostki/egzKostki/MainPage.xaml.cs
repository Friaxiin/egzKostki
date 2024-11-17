using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace egzKostki
{
    public partial class MainPage : ContentPage
    {
        public static int gameScore = 0;
        public static int points = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        private void RollDices(object sender, EventArgs e)
        {
            points = 0;
            rollResult.Text = "0";

            Random random = new Random();
            int diceRoll = 0;
            int[] values = new int[5];

            for (int i = 0; i < values.Length; i++)
            {
                diceRoll = random.Next(1, 7);
                values[i] = diceRoll;
            }

            var groups = values.GroupBy(v => v);

            foreach (var group in groups)
            {
                if (group.Count() >= 2)
                {
                    points += group.Key * group.Count();
                }
            }

            dice1.Text = values[0].ToString();
            dice2.Text = values[1].ToString();
            dice3.Text = values[2].ToString();
            dice4.Text = values[3].ToString();
            dice5.Text = values[4].ToString();

            rollResult.Text = points.ToString();

            gameResult.Text = (gameScore += points).ToString();
        }

        private void Reset(object sender, EventArgs e)
        {
            points = 0;
            gameScore = 0;

            rollResult.Text = points.ToString();
            gameResult.Text = gameScore.ToString();

            dice1.Text = "?";
            dice2.Text = "?";
            dice3.Text = "?";
            dice4.Text = "?";
            dice5.Text = "?";
        }
    }
}
