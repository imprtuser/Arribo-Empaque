using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArriboEmpaque.Classes
{
    public class Folio
    {
        public int idWnW { get; set; }
        public decimal dNet { get; set; }
        public int iBoxes { get; set; }
        public String vUserCreated { get; set; }
        public String folioCode { get; set; }
        public String vDate { get; set; }
        public String vPlant { get; set; }
        public String vGreenhouse { get; set; }
        public String vQuality { get; set; }
        public String vProduct { get; set; }
        public int isGP { get; set; }
        public int idTarePlantPallet { get; set; }
        public int idTarePlantCaja { get; set; }

        public String toXML()
        {
            return "<data>" +
                        "<folio>" +
                            "<idWnW>" + idWnW + "</idWnW>" +
                            "<Net>" + dNet + "</Net>" +
                            "<Boxes>" + iBoxes + "</Boxes>" +
                            "<UserCreated>" + vUserCreated + "</UserCreated>" +
                            "<FolioCode>" + folioCode + "</FolioCode>" +

                        "</folio>" +
                   "</data>";
        }
    }
}
