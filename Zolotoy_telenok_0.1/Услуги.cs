//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zolotoy_telenok_0._1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Услуги
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Услуги()
        {
            this.Запись = new HashSet<Запись>();
        }
    
        public int ИД_Услуги { get; set; }
        public string Наименование { get; set; }
        public string Описание { get; set; }
        public decimal Цена { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Запись> Запись { get; set; }
    }
}
