using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WyscigiHartow
{
    public partial class Form1 : Form
    {
        Guy[] GuysArray = new Guy[3];
        Greyhound[] GreyhoundsArray = new Greyhound[4];

        public Form1()
        {
            InitializeComponent();
            
            GuysArray[0] = new Guy() { Name = "Joe", Cash = 50, MyRadioButton = joeRadioButton, MyLabel = joeLabel };
            GuysArray[1] = new Guy() { Name = "Bob", Cash = 75, MyRadioButton = bobRadioButton, MyLabel = bobLabel };
            GuysArray[2] = new Guy() { Name = "Al", Cash = 45, MyRadioButton = alRadioButton, MyLabel = alLabel };
            foreach (Guy Guy in GuysArray)
            {
                Guy.ClearBet();
            }

            GreyhoundsArray[0] = new Greyhound() { MyPictureBox = pictureBox2, MyRandom = new Random(), RaceLenght= track.Right - pictureBox2.Right, StartingPosition= pictureBox2.Left };
            GreyhoundsArray[1] = new Greyhound() { MyPictureBox = pictureBox3, MyRandom = GreyhoundsArray[0].MyRandom, RaceLenght = track.Right - pictureBox3.Right, StartingPosition = pictureBox3.Left };
           GreyhoundsArray[2] = new Greyhound() { MyPictureBox = pictureBox4, MyRandom = GreyhoundsArray[0].MyRandom, RaceLenght = track.Right - pictureBox4.Right, StartingPosition = pictureBox4.Left };
            GreyhoundsArray[3] = new Greyhound() { MyPictureBox = pictureBox5, MyRandom = GreyhoundsArray[0].MyRandom,RaceLenght = track.Right- pictureBox5.Right, StartingPosition= pictureBox5.Left };
            
            
            numericUpDown1.Minimum = 5;
            minimumBetLabel.Text = "Minimalny zaklad: "+ numericUpDown1.Minimum + " zl";
            
            numericUpDown2.Minimum = 1;  //ogarnac pokazywanie numeru dpo uzytkownika i do metod
            numericUpDown2.Maximum = 4;
        }

        private void betButton_Click(object sender, EventArgs e)
        {
             int GuySelected=0; 
           
            if (joeRadioButton.Checked)
            {
                GuySelected = 0;
            }
            else if(bobRadioButton.Checked)
            {
                GuySelected = 1;
            }
            else if(alRadioButton.Checked)
            {
                GuySelected = 2;
            }

            GuysArray[GuySelected].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value-1);

        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            guyNameLabel.Text = GuysArray[0].Name;
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            guyNameLabel.Text = GuysArray[1].Name;
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            guyNameLabel.Text = GuysArray[2].Name;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            foreach (Greyhound Greyhound in GreyhoundsArray)
            {
                Greyhound.TakeStartingPosition();
            }
            groupBox1.Enabled = false;
            timer1.Enabled = true;
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           for (int i = 0; i <= 3; i++)
           {
               if (GreyhoundsArray[i].Run(track))
               {

                   timer1.Stop();
                   timer1.Enabled = false;
                   groupBox1.Enabled = true;
                   int winner = i + 1;
                   MessageBox.Show("Wygral chart numer: " + winner, "Koniec wyscigu");
                   for (int j = 0; j <= 2; j++)
                   {
                       GuysArray[j].Collection(i);
                       
                       if (GuysArray[j].IsAWinner(i) > 0)
                       {
                           MessageBox.Show(GuysArray[i].Name + " wygral!");
                       }

                   }
                  
                   
                   break;
               }
               
                }
         
        }

        
        


        

      
    }
}
