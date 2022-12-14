// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using E_Prescription2.Areas.Identity.Data;
using E_Prescription2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace E_Prescription2.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        [BindProperty]
        public int SelectedGenderId { get; set; }

        //[BindProperty]
        //public int SelectedProvinceId { set; get; }

        //[BindProperty]
        //public int SelectedCityId { set; get; }

        //[BindProperty]
        //public int SelectedSuburbId { set; get; }

        //[BindProperty]
        //public int SelectedPostalCodeId { set; get; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }


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
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            
                [Display(Name = "First Name")]
                public string FirstName { get; set; }

                [Display(Name = "Last Name")]
                public string LastName { get; set; }

                [Display(Name = "Date Of Birth")]
                [DataType(DataType.Date)]
                [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
                public DateTime DOB { get; set; }

                [Display(Name = "Identification Number")]
                [MaxLength(13)]
                [MinLength(13, ErrorMessage = "A minimum of 13 characters is needed for an ID number, Please enter a valid ID number")]
                [RegularExpression("([0-9]+)", ErrorMessage = "Please enter a valid ID number")]
                public string IdNumber { get; set; }

                [Display(Name = "Gender")]
                [ForeignKey("Genders")]
                public int GenderID { get; set; }
                public virtual Gender Genders { get; set; }

                [Display(Name = "Address Line 1")]
                public string AddressLine1 { get; set; }
                
                [Display(Name = "Address Line 2")]
                public string AddressLine2 { get; set; }

                [Display(Name = "Province")]
                [ForeignKey("Provinces")]
                public int ProvinceId { get; set; }
                public virtual Province Province { get; set; }

                
                [Display(Name = "City / Town")]
                [ForeignKey("Cities")]
                public int CityId { get; set; }
                public virtual City City { get; set; }

            
                [Display(Name = "Suburb")]
                [ForeignKey("Suburbs")]
                public int SuburbId { get; set; }
                public virtual Suburb Suburb { get; set; }

            
                [Display(Name = "PostalCode")]
                [ForeignKey("PostalCodes")]
                public int PostalCodeId { get; set; }
                public virtual PostalCode PostalCode { get; set; }

                [Display(Name = "Username")]
                public string Username { get; set; }
                [Phone]
                [Display(Name = "Phone number")]
                public string PhoneNumber { get; set; }
                [Display(Name = "Profile Picture")]
                public byte[] ProfilePicture { get; set; }
            
        }
        public List<SelectListItem> GenderItem { set; get; }
        //public List<SelectListItem> ProvinceItem { set; get; }
        //public List<SelectListItem> CityItem { set; get; }
        //public List<SelectListItem> SuburbItem { set; get; }
        //public List<SelectListItem> PostalCodeItem { set; get; }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var firstName = user.FirstName;
            var lastName = user.LastName;
            var profilePicture = user.ProfilePicture;

            var dob = user.DOB;
            var idNumber = user.IdNumber;
            var addressLine1 = user.AddressLine1;
            var addressLine2 = user.AddressLine2;
            var SelectedGenderId = this.SelectedGenderId;
            var SelectedProvince = user.ProvinceId;
            var SelectedCity = user.CityId;
            var SelectedSuburb = user.SuburbId;
            var SelectedPostalCode = user.PostalCodeId;
            
            Username = userName;

            Input = new InputModel
            {
                DOB = (DateTime)dob,
                IdNumber = idNumber,
                AddressLine1 = addressLine1,
                AddressLine2 = addressLine2,
                GenderID = SelectedGenderId,
                ProvinceId = (int)SelectedProvince,
                CityId = (int)SelectedCity,
                SuburbId = (int)SelectedSuburb,
                PostalCodeId = (int)SelectedPostalCode,
                PhoneNumber = phoneNumber,
                Username = userName,
                FirstName = firstName,
                LastName = lastName,
                ProfilePicture = profilePicture
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            GenderItem = _context.Genders.Select(g => new SelectListItem
            {
                Value = g.GenderId.ToString(),
                Text = g.GenderType
            }).ToList();
            ViewData["Provinces"] = await _context.Provinces.ToListAsync();
            ViewData["Prov_s"] = JsonConvert.SerializeObject(_context.Provinces.ToList());
            ViewData["Cities"] = await _context.Cities.ToListAsync();
            ViewData["City_s"] = JsonConvert.SerializeObject(_context.Cities.ToList());
            ViewData["Suburbs"] = await _context.Suburbs.ToListAsync();
            ViewData["Suburb_s"] = JsonConvert.SerializeObject(_context.Suburbs.ToList());
            ViewData["PostalCodes"] = await _context.PostalCodes.ToListAsync();
            ViewData["PostalCode_s"] = JsonConvert.SerializeObject(_context.PostalCodes.ToList());
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            var firstName = user.FirstName;
            var lastName = user.LastName;
            var dob = user.DOB;
            var idNumber = user.IdNumber;
            var addressLine1 = user.AddressLine1;
            var addressLine2 = user.AddressLine2;
            var profilePicture = user.ProfilePicture;
            var selectedGenderId = this.SelectedGenderId;
            var selectedProvinceId = user.ProvinceId;
            var selectedCityId = user.CityId;
            var selectedSuburbId = user.SuburbId;
            var selectedPostalCodeId = user.PostalCodeId;

            if (Request.Form.Files.Count > 0)
            {
                IFormFile file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    user.ProfilePicture = dataStream.ToArray();
                }
                await _userManager.UpdateAsync(user);
            }

            if (Input.FirstName != firstName)
            {
                user.FirstName = Input.FirstName;
                await _userManager.UpdateAsync(user);
            }
            if (Input.LastName != lastName)
            {
                user.LastName = Input.LastName;
                await _userManager.UpdateAsync(user);
            }
            if(Input.AddressLine1 != addressLine1)
            {
                user.AddressLine1 = Input.AddressLine1;
                await _userManager.UpdateAsync(user);
            }
            if(Input.AddressLine2 != addressLine2)
            {
                user.AddressLine2 = Input.AddressLine2;
                await _userManager.UpdateAsync(user);
            }
            if(SelectedGenderId != selectedGenderId)
            {
                this.SelectedGenderId = SelectedGenderId;
                await _userManager.UpdateAsync(user);
            }
            if(Input.ProvinceId != selectedProvinceId)
            {
                user.ProvinceId = Input.ProvinceId;
                await _userManager.UpdateAsync(user);
            }
            if(Input.CityId != selectedCityId)
            {
                user.CityId = Input.CityId;
                await _userManager.UpdateAsync(user);
            }
            if(Input.SuburbId != selectedSuburbId)
            {
                user.SuburbId = Input.SuburbId;
                await _userManager.UpdateAsync(user);
            }
            if(Input.PostalCodeId != selectedPostalCodeId)
            {
                user.PostalCodeId = Input.PostalCodeId;
                await _userManager.UpdateAsync(user);
            }
            
            
              
            


            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
