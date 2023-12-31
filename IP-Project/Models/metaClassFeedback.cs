using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication1.Models
{

    [MetadataType(typeof(FeedbackMetaData))]
    public partial class feedback
    {
        
    }

    public class FeedbackMetaData
    {
        [DisplayName("Feedback number")]
        public int feedback_id { get; set; }


        [DisplayName("Your user id")]

        public int person_id { get; set; }

        [DisplayName("Feedback Description")]

        public string feedback_desc { get; set; }


        [DisplayName("Feedback Date")]

        public Nullable<System.DateTime> feedback_date { get; set; }




    }
}