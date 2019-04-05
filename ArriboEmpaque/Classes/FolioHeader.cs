using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArriboEmpaque.Classes
{
    public class FolioHeader
    {
        public int idHeader { get; set; }
        public int iBoxes { get; set; }
        public decimal dGrossLibs { get; set; }
        public int idTarePlant { get; set; }
        public int idTareBox { get; set; }

        public String toXML()
        {
            return "<data>" +
                     "<FolioHeader>" +
                          "<idHeader>" + idHeader + "</idHeader>" +
                          "<iBoxes>" + iBoxes + "</iBoxes>" +
                          "<dGrossLibs>" + dGrossLibs + "</dGrossLibs>" +
                          "<idTarePlant>" + idTarePlant + "</idTarePlant>" +
                          "<idTareBox>" + idTareBox + "</idTareBox>" +
                     "</FolioHeader>" +
                 "</data>";
        }
    }
}
