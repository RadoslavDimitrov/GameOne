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

            Hero myCharacter = SettingHeroAndIntro();

            int roomNumber = 1;
            Random rand = new Random();
            string roomType = string.Empty;

            Monster hellHound = new Monster { HP = 10, DMG = 6 , MonsterName = "Hell Hound"};
            Monster bear = new Monster { HP = 15, DMG = 4 , MonsterName = "Cave bear"};

            while (true)
            {
                if (myCharacter.Health <= 0)
                {
                    break;
                }

                if (rand.Next(1, 10) < 6)
                {
                    roomType = "monster room";

                    Console.WriteLine($"You entered room: {roomNumber} and found {roomType}");

                    Monster currMonster = new Monster { HP = 0, DMG = 0 };

                    if(rand.Next(1, 6) < 3)
                    {
                        currMonster = hellHound;
                    }
                    else
                    {
                        currMonster = bear;
                    }

                    while (currMonster.HP > 0 || myCharacter.Health > 0)
                    {
                        currMonster.HP -= myCharacter.Attack;
                        if (currMonster.HP <= 0)
                        {
                            Console.WriteLine($"You have won the battel against {currMonster.MonsterName}");
                            ResettingMonsterHp(hellHound, bear, currMonster);
                            break;
                        }
                        else
                        {
                            System.Threading.Thread.Sleep(1000);
                            Console.WriteLine($"You attack {currMonster.MonsterName} with your weapon and deal {myCharacter.Attack} Dmg");
                            System.Threading.Thread.Sleep(1000);
                            Console.WriteLine($"{currMonster.MonsterName} has {currMonster.HP} HP left");
                        }
                        myCharacter.Health -= currMonster.DMG;
                        if(myCharacter.Health <= 0)
                        {
                            System.Threading.Thread.Sleep(1000);
                            Console.WriteLine($"{currMonster.MonsterName} attack and kills you.");
                            System.Threading.Thread.Sleep(1000);
                            Console.WriteLine($"{myCharacter.Name} has lost the battle agains evil");
                            break;
                        }
                        else
                        {
                            System.Threading.Thread.Sleep(1000);
                            Console.WriteLine($"{currMonster.MonsterName} attacks you and deal {currMonster.DMG} dmg to you");
                            System.Threading.Thread.Sleep(1000);
                            Console.WriteLine($"You survived the attack, and have {myCharacter.Health} health left");
                        }

                    }
                }
                else
                {
                    roomType = "treasure room";

                    Console.WriteLine($"You entered room: {roomNumber} and found {roomType}");
                }

                roomNumber++;
                
            }

            Console.WriteLine("You died!");

        }

        private static void ResettingMonsterHp(Monster hellHound, Monster bear, Monster currMonster)
        {
            if (currMonster == bear)
            {
                currMonster.HP = 15;
            }
            else if (currMonster == hellHound)
            {
                currMonster.HP = 10;
            }
        }

        private static Hero SettingHeroAndIntro()
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
            return myCharacter;
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
        public Hero()
        {
            this.Attack = Attack;
            this.Deffence = Deffence;
            this.Mana = Mana;
            this.Health = Health;
            this.Name = Name;
            this.HeroClass = HeroClass;
        }

        public override string ToString()
        {
            return $"Health = {Health}, mana = {Mana}, attack = {Attack}, deffence = {Deffence}";
        }

    }


    public class Monster
    {
        public int HP { get; set; }
        public int DMG { get; set; }
        public string MonsterName { get; set; }

        public Monster()
        {
            this.DMG = DMG;
            this.HP = HP;
            this.MonsterName = MonsterName;
        }

        public override string ToString()
        {
            return $"{MonsterName} with Health = {HP}, attack = {DMG}";
        }
    }

}
