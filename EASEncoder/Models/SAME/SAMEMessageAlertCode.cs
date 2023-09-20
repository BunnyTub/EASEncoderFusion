namespace EASEncoder.Models.SAME
{
    public class SAMEMessageAlertCode
    {
        public SAMEMessageAlertCode(string id, string name, bool compliant = true)
        {
            Id = id;
            Name = name;
            Compliant = compliant;
        }

        public string Id { private set; get; }
        public string Name { private set; get; }
        public bool Compliant { private set; get; } = true;
    }
}