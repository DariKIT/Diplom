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
    
    public partial class Клиент
    {
        public int ИД_Клиента { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public Nullable<int> ИдУслуги { get; set; }
        public Nullable<System.DateTime> Время { get; set; }
        public string Телефон { get; set; }
        public Nullable<int> ИдМашины { get; set; }
    
        public virtual Машина Машина { get; set; }
        public virtual Услуги Услуги { get; set; }
    }
}
