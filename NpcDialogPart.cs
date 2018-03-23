using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class NpcDialogPart:IDialogPart
    {
        List<IDialogPart> possibleStatements;
        String currStatement;
        public NpcDialogPart(String message, List<IDialogPart> heroDialogPart)
        {
            currStatement = message;
            possibleStatements = heroDialogPart;
        }

        public string Message()
        {
            return currStatement;
        }

        public List<IDialogPart> PossibleStatments()
        {
            return possibleStatements;
        }

    }
}
