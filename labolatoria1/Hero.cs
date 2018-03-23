using System;
using ConsoleApp2;
    public class Hero
    {
        public String name { get; }
        private EHeroClass heroClass;

        public Hero(String name, EHeroClass heroClass)
        {
            this.name = name;
            this.heroClass = heroClass;
        }
        
        public void IntroduceYourself()
        {
            Console.WriteLine(heroClass.ToString() + " " + name + " hasa po lasach w poszukiwaniu przygody...");
        }

    }
