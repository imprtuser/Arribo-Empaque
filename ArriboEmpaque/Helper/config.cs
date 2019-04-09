using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace arrivov2.helper {

    class config {

        public static String dbLocalName = "ArriboEmpaqueLocalDB";
        //public static String pathWS = "http://planning.naturesweet.com/wspackwedge/WSArriboService.asmx";
        public static String pathWS = "http://192.168.167.8:289/WSArriboService.asmx/";
        public static String webMethodLogin                      = "Login";
        public static String webMethodDescargarComprobarConexion = "testCon";
        public static String webMethodGetInfoFolio = "getInfoFolio";
        public static String webMethodSaveInfoFolio = "saveInfoFolio";
        public static String webMethodPingWS = "pingToWS";
        public static String webMethodGetFolios = "getFolios";
        public static String webMethodGetPlants = "getPlants";
        public static String webMethodGetFoliosByID = "getInfoFoliosByID";
        public static String webMethodSavePorts = "savePorts";
        public static String webMethodGetPorts = "getPorts";
    }
}
