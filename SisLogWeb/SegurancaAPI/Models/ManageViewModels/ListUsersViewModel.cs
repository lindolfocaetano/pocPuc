using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SegurancaAPI.Models.ManageViewModels
{
    public class ListUsersViewModel
    {

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "CPF/CNPJ")]
        public string CPF_CNPJ { get; set; }

        public IEnumerable<Perfil> Perfis { get; set; }

        public string NmPerfil { get; set; }

        public string Id { get; set; }

        public bool VlAtivo { get; set; }

    }

    public class Perfil
    {
        public string NmPerfil { get; set; }
    }
}

