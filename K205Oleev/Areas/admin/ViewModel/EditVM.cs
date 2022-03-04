

using Entities;

namespace K205Oleev.Areas.admin.ViewModel
{
    public class EditVM
    {
        public List<AboutLanguage> aboutLanguages { get; set; }
        public About About { get; set; }
        public List<InfoLanguage> infoLanguages { get; set; }
        public Info Info { get; set; }
        public List<OurServiceLanguage> ourServiceLanguages { get; set; }
        public OurService OurService { get; set; }
        public List<CountDownLanguage> countDownLanguages { get; set; } 
        public CountDown CountDown { get; set; }
    }
}
