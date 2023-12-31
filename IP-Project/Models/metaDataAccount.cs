using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //b3ml add leh deh


namespace WebApplication1.Models
{
    [MetadataType(typeof(metadata_person))] //bzwd deh kman // btsht8l only fel run time
    public partial class person
    {
        [Display(Name = "New Password")]
        public string new_pass { get; set; }
    }

    public class metadata_person
    {
        // ... existing properties ...

        [Display(Name = "Person First name")]
        [Required(ErrorMessage = "First name is required")]
        public string person_Fname { get; set; }

        [Display(Name = "Person Last name")]
        [Required(ErrorMessage = "Last name is required")]
        public string person_Lname { get; set; }

        [Display(Name = "Person username")]
        [Required(ErrorMessage = "Username is required")]
        public string person_username { get; set; }

        [Display(Name = "Person password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "minimum 8 characters")]
        public string person_password { get; set; }

        [Display(Name = "Person DOB")]
        [Required(ErrorMessage = "Date of birth is required")]
        public Nullable<System.DateTime> person_dob { get; set; }

        [Display(Name = "Person email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string person_email { get; set; }

        [Display(Name = "Person phone no")]
        [Required(ErrorMessage = "Phone number is required")]
        public string person_phoneNo { get; set; }

        [Display(Name = "Person address")]
        [Required(ErrorMessage = "Address is required")]
        public string person_address { get; set; }

        [Display(Name = "Person role")]
        public string person_role { get; set; }
    }

}