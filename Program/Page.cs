namespace Program
{
    public class Page
    {
        private string _title;
        public string getTitle => _title;
        public string type;
        private int _visitCount;
        public int getVisitCount => _visitCount;
        public int level;
        public Page(string title)
        {
            _title = title;
        }

        public void AddVisit()
        {
            _visitCount++;
        }
    }
}