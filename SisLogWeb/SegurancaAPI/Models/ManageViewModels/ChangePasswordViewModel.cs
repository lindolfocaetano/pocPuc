using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SegurancaAPI.Models.ManageViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha Atual")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O {0} precisa ter no míniomo {2} e no máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("NewPassword", ErrorMessage = "A senha e sua confirmação são diferentes.")]
        public string ConfirmPassword { get; set; }

        public string StatusMessage { get; set; }
    }
}
