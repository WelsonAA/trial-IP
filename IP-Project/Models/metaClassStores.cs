using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;



namespace WebApplication1.Models
{
    
    [MetadataType(typeof(metadata_stores))]
    public partial class stores
    {
        //add new property
    }

    public class metadata_stores
    {
        public int store_id { get; set; }
        [Required(ErrorMessage = "Store name is required")]
        [Display(Name = "Store name" )]
        public string store_name { get; set; }
        public string store_image { get; set; }
        [Display(Name = "Store open time")]

        public string store_open_times { get; set; }
        [Display(Name = "Store close time")]

        public string store_close_times { get; set; }
        [Display(Name = "Store address")]
        [Required(ErrorMessage = "Store address is required")]
        public string store_address { get; set; }
        [Display(Name = "Store phone number")]
        [Required(ErrorMessage = "Store phone number is required")]
        public string store_Phonenumber { get; set; }


    }

}