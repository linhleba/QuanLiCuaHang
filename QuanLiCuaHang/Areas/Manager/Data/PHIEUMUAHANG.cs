
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
    
public partial class PHIEUMUAHANG
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public PHIEUMUAHANG()
    {

        this.CHITIET_PMH = new HashSet<CHITIET_PMH>();

    }


    public int MaPMH { get; set; }

     
    public System.DateTime NgayLap { get;  set;  }

    public decimal TongTien { get; set; }

    public int MaNCC { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<CHITIET_PMH> CHITIET_PMH { get; set; }

    public virtual NHACUNGCAP NHACUNGCAP { get; set; }

}

}
