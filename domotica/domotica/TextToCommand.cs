using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domotica
{
    public class TextToCommand
    {
        public TextToCommand()
        {

        }

        public string[] textToCommand( string aInput )
        {
            string[] words = aInput.Split(' ');

            return words;
        }
    }
}
