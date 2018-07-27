//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bin()
        {
            this.BinLogs = new HashSet<BinLog>();
            this.WasteTransferLogs = new HashSet<WasteTransferLog>();
        }
    
        public int BinId { get; set; }
        public int BinTypeId { get; set; }
        public double CurrentCapacity { get; set; }
        public bool IsInUse { get; set; }
        public Nullable<int> BuildingId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinLog> BinLogs { get; set; }
        public virtual Building Building { get; set; }
        public virtual LUT_BinType LUT_BinType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WasteTransferLog> WasteTransferLogs { get; set; }
    }
}
