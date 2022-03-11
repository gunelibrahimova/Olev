

using Entities;

namespace K205Oleev.Areas.admin.ViewModel
{
    public class EditVM
    {
        public List<İnfoLanguage> aboutLanguages { get; set; }
        public About About { get; set; }
        public List<InfoLanguage> infoLanguages { get; set; }
        public Info Info { get; set; }
        public List<OurServiceLanguage> ourServiceLanguages { get; set; }
        public OurService OurService { get; set; }
        public List<CountDownLanguage> countDownLanguages { get; set; } 
        public CountDown CountDown { get; set; }
        public List<ProductLanguage> ProductLanguages { get; set; }
        public Product Product { get; set; }
        public List<StudyLanguage> StudyLanguages { get; set; }
        public Study Study { get; set; }
        public List<CaseLanguage> CaseLanguages { get; set; }
        public Case Case { get; set; }
        public List<ChooseLanguage> chooseLanguages { get; set; }
        public Choose choose { get; set; }
        public List<ExpertiseLanguage> expertiseLanguages { get; set; }
        public Expertise Expertise { get; set; }
        public List<ArticleLanguage> articleLanguages { get; set; }
        public Article Article { get; set; }
        public List<TeamLanguage> teamLanguages { get; set; }
        public Team Team { get; set; }
    }
}
