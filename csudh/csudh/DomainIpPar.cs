using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csudh
{
    class DomainIpPar
    {
        string domain_name;
        string ip_address;

        public DomainIpPar(string domain_name, string ip_address)
        {
            this.domain_name = domain_name;
            this.ip_address = ip_address;
        }

        public string Domain_name { get => domain_name; set => domain_name = value; }
        public string Ip_address { get => ip_address; set => ip_address = value; }
    }
}
