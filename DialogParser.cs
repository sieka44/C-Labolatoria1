using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class DialogParser
    {
        Hero mainCharacter;

        public DialogParser(Hero hero)
        {
            mainCharacter = hero;
        }

        public String ParseDialog(IDialogPart dialogPart)
        {
            String message = dialogPart.Message();
            return message.Replace("{ImięPostaci}", mainCharacter.name);
        }
    }
}
