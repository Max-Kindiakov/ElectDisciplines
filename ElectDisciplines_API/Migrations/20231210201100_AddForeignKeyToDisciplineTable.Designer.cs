﻿// <auto-generated />
using System;
using ElectDisciplines_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElectDisciplinesAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231210201100_AddForeignKeyToDisciplineTable")]
    partial class AddForeignKeyToDisciplineTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ElectDisciplines_API.Models.Discipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Course")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<string>("Teacher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Disciplines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Course = 2,
                            CreatedDate = new DateTime(2023, 12, 10, 22, 11, 0, 666, DateTimeKind.Local).AddTicks(4942),
                            Description = "",
                            ImageUrl = "https://my.kpi.ua/static/images/logo_fiot.png",
                            Name = "Практикум з Linux",
                            Rate = 9.0,
                            Teacher = "Іванов І.П.",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Course = 2,
                            CreatedDate = new DateTime(2023, 12, 10, 22, 11, 0, 666, DateTimeKind.Local).AddTicks(4987),
                            Description = "Предмет навчальної дисципліни – закономірності стосунків та поведінки людей у конфліктних ситуаціях, причини виникнення конфліктів і методи їх подолання.",
                            ImageUrl = "https://my.kpi.ua/static/images/logo_fiot.png",
                            Name = "Психологія конфлікту",
                            Rate = 7.2000000000000002,
                            Teacher = "Петрова О.А.",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Course = 2,
                            CreatedDate = new DateTime(2023, 12, 10, 22, 11, 0, 666, DateTimeKind.Local).AddTicks(4990),
                            Description = "футбол, волейбол, баксетбол, теніс, настільний теніс",
                            ImageUrl = "https://my.kpi.ua/static/images/logo_fiot.png",
                            Name = "Ігрові види спорту",
                            Rate = 8.0,
                            Teacher = "Сидоренко С.В.",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Course = 3,
                            CreatedDate = new DateTime(2023, 12, 10, 22, 11, 0, 666, DateTimeKind.Local).AddTicks(4992),
                            Description = "Даний курс орієнтований на вивчення Java як людьми з мінімальним рівнем знання програмування так і людьми, які хочуть покращити свої знання з певних нюансів мови. Після його завершення ви зможете писати програми на Java, і будете мати основу, необхідну для подальшого поглиблення своїх знань та навичок в програмуванні.",
                            ImageUrl = "https://my.kpi.ua/static/images/logo_fiot.png",
                            Name = "Мова програмування Java",
                            Rate = 9.3000000000000007,
                            Teacher = "Коваленко Л.М.",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Course = 3,
                            CreatedDate = new DateTime(2023, 12, 10, 22, 11, 0, 666, DateTimeKind.Local).AddTicks(4995),
                            Description = "Навчальна та робоча програми дисципліни, Силабус, РСО, контрольні завдання, методичні рекомендації до виконання комп’ютерного практикуму. Навчальний посібник «CAD-системи та мультимедіа».   ",
                            ImageUrl = "https://my.kpi.ua/static/images/logo_fiot.png",
                            Name = "Комп’ютерна графіка та обробка зображень",
                            Rate = 9.0,
                            Teacher = "Мельник І.І.",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            Course = 3,
                            CreatedDate = new DateTime(2023, 12, 10, 22, 11, 0, 666, DateTimeKind.Local).AddTicks(4997),
                            Description = "Працювати з системою, використовуючи командний рядок Shell;  управляти файлами, каталогами, правами доступу, користувачами та групами, процесами, журналюванням  операцій в Linux; конфігурувати систему через налаштування пакетів, апаратного забезпечення, файлових систем, графічного середовища, мереж",
                            ImageUrl = "https://my.kpi.ua/static/images/logo_fiot.png",
                            Name = "Linux",
                            Rate = 10.0,
                            Teacher = "Захарчук Г.С.",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            Course = 3,
                            CreatedDate = new DateTime(2023, 12, 10, 22, 11, 0, 666, DateTimeKind.Local).AddTicks(5000),
                            Description = "Програма курсу передбачає:\r\n\r\nвивчення архітектури платформи Android\r\nрозробку нативних додатків на мові Java\r\nроботу з файловою системою та базами даних SQLite\r\nдоступ до глобальної мережі та розробки веб-додатку\r\nопанування роботи з датчиками та мультимедіа",
                            ImageUrl = "https://my.kpi.ua/static/images/logo_fiot.png",
                            Name = "Розробка мобільних застосувань під Android",
                            Rate = 10.0,
                            Teacher = "Кузьменко К.О.",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            Course = 3,
                            CreatedDate = new DateTime(2023, 12, 10, 22, 11, 0, 666, DateTimeKind.Local).AddTicks(5002),
                            Description = "",
                            ImageUrl = "https://my.kpi.ua/static/images/logo_fiot.png",
                            Name = "Робота з даними в хмарних середовищах",
                            Rate = 5.5,
                            Teacher = "Григорчук Т.І.",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 9,
                            Course = 3,
                            CreatedDate = new DateTime(2023, 12, 10, 22, 11, 0, 666, DateTimeKind.Local).AddTicks(5004),
                            Description = "розробка систем управління автономними мобільними роботами та дронами;\r\nвирішення задач навігації та локалізації для інших безпілотних систем.",
                            ImageUrl = "https://my.kpi.ua/static/images/logo_fiot.png",
                            Name = "Бази даних безпілотних систем та автономної робототехніки",
                            Rate = 7.0,
                            Teacher = "Шевченко О.Г.",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 10,
                            Course = 3,
                            CreatedDate = new DateTime(2023, 12, 10, 22, 11, 0, 666, DateTimeKind.Local).AddTicks(5007),
                            Description = "",
                            ImageUrl = "https://my.kpi.ua/static/images/logo_fiot.png",
                            Name = "Професійне використання SQL та PL/SQL на прикладі РСУБД Oracle 11g",
                            Rate = 9.4000000000000004,
                            Teacher = "Лисенко Н.В.",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ElectDisciplines_API.Models.DisciplineNumber", b =>
                {
                    b.Property<int>("DisciplineNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DisciplineId")
                        .HasColumnType("int");

                    b.Property<string>("SpecialDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DisciplineNo");

                    b.HasIndex("DisciplineId");

                    b.ToTable("DisciplineNumbers");
                });

            modelBuilder.Entity("ElectDisciplines_API.Models.DisciplineNumber", b =>
                {
                    b.HasOne("ElectDisciplines_API.Models.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discipline");
                });
#pragma warning restore 612, 618
        }
    }
}
