//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace курсовая
{
    using System;
    using System.Collections.Generic;
    
    public partial class Предметы
    {
        public Предметы()
        {
            this.Оценки = new HashSet<Оценки>();
        }
    
        public int Id { get; set; }
        public string НазваниеПредмета { get; set; }
    
        public virtual ICollection<Оценки> Оценки { get; set; }
    }
}
