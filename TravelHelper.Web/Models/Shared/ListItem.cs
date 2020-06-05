namespace TravelHelper.Web.Models.Shared
{
    public class ListItem<TValue>
    {
        public TValue Value { get; set; }
        public string Key { get; set; }
        public bool IsSelected { get; set; }
    }
}
