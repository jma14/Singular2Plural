using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singular2Plural
{
    public class Pluralize
    {
        private string _consonants = "bcdfghjklmnpqrstvwxz";
        private List<string> _endingsForES = new List<string> { "ch", "s", "sh", "x", "z" };
        private string _noun;
        private char _last;
        private char _secondToLast;
        public string Plural;

        public Pluralize(string noun)
        {
            _noun = noun.ToLower();  // Convert to lower case in order to make input case insensitive
            _last = _noun[_noun.Length - 1]; // Get last letter of the noun
            _secondToLast = _noun[_noun.Length - 2]; // Get second to last letter of the noun
            Plural = checkNoun();
        }

        // Check different unique cases for pluralizing (i.e. not just adding an 's'), otherwise just add 's'
        private string checkNoun()
        {
            if (needsIES())
            {
                return _noun.Substring(0, _noun.Length - 1) + "ies";
            }
            else if (needsES())
            {
                return _noun + "es";
            }
            else
            {
                return _noun + "s";
            }
        }

        // Check for endings that require the plural to remove the 'y' and add 'ies'
        private bool needsIES()
        { 
            if ((_consonants.IndexOf(_secondToLast) != -1) && (_last == 'y'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Check for endings that require the plural to be the noun + 'es'
        private bool needsES()
        {
            if(_endingsForES.Contains(_last.ToString()))
            {
                return true;
            }
            else if(_endingsForES.Contains(_secondToLast.ToString() + _last.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
