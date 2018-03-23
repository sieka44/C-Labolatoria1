using ConsoleApp2;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Program
{
    private static DialogParser parser;

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
        LocationScreen(hero, new Location("Rivendel"));
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

    private static void LocationScreen(Hero hero, Location location)
    {
        if (hero == null || location == null)
        {
            Console.Write("FATAL ERROR");
            return;
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
        } while (clicked.Key != ConsoleKey.X);
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
        Console.WriteLine("<Koniec>. Kliknij aby wrócić do ekranu lokacji...");
        Console.ReadKey();
    }

    public static void Main() => StartGame();
}