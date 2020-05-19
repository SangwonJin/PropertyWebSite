using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcRES2019.Models
{
    public class Customer
    {

        public int CustomerID { get; set; }


        [Required]
        [Display(Name = "First Name")]
        [StringLength(30, MinimumLength = 2)]

        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30, MinimumLength = 2)]

        public string LastName { get; set; }


        [Display(Name = "Middle Name (optional) ")]
        [StringLength(30, MinimumLength = 2)]

        public string MiddleName { get; set; }



        [Required]
        [Display(Name = "Municipality (town/city) ")]
        

        public City Municipality { get; set; }

        [Required]
        [Display(Name = "Province")]
        

        public Province Province { get; set; }

        [Required]
        [Display(Name = "Country")]
        

        public Country Country { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        [RegularExpression(@"^([0-9]{5})$|^[ABCEGHJKLMNPRSTVXYabceghjklmnprstvxy]{1}\d{1}[A-Za-z]{1} *\d{1}[A-Za-z]{1}\d{1}$",
        ErrorMessage = "Please enter a valid postal code for USA/CA")]
        [StringLength(30, MinimumLength = 2)]

        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(30, MinimumLength = 2)]
        [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}",
        ErrorMessage = "Please enter a valid phone number")]
        public string PhoneNumber { get; set; }



        [Required]
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]


        public string BirthDay { get; set; }



        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",
      ErrorMessage = "Please enter a valid email address")]
        [StringLength(50, MinimumLength = 2)]

        public string Email { get; set; }

      
        public virtual ICollection<Contract> Contracts { get; set; }

        
    }
}