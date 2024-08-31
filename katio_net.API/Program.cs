using Katio.Business.Interface;
using Katio.Business.Services;
using katio_net.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<KatioContext>(
    opt => opt.UseInMemoryDatabase("Katio"));

    
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();



var app = builder.Build();

PopulateDB(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

#region DB Population

async void PopulateDB(WebApplication app)
{
    using(var scope = app.Services.CreateAsyncScope())
    {
        var AuthorService = scope.ServiceProvider.GetService<IAuthorService>();
        await AuthorService.CreateAuthor(new Katio.Data.Models.Author{
            Name = "Gabriel",
            LastName = "García Márques",
            Country = "Colombia",
            BirthDate = new DateOnly (1940, 03, 03) 
        });

        var bookService = scope.ServiceProvider.GetRequiredService<IBookService>();
        await bookService.CreateBook(new Katio.Data.Models.Books{
            Title = "Cien años de soledad",
            ISBN10 = "8420471836",
            ISBN13 = "978-8420471839",
            Published = new DateTime(1967, 06, 05),
            Edition = "RAE Obra Académica",
            DeweyIndex = "800",
            AuthorId = 1
        });

        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Huellas",
            ISBN10 = "9584277278",
            ISBN13 = "978-958427275",
            Published = new DateTime(2019, 01, 01),
            Edition = "1ra Edicion",
            DeweyIndex = "800"
        });

        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "María",
            ISBN10 = "14802722922",
            ISBN13 = "978-148027292",
            Published = new DateTime(1867, 01, 01),
            Edition = "1ra edición",
            DeweyIndex = "800"
        });

        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Mexico Gothic",
            ISBN10 = "8420471836",
            ISBN13 = "978-05256620785",
            Published = new DateTime(2020, 06, 30),
            Edition = "Del Rey",
            DeweyIndex = "800"
        });

        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Sin remedio",
            ISBN10 = "3161484100",
            ISBN13 = "978-3161484100",
            Published = new DateTime(1984, 01, 01),
            Edition = "Alfaguara",
            DeweyIndex = "800"
        });

        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Delirio",
            ISBN10 = "9587041453",
            ISBN13 = "978-9587041453",
            Published = new DateTime(2004, 01, 01),
            Edition = "Alfaguara",
            DeweyIndex = "800"
        });

        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Infinito en un junco",
            ISBN10 = "8417860790",
            ISBN13 = "9788417860790",
            Published = new DateTime(2019, 01, 01),
            Edition = "Siruela",
            DeweyIndex = "800"
        });

        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "El olvido que seremos",
            ISBN10 = "8420426402",
            ISBN13 = "978-8420426402",
            Published = new DateTime(2017, 10, 16),
            Edition = "Alfaguara",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Sin remedio",
            ISBN10 = "3161484100",
            ISBN13 = "978-3161484100",
            Published = new DateTime(1984,01,01),
            Edition = "Alfaguara",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Delirio",
            ISBN10 = "9587041453",
            ISBN13 = "9789587041453",
            Published = new DateTime(2004, 01, 01),
            Edition = "Alfaguara",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Infinito en un junco",
            ISBN10 = "8417860790",
            ISBN13 = "9788417860790",
            Published = new DateTime(2019, 01, 01),
            Edition = "Siruela",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "El olvido que seremos",
            ISBN10 = "8420426402",
            ISBN13 = "978-8420426402",
            Published = new DateTime(2017, 10, 06),
            Edition = "Alfaguara",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "El país de la canela",
            ISBN10 = "8439738831",
            ISBN13 = "978-8439738831",
            Published = new DateTime(2020, 08, 22),
            Edition = "ndom House",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Lo que no tiene nombre",
            ISBN10 = "6287659216",
            ISBN13 = "978-6287659216",
            Published = new DateTime(2024, 03, 19),
            Edition = "Alfaguara",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "El ruido de las cosas al caer",
            ISBN10 = "6073137515",
            ISBN13 = "978-6073137515",
            Published = new DateTime(2015, 12, 29),
            Edition = "ebolsillo",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "El síndrome de Ulises",
            ISBN10 = "9584211903",
            ISBN13 = "978-9584211903",
            Published = new DateTime(2005, 03, 30),
            Edition = "Planeta",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "La puta de Babilonia",
            ISBN10 = "6073158855",
            ISBN13 = "978-6073158855",
            Published = new DateTime(2018, 01, 30),
            Edition = "ebolsillo",
            DeweyIndex = "800"

        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Memorias de un sinvergüenza de siete suelas",
            ISBN10 = "9504932611",
            ISBN13 = "978-9504932611",
            Published = new DateTime(2012, 01, 01),
            Edition = "Planeta",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Satanás",
            ISBN10 = "9584273543",
            ISBN13 = "978-9584273543",
            Published = new DateTime(2018, 01, 01),
            Edition = "Planeta DeAgostini Comic",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "It (Eso)",
            ISBN10 = "0525566267",
            ISBN13 = "978-0525566267",
            Published = new DateTime(2019, 01, 27),
            Edition = "Vinntage Espanol",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "El Resplandor",
            ISBN10 = "0593311233",
            ISBN13 = "978-0593311233",
            Published = new DateTime(2005, 08, 25),
            Edition = "Vintage",
            DeweyIndex = "800"

        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Cujo",
            ISBN10 = "1501192241",
            ISBN13 = "978-1501192241",
            Published = new DateTime(2018, 02, 20),
            Edition = "Scribner",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Trono de Cristal",
            ISBN10 = "8890981547",
            ISBN13 = "979-8890981547",
            Published = new DateTime(2022, 05, 13),
            Edition = "Alfaguara",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Entrevista con el Vampiro",
            ISBN10 = "6073198929",
            ISBN13 = "978-6073198929",
            Published = new DateTime(2021, 05, 18),
            Edition = "de Bolsillo",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Anniquilación",
            ISBN10 = "0374104092",
            ISBN13 = "978-0374104092",
            Published = new DateTime(2014, 02, 04),
            Edition = "G Originals",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Autoridad",
            ISBN10 = "0374104108",
            ISBN13 = "978-0374104108",
            Published = new DateTime(2014, 05, 06),
            Edition = "G Originals",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Aceptación",
            ISBN10 = "374104115",
            ISBN13 = "978-0374104115",
            Published = new DateTime(2014, 09, 02),
            Edition = "G Originals",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Historia de Colombia y sus oligarquias",
            ISBN10 = "9584268754",
            ISBN13 = "978-9584268754",
            Published = new DateTime(2019, 01, 01),
            Edition = "Crítica",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "El problema de los tres cuerpos",
            ISBN10 = "8466659734",
            ISBN13 = "978-8466659734",
            Published = new DateTime(2016, 11, 01),
            Edition = "Nova",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "El Bosque Oscuro",
            ISBN10 = "978-8413146454",
            ISBN13 = "978-8413146454",
            Published = new DateTime(2024, 05, 01),
            Edition = "Nova",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "El fin de la muerte",
            ISBN10 = "8417347017",
            ISBN13 = "978-8417347017",
            Published = new DateTime(2018, 08, 01),
            Edition = "1",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Crimen y Castigo",
            ISBN10 = "8872132677",
            ISBN13 = "979-8872132677",
            Published = new DateTime(1866, 12, 01),
            Edition = "dependiente",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Las obras de Leo Tolstoy",
            ISBN10 = "1016243247",
            ISBN13 = "978-1016243247",
            Published = new DateTime(2022, 10, 27),
            Edition = "CLassic",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Historias Cortas",
            ISBN10 = "9389717105",
            ISBN13 = "978-9389717105",
            Published = new DateTime(2019, 01, 12),
            Edition = "Finngerprint",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Trilogía Fundación",
            ISBN10 = "8499083209",
            ISBN13 = "978-8499083209",
            Published = new DateTime(2023, 03, 23),
            Edition = "debolsillo",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "El libro de la selva",
            ISBN10 = "8467871029",
            ISBN13 = "978-8467871029",
            Published = new DateTime(1894, 01, 01),
            Edition = "Classic",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "El señor de los anillos",
            ISBN10 = "8445013830",
            ISBN13 = "978-8445013830",
            Published = new DateTime(2023, 11, 02),
            Edition = "Fantasia epica",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Juego de tronos",
            ISBN10 = "1644736135",
            ISBN13 = "978-1644736135",
            Published = new DateTime(2022, 06, 21),
            Edition = "Vintage",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Duna",
            ISBN10 = "6073194648",
            ISBN13 = "978-6073194648",
            Published = new DateTime(2020, 11, 07),
            Edition = "Classic",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "El extranjero",
            ISBN10 = "1518660016",
            ISBN13 = "978-1518660016",
            Published = new DateTime(2015, 10, 06),
            Edition = "Ciencia ficcion",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "El cuento de la criada",
            ISBN10 = "8498388015",
            ISBN13 = "978-8498388015",
            Published = new DateTime(2017, 06, 17),
            Edition = "Salamandra",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Asesinato en el Orient Express",
            ISBN10 = "6070743986",
            ISBN13 = "978-6070743986",
            Published = new DateTime(2022, 02, 15),
            Edition = "Planeta",
            DeweyIndex = "800"
        });
        await bookService.CreateBook(new Katio.Data.Models.Books
        {
            Title = "Cuentos de Terramar",
            ISBN10 = "8467437560",
            ISBN13 = "978-8467437560",
            Published = new DateTime(2007, 01, 01),
            Edition = "Planeta",
            DeweyIndex = "800"
        });

    }
}

#endregion

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
