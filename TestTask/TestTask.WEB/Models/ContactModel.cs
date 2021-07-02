using System;

namespace TestTask.WEB.Models
{
    public class ContactModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string MobilePhone { get; set; }
        public string JobTitle { get; set; }
        public string BirthDate { get; set; }
    }
}
