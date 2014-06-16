//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIMPEDA_V01.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pegawai
    {
        public Pegawai()
        {
            this.Transaksis = new HashSet<Transaksi>();
        }
    
        public string idPegawai { get; set; }
        public int idJurusan { get; set; }
        public string namaPegawai { get; set; }
        public string jabatan { get; set; }
        public string teleponPegawai { get; set; }
        public string alamatPegawai { get; set; }
        public string emailPegawai { get; set; }
        public Nullable<int> poinPunishmetPegawai { get; set; }
        public string barcodeImagePegawai { get; set; }
        public string barcodePegawai { get; set; }
        public string password_Pegawai { get; set; }
    
        public virtual JurusanInstansi JurusanInstansi { get; set; }
        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
