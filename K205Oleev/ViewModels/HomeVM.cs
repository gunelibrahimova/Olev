using Entities;

namespace K205Oleev.ViewModels
{
    public class HomeVM
    {
        public List<İnfoLanguage> AboutLanguages { get; set; }
        public About About { get; set; }
        public List<ProductLanguage> ProductLanguages { get; set; }
        public Product Product { get; set; }
        public List<OurServiceLanguage> ourServiceLanguages { get; set; }
        public OurService OurService { get; set; }
        public List<CountDownLanguage> CountDownLanguages { get; set; }
        public CountDown countDown { get; set; }
        public List<CaseLanguage> CaseLanguages { get; set; }
        public Case Case { get; set; }
        public List<ChooseLanguage> chooseLanguages { get; set; }
        public Choose Choose { get; set; }
        public List<StudyLanguage> studyLanguages { get; set; }
        public Study study { get; set; }
        public List<ExpertiseLanguage> expertiseLanguages { get; set; }
        public Expertise Expertise { get; set; }
        public List<ArticleLanguage> articleLanguages { get; set; }
        public Article Article { get; set; }
        public List<TeamLanguage> teamLanguages { get; set; }
        public Team Team { get; set; }
    }
}
