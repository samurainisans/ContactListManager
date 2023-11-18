namespace MVC_Web_App.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Contact> Contacts { get; set; }
        public PageViewModel PageViewModel { get; }
        public FilterViewModel FilterViewModel { get; }
        public IndexViewModel(IEnumerable<Contact>  contacts, PageViewModel pageViewModel,
            FilterViewModel filterViewModel)
        {
            Contacts = contacts;
            PageViewModel = pageViewModel;
            FilterViewModel = filterViewModel;
        }
    }
}