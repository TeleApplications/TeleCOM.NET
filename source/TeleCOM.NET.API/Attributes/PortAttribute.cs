
namespace TeleCOM.NET.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    internal sealed class PortAttribute : Attribute
    {
        public int Id { get; }
        public string Name { get; }

        public PortAttribute(int id, string name) 
        {
            Id = id;
            Name = name;
        }
    }
}
