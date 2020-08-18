using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace GameOne
{
    class Program
    {
        //System.Threading.Thread.Sleep(1000); slowing donw output

        static void Main(string[] args)
        {
            SettingHeroAndIntro();

        }

        private static void SettingHeroAndIntro()
        {
            Console.WriteLine("Intro");  //put some intro

            Console.WriteLine("Greetings, my hero!");

            System.Threading.Thread.Sleep(1000);

            Console.WriteLine("Pleace choose your type of Hero");


            Console.WriteLine();
            Hero myCharacter = ChooseHero();

            Console.WriteLine();
            System.Threading.Thread.Sleep(1000);

            Console.WriteLine($"So, you choose to be a {myCharacter.HeroClass}. And your name is {myCharacter.Name}");
            Console.WriteLine();
            System.Threading.Thread.Sleep(1500);
            Console.WriteLine($"Remmenber, those are your stats: {myCharacter.ToString()}");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Okey, grab your boots and let's dive into the dungeon full of nasty creatures");
        }

        private static Hero ChooseHero()
        {
            Console.WriteLine("Type \"1\" for Knight, \"2\" for Mage");

            string type = Console.ReadLine();

            Console.WriteLine("Perfect! Now type your hero's name");

            string heroName = Console.ReadLine();

            Hero myCharacter = new Hero { Health = 0, Mana = 0, Attack = 0, Deffence = 0, Name = "", HeroClass = "" };

            if (type == "1")
            {
                myCharacter = new Hero { Health = 100, Mana = 20, Attack = 7, Deffence = 5, Name = heroName, HeroClass = "Knight" };
            }
            else if (type == "2")
            {
                myCharacter = new Hero { Health = 70, Mana = 50, Attack = 9, Deffence = 3, Name = heroName, HeroClass = "Mage" };
            }

            return myCharacter;
        }

        
    }

    public class Hero
    {
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Attack { get; set; }
        public int Deffence { get; set; }

        public string HeroClass { get; set; }

        public string Name { get; set; }

        public Dictionary<string, List<int>> SpellBook = new Dictionary<string, List<int>>();
        public  Hero()
        {
            this.Attack = Attack;
            this.Deffence = Deffence;
            this.Mana = Mana;
            this.Health = Health;
            this.Name = Name;
            this.HeroClass = HeroClass;
        }

        public  override string ToString()
        {
            return $"Health = {Health}, mana = {Mana}, attack = {Attack}, deffence = {Deffence}";
        }

    }
}
