namespace shellXamarin.Module.Common.Models
{
    public class Language:BaseModel
    {
        string id;
        public string Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        string flag;
        public string Flag
        {
            get { return flag; }
            set { SetProperty(ref flag, value); }
        }

        string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
