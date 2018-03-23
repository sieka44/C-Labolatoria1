using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class NPC
    {
        NpcDialogPart startDialog;
        public String Name { get; }

        public NPC(String name,NpcDialogPart start)
        {
            this.Name = name;
            startDialog = start;
        }

        public NpcDialogPart StartTalking()
        {
            return startDialog;
        }
        
    }
}
