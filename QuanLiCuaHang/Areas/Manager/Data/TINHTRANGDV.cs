
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
    
public partial class TINHTRANGDV
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public TINHTRANGDV()
    {

        this.CHITIET_PHIEUDV = new HashSet<CHITIET_PHIEUDV>();

    }


    public int MaTinhTrangDV { get; set; }

    public string TenTinhTrang { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<CHITIET_PHIEUDV> CHITIET_PHIEUDV { get; set; }

}

}
