//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace suleyman
{
    using System;
    using System.Collections.Generic;
    
    public partial class User1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User1()
        {
            this.FingerPrints = new HashSet<FingerPrint>();
        }
    
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public int Department_Id { get; set; }
        public int Authority_Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Country_Id { get; set; }
    
        public virtual Authority Authority { get; set; }
        public virtual Department Department { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FingerPrint> FingerPrints { get; set; }
        public virtual Country Country1 { get; set; }
    }
}
