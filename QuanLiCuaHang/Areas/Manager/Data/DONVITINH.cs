
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace QuanLiCuaHang.Areas.Manager.Data
{

using System;
    using System.Collections.Generic;
    
public partial class DONVITINH
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public DONVITINH()
    {

        this.LOAISANPHAMs = new HashSet<LOAISANPHAM>();

    }


    public int MaDVT { get; set; }

    public string TenDVT { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<LOAISANPHAM> LOAISANPHAMs { get; set; }

}

}
