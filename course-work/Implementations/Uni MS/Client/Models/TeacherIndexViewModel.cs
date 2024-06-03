namespace Client.Models
{
    public class TeacherIndexViewModel
    {
        public List<TeacherViewModel> Data { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Page { get; set; }
        public int PagesCount { get; set; }
    }
}
