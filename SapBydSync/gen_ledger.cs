//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SapBydSync
{
    using System;
    using System.Collections.Generic;
    
    public partial class gen_ledger
    {
        public Nullable<System.DateTime> created_date { get; set; }
        public Nullable<System.DateTime> changed_date { get; set; }
        public string jour_id { get; set; }
        public string jour_item_id { get; set; }
        public string jour_type { get; set; }
        public string bus_part_addr { get; set; }
        public string chart_of_act { get; set; }
        public string cus_code1 { get; set; }
        public string cus_code2 { get; set; }
        public string cus_code3 { get; set; }
        public Nullable<int> debit_credit { get; set; }
        public string employee_id { get; set; }
        public Nullable<int> fiscal_year { get; set; }
        public string gl_acct { get; set; }
        public string gl_acct_type { get; set; }
        public Nullable<System.DateTime> post_date { get; set; }
        public string prod_id { get; set; }
        public Nullable<long> comp_cur_amt { get; set; }
        public Nullable<long> item_cur_amt { get; set; }
        public Nullable<long> tran_cur_amt { get; set; }
        public Nullable<long> val_qty_unt { get; set; }
        public string C_uid { get; set; }
    
        public virtual journal journal { get; set; }
    }
}
