//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToFast.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Subject
    {
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public string SubjectName { get; set; }
    
        public virtual Teacher Teacher { get; set; }
    }
}
