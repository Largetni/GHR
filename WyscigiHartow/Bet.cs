using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WyscigiHartow
{
    public class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;
        
        public string GetGuyDescription()
    {
        string desc;
        int DogToShow = this.Dog + 1; 
        if (Amount == 0)
        {
            desc = Bettor.Name + " nie postawil zakladu";

        }
        else 
        {
        desc= Bettor.Name + " postawil " + this.Amount +" na psa numer " + DogToShow ;
        }
        return desc;

    }
        public int PayOut(int Winner)
        {
            if (Winner == this.Dog)
            {
                return this.Amount;
            }
            else 
            {
                return -this.Amount;
            }
        }
    }
}
