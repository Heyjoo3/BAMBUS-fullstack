using Bambus.Enums;
using Bambus.Models;
using Microsoft.EntityFrameworkCore;

namespace Bambus.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<LoanModel> Loans { get; set; }
        public DbSet<RatingModel> Ratings { get; set; }
        public DbSet<MessageModel> Messages { get; set; }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<MagazineModel> Magazines { get; set; }
        public DbSet<GameModel> Games { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MagazineModel>(entity =>
            {
                entity.Property(e => e.ItemId)
                    .HasDefaultValueSql("NEXT VALUE FOR dbo.GlobalIdSequence");
            });
            modelBuilder.Entity<BookModel>(entity =>
            {
                entity.Property(e => e.ItemId)
                    .HasDefaultValueSql("NEXT VALUE FOR dbo.GlobalIdSequence");
            });
            modelBuilder.Entity<GameModel>(entity =>
            {
                entity.Property(e => e.ItemId)
                    .HasDefaultValueSql("NEXT VALUE FOR dbo.GlobalIdSequence");
            });

            Utility.CreatePasswordHash("Password123!", out byte[] passwordHash, out byte[] passwordSalt);

            modelBuilder.Entity<UserModel>().HasData(
                new UserModel { UserId = 1, Username = "user1", Password = "Password123!", Email = "user1@email.com", FirstName = "User1First", LastName = "User1Last", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = Role.User, NumberLoans = 1, NumberExtensions = 2, NumberMissedReturns = 3 },
                new UserModel { UserId = 2, Username = "user2", Password = "Password123!", Email = "user2@email.com", FirstName = "User2First", LastName = "User2Last", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = Role.User, NumberLoans = 1, NumberExtensions = 2, NumberMissedReturns = 3 },
                new UserModel { UserId = 3, Username = "user3", Password = "Password123!", Email = "user3@email.com", FirstName = "User3First", LastName = "User3Last", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = Role.User, NumberLoans = 1, NumberExtensions = 2, NumberMissedReturns = 3 },
                new UserModel { UserId = 4, Username = "admin1", Password = "Password123!", Email = "admin1@email.com", FirstName = "Admin1First", LastName = "Admin1Last", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = Role.Admin},
                new UserModel { UserId = 5, Username = "manager1", Password = "Password123!", Email = "manager1@email.com", FirstName = "Manager1First", LastName = "Manager1Last", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = Role.Manager }
            );

            modelBuilder.Entity<MagazineModel>().HasData(
                new MagazineModel { ItemId = 1, Author = "Author1", Title = "Title1", Category = "Category1", ISSN = "ISSN1", CurrentLoanId = null, Condition = Condition.OK, Reservations = null},
                new MagazineModel { ItemId = 2, Author = "Author2", Title = "Title2", Category = "Category2", ISSN = "ISSN2", CurrentLoanId = 4, Condition = Condition.NeedsCheck, Reservations = [2,3], AvgRating = 5},
                new MagazineModel { ItemId = 3, Author = "Author3", Title = "Title3", Category = "Category3", ISSN = "ISSN3", CurrentLoanId = 5, Condition = Condition.Damaged, Reservations = [1], AvgRating = 4.5}
            );

            modelBuilder.Entity<BookModel>().HasData(
                new BookModel { ItemId = 4, Author = "Author4", Title = "Title4", Category = "Category1", ISBN = "ISBN4", CurrentLoanId = null, Condition = Condition.OK, Reservations = null},
                new BookModel { ItemId = 5, Author = "Author5", Title = "Title5", Category = "Category2", ISBN = "ISBN5", CurrentLoanId = 6, Condition = Condition.NeedsCheck, Reservations = [3,1], AvgRating = 3},
                new BookModel { ItemId = 6, Author = "Author6", Title = "Title6", Category = "Category3", ISBN = "ISBN6", CurrentLoanId = 7, Condition = Condition.Damaged, Reservations = [2]}
            );

            modelBuilder.Entity<GameModel>().HasData(
                new GameModel { ItemId = 7, Title = "Title7", CurrentLoanId = null, Condition = Condition.OK, Reservations = null},
                new GameModel { ItemId = 8, Title = "Title8", CurrentLoanId = 8, Condition = Condition.NeedsCheck, Reservations = [1,2]},
                new GameModel { ItemId = 9, Title = "Title9", CurrentLoanId = 9, Condition = Condition.Damaged, Reservations = [3]}
            );

            modelBuilder.Entity<LoanModel>().HasData(
                new LoanModel { LoanId = 1, UserId = 1, ItemId = 2, StartDate = new DateTime(2021, 1, 1), DueDate = new DateTime(2021, 2, 1), ReturnDate = new DateTime(2021, 1, 15), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 2, UserId = 2, ItemId = 3, StartDate = new DateTime(2021, 1, 2), DueDate = new DateTime(2021, 2, 1), ReturnDate = new DateTime(2021, 1, 16), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 3, UserId = 3, ItemId = 5, StartDate = new DateTime(2021, 1, 3), DueDate = new DateTime(2021, 2, 1), ReturnDate = new DateTime(2021, 1, 17), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 4, UserId = 1, ItemId = 2, StartDate = new DateTime(2023, 4, 1), DueDate = new DateTime(2023, 5, 1), ReturnDate = null, ExtensionRequestRunning = true },
                new LoanModel { LoanId = 5, UserId = 2, ItemId = 3, StartDate = new DateTime(2023, 4, 1), DueDate = new DateTime(2023, 5, 1), ReturnDate = null, ExtensionRequestRunning = false },
                new LoanModel { LoanId = 6, UserId = 2, ItemId = 5, StartDate = new DateTime(2023, 4, 1), DueDate = new DateTime(2023, 5, 1), ReturnDate = null, ExtensionRequestRunning = false },
                new LoanModel { LoanId = 7, UserId = 1, ItemId = 6, StartDate = new DateTime(2023, 4, 1), DueDate = new DateTime(2023, 5, 1), ReturnDate = null, ExtensionRequestRunning = true },
                new LoanModel { LoanId = 8, UserId = 3, ItemId = 8, StartDate = new DateTime(2023, 4, 1), DueDate = new DateTime(2023, 5, 1), ReturnDate = null, ExtensionRequestRunning = false },
                new LoanModel { LoanId = 9, UserId = 2, ItemId = 9, StartDate = new DateTime(2023, 4, 1), DueDate = new DateTime(2023, 5, 1), ReturnDate = null, ExtensionRequestRunning = false }
            );
            modelBuilder.Entity<RatingModel>().HasData(
                new RatingModel { RatingId = 2, UserId = 2, ItemId = 3, Rating = 4, Comment = "Nice", IsRecommended = true },
                new RatingModel { RatingId = 3, UserId = 3, ItemId = 5, Rating = 3, Comment = "Ok", IsRecommended = false },
                new RatingModel { RatingId = 4, UserId = 1, ItemId = 2, Rating = 5, Comment = "Good", IsRecommended = true },
                new RatingModel { RatingId = 5, UserId = 1, ItemId = 3, Rating = 5, Comment = "Lovely", IsRecommended = true }
            );
            modelBuilder.Entity<MessageModel>().HasData(
                new MessageModel { MessageId = 1, SenderId = 1, ReceiverId = 5, Date = new DateTime(2021, 1, 15) , Text = "Text", Type = MessageType.ExtensionRequest, Payload = "Payload" },
                new MessageModel { MessageId = 2, SenderId = 5, ReceiverId = 1, Date = new DateTime(2021, 1, 16) , Text = "Text", Type = MessageType.RequestResponse, Payload = "Payload" }, 
                new MessageModel { MessageId = 3, SenderId = 1, ReceiverId = 4, Date = new DateTime(2021, 1, 1) , Text = "Text", Type = MessageType.UserRegistered, Payload = "Payload" },
                new MessageModel { MessageId = 4, SenderId = 4, ReceiverId = 1, Date = new DateTime(2021, 1, 2) , Text = "Text", Type = MessageType.PasswordReset, Payload = "Payload" },
                new MessageModel { MessageId = 5, SenderId = 0, ReceiverId = 0, Date = new DateTime(2021, 1, 3) , Text = "Text", Type = MessageType.NewItem, Payload = "Payload" },
                new MessageModel { MessageId = 6, SenderId = 1, ReceiverId = 5, Date = new DateTime(2021, 1, 4) , Text = "Text", Type = MessageType.DamageReport, Payload = "Payload" },
                new MessageModel { MessageId = 7, SenderId = 0, ReceiverId = 1, Date = new DateTime(2021, 1, 5) , Text = "Text", Type = MessageType.ReturnReminder, Payload = "Payload" }

           );
        }
    }
}
