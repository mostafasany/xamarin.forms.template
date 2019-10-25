namespace shellXamarin.Module.Account.Models
{
    public class Gender
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
