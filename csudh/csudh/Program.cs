using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csudh
{
    class Program
    {
        static List<DomainIpPar> domainIpParok;
        static void Main(string[] args)
        {
            Feladat2();
            Feladat3();
            Feladat5();
            Feladat6();
            Console.ReadLine();

        }

        private static void Feladat6()
        {
            using (var sw = new StreamWriter("table.html"))
            {
                sw.WriteLine("<table>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th style='text-align: left'>Ssz</th>");
                sw.WriteLine("<th style='text-align: left'>Host domain neve</th>");
                sw.WriteLine("<th style='text-align: left'>Host IP címe</th>");
                sw.WriteLine("<th style='text-align: left'>1. szint</th>");
                sw.WriteLine("<th style='text-align: left'>2. szint</th>");
                sw.WriteLine("<th style='text-align: left'>3. szint</th>");
                sw.WriteLine("<th style='text-align: left'>4. szint</th>");
                sw.WriteLine("<th style='text-align: left'>5. szint</th>");
                sw.WriteLine("</tr>");
                int sSz = 1;
                foreach (var par in domainIpParok)
                {
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<th style='text-align: left'>{0}.</th>",sSz);
                    sw.WriteLine("<td>{0}</td>",par.Domain_name);
                    sw.WriteLine("<td>{0}</td>",par.Ip_address);
                    for (int i = 1; i < 6; i++)
                    {
                        sw.WriteLine("<td>{0}</td>", Domain(i,par.Ip_address));
                    }
                    sw.WriteLine("</tr>");
                    sSz++;
                }
                sw.WriteLine("</table>");
            }
        }

        private static void Feladat5()
        {
            Console.WriteLine("5. feladat: Az első domain felépítése:");
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine("\t {0}. szint: {1}", i, Domain(i,domainIpParok[0].Ip_address));
            }
        }

        private static string Domain(int szint, string ip_address)
        {
            foreach (var par in domainIpParok)
            {
                if (par.Ip_address == ip_address)
                {
                    var domain = par.Domain_name.Split('.');
                    if (domain.Length < szint)
                    {
                        return "nincs";
                    }
                    else
                    {
                        return domain[domain.Length - szint];
                    }
                }
            }
            return "nincs";
        }

        private static void Feladat3()
        {
            Console.WriteLine("3. feladat: Domainek száma: {0}", domainIpParok.Count);
        }

        private static void Feladat2()
        {
            domainIpParok = new List<DomainIpPar>();
            using (var sr = new StreamReader("csudh.txt"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string[] sor = sr.ReadLine().Split(';');
                    string domain_name = sor[0];
                    string ip_address = sor[1];
                    var d = new DomainIpPar(domain_name, ip_address);
                    domainIpParok.Add(d);
                }
            }
        }
    }
}
