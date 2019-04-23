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

        //Nombre de la base de datos local
        public static String dbLocalName = "ArriboEmpaqueLocalDB";

        //Rutas para webservice de pruebas y produccion
        public static String pathWS = "http://planning.naturesweet.com/wspackwedge/WSArriboService.asmx";
        //public static String pathWS = "http://192.168.167.8:289/WSArriboService.asmx/";

        //VERSION 4.0.1 WEBMETHODS
        public static String webMethodLogin             = "Login_401";
        public static String webMethodPingWS            = "pingToWS_401";
        public static String webMethodGetPlants         = "getPlants_401";
        public static String webMethodGetFoliosByID     = "getInfoFoliosByID_401";
        public static String webMethodGetInfoFolio      = "getInfoFolio_401";
        public static String webMethodSaveInfoFolio     = "saveInfoFolio_401";
        public static String webMethodGetFolios         = "getFolios_401";
        public static String webMethodFilterFoliosByID  = "filterFoliosByID_401";
        public static String webMethodGetNetLibsPesaje  = "getNetLibsPesaje_401";

    }
}
