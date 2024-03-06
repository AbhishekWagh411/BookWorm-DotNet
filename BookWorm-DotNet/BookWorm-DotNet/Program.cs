using BookWorm_DotNet.DAL;
using BookWorm_DotNet.Controllers;
using BookWorm_DotNet.Data;
using BookWorm_DotNet.Services;
using Microsoft.EntityFrameworkCore;


namespace BookWorm_DotNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddControllers();

            builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IMyShelfRepository, MyShelfRepository>();
            builder.Services.AddScoped<IRoyaltyCalculationRepository, RoyaltyCalculationRepository>();
            builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            builder.Services.AddScoped<IInvoiceDetailRepository, InvoiceDetailRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            builder.Services.AddScoped<IProductUrlRepository, ProductUrlRepository>();
            builder.Services.AddScoped<IProductBeneficiaryRepository, ProductBeneficiaryRepository>();
            builder.Services.AddScoped<IBeneficiaryRepository, BeneficiaryRepository>();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("*")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            
            builder.Services.AddDbContext<BookwormContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddCors(
            (p) => p.AddDefaultPolicy(policy => policy.WithOrigins("*")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    )
            );
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }




            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors();
            app.MapControllers();

            app.Run();
        }
    }
}
