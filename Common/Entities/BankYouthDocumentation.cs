using System;

namespace Common.Entities
{
    public class BankYouthDocumentation
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int RegNumber { get; set; }
        public DateTime RegDate { get; set; }

        public string Filename { get; set; }
        public string Path { get; set; }
    }
}
