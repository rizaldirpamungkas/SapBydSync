using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SapBydSync.Miscs
{
    public class Parameter
    {
        public IDictionary<string, string> uriAPI;
        public IDictionary<string, string> securityAPI;

        public string workcenterURI;

        public Parameter()
        {
            workcenterURI = "";

            uriAPI = new Dictionary<string, string>();

            uriAPI["GeneralLedger"] = workcenterURI+"";
            uriAPI["JournalEntry"] = workcenterURI+"";

            securityAPI = new Dictionary<string, string>();

            securityAPI["Username"] = "";
            securityAPI["Password"] = "";
        }
    }
}