using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcRES2019.Models
{
    public class Contract
    {
        public int ID { get; set; }

        [Display(Name = "Agent")]
        public int AgentID { get; set; }
        public virtual Agent Agents { get; set; }

        [Display(Name = "Customer")]
        public int CustomerID { get; set; }
        public virtual Customer Customers { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]


        public DateTime StartDate { get; set; }
        

        [Required]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]


        public DateTime EndDate { get; set; }
        //public virtual ICollection<List> Lists { get; set; }

        [Required]
        
        [Display(Name = "Country")]
        
        public Country Country { get; set; }

        




        [Required]
        
        [Display(Name = "Province")]
       

        public Province Province { get; set; }

        [Required]
        
        [Display(Name = "Municipality")]
       

        public City Municipality { get; set; }


        [Required]
        
        [Display(Name = "Area Of City")]
        [StringLength(255)]

        public string Area { get; set; }

        [Required]
       
        [Display(Name = "Postal Code")]
        [RegularExpression(@"^([0-9]{5})$|^[ABCEGHJKLMNPRSTVXYabceghjklmnprstvxy]{1}\d{1}[A-Za-z]{1} *\d{1}[A-Za-z]{1}\d{1}$",
        ErrorMessage = "Please enter a valid postal code for USA/CA")]
        [StringLength(30, MinimumLength = 2)]

        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "Number of Beds")]
        public int NumBeds { get; set; }

        [Required]
        [Display(Name = "Number of Baths")]
        public int NumBaths { get; set; }

        [Required]
        [Display(Name = "Square Footage")]
        public int SquareFootage { get; set; }

        [Required]
       
        [Display(Name = "Type Of Heating")]
        [StringLength(255)]
        public string TypeOfHeating { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }


       
        [Display(Name = "Summary")]
        [StringLength(255)]
        public string Summary { get; set; }

        //[Required]
        //[Display(Name = "Image")]
        //public byte[] Image { get; set; }

        [Display(Name = "Image")]
        public int ImageID { get; set; }
        public virtual Image Images { get; set; }


        public bool Signed { get; set; }
    }
}