//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QL_KhoaHocOnl.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class QUIZZES
    {
        public string QUIZID { get; set; }
        public string MA_COURSE { get; set; }
        public string TITLE_QUIZID { get; set; }
        public string DESCRIPTION_QUIZID { get; set; }
        public Nullable<System.DateTime> DUEDATE_QUIZ { get; set; }
        public Nullable<int> QUESTION { get; set; }
        public Nullable<double> POINTS_QUIZ { get; set; }
    
        public virtual COURSE COURSE { get; set; }
    }
}
