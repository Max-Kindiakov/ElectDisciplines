using ElectDisciplines_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectDisciplines_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<DisciplineNumber> DisciplineNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discipline>().HasData(
                               new Discipline()
                               {
                                   Id = 1,
                                   Name = "Практикум з Linux",
                                   Description = "",
                                   Course = 2,
                                   Teacher = "Іванов І.П.",
                                   Rate = 9,
                                   ImageUrl = "https://my.kpi.ua/static/images/logo_fiot.png",
                                   CreatedDate = DateTime.Now
                               },
                             new Discipline()
                             {
                                 Id = 2,
                                 Name = "Психологія конфлікту",
                                 Description = "Предмет навчальної дисципліни – закономірності стосунків та поведінки людей у конфліктних ситуаціях, причини виникнення конфліктів і методи їх подолання.",
                                 Course = 2,
                                 Teacher = "Петрова О.А.",
                                 Rate = 7.2,
                                 ImageUrl = "https://my.kpi.ua/static/images/logo_fiot.png",
                                 CreatedDate = DateTime.Now
                             },
                            new Discipline()
                            {
                                Id = 3,
                                Name = "Ігрові види спорту",
                                Description = "футбол, волейбол, баксетбол, теніс, настільний теніс",
                                Course = 2,
                                Teacher = "Сидоренко С.В.",
                                Rate = 8,
                                ImageUrl = "https://my.kpi.ua/static/images/logo_fiot.png",
                                CreatedDate = DateTime.Now
                            },
                           new Discipline()
                           {
                               Id = 4,
                               Name = "Мова програмування Java",
                               Description = "Даний курс орієнтований на вивчення Java як людьми з мінімальним рівнем знання програмування так і людьми, які хочуть покращити свої знання з певних нюансів мови. Після його завершення ви зможете писати програми на Java, і будете мати основу, необхідну для подальшого поглиблення своїх знань та навичок в програмуванні.",
                               Course = 3,
                               Teacher = "Коваленко Л.М.",
                               Rate =  9.3,
                               ImageUrl = "https://my.kpi.ua/static/images/logo_fiot.png",
                               CreatedDate = DateTime.Now
                           },
                           new Discipline()
                           {
                               Id = 5,
                               Name = "Комп’ютерна графіка та обробка зображень",
                               Description = "Навчальна та робоча програми дисципліни, Силабус, РСО, контрольні завдання, методичні рекомендації до виконання комп’ютерного практикуму. Навчальний посібник «CAD-системи та мультимедіа».   ",
                               Course = 3,
                               Teacher = "Мельник І.І.",
                               Rate = 9,
                               ImageUrl = "https://my.kpi.ua/static/images/logo_fiot.png",
                               CreatedDate = DateTime.Now
                           },
                           new Discipline()
                           {
                               Id = 6,
                               Name = "Linux",
                               Description = "Працювати з системою, використовуючи командний рядок Shell;  управляти файлами, каталогами, правами доступу, користувачами та групами, процесами, журналюванням  операцій в Linux; конфігурувати систему через налаштування пакетів, апаратного забезпечення, файлових систем, графічного середовища, мереж",
                               Course = 3,
                               Teacher = "Захарчук Г.С.",
                               Rate = 10,
                               ImageUrl = "https://my.kpi.ua/static/images/logo_fiot.png",
                               CreatedDate = DateTime.Now
                           },
                           new Discipline()
                           {
                               Id = 7,
                               Name = "Розробка мобільних застосувань під Android",
                               Description = "Програма курсу передбачає:\r\n\r\nвивчення архітектури платформи Android\r\nрозробку нативних додатків на мові Java\r\nроботу з файловою системою та базами даних SQLite\r\nдоступ до глобальної мережі та розробки веб-додатку\r\nопанування роботи з датчиками та мультимедіа",
                               Course = 3,
                               Teacher = "Кузьменко К.О.",
                               Rate = 10,
                               ImageUrl = "https://my.kpi.ua/static/images/logo_fiot.png",
                               CreatedDate = DateTime.Now
                           },
                           new Discipline()
                           {
                               Id = 8,
                               Name = "Робота з даними в хмарних середовищах",
                               Description = "",
                               Course = 3,
                               Teacher = "Григорчук Т.І.",
                               Rate = 5.5,
                               ImageUrl = "https://my.kpi.ua/static/images/logo_fiot.png",
                               CreatedDate = DateTime.Now
                           },
                           new Discipline()
                           {
                               Id = 9,
                               Name = "Бази даних безпілотних систем та автономної робототехніки",
                               Description = "розробка систем управління автономними мобільними роботами та дронами;\r\nвирішення задач навігації та локалізації для інших безпілотних систем.",
                               Course = 3,
                               Teacher = "Шевченко О.Г.",
                               Rate = 7,
                               ImageUrl = "https://my.kpi.ua/static/images/logo_fiot.png",
                               CreatedDate = DateTime.Now
                           },
                           new Discipline()
                           {
                               Id = 10,
                               Name = "Професійне використання SQL та PL/SQL на прикладі РСУБД Oracle 11g",
                               Description = "",
                               Course = 3,
                               Teacher = "Лисенко Н.В.",
                               Rate = 9.4,
                               ImageUrl = "https://my.kpi.ua/static/images/logo_fiot.png",
                               CreatedDate = DateTime.Now
                           });
        }
    }
}
