//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OBS.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Not_
    {
        public int NotID { get; set; }
        public Nullable<int> vize { get; set; }
        public Nullable<int> final { get; set; }
        public Nullable<double> ortalama { get; set; }
        public string harfnotu { get; set; }
        public string OgrtID { get; set; }
        public string DersKodu { get; set; }
        public string OgrNo { get; set; }
    
        public virtual Der Der { get; set; }
        public virtual Ogrenci Ogrenci { get; set; }
        public virtual OgretimElemani OgretimElemani { get; set; }
    }
}
