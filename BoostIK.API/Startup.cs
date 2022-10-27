using BoostIK.BLL.AutoMapper;
using BoostIK.BLL.Models.DTOs;
using BoostIK.BLL.Services.AdminService;
using BoostIK.BLL.Services.CompanyService;
using BoostIK.BLL.Services.DayOffRequestRepository;
using BoostIK.BLL.Services.PaymentService;
using BoostIK.BLL.Services.PermissionLimitService;
using BoostIK.BLL.Services.PermissionService;
using BoostIK.BLL.Services.PersonelService;
using BoostIK.BLL.Services.SpendingService;
using BoostIK.CORE.Entities;
using BoostIK.CORE.IRepositories;
using BoostIK.DAL;
using BoostIK.DAL.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoostIK.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            //services.AddCors(options =>
            //     options.AddPolicy("mypolicy", builder =>
            //     builder.WithOrigins("https://localhost:44396").AllowAnyMethod().AllowAnyHeader()));

            // Entity Framework
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ConnString"));
            });

            // Identity
            services.AddIdentity<Personel, IdentityRole>(config =>
            {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.SignIn.RequireConfirmedEmail = false; // bu true olacak

                config.User.RequireUniqueEmail = false;  // emailler unique oldu
                config.User.AllowedUserNameCharacters = "abcçdefghiýjklmnoöpqrsþtuüvwxyzABCÇDEFGHIÝJKLMNOÖPQRSÞTUÜVWXYZ0123456789-._@+";
            }).AddEntityFrameworkStores<AppDbContext>()
            .AddTokenProvider<DataProtectorTokenProvider<Personel>>(TokenOptions.DefaultProvider)
            .AddEntityFrameworkStores<AppDbContext>();

            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            //services.AddTransient<ICompanyRepository, CompanyRepository>();
            //services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IDayOffRequestRepository, DayOffRequestRepository>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            services.AddTransient<IPermissionLimitRepository, PermissionLimitRepository>();
            services.AddTransient<IPersonelRepository, PersonelRepository>();
            services.AddTransient<ISpendingRepository, SpendingRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IPersonelService, PersonelService>();
            services.AddScoped<IPermissionLimitService, PermissionLimitService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IDayOffRequestService, DayOffRequestService>();
            services.AddScoped<ISpendingService, SpendingService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IAdminService, AdminService>();

            services.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<UpdatePersonelDTO>();
            });

            //AutoMapper
            services.AddAutoMapper(typeof(Mapping));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
