﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UP_2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TRmontEntities : DbContext
    {
        public TRmontEntities()
            : base("name=TRmontEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Должность_> Должность_ { get; set; }
        public virtual DbSet<Запчасти_> Запчасти_ { get; set; }
        public virtual DbSet<Заявка_> Заявка_ { get; set; }
        public virtual DbSet<Комментарии_> Комментарии_ { get; set; }
        public virtual DbSet<Модели_> Модели_ { get; set; }
        public virtual DbSet<Оргтехника_> Оргтехника_ { get; set; }
        public virtual DbSet<Пользователи_> Пользователи_ { get; set; }
        public virtual DbSet<Проблемы> Проблемы { get; set; }
        public virtual DbSet<C_Статус_заявки__> C_Статус_заявки__ { get; set; }
    }
}
