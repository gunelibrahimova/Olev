namespace Entities
{
    public class OurServiceLanguage : Base
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public string LangCode { get; set; }
        public int OurServiceID { get; set; }
        public virtual OurService OurServices { get; set; }
        public string SEO { get; set; }
    }
}
