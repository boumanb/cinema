using BioscoopB3Web.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioscoopB3Web.Domain.Entities;

namespace BioscoopB3Web.Domain.Concrete
{
    public class EFSurveyRepository : ISurveyRepository
    {

        private BioscoopModel BioscoopModel;

        public EFSurveyRepository(BioscoopModel BioscoopModel)
        {
            this.BioscoopModel = BioscoopModel;
        }

        public bool AddSurvey(Survey Survey)
        {
            BioscoopModel.Surveys.Add(Survey);
            BioscoopModel.SaveChanges();
            return true;
        }

        public IEnumerable<Survey> GetAllSurveys()
        {
            return BioscoopModel.Surveys;
        }

        public bool SetOpenQDeletedTrue(int SurveyID)
        {
            Survey Survey = BioscoopModel.Surveys.Find(SurveyID);
            Survey.OpenQIsDeleted = true;
            BioscoopModel.SaveChanges();
            return true;
        }
    }
}
