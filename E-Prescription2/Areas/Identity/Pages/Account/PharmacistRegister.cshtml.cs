// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using E_Prescription2.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using E_Prescription2.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace E_Prescription2.Areas.Identity.Pages.Account
{
    public class PharmacistRegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;

        public PharmacistRegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext applicationDb)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = applicationDb;
        }

        [BindProperty]
        public int SelectedPharmacyId { get; set; }
        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            [Required]
            [Display(Name = "First Name*")]
            [DataType(DataType.Text)]
            public string FirstName { get; set; }
            [Required]
            [Display(Name = "Last Name*")]
            [DataType(DataType.Text)]
            public string LastName { get; set; }

            //[Required]
            //[Display(Name ="Date Of Birth*")]
            //[DataType(DataType.Date)]
            //[DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
            //public DateTime DOB { get; set; }

            //[Required]
            //[Display(Name = "Identification Number*")]
            //[MaxLength(13)]
            //[MinLength(13, ErrorMessage = "A minimum of 13 characters is needed for an ID number, Please enter a valid ID number")]
            //[RegularExpression("([0-9]+)", ErrorMessage = "Please enter a valid ID number")]
            //public string IdNumber { get; set; }


            //[Required]
            //[Display(Name = "Gender")]
            //[ForeignKey("Genders")]
            //public int GenderID { get; set; }
            //public virtual Gender Genders { get; set; }

            [Required]
            [Phone]
            [Display(Name = "Phone Number*")]
            [MaxLength(10)]
            [MinLength(10, ErrorMessage = "A minimum of 10 characters is needed for a phone number")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Please enter a valid phone number")]
            public string PhoneNumber { get; set; }




            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email Address*")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password*")]
            
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password*")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name ="Registration Number*")]
            [MaxLength(6)]
            [MinLength(6, ErrorMessage = "A minimum of 6 characters is needed for a registration number")]
           
            public string RegistrationNumber { get;set; }

            [ForeignKey("PharmacyRecords")]
            public int? PharmacyId { get; set; }
            public virtual PharmacyRecord PharmacyRecords { get; set; }

            //[Required]
            //[Display(Name = "Address Line 1*")]
            //public string AddressLine1 { get; set; }
            ////[Required]
            //[Display(Name = "Address Line 2")]
            //public string AddressLine2 { get; set; }

            //[Required]
            //[Display(Name ="Province")]
            //[ForeignKey("Provinces")]
            //public int ProvinceId { get; set; }
            //public virtual Province Province { get; set; }

            //[Required]
            //[Display(Name = "City / Town")]
            //[ForeignKey("Cities")]
            //public int CityId { get; set; }
            //public virtual City City { get; set; }

            //[Required]
            //[Display(Name ="Suburb")]
            //[ForeignKey("Suburbs")]
            //public int SuburbId { get; set; }
            //public virtual Suburb Suburb { get; set; }

            //[Required]
            //[Display(Name = "PostalCode")]
            //[ForeignKey("PostalCodes")]
            //public int PostalCodeId { get; set; }
            //public virtual PostalCode PostalCode { get; set; }





        }

        public List<SelectListItem> PharmacyItem { set; get; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            PharmacyItem = _context.PharmacyRecords.Select(g => new SelectListItem
            {
                Value = g.PharmacyId.ToString(),
                Text = g.PharmacyName
            }).ToList();


            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            var SelectedPharmacyId = this.SelectedPharmacyId;

            returnUrl ??= Url.Content("~/UserRoles/Index");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                MailAddress address = new MailAddress(Input.Email);
                string userName = address.User;
                var user = new ApplicationUser
                {
                    UserName = userName,
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    
                   RegistrationNumber = Input.RegistrationNumber,
                   PharmacyId = SelectedPharmacyId,
                    PhoneNumber = Input.PhoneNumber,
                       
                    
                    
                };

                //var user = CreateUser();

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    await _userManager.AddToRoleAsync(user, Enums.Roles.Pharmacist.ToString());

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        //await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        //private ApplicationUser CreateUser()
        //{
        //    try
        //    {
        //        return Activator.CreateInstance<ApplicationUser>();
        //    }
        //    catch
        //    {
        //        throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
        //            $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
        //            $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
        //    }
        //}

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
