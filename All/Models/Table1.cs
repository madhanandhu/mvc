//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace All.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Table1
    {
        public int SId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Id { get; set; }
    
        public virtual Table Table { get; set; }
    }
}
