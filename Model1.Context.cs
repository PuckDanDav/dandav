﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Группа> Группа { get; set; }
        public DbSet<Оценки> Оценки { get; set; }
        public DbSet<Пользователи> Пользователи { get; set; }
        public DbSet<Предметы> Предметы { get; set; }
        public DbSet<Роли> Роли { get; set; }
        public DbSet<Студенты> Студенты { get; set; }
    }
}
