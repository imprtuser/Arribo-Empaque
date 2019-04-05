using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArriboEmpaque.Classes
{
    public class FolioDetails
    {
        public int idWnW { get; set; }
        public int iBoxes { get; set; }

        public String toXML()
        {
            return "<FolioDetail>" +
                          "<idWnW>" + idWnW + "</idWnW>" +
                          "<iBoxes>" + iBoxes + "</iBoxes>" +
                 "</FolioDetail>";
        }
    }
}
