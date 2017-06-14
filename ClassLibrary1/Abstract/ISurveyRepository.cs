using BioscoopB3Web.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopB3Web.Domain.Abstract
{
    public interface ISurveyRepository
    {
        bool AddSurvey(Survey Survey);
        bool SetOpenQDeletedTrue(int SurveyID);
        IEnumerable<Survey> GetAllSurveys();
    }
}
