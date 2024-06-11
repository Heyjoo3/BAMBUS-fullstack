using Bambus.Data;
using Bambus.Services.Item;
using Bambus.Services.Loan;
using Bambus.Services.Messages;
using Bambus.Services.Rating;
using Bambus.Services.User;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Bambus.DTOs.UserDtos;
using Bambus.Validators.User;
using Bambus.DTOs.RatingDtos;
using Bambus.Validators.Rating;
using Bambus.Validators.Message;
using Bambus.DTOs.MessageDtos;
using Bambus.Validators.Item;
using Bambus.DTOs.ItemDtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                           .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddScoped<ILoanService, LoanService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IValidator<RegisterDTO>, RegisterDTOValidator>();
builder.Services.AddScoped<IValidator<UpdateUserDTO>, UpdateUserDTOValidator>();
builder.Services.AddScoped<IValidator<LoginDTO>, LoginDTOValidator>();
builder.Services.AddScoped<IValidator<AddRatingDTO>, AddRatingValidator>();
builder.Services.AddScoped<IValidator<UpdateRatingDTO>, UpdateRatingValidator>();
builder.Services.AddScoped<IValidator<AddMessageDTO>, AddMessageValidator>();
builder.Services.AddScoped <IValidator<AddItemDTO>, AddItemValidator>();
builder.Services.AddScoped<IValidator<UpdateItemDTO>, UpdateItemValidator>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(policy =>
{
    policy.AllowAnyOrigin();
    policy.AllowAnyMethod();
    policy.AllowAnyHeader();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();