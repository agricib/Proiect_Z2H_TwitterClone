using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Entities.BaseEntity;

namespace User.Entities
{
      public class UserInfo : BaseEntity<int>
        {
            public string UserName { get; set; }

            public string Name { get; set; }

            public double Latitude { get; set; }

            public double Longitude { get; set; }

            public DateTime PositionDate { get; set; }

            public bool Online { get; set; }
 
        }
    
}
