//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExpenseApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AddExpense
    {
        public int expenseId { get; set; }
        public string expenseName { get; set; }
        public Nullable<int> expensePrice { get; set; }
        public Nullable<System.DateTime> expenseDate { get; set; }
        public string expenseAim { get; set; }
        public Nullable<int> userId { get; set; }
        public string expenseApproval { get; set; }
        public string approvalInfo { get; set; }
        public string expenseCurrency { get; set; }
    
        public virtual User User { get; set; }
    }
}
