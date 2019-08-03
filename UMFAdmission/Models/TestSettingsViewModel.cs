using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UMFAdmission.Models
{
    public class TestSettingsViewModel
    {
       
        
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        [RegularExpression("[^0-9]", ErrorMessage = "UPRN must be numeric")]
        public string NumberOfQuestions { get; set; }
        //Category
        public List<string> Categories { get; set; }

        public List<bool> Bio { get; set; }
        

        public TestSettingsViewModel()
        {
            Categories = new List<string>
        {
            "Toate capitolele",
            "Alcatiuirea corpului uman",
            "Sistem nervos",
            "Analizatorii",
            "Glandele endocrine",
            "Aparatul locomotor",
            "Digestia si absortia",
            "Sangele",
            "Circulatia - Sistemul cardio-vascular",
            "Respiratia",
            "Aparatul excretor",
            "Metabolismul",
            "Functia de reproducere"
        };

            Bio = new List<bool>();
            foreach (var i in Categories)
            {
                Bio.Add(false);
            }
        }
    }
}