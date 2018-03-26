using ConsoleApp2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Program
{
    private static DialogParser parser;
    private static List<Location> locationList = new List<Location>
    {
        new Location("Rivendell",true),
        new Location("EMordor",true),
        new Location("DHelm's Deep",true),
        new Location("CMinas Tirith",true),
        new Location("BMinas Morgul",false),
        new Location("AMines Of Moria",false)
    };

    private static void StartGame()
    {
        Console.Clear();
        Console.WriteLine("Witaj w grze NAZWA GRY");
        Console.WriteLine("[1] Zacznij nową grę");
        Console.WriteLine("[X] Zamknij program");
        ConsoleKeyInfo clicked;
        Hero hero = null;
        do
        {
            clicked = Console.ReadKey();
            if (clicked.Key == ConsoleKey.D1)
            {
                hero = CreateHero();
                hero.IntroduceYourself();
                Console.WriteLine("Kliknij aby przejść do ekranu lokacji...");
                Console.ReadKey();
                parser = new DialogParser(hero);
                break;
            }
        } while (clicked.Key != ConsoleKey.X);
        Location currLocation = locationList.Find(x => x.Name=="Rivendell");
        while (currLocation!=null)
        {
            currLocation = LocationScreen(hero, currLocation);
        }

    }

    private static Hero CreateHero()
    {
        String name;
        String clas;
        Hero hero = null;
        Regex r = new Regex("^[a-zA-Z0-9]*$");
        do
        {
            Console.Clear();
            Console.WriteLine("Podaj nazwę bohatera:");
            name = Console.ReadLine().Trim();
        } while (name.Length < 3  || !r.IsMatch(name));

        Console.WriteLine("Podaj klasę bohatera");

        do
        {
            clas = Console.ReadLine().Trim();
            if (clas == "Barbarzynca")
            {
                hero = new Hero(name, EHeroClass.Barbarzynca);
                break;
            }
            else if (clas == "Amazonka")
            {
                hero = new Hero(name, EHeroClass.Amazonka);
                break;
            }
            else if (clas == "Paladyn")
            {
                hero = new Hero(name, EHeroClass.Paladyn);
                break;
            }
            else Console.WriteLine("Podaj poprawną nazwę(Barbarzynca, Amazonka, Paladyn):");
        } while (true);

        return hero;
    }

    private static Location LocationScreen(Hero hero, Location location)
    {
        if (hero == null || location == null)
        {
            Console.Write("FATAL ERROR");
            return null;
        } 
        
        ConsoleKeyInfo clicked;
        do
        {
            Console.Clear();
            Console.WriteLine("Znajdujesz się w " + location.Name + ".");
            NPC[] npcList = location.NpcList.ToArray();
            for (int i = 0; i < npcList.Length; i++)
            {
                Console.WriteLine("Kliknij [" + i + "] aby porozmawiać z " + npcList[i].Name.ToString());
            }
            Console.WriteLine("Kliknij [T] aby podróżować");
            Console.WriteLine("Kliknij [X] aby wyjść");
            clicked = Console.ReadKey();
            if (clicked.Key == ConsoleKey.D0)
            {
                PerformTalk(npcList[0]);
            }
            else if (clicked.Key == ConsoleKey.D1)
            {
                PerformTalk(npcList[1]);
            }
            else if (clicked.Key == ConsoleKey.T)
            {
                Console.Clear();
                Console.WriteLine("Gdzie chcesz podróżować?");
                List<String> tmpList = locationList.Where(x => x.IsUnlocked && x != location).Select(a => a.Name).OrderBy(a => a).ToList();
                for(int i = 0; i < tmpList.Count; i++)
                {
                    Console.WriteLine("["+i+"]"+tmpList[i]);
                }
                Console.WriteLine("Wybierz nr lokalizacji:");
                ConsoleKeyInfo keyPressed;
                int index = 0;
                do
                {
                    keyPressed = Console.ReadKey();
                } while (!Int32.TryParse(keyPressed.KeyChar.ToString(), out index) || index>=tmpList.Count);
                return locationList.Find(x => x.Name == tmpList[index]);
            }
        } while (clicked.Key != ConsoleKey.X);
        return null;
    }

    private static void PerformTalk(NPC npc)
    {
        IDialogPart dialogPart = npc.StartTalking();
        Console.WriteLine("Rozmawiasz z "+npc.Name);
        while (dialogPart!=null)
        {
            Console.Clear();
            List<IDialogPart> heroPartLists = dialogPart.PossibleStatments();
            if (dialogPart.GetType() == typeof(NpcDialogPart))
            {
                Console.WriteLine(parser.ParseDialog( dialogPart ));
                if (heroPartLists == null) break;
                for (int i = 0; i < heroPartLists.Count; i++)
                {
                    Console.WriteLine("["+i+"] "+parser.ParseDialog( dialogPart.PossibleStatments()[i]) );
                }
                ConsoleKeyInfo clicked;
                int x = int.MaxValue;
                do
                {
                    clicked = Console.ReadKey();
                    Int32.TryParse(clicked.KeyChar.ToString(), out x);
                } while ( x > heroPartLists.Count);

                dialogPart = heroPartLists[x];
            }
            else if (dialogPart.GetType() == typeof(HeroDialogPart))
            {
                if (heroPartLists == null) break;
                dialogPart = dialogPart.PossibleStatments()[0];
            }
            else
            {
                Console.WriteLine("Fatal Error Diff Type Expected.");
                break;
            }
        }
        locationList.Find(x => x.Name == "AMines Of Moria").IsUnlocked=true;
        Console.WriteLine("<Koniec>. Kliknij aby wrócić do ekranu lokacji...");
        Console.ReadKey();
    }

    public static void Main() => StartGame();
}