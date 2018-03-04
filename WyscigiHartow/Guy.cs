using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WyscigiHartow
{
    public class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;

        public RadioButton MyRadioButton;
        public Label MyLabel;
        public void UpdateLabels()
        { 
        MyLabel.Text= MyBet.GetGuyDescription();
        MyRadioButton.Text = this.Name + " ma " + this.Cash + " zl";
        }
        public void ClearBet()
        { 
            MyBet = new Bet() { Amount = 0, Bettor= this};
            UpdateLabels();
        }
        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            
            if (BetAmount <= this.Cash)
            {
                MyBet = new Bet()
                {
                    Amount = BetAmount,
                    Dog = DogToWin,
                    Bettor = this
                };
                UpdateLabels();

                return true;
            }
            else { return false; }

        }
        public void Collection(int Winner)
        {
            
            this.Cash = this.Cash + MyBet.PayOut(Winner);
            ClearBet();   
            UpdateLabels();

        }
        public int IsAWinner(int Winner)
        {

            return MyBet.PayOut(Winner);

               
                
            
        }

    }
}
