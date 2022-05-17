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
            workcenterURI = "https://my361178.sapbydesign.com/sap/byd/odata/analytics/ds/";

            uriAPI = new Dictionary<string, string>();

            uriAPI["GeneralLedger"] = workcenterURI + "Finglau02.svc/Finglau02?$select=C_Fiscyear,C_Chofaccts,C_AddrBusPart,C_EmployeeUuid,C_CustomCode1,C_AccDocUuid,C_CustomCode2,C_CustomCode3,C_Accdoctype,C_AccDocItUuid,C_LaChangeDate,C_CreationDate,C_PostingDate,C_ProductUuid,C_Glacct,C_Debitcredit,C_GlacctTc,K_Amtlit,K_ValQuantity,K_Amttra,K_Amtcomp&$format=json";
            uriAPI["JournalEntry"] = workcenterURI + "Finglau03.svc/Finglau03?$select=C_AccDocUuid,C_SaLcIdUuid,C_SaLcDateTime,C_SaCrIdUuid,C_CreationDate,C_GlacctTc,C_Fiscyear,C_Debitcredit,C_Glacct,C_AccDocId,K_Amtcomp,K_Amttra,K_Amtlit&$format=json";

            securityAPI = new Dictionary<string, string>();

            securityAPI["Username"] = "_ADMIN";
            securityAPI["Password"] = "Admin123";
        }
    }
}