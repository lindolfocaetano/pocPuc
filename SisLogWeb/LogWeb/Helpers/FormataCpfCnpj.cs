using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogWeb.Helpers
{
    public class FormataCpfCnpj
    {
        public static string Formatar(string cpfCnpj)
        {
            if (cpfCnpj.Length == 11)
            {
                var cpf = Convert.ToInt64(cpfCnpj);
                return $@"{cpf:000\.###\.###-##}";
            }
            else
            {
                var cnpj = Convert.ToInt64(cpfCnpj);
                return $@"{cnpj:00\.000\.000\/0000\-00}";

            }
        }
        public static string Desformatar(string cpfCnpj)
        {
            return cpfCnpj.Replace("/", "").Replace(".", "").Replace("-", "");
        }
    }
}


