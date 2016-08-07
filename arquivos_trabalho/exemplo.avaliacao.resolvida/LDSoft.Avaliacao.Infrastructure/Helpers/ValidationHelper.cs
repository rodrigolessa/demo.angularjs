using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDSoft.Avaliacao.Infrastructure.Helpers
{
    public class ValidationHelper
    {
        public static void StringLength(string propName, string stringValue, int maximum)
        {
            StringLength(stringValue, maximum, propName + " não pode ter mais que " + maximum + " caracteres");
        }

        public static void StringLength(string stringValue, int maximum, string message)
        {
            int length = stringValue.Length;
            if (length > maximum)
            {
                throw new Exception(message);
            }
        }
    }
}
