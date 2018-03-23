using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class HeroDialogPart:IDialogPart
    {
        String currStatement;
        NpcDialogPart possibleStatements;
        public HeroDialogPart(String message, NpcDialogPart npcParts)
        {
            this.currStatement = message;
            this.possibleStatements = npcParts;
        }

        public string Message()
        {
            return currStatement;
        }

        public List<IDialogPart> PossibleStatments()
        {
            List<IDialogPart> outcome = new List<IDialogPart>
            {
                possibleStatements
            };
            return outcome;
        }
    }
}
