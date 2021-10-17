namespace XamarinTraining.Core.Domain
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public string Image { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} Status: {Status}";
        }
    }
}