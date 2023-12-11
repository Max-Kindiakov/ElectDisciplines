using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ElectDisciplinesAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingDisciplineTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Course = table.Column<int>(type: "int", nullable: false),
                    Teacher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Course", "CreatedDate", "Description", "ImageUrl", "Name", "Rate", "Teacher", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2023, 12, 10, 16, 13, 1, 222, DateTimeKind.Local).AddTicks(4968), "", "https://my.kpi.ua/static/images/logo_fiot.png", "Практикум з Linux", 9.0, "Іванов І.П.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2023, 12, 10, 16, 13, 1, 222, DateTimeKind.Local).AddTicks(5022), "Предмет навчальної дисципліни – закономірності стосунків та поведінки людей у конфліктних ситуаціях, причини виникнення конфліктів і методи їх подолання.", "https://my.kpi.ua/static/images/logo_fiot.png", "Психологія конфлікту", 7.2000000000000002, "Петрова О.А.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, new DateTime(2023, 12, 10, 16, 13, 1, 222, DateTimeKind.Local).AddTicks(5026), "футбол, волейбол, баксетбол, теніс, настільний теніс", "https://my.kpi.ua/static/images/logo_fiot.png", "Ігрові види спорту", 8.0, "Сидоренко С.В.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 3, new DateTime(2023, 12, 10, 16, 13, 1, 222, DateTimeKind.Local).AddTicks(5030), "Даний курс орієнтований на вивчення Java як людьми з мінімальним рівнем знання програмування так і людьми, які хочуть покращити свої знання з певних нюансів мови. Після його завершення ви зможете писати програми на Java, і будете мати основу, необхідну для подальшого поглиблення своїх знань та навичок в програмуванні.", "https://my.kpi.ua/static/images/logo_fiot.png", "Мова програмування Java", 9.3000000000000007, "Коваленко Л.М.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 3, new DateTime(2023, 12, 10, 16, 13, 1, 222, DateTimeKind.Local).AddTicks(5034), "Навчальна та робоча програми дисципліни, Силабус, РСО, контрольні завдання, методичні рекомендації до виконання комп’ютерного практикуму. Навчальний посібник «CAD-системи та мультимедіа».   ", "https://my.kpi.ua/static/images/logo_fiot.png", "Комп’ютерна графіка та обробка зображень", 9.0, "Мельник І.І.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 3, new DateTime(2023, 12, 10, 16, 13, 1, 222, DateTimeKind.Local).AddTicks(5038), "Працювати з системою, використовуючи командний рядок Shell;  управляти файлами, каталогами, правами доступу, користувачами та групами, процесами, журналюванням  операцій в Linux; конфігурувати систему через налаштування пакетів, апаратного забезпечення, файлових систем, графічного середовища, мереж", "https://my.kpi.ua/static/images/logo_fiot.png", "Linux", 10.0, "Захарчук Г.С.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 3, new DateTime(2023, 12, 10, 16, 13, 1, 222, DateTimeKind.Local).AddTicks(5042), "Програма курсу передбачає:\r\n\r\nвивчення архітектури платформи Android\r\nрозробку нативних додатків на мові Java\r\nроботу з файловою системою та базами даних SQLite\r\nдоступ до глобальної мережі та розробки веб-додатку\r\nопанування роботи з датчиками та мультимедіа", "https://my.kpi.ua/static/images/logo_fiot.png", "Розробка мобільних застосувань під Android", 10.0, "Кузьменко К.О.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 3, new DateTime(2023, 12, 10, 16, 13, 1, 222, DateTimeKind.Local).AddTicks(5046), "", "https://my.kpi.ua/static/images/logo_fiot.png", "Робота з даними в хмарних середовищах", 5.5, "Григорчук Т.І.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 3, new DateTime(2023, 12, 10, 16, 13, 1, 222, DateTimeKind.Local).AddTicks(5051), "розробка систем управління автономними мобільними роботами та дронами;\r\nвирішення задач навігації та локалізації для інших безпілотних систем.", "https://my.kpi.ua/static/images/logo_fiot.png", "Бази даних безпілотних систем та автономної робототехніки", 7.0, "Шевченко О.Г.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 3, new DateTime(2023, 12, 10, 16, 13, 1, 222, DateTimeKind.Local).AddTicks(5055), "", "https://my.kpi.ua/static/images/logo_fiot.png", "Професійне використання SQL та PL/SQL на прикладі РСУБД Oracle 11g", 9.4000000000000004, "Лисенко Н.В.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disciplines");
        }
    }
}
