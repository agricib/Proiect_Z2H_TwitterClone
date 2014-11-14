using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Entities.BaseEntity;

namespace User.Entities
{
    public class Message : BaseEntity<int>
    {
        public string Sender { get; set; }

        public string Receiver { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string TextMessage { get; set; }

        public DateTime Time { get; set; }
    }

}