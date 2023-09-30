using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Source._Mapper
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public DateTime DateTimeIssued { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime? DateTimeExecuted { get; set; }
        public Guid ProcessorIdentifier { get; set; }
    }
}
