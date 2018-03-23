using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Location
    {
        private List<NPC> npcList;

        public String Name { get; }
        public List<NPC> NpcList { get { return npcList; } }

        public Location(String name)
        {
            this.Name = name;
            npcList = new List<NPC>
            {
                new NPC("Zbyszko z " + name, BuildDialogue1()),
                new NPC("Jagna z " + name, BuildDiague2())
            };
        }

        /*
         * BuildDialogue1 builds shown dialogue:
         * 
      NPC: „Witaj, czy możesz mi pomóc dostać się do innego miasta?”
       Hero: „Tak, chętnie pomogę”
        NPC: „Dziękuję! W nagrodę otrzymasz ode mnie 100 sztuk złota”.
         Hero: „Dam znać jak będę gotowy” <KONIEC>
         Hero: „100 sztuk złota to za mało!”
          NPC: „Niestety nie mam więcej. Jestem bardzo biedny”.
           Hero: „OK, może być 100 sztuk złota.”
            NPC: „Dziękuję.” <KONIEC>
         Hero: „W takim razie radź sobie sam.” <KONIEC>
      Hero: „Nie, nie pomogę, żegnaj.” <KONIEC>
       */
        private NpcDialogPart BuildDialogue1()
        {
            List<IDialogPart> heroPartLists = new List<IDialogPart>();
            NpcDialogPart oneNpcPart = new NpcDialogPart("„Dziękuję.”", null);
            IDialogPart oneHeroPart = (IDialogPart)new HeroDialogPart("„OK, może być 100 sztuk złota.”", oneNpcPart);
            heroPartLists.Add(oneHeroPart);
            oneHeroPart = (IDialogPart)new HeroDialogPart("„W takim razie radź sobie sam.”", null);
            heroPartLists.Add(oneHeroPart);
            oneNpcPart = new NpcDialogPart("„Niestety nie mam więcej. Jestem bardzo biedny”", new List<IDialogPart>(heroPartLists));
            oneHeroPart = (IDialogPart)new HeroDialogPart("„100 sztuk złota to za mało!”", oneNpcPart);
            heroPartLists.Clear();
            heroPartLists.Add(oneHeroPart);
            oneHeroPart = (IDialogPart)new HeroDialogPart("„Dam znać jak będę gotowy”", null);
            heroPartLists.Add(oneHeroPart);
            oneNpcPart = new NpcDialogPart("„Dziękuję! W nagrodę otrzymasz ode mnie 100 sztuk złota”", new List<IDialogPart>(heroPartLists));
            oneHeroPart = (IDialogPart)new HeroDialogPart("„Tak, chętnie pomogę”", oneNpcPart);
            heroPartLists.Clear();
            heroPartLists.Add(oneHeroPart);
            oneHeroPart = (IDialogPart)new HeroDialogPart("„Nie, nie pomogę, żegnaj.”", null);
            heroPartLists.Add(oneHeroPart);
            oneNpcPart = new NpcDialogPart("„Witaj, czy możesz mi pomóc dostać się do innego miasta?”", new List<IDialogPart>(heroPartLists));
            return oneNpcPart;
        }

        /*
        * BuildDialogue2 builds shown dialogue:
        * NPC: „Hej czy to Ty jesteś tym słynnym {ImięPostaci} – pogromcą smoków?”
            Hero: „Tak, jestem {ImięPostaci}”
                NPC: „WOW! Miło poznać!”. <KONIEC>
            Hero: „Nie.” <KONIEC>
      */
        private NpcDialogPart BuildDiague2()
        {
            List<IDialogPart> heroPartLists = new List<IDialogPart>();
            NpcDialogPart oneNpcPart = new NpcDialogPart("„WOW! Miło poznać!”", null);
            HeroDialogPart oneHeroPart = new HeroDialogPart("„Tak, jestem {ImięPostaci}”", oneNpcPart);
            heroPartLists.Add(oneHeroPart);
            oneHeroPart = new HeroDialogPart("„Nie.”", null);
            heroPartLists.Add(oneHeroPart);
            oneNpcPart = new NpcDialogPart("„Hej czy to Ty jesteś tym słynnym {ImięPostaci} – pogromcą smoków?”",heroPartLists);
            return oneNpcPart;
        }
       
    }
}
