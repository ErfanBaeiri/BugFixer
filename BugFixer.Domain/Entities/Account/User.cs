using BugFixer.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Domain.Entities.Account
{
    public class User : BaseEntity
    {
        #region Properties
        [Display(Name = "نام")]
        [MaxLength(100, ErrorMessage = "{نمی تواند بیشتر از {1} کاراکتر باشد {0")]
        public string? FirstName { get; set; }
        [Display(Name = "نام خانوادگی")]
        [MaxLength(100, ErrorMessage = "{نمی تواند بیشتر از {1} کاراکتر باشد {0")]
        public string? LastName { get; set; }
        [Display(Name = "شماره تماس")]
        [MaxLength(20, ErrorMessage = "{نمی تواند بیشتر از {1} کاراکتر باشد {0")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "ایمیل شما معتبر نمی باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Email { get; set; }
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{نمی تواند بیشتر از {1} کاراکتر باشد {0")]
        public string Password { get; set; }
        [Display(Name = "توضیحات")]
        public string? Description { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsBan { get; set; }
        public string EmailActivation { get; set; }
        public string Avatar { get; set; }
        #endregion

        #region Relations

        #endregion
    }
}
