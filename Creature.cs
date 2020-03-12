using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBuddy
{
    class Creature
    {
        private Uri creatureUri;
        private bool isHatched;
        private string intro;
        public bool IsHatched
        {
            get { return isHatched; }
            set { isHatched = value; }
        }
        public Uri CreatureUri
        {
            get { return creatureUri; }
            set { creatureUri = value; }
        }
        public string Intro
        {
            get { return intro; }
            set { intro = value; }
        }
    }
    public interface IDigiBuddy
    {
        void Feed();
        void Noise();
        void Lullaby();
    }
    class Veemon : Creature, IDigiBuddy
    {
        public void Feed()
        {

        }
        public void Noise()
        {

        }
        public void Lullaby()
        {

        }
        public Veemon()
        {
            Intro = "Oh hello! My name is Veemon!";
            CreatureUri = new Uri ("C:\\Users\\Adel Lombardi\\Documents\\DesktopBuddy\\Creatures\\CreatureSelect\\Veemon.gif");
        }
    }
    class Gabumon : Creature, IDigiBuddy
    {
        public void Feed()
        {

        }
        public void Noise()
        {

        }
        public void Lullaby()
        {

        }
        public Gabumon()
        {
            Intro = "Sup, my name is Gabumon!";
            CreatureUri = new Uri("C:\\Users\\Adel Lombardi\\Documents\\DesktopBuddy\\Creatures\\CreatureSelect\\Gabumon.gif");
        }
    }
}
