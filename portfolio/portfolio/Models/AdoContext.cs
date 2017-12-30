namespace portfolio.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AdoContext : DbContext
    {
        // Контекст настроен для использования строки подключения "AdoContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "portfolio.Models.AdoContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "AdoContext" 
        // в файле конфигурации приложения.
        public AdoContext()
            : base("name=AdoContext")
        {

        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<Prices> Prices { get; set; }
        public virtual DbSet<SocialLinks> SocialLinks { get; set; }
        public virtual DbSet<Topics> Topics { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Works> Works { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}