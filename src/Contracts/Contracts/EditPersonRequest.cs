using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class EditPersonRequest
    {
        public string Name { get; set; }
        public DateTime DateBirthday { get; set; }
    }
}
