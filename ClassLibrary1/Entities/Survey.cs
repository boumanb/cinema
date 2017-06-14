using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopB3Web.Domain.Entities
{
    public class Survey
    {
        [Key]
        public int SurveyID { get; set; }
        public int ScoreQ { get; set; }
        public string MultipleChoiceQ { get; set; }
        public string OpenQ { get; set; }
        public bool OpenQIsDeleted { get; set; }
    }
}
