using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InvestimentoApi.Models
{
    public class Quote
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [Column("18,2")]
        public decimal Value { get; set; }        
        DateTime DateTime { get; set; }
    }
}
