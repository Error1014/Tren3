//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tren3
{
    using System;
    using System.Collections.Generic;
    
    public partial class Material
    {
        public int ID { get; set; }
        public string Number { get; set; }
        public string Title { get; set; }
        public Nullable<int> EdIzmerID { get; set; }
        public Nullable<int> Ostat { get; set; }
        public Nullable<int> StorageID { get; set; }
    
        public virtual EdIzmer EdIzmer { get; set; }
        public virtual Storage Storage { get; set; }
    }
}
