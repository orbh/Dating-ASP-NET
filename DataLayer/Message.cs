//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Message
    {
        public int ID { get; set; }
        public int SenderID { get; set; }
        public int RecieverID { get; set; }
        public string Message1 { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}