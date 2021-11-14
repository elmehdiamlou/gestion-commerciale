using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCommercial
{
    class utilisateur
    {
        public static string unom { get; set; }
        public string nom
        {
            get { return unom; }
            set { unom = value; }
        }
    }
}
