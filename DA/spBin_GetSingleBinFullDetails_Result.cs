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
    
    public partial class spBin_GetSingleBinFullDetails_Result
    {
        public int BinId { get; set; }
        public int BinTypeId { get; set; }
        public double CurrentCapacity { get; set; }
        public Nullable<int> BuildingId { get; set; }
        public string BinTypeDesc { get; set; }
        public double Capacity { get; set; }
        public double BinTrashDisposalArea { get; set; }
        public string BuildingAddress { get; set; }
        public Nullable<int> AreaId { get; set; }
        public string AreaDesc { get; set; }
    }
}