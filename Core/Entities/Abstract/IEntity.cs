using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Abstract
{
    public interface IEntity
    {
        public DateTime? ProcessDate { get; set; }

        //public string Show();
    }
}
