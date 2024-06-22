using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAuction.Offers
{
    public class Offer : Entity<long>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public double Price { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsActive { get; set; }
        public long CreatorUserId { get; set; }
    }
}
