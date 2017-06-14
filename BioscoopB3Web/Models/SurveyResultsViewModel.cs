using BioscoopB3Web.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BioscoopB3Web.Models
{
    public class SurveyResultsViewModel
    {
        public IEnumerable<Survey> Surveys { get; set; }
    }
}