using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WyscigiHartow
{
    public class Greyhound
    {
        public int StartingPosition;
        public int RaceLenght;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random MyRandom;

        public bool Run( PictureBox trackLenght)
        { 
       
       this.MyPictureBox.Left += this.MyRandom.Next(1,4);
            if( this.MyPictureBox.Right > trackLenght.Width )           
            {
                return true;
            }else
            {
                return false;
            }

        }
        public void TakeStartingPosition()
        {
            this.MyPictureBox.Left = 0;
        }




    }
}
