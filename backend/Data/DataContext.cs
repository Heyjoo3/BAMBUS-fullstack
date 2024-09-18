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
                //new UserModel { UserId = 1, Username = "user1", Password = "Password123!", Email = "user1@email.com", FirstName = "User1First", LastName = "User1Last", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = Role.User, NumberLoans = 1, NumberExtensions = 2, NumberMissedReturns = 3 },
                //new UserModel { UserId = 2, Username = "user2", Password = "Password123!", Email = "user2@email.com", FirstName = "User2First", LastName = "User2Last", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = Role.User, NumberLoans = 1, NumberExtensions = 2, NumberMissedReturns = 3 },
                //new UserModel { UserId = 3, Username = "user3", Password = "Password123!", Email = "user3@email.com", FirstName = "User3First", LastName = "User3Last", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = Role.User, NumberLoans = 1, NumberExtensions = 2, NumberMissedReturns = 3 },
                //new UserModel { UserId = 4, Username = "admin1", Password = "Password123!", Email = "admin1@email.com", FirstName = "Admin1First", LastName = "Admin1Last", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = Role.Admin },
                //new UserModel { UserId = 5, Username = "manager1", Password = "Password123!", Email = "manager1@email.com", FirstName = "Manager1First", LastName = "Manager1Last", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = Role.Manager }
            
                new UserModel { UserId = 1, Username = "user1", Password = "Password123!", Email = "user1@email.com", FirstName = "User1First", LastName = "User1Last", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = Role.User, NumberLoans = 2, NumberExtensions = 86, NumberMissedReturns = 3 },
            new UserModel { UserId = 2, Username = "user2", Password = "Password123!", Email = "user2@email.com", FirstName = "User2First", LastName = "User2Last", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = Role.User, NumberLoans = 2, NumberExtensions = 35, NumberMissedReturns = 6 },
            new UserModel { UserId = 3, Username = "user3", Password = "Password123!", Email = "user3@email.com", FirstName = "User3First", LastName = "User3Last", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = Role.User, NumberLoans = 2, NumberExtensions = 24, NumberMissedReturns = 3 },
            new UserModel { UserId = 4, Username = "admin1", Password = "Password123!", Email = "admin1@email.com", FirstName = "Admin1First", LastName = "Admin1Last", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = Role.Admin, NumberLoans = 0, NumberExtensions = 0, NumberMissedReturns = 0 },
            new UserModel { UserId = 5, Username = "manager1", Password = "Password123!", Email = "manager1@email.com", FirstName = "Manager1First", LastName = "Manager1Last", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = Role.Manager, NumberLoans = 0, NumberExtensions = 0, NumberMissedReturns = 23 },
            new UserModel { UserId = 10, Username = "user4", Password = "12345678", Email = "user4@email.com", FirstName = "User4First", LastName = "User4Last", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = Role.User, NumberLoans = 0, NumberExtensions = 0, NumberMissedReturns = 0 },
            new UserModel { UserId = 14, Username = "BigB", Password = "Password123!", Email = "bruno@email.com", FirstName = "Bruno", LastName = "Banani", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = Role.User, NumberLoans = 0, NumberExtensions = 0, NumberMissedReturns = 0 },
            new UserModel { UserId = 15, Username = "rasendeReporterinK", Password = "Password123!", Email = "karla@email.com", FirstName = "Karla", LastName = "Kolumna", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = Role.User, NumberLoans = 0, NumberExtensions = 0, NumberMissedReturns = 0 },
            new UserModel { UserId = 17, Username = "Spidey", Password = "ABcd12!?", Email = "peterp@email.com", FirstName = "Peter", LastName = "Parker", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = Role.User, NumberLoans = 0, NumberExtensions = 49, NumberMissedReturns = 0 },
            new UserModel { UserId = 19, Username = "lissi", Password = "Password123!", Email = "lissi@email.com", FirstName = "Lisbeth", LastName = "Salander", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = Role.User, NumberLoans = 0, NumberExtensions = 1, NumberMissedReturns = 0 },
            new UserModel { UserId = 22, Username = "snips", Password = "Password123!", Email = "tano@email.com", FirstName = "Ahsoka", LastName = "Tano", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = Role.User, NumberLoans = 0, NumberExtensions = 32, NumberMissedReturns = 0 },
            new UserModel { UserId = 23, Username = "admin2", Password = "Password123!", Email = "admin2@emial.com", FirstName = "Admin2First", LastName = "Admin2Last", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = Role.Admin, NumberLoans = 0, NumberExtensions = 0, NumberMissedReturns = 0 },
            new UserModel { UserId = 24, Username = "manager2", Password = "Password123!", Email = "manager2@email.com", FirstName = "Manager2First", LastName = "Manager2Last", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = Role.Manager, NumberLoans = 0, NumberExtensions = 0, NumberMissedReturns = 0 },
            new UserModel { UserId = 25, Username = "userin5", Password = "Password123!", Email = "userin5@email.com", FirstName = "Userin5First", LastName = "Userin5Last", PasswordHash = passwordHash, PasswordSalt = passwordSalt, Role = Role.User, NumberLoans = 1, NumberExtensions = 1, NumberMissedReturns = 0 }

                );

            modelBuilder.Entity<MagazineModel>().HasData(
            //new MagazineModel { ItemId = 1, Author = "Author1", Title = "Title1", Category = "Category1", ISSN = "ISSN1", CurrentLoanId = null, Condition = Condition.OK, Reservations = null },
            //new MagazineModel { ItemId = 2, Author = "Author2", Title = "Title2", Category = "Category2", ISSN = "ISSN2", CurrentLoanId = 4, Condition = Condition.NeedsCheck, Reservations = [2, 3], AvgRating = 5 },
            //new MagazineModel { ItemId = 3, Author = "Author3", Title = "Title3", Category = "Category3", ISSN = "ISSN3", CurrentLoanId = 5, Condition = Condition.Damaged, Reservations = [1], AvgRating = 4.5}
            
            new MagazineModel { ItemId = 2, Author = "Author2", Title = "Title2", Category = "Category2", ISSN = "ISSN2", CurrentLoanId = 0, Condition = Condition.NeedsCheck, Reservations = new List<int>(), AvgRating = 2.75 },
            new MagazineModel { ItemId = 3, Author = "Author3", Title = "Title3", Category = "Category3", ISSN = "ISSN3", CurrentLoanId = 0, Condition = Condition.NeedsCheck, Reservations = new List<int>(), AvgRating = 3 },
            new MagazineModel { ItemId = 44, Author = "Anne", Title = "Vogue", Category = "Mode", ISSN = "d234se", CurrentLoanId = 220, Condition = Condition.Damaged, Reservations = new List<int>(), AvgRating = 4 },
            new MagazineModel { ItemId = 45, Author = "Chuck Shurley", Title = "Supernatural Evangelium", Category = "Religion", ISSN = "1111111111111111", CurrentLoanId = 221, Condition = Condition.OK, Reservations = new List<int>(), AvgRating = 3 }
                );

            modelBuilder.Entity<BookModel>().HasData(
                //new BookModel { ItemId = 4, Author = "Author4", Title = "Title4", Category = "Category1", ISBN = "ISBN4", CurrentLoanId = null, Condition = Condition.OK, Reservations = null},
                //new BookModel { ItemId = 5, Author = "Author5", Title = "Title5", Category = "Category2", ISBN = "ISBN5", CurrentLoanId = 6, Condition = Condition.NeedsCheck, Reservations = [3,1], AvgRating = 3},
                //new BookModel { ItemId = 6, Author = "Author6", Title = "Title6", Category = "Category3", ISBN = "ISBN6", CurrentLoanId = 7, Condition = Condition.Damaged, Reservations = [2]}
                new BookModel { ItemId = 1, Author = "Author1Updated", Title = "Title1Updated", Category = "Category1Updated", ISBN = "123456789", CurrentLoanId = 218, Condition = Condition.Damaged, Reservations = new List<int>(), AvgRating = 1.66666666666667 },
                new BookModel { ItemId = 4, Author = "Author4", Title = "Title4", Category = "Category1", ISBN = "ISBN4", CurrentLoanId = 219, Condition = Condition.NeedsCheck, Reservations = new List<int> { 3 }, AvgRating = 3.33333333333333 },
                new BookModel { ItemId = 5, Author = "Author5", Title = "Title5", Category = "Category2", ISBN = "ISBN5", CurrentLoanId = 0, Condition = Condition.OK, Reservations = new List<int>(), AvgRating = 4 },
                new BookModel { ItemId = 6, Author = "Author6", Title = "Title6", Category = "Category3", ISBN = "ISBN6", CurrentLoanId = 0, Condition = Condition.Damaged, Reservations = new List<int>(), AvgRating = 5 },
                new BookModel { ItemId = 12, Author = "Johann", Title = "Item12", Category = "Category12", ISBN = "string", CurrentLoanId = 0, Condition = Condition.OK, Reservations = new List<int>(), AvgRating = 2.75 },
                new BookModel { ItemId = 23, Author = "Marion", Title = "ABC", Category = "Kinder", ISBN = "2345", CurrentLoanId = 0, Condition = Condition.NeedsCheck, Reservations = new List<int>(), AvgRating = 3.4 },
                new BookModel { ItemId = 24, Author = "Marion", Title = "Biene Maja", Category = "Kinder", ISBN = "2345", CurrentLoanId = 217, Condition = Condition.OK, Reservations = new List<int>(), AvgRating = 3.75 },
                new BookModel { ItemId = 25, Author = "A1", Title = "TestReservation1", Category = "C1", ISBN = "3456", CurrentLoanId = 216, Condition = Condition.OK, Reservations = new List<int>(), AvgRating = 3 },
                new BookModel { ItemId = 26, Author = "A2", Title = "TestReservation2", Category = "C2", ISBN = "4567", CurrentLoanId = 0, Condition = Condition.OK, Reservations = new List<int>(), AvgRating = 1.66666666666667 },
                new BookModel { ItemId = 27, Author = "A3", Title = "TestReservation3", Category = "C3", ISBN = "5678", CurrentLoanId = 0, Condition = Condition.OK, Reservations = new List<int>(), AvgRating = 3 },
                new BookModel { ItemId = 28, Author = "A4", Title = "TestReservation4", Category = "C4", ISBN = "6789", CurrentLoanId = 0, Condition = Condition.OK, Reservations = new List<int>(), AvgRating = 2 },
                new BookModel { ItemId = 29, Author = "Else Müller", Title = "Heidi", Category = "Kinder", ISBN = "84654e856", CurrentLoanId = 0, Condition = Condition.OK, Reservations = new List<int>(), AvgRating = 4.5 },
                new BookModel { ItemId = 30, Author = "F. Scott Fitzgerald", Title = "The Great Gatsby", Category = "Roman", ISBN = "25472683", CurrentLoanId = 0, Condition = Condition.OK, Reservations = new List<int>(), AvgRating = 4.5 },
                new BookModel { ItemId = 31, Author = "Arthur Miller", Title = "Hexenjagd", Category = "Tragödie", ISBN = "459174365", CurrentLoanId = 0, Condition = Condition.OK, Reservations = new List<int>(), AvgRating = 4 },
                new BookModel { ItemId = 32, Author = "Schreiberling", Title = "Peter Pan", Category = "Kinder", ISBN = "476547", CurrentLoanId = 0, Condition = Condition.OK, Reservations = new List<int>(), AvgRating = 4 },
                new BookModel { ItemId = 33, Author = "Bundestag", Title = "BGB", Category = "Gesetzestext", ISBN = "2345678", CurrentLoanId = 0, Condition = Condition.NeedsCheck, Reservations = new List<int> { 1 }, AvgRating = 5 },
                new BookModel { ItemId = 34, Author = "Gebrüder Grimm", Title = "Hänsel und Gretel", Category = "Märchen", ISBN = "829374", CurrentLoanId = 0, Condition = Condition.OK, Reservations = new List<int>(), AvgRating = 2.5 },
                new BookModel { ItemId = 35, Author = "Karl Marx", Title = "Das Kapital. Band I", Category = "Wirtschaft", ISBN = "84375918347", CurrentLoanId = 0, Condition = Condition.OK, Reservations = new List<int>(), AvgRating = 2.33333333333333 },
                new BookModel { ItemId = 36, Author = "Georg Büchner", Title = "Dantons Tod", Category = "Drama", ISBN = "7985123460", CurrentLoanId = 0, Condition = Condition.OK, Reservations = new List<int>(), AvgRating = 0 },
                new BookModel { ItemId = 37, Author = "Dantons Tod", Title = "Woyzeck", Category = "Drama", ISBN = "0186z435", CurrentLoanId = 0, Condition = Condition.Damaged, Reservations = new List<int>(), AvgRating = 2.5 },
                new BookModel { ItemId = 46, Author = "Stephen King", Title = "Es", Category = "Horror", ISBN = "676767867867", CurrentLoanId = 0, Condition = Condition.OK, Reservations = new List<int>(), AvgRating = 1 },
                new BookModel { ItemId = 52, Author = "1111", Title = "TestReturnItem", Category = "1111", ISBN = "1111", CurrentLoanId = 0, Condition = Condition.NeedsCheck, Reservations = new List<int> { 1 }, AvgRating = 3.33333333333333 }
               );

            modelBuilder.Entity<GameModel>().HasData(
                //new GameModel { ItemId = 7, Title = "Title7", CurrentLoanId = null, Condition = Condition.OK, Reservations = null},
                //new GameModel { ItemId = 8, Title = "Title8", CurrentLoanId = 8, Condition = Condition.NeedsCheck, Reservations = [1,2]},
                //new GameModel { ItemId = 9, Title = "Title9", CurrentLoanId = 9, Condition = Condition.Damaged, Reservations = [3]}

                new GameModel { ItemId = 7, Title = "Title7", CurrentLoanId = 0, Condition = Condition.OK, Reservations = new List<int>(), AvgRating = 4 },
                new GameModel { ItemId = 8, Title = "Title8", CurrentLoanId = 0, Condition = Condition.NeedsCheck, Reservations = new List<int>(), AvgRating = 1 },
                new GameModel { ItemId = 9, Title = "Title9", CurrentLoanId = 0, Condition = Condition.Damaged, Reservations = new List<int>(), AvgRating = 0 },
                new GameModel { ItemId = 18, Title = "2222", CurrentLoanId = 0, Condition = Condition.NeedsCheck, Reservations = new List<int>(), AvgRating = 4 },
                new GameModel { ItemId = 42, Title = "Schach", CurrentLoanId = 0, Condition = Condition.NeedsCheck, Reservations = new List<int>(), AvgRating = 1 },
                new GameModel { ItemId = 43, Title = "Mühle", CurrentLoanId = 0, Condition = Condition.OK, Reservations = new List<int>(), AvgRating = 4 },
                new GameModel { ItemId = 47, Title = "Mensch-ärger-dich-nicht", CurrentLoanId = 0, Condition = Condition.OK, Reservations = new List<int>(), AvgRating = 3 },
                new GameModel { ItemId = 48, Title = "Phase 10", CurrentLoanId = 0, Condition = Condition.OK, Reservations = new List<int>(), AvgRating = 4 },
                new GameModel { ItemId = 49, Title = "Skyjo", CurrentLoanId = 0, Condition = Condition.OK, Reservations = new List<int>(), AvgRating = 4.33333333333333 },
                new GameModel { ItemId = 50, Title = "Catan", CurrentLoanId = 0, Condition = Condition.OK, Reservations = new List<int>(), AvgRating = 3 },
                new GameModel { ItemId = 51, Title = "Risiko", CurrentLoanId = 0, Condition = Condition.OK, Reservations = new List<int>(), AvgRating = 3.66666666666667 }

            );

            modelBuilder.Entity<LoanModel>().HasData(
                //new LoanModel { LoanId = 1, UserId = 1, ItemId = 2, StartDate = new DateTime(2021, 1, 1), DueDate = new DateTime(2021, 2, 1), ReturnDate = new DateTime(2021, 1, 15), ExtensionRequestRunning = false },
                //new LoanModel { LoanId = 2, UserId = 2, ItemId = 3, StartDate = new DateTime(2021, 1, 2), DueDate = new DateTime(2021, 2, 1), ReturnDate = new DateTime(2021, 1, 16), ExtensionRequestRunning = false },
                //new LoanModel { LoanId = 3, UserId = 3, ItemId = 5, StartDate = new DateTime(2021, 1, 3), DueDate = new DateTime(2021, 2, 1), ReturnDate = new DateTime(2021, 1, 17), ExtensionRequestRunning = false },
                //new LoanModel { LoanId = 4, UserId = 1, ItemId = 2, StartDate = new DateTime(2023, 4, 1), DueDate = new DateTime(2023, 5, 1), ReturnDate = null, ExtensionRequestRunning = true },
                //new LoanModel { LoanId = 5, UserId = 2, ItemId = 3, StartDate = new DateTime(2023, 4, 1), DueDate = new DateTime(2023, 5, 1), ReturnDate = null, ExtensionRequestRunning = false },
                //new LoanModel { LoanId = 6, UserId = 2, ItemId = 5, StartDate = new DateTime(2023, 4, 1), DueDate = new DateTime(2023, 5, 1), ReturnDate = null, ExtensionRequestRunning = false },
                //new LoanModel { LoanId = 7, UserId = 1, ItemId = 6, StartDate = new DateTime(2023, 4, 1), DueDate = new DateTime(2023, 5, 1), ReturnDate = null, ExtensionRequestRunning = true },
                //new LoanModel { LoanId = 8, UserId = 3, ItemId = 8, StartDate = new DateTime(2023, 4, 1), DueDate = new DateTime(2023, 5, 1), ReturnDate = null, ExtensionRequestRunning = false },
                //new LoanModel { LoanId = 9, UserId = 2, ItemId = 9, StartDate = new DateTime(2023, 4, 1), DueDate = new DateTime(2023, 5, 1), ReturnDate = null, ExtensionRequestRunning = false }

                new LoanModel { LoanId = 1, UserId = 1, ItemId = 2, StartDate = new DateTime(2021, 1, 1), DueDate = new DateTime(2021, 2, 1), ReturnDate = new DateTime(2021, 1, 15), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 2, UserId = 2, ItemId = 3, StartDate = new DateTime(2021, 1, 2), DueDate = new DateTime(2021, 2, 1), ReturnDate = new DateTime(2021, 1, 16), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 3, UserId = 3, ItemId = 5, StartDate = new DateTime(2021, 1, 3), DueDate = new DateTime(2021, 2, 1), ReturnDate = new DateTime(2021, 1, 17), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 4, UserId = 1, ItemId = 2, StartDate = new DateTime(2023, 4, 1), DueDate = new DateTime(2023, 5, 1), ReturnDate = new DateTime(2024, 6, 4, 9, 31, 35), ExtensionRequestRunning = true },
                new LoanModel { LoanId = 5, UserId = 2, ItemId = 3, StartDate = new DateTime(2023, 4, 1), DueDate = new DateTime(2023, 5, 1), ReturnDate = new DateTime(2024, 6, 4, 9, 11, 32), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 6, UserId = 2, ItemId = 5, StartDate = new DateTime(2023, 4, 1), DueDate = new DateTime(2023, 5, 1), ReturnDate = new DateTime(2024, 5, 16, 10, 37, 54), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 7, UserId = 1, ItemId = 6, StartDate = new DateTime(2023, 4, 1), DueDate = new DateTime(2023, 5, 1), ReturnDate = new DateTime(2024, 5, 7, 13, 56, 55), ExtensionRequestRunning = true },
                new LoanModel { LoanId = 8, UserId = 3, ItemId = 8, StartDate = new DateTime(2023, 4, 1), DueDate = new DateTime(2023, 5, 1), ReturnDate = new DateTime(2024, 5, 8, 10, 16, 24), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 9, UserId = 2, ItemId = 9, StartDate = new DateTime(2023, 4, 1), DueDate = new DateTime(2023, 5, 1), ReturnDate = new DateTime(2024, 6, 4, 9, 11, 40), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 201, UserId = 2, ItemId = 30, StartDate = new DateTime(2024, 6, 5, 11, 44, 20), DueDate = new DateTime(2024, 6, 14), ReturnDate = new DateTime(2024, 6, 5, 13, 45, 8), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 202, UserId = 2, ItemId = 31, StartDate = new DateTime(2024, 6, 5, 11, 44, 22), DueDate = new DateTime(2024, 6, 14), ReturnDate = new DateTime(2024, 6, 5, 13, 45, 42), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 203, UserId = 2, ItemId = 27, StartDate = new DateTime(2024, 6, 5, 11, 44, 25), DueDate = new DateTime(2024, 6, 26), ReturnDate = new DateTime(2024, 6, 5, 13, 45, 49), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 204, UserId = 2, ItemId = 25, StartDate = new DateTime(2024, 6, 5, 11, 44, 27), DueDate = new DateTime(2024, 6, 20), ReturnDate = new DateTime(2024, 6, 5, 13, 46, 2), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 205, UserId = 2, ItemId = 24, StartDate = new DateTime(2024, 6, 5, 11, 44, 29), DueDate = new DateTime(2024, 6, 22), ReturnDate = new DateTime(2024, 6, 5, 13, 46, 19), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 206, UserId = 22, ItemId = 1, StartDate = new DateTime(2024, 6, 5, 13, 7, 13), DueDate = new DateTime(2024, 6, 21), ReturnDate = new DateTime(2024, 6, 5, 15, 7, 21), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 207, UserId = 22, ItemId = 5, StartDate = new DateTime(2024, 6, 5, 13, 7, 14), DueDate = new DateTime(2024, 6, 20), ReturnDate = new DateTime(2024, 6, 5, 15, 7, 25), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 208, UserId = 22, ItemId = 4, StartDate = new DateTime(2024, 6, 5, 13, 7, 15), DueDate = new DateTime(2024, 6, 14), ReturnDate = new DateTime(2024, 6, 5, 15, 7, 28), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 209, UserId = 22, ItemId = 6, StartDate = new DateTime(2024, 6, 5, 13, 7, 16), DueDate = new DateTime(2024, 6, 28), ReturnDate = new DateTime(2024, 6, 5, 15, 7, 30), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 210, UserId = 22, ItemId = 42, StartDate = new DateTime(2024, 6, 5, 13, 7, 50), DueDate = new DateTime(2024, 6, 22), ReturnDate = new DateTime(2024, 6, 5, 15, 8, 10), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 211, UserId = 22, ItemId = 51, StartDate = new DateTime(2024, 6, 5, 13, 7, 51), DueDate = new DateTime(2024, 7, 2), ReturnDate = new DateTime(2024, 6, 5, 15, 8, 33), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 212, UserId = 22, ItemId = 48, StartDate = new DateTime(2024, 6, 5, 13, 7, 52), DueDate = new DateTime(2024, 6, 13), ReturnDate = new DateTime(2024, 6, 5, 15, 9, 6), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 213, UserId = 22, ItemId = 49, StartDate = new DateTime(2024, 6, 5, 13, 7, 53), DueDate = new DateTime(2024, 6, 22), ReturnDate = new DateTime(2024, 6, 5, 15, 9, 30), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 214, UserId = 2, ItemId = 12, StartDate = new DateTime(2024, 6, 5, 13, 10, 24), DueDate = new DateTime(2024, 6, 20), ReturnDate = new DateTime(2024, 6, 5, 15, 10, 58), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 215, UserId = 2, ItemId = 23, StartDate = new DateTime(2024, 6, 5, 13, 10, 25), DueDate = new DateTime(2024, 6, 14), ReturnDate = new DateTime(2024, 6, 5, 16, 15, 54), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 216, UserId = 2, ItemId = 25, StartDate = new DateTime(2024, 6, 5, 13, 10, 26), DueDate = new DateTime(2024, 6, 20), ReturnDate = null, ExtensionRequestRunning = false },
                new LoanModel { LoanId = 217, UserId = 2, ItemId = 24, StartDate = new DateTime(2024, 6, 5, 13, 10, 26), DueDate = new DateTime(2024, 6, 12), ReturnDate = null, ExtensionRequestRunning = false },
                new LoanModel { LoanId = 218, UserId = 2, ItemId = 1, StartDate = new DateTime(2024, 6, 5, 13, 10, 27), DueDate = new DateTime(2024, 6, 18), ReturnDate = null, ExtensionRequestRunning = false },
                new LoanModel { LoanId = 219, UserId = 2, ItemId = 4, StartDate = new DateTime(2024, 6, 5, 13, 10, 28), DueDate = new DateTime(2024, 6, 13), ReturnDate = null, ExtensionRequestRunning = false },
                new LoanModel { LoanId = 220, UserId = 2, ItemId = 44, StartDate = new DateTime(2024, 6, 5, 13, 10, 29), DueDate = new DateTime(2024, 6, 13), ReturnDate = null, ExtensionRequestRunning = false },
                new LoanModel { LoanId = 221, UserId = 2, ItemId = 45, StartDate = new DateTime(2024, 6, 5, 13, 10, 30), DueDate = new DateTime(2024, 6, 13), ReturnDate = null, ExtensionRequestRunning = false },
                new LoanModel { LoanId = 222, UserId = 1, ItemId = 52, StartDate = new DateTime(2024, 6, 7, 11, 30, 21), DueDate = new DateTime(2024, 6, 14), ReturnDate = new DateTime(2024, 6, 7, 14, 14, 22), ExtensionRequestRunning = false },
                new LoanModel { LoanId = 223, UserId = 2, ItemId = 52, StartDate = new DateTime(2024, 6, 7, 12, 15, 48), DueDate = new DateTime(2024, 6, 22), ReturnDate = new DateTime(2024, 6, 7, 14, 17, 40), ExtensionRequestRunning = false }

                );
            modelBuilder.Entity<RatingModel>().HasData(
                //new RatingModel { RatingId = 2, UserId = 2, ItemId = 3, Rating = 4, Comment = "Nice", IsRecommended = true },
                //new RatingModel { RatingId = 3, UserId = 3, ItemId = 5, Rating = 3, Comment = "Ok", IsRecommended = false },
                //new RatingModel { RatingId = 4, UserId = 1, ItemId = 2, Rating = 5, Comment = "Good", IsRecommended = true },
                //new RatingModel { RatingId = 5, UserId = 1, ItemId = 3, Rating = 5, Comment = "Lovely", IsRecommended = true }

                new RatingModel { RatingId = 3, UserId = 3, ItemId = 5, Rating = 3, Comment = "Ok", IsRecommended = false },
                new RatingModel { RatingId = 6, UserId = 1, ItemId = 12, Rating = 2, Comment = "Mmh...", IsRecommended = false },
                new RatingModel { RatingId = 24, UserId = 1, ItemId = 24, Rating = 4, Comment = "Supi", IsRecommended = true },
                new RatingModel { RatingId = 25, UserId = 2, ItemId = 24, Rating = 2, Comment = "nope. Maja ist keine Biene sondern eine Hummer", IsRecommended = false },
                new RatingModel { RatingId = 29, UserId = 1, ItemId = 23, Rating = 3, Comment = "qwertz", IsRecommended = true },
                new RatingModel { RatingId = 30, UserId = 3, ItemId = 24, Rating = 5, Comment = "Fantastisch", IsRecommended = true },
                new RatingModel { RatingId = 32, UserId = 1, ItemId = 7, Rating = 4, Comment = "Cool", IsRecommended = true },
                new RatingModel { RatingId = 35, UserId = 17, ItemId = 33, Rating = 5, Comment = "Wegweisend für jeden. Grundi rockt!", IsRecommended = true },
                new RatingModel { RatingId = 36, UserId = 17, ItemId = 37, Rating = 1, Comment = "Verrückt", IsRecommended = false },
                new RatingModel { RatingId = 38, UserId = 1, ItemId = 37, Rating = 4, Comment = "Interessant", IsRecommended = true },
                new RatingModel { RatingId = 43, UserId = 1, ItemId = 4, Rating = 3, Comment = "Super", IsRecommended = true },
                new RatingModel { RatingId = 44, UserId = 1, ItemId = 1, Rating = 3, Comment = "Toll", IsRecommended = true },
                new RatingModel { RatingId = 45, UserId = 2, ItemId = 1, Rating = 1, Comment = "one star is even too much", IsRecommended = false },
                new RatingModel { RatingId = 47, UserId = 1, ItemId = 29, Rating = 5, Comment = "Idyll", IsRecommended = true },
                new RatingModel { RatingId = 49, UserId = 1, ItemId = 8, Rating = 1, Comment = "Doof", IsRecommended = false },
                new RatingModel { RatingId = 50, UserId = 19, ItemId = 5, Rating = 5, Comment = "Grandios", IsRecommended = true },
                new RatingModel { RatingId = 51, UserId = 17, ItemId = 44, Rating = 4, Comment = "Super", IsRecommended = true },
                new RatingModel { RatingId = 52, UserId = 2, ItemId = 25, Rating = 2, Comment = "Zeitweise ok, oft aber fad", IsRecommended = false },
                new RatingModel { RatingId = 54, UserId = 3, ItemId = 26, Rating = 1, Comment = "Nicht Krass", IsRecommended = false },
                new RatingModel { RatingId = 55, UserId = 1, ItemId = 25, Rating = 4, Comment = "Schöne Worte", IsRecommended = true },
                new RatingModel { RatingId = 57, UserId = 1, ItemId = 27, Rating = 4, Comment = "Interessant und gut erklärt", IsRecommended = true },
                new RatingModel { RatingId = 59, UserId = 2, ItemId = 28, Rating = 3, Comment = "Schon ok ,aber geht besser", IsRecommended = true },
                new RatingModel { RatingId = 60, UserId = 3, ItemId = 27, Rating = 4, Comment = "Tip Top", IsRecommended = true },
                new RatingModel { RatingId = 61, UserId = 3, ItemId = 28, Rating = 1, Comment = "Nicht so lecker", IsRecommended = false },
                new RatingModel { RatingId = 62, UserId = 1, ItemId = 26, Rating = 1, Comment = "Joa ne. kein Hit", IsRecommended = false },
                new RatingModel { RatingId = 63, UserId = 22, ItemId = 6, Rating = 5, Comment = "Interessant und lehrreich. Ich bin jetz ein besserer Mensch und habe meinen Glauben wieder gefunden. Ein muss für jedes verlorene Schaf. Am liebsten würde ich es allen menschen dieser Welt schenken.", IsRecommended = true },
                new RatingModel { RatingId = 64, UserId = 22, ItemId = 30, Rating = 4, Comment = "Glam und Glimmer in einer schweren Zeit", IsRecommended = true },
                new RatingModel { RatingId = 65, UserId = 22, ItemId = 2, Rating = 4, Comment = "Great", IsRecommended = true },
                new RatingModel { RatingId = 66, UserId = 22, ItemId = 3, Rating = 2, Comment = "Es fehlt an tiefe", IsRecommended = false },
                new RatingModel { RatingId = 67, UserId = 22, ItemId = 45, Rating = 5, Comment = "Ein Augenöffner", IsRecommended = true },
                new RatingModel { RatingId = 68, UserId = 22, ItemId = 44, Rating = 4, Comment = "Thats Fashion Baby", IsRecommended = true },
                new RatingModel { RatingId = 69, UserId = 22, ItemId = 1, Rating = 1, Comment = "Fehlt an Inhalt", IsRecommended = false },
                new RatingModel { RatingId = 70, UserId = 22, ItemId = 4, Rating = 3, Comment = "Mittelklasse", IsRecommended = false },
                new RatingModel { RatingId = 71, UserId = 17, ItemId = 4, Rating = 4, Comment = "4 Gut gemeinte Sterne", IsRecommended = true },
                new RatingModel { RatingId = 73, UserId = 17, ItemId = 46, Rating = 1, Comment = "Gruselig.Habe jetzt Angst vor Clowns. ist doof wenn man in Zirkus arbeitet", IsRecommended = false },
                new RatingModel { RatingId = 74, UserId = 17, ItemId = 29, Rating = 4, Comment = "Meine welt sind auch die berge", IsRecommended = true },
                new RatingModel { RatingId = 75, UserId = 22, ItemId = 5, Rating = 5, Comment = "Fabulous", IsRecommended = true },
                new RatingModel { RatingId = 76, UserId = 22, ItemId = 24, Rating = 4, Comment = "Die Dynamik der Protagonisten ist eins a dargestellt", IsRecommended = true },
                new RatingModel { RatingId = 77, UserId = 22, ItemId = 34, Rating = 1, Comment = "Hatte Angst. Unterstütze auch keinen Mord", IsRecommended = false },
                new RatingModel { RatingId = 78, UserId = 3, ItemId = 34, Rating = 4, Comment = "Mega. Vor allem der Teil mit dem Zuckerhaus", IsRecommended = true },
                new RatingModel { RatingId = 80, UserId = 1, ItemId = 35, Rating = 1, Comment = "Nicht mein Verständnis der Wirtschaft", IsRecommended = false },
                new RatingModel { RatingId = 81, UserId = 2, ItemId = 35, Rating = 5, Comment = "Sollten alle mal lesen", IsRecommended = true },
                new RatingModel { RatingId = 82, UserId = 22, ItemId = 43, Rating = 3, Comment = "Habe immer nur verloren", IsRecommended = true },
                new RatingModel { RatingId = 83, UserId = 22, ItemId = 18, Rating = 4, Comment = "Liebe einfach Spiele mit 2", IsRecommended = true },
                new RatingModel { RatingId = 84, UserId = 17, ItemId = 43, Rating = 5, Comment = "Immer gewonnen", IsRecommended = true },
                new RatingModel { RatingId = 85, UserId = 17, ItemId = 49, Rating = 4, Comment = "Lustig", IsRecommended = true },
                new RatingModel { RatingId = 87, UserId = 17, ItemId = 48, Rating = 5, Comment = "Fantastisch", IsRecommended = true },
                new RatingModel { RatingId = 88, UserId = 17, ItemId = 50, Rating = 1, Comment = "Mag die Räuber nicht", IsRecommended = false },
                new RatingModel { RatingId = 89, UserId = 17, ItemId = 7, Rating = 4, Comment = "Mega", IsRecommended = true },
                new RatingModel { RatingId = 90, UserId = 17, ItemId = 32, Rating = 4, Comment = "Unterstütze diese Kidnapper", IsRecommended = true },
                new RatingModel { RatingId = 91, UserId = 17, ItemId = 47, Rating = 1, Comment = "Habe mich wieder geärgert.", IsRecommended = false },
                new RatingModel { RatingId = 92, UserId = 17, ItemId = 23, Rating = 4, Comment = "Endlich kann ich lesen", IsRecommended = true },
                new RatingModel { RatingId = 93, UserId = 17, ItemId = 51, Rating = 5, Comment = "Konnte meinem Bruder beweisen wer schlauer ist", IsRecommended = true },
                new RatingModel { RatingId = 94, UserId = 17, ItemId = 12, Rating = 1, Comment = "Was soll 12 überhaupt sein", IsRecommended = true },
                new RatingModel { RatingId = 95, UserId = 17, ItemId = 2, Rating = 2, Comment = "Zwei hat mich nicht überzeugt", IsRecommended = false },
                new RatingModel { RatingId = 96, UserId = 2, ItemId = 50, Rating = 5, Comment = "Mochte die Räuber so", IsRecommended = true },
                new RatingModel { RatingId = 98, UserId = 2, ItemId = 47, Rating = 5, Comment = "Immer gewonnen. Bin halt ein Glückskind", IsRecommended = true },
                new RatingModel { RatingId = 99, UserId = 2, ItemId = 30, Rating = 5, Comment = "Nicht ohne Grund eines seiner bekanntesten Werke", IsRecommended = true },
                new RatingModel { RatingId = 100, UserId = 2, ItemId = 31, Rating = 4, Comment = "\"Was bleibt mir nur außer mein Name?\" Dieses Zitat muss man einfach kennen", IsRecommended = true },
                new RatingModel { RatingId = 103, UserId = 22, ItemId = 51, Rating = 5, Comment = "Ich bin Herrscher der Welt", IsRecommended = true },
                new RatingModel { RatingId = 104, UserId = 22, ItemId = 48, Rating = 3, Comment = "Ich fands gut. meine Freunde aber nicht", IsRecommended = true },
                new RatingModel { RatingId = 105, UserId = 22, ItemId = 49, Rating = 5, Comment = "Gut Kombi aus Strategie und Glück", IsRecommended = true },
                new RatingModel { RatingId = 106, UserId = 2, ItemId = 12, Rating = 4, Comment = "Sehr gut, aber ich gebe nie volle Punktzahl", IsRecommended = true },
                new RatingModel { RatingId = 110, UserId = 3, ItemId = 52, Rating = 5, Comment = "Ein Augenöffnendes Erlebnis", IsRecommended = true },
                new RatingModel { RatingId = 111, UserId = 3, ItemId = 2, Rating = 2, Comment = "Zwei, weil einfach nicht gut geschrieben aber nette Bilder", IsRecommended = false },
                new RatingModel { RatingId = 112, UserId = 3, ItemId = 3, Rating = 4, Comment = "In der Mitte etwas zäh, aber das Ende macht alles wieder wett", IsRecommended = true },
                new RatingModel { RatingId = 113, UserId = 3, ItemId = 23, Rating = 5, Comment = "Mein Hund kann jetzt endlich mit mir reden", IsRecommended = true },
                new RatingModel { RatingId = 114, UserId = 3, ItemId = 49, Rating = 4, Comment = "Interessante Kombi aus Glück und Strategie", IsRecommended = true },
                new RatingModel { RatingId = 115, UserId = 22, ItemId = 23, Rating = 1, Comment = "Zu leicht", IsRecommended = false },
                new RatingModel { RatingId = 116, UserId = 22, ItemId = 12, Rating = 4, Comment = "Sehr spannend", IsRecommended = true },
                new RatingModel { RatingId = 117, UserId = 22, ItemId = 26, Rating = 3, Comment = "Nicht das schlechteste, aber auch nicht das beste", IsRecommended = true },
                new RatingModel { RatingId = 118, UserId = 22, ItemId = 31, Rating = 4, Comment = "Eine wunderbare Abhandlung über Hysterie und Massenpanik", IsRecommended = true }

            );
            modelBuilder.Entity<MessageModel>().HasData(
                //new MessageModel { MessageId = 1, SenderId = 1, ReceiverId = 5, Date = new DateTime(2021, 1, 15), Text = "Text", Type = MessageType.ExtensionRequest, Payload = "Payload" },
                //new MessageModel { MessageId = 2, SenderId = 5, ReceiverId = 1, Date = new DateTime(2021, 1, 16), Text = "Text", Type = MessageType.RequestResponse, Payload = "Payload" },
                //new MessageModel { MessageId = 3, SenderId = 1, ReceiverId = 4, Date = new DateTime(2021, 1, 1), Text = "Text", Type = MessageType.UserRegistered, Payload = "Payload" },
                //new MessageModel { MessageId = 4, SenderId = 4, ReceiverId = 1, Date = new DateTime(2021, 1, 2), Text = "Text", Type = MessageType.PasswordReset, Payload = "Payload" },
                //new MessageModel { MessageId = 5, SenderId = 0, ReceiverId = 0, Date = new DateTime(2021, 1, 3), Text = "Text", Type = MessageType.NewItem, Payload = "Payload" },
                //new MessageModel { MessageId = 6, SenderId = 1, ReceiverId = 5, Date = new DateTime(2021, 1, 4), Text = "Text", Type = MessageType.DamageReport, Payload = "Payload" },
                //new MessageModel { MessageId = 7, SenderId = 0, ReceiverId = 1, Date = new DateTime(2021, 1, 5), Text = "Text", Type = MessageType.ReturnReminder, Payload = "Payload" }

                new MessageModel { MessageId = 1, SenderId = 1, ReceiverId = 5, Date = new DateTime(2021, 1, 15), Text = "Text", Type = MessageType.ExtensionRequest, Payload = "Payload" },
                new MessageModel { MessageId = 2, SenderId = 5, ReceiverId = 1, Date = new DateTime(2021, 1, 16), Text = "Text", Type = MessageType.RequestResponse, Payload = "Payload" },
                new MessageModel { MessageId = 3, SenderId = 1, ReceiverId = 4, Date = new DateTime(2021, 1, 1), Text = "Text", Type = MessageType.UserRegistered, Payload = "Payload" },
                new MessageModel { MessageId = 4, SenderId = 4, ReceiverId = 1, Date = new DateTime(2021, 1, 2), Text = "Text", Type = MessageType.PasswordReset, Payload = "Payload" },
                new MessageModel { MessageId = 5, SenderId = 0, ReceiverId = 0, Date = new DateTime(2021, 1, 3), Text = "Text", Type = MessageType.NewItem, Payload = "Payload" },
                new MessageModel { MessageId = 6, SenderId = 1, ReceiverId = 5, Date = new DateTime(2021, 1, 4), Text = "Text", Type = MessageType.DamageReport, Payload = "Payload" },
                new MessageModel { MessageId = 7, SenderId = 0, ReceiverId = 1, Date = new DateTime(2021, 1, 5), Text = "Text", Type = MessageType.ReturnReminder, Payload = "Payload" },
                new MessageModel { MessageId = 244, SenderId = 0, ReceiverId = 0, Date = new DateTime(2024, 5, 21, 12, 53, 24), Text = "Der Artikel Mühle wurde zum Katalog hinzugefügt", Type = MessageType.NewItem, Payload = "Mühle" },
                new MessageModel { MessageId = 263, SenderId = 0, ReceiverId = 0, Date = new DateTime(2024, 5, 21, 13, 19, 41), Text = "Der Artikel Vogue wurde zum Katalog hinzugefügt", Type = MessageType.NewItem, Payload = "Vogue" },
                new MessageModel { MessageId = 285, SenderId = 13, ReceiverId = 4, Date = new DateTime(2024, 5, 21, 13, 40, 27), Text = "lissi@email.com hat eine Zurücksetzung des Passworts angefragt", Type = MessageType.PasswordReset, Payload = "lissi@email.com" },
                new MessageModel { MessageId = 291, SenderId = 19, ReceiverId = 4, Date = new DateTime(2024, 5, 21, 14, 44, 7), Text = "lissi hat sich registriert", Type = MessageType.UserRegistered, Payload = "NULL" },
                new MessageModel { MessageId = 292, SenderId = 20, ReceiverId = 4, Date = new DateTime(2024, 6, 3, 8, 34, 59), Text = "Delete hat sich registriert", Type = MessageType.UserRegistered, Payload = "NULL" },
                new MessageModel { MessageId = 293, SenderId = 21, ReceiverId = 4, Date = new DateTime(2024, 6, 3, 8, 39, 32), Text = "deleteAccount hat sich registriert", Type = MessageType.UserRegistered, Payload = "NULL" },
                new MessageModel { MessageId = 294, SenderId = 0, ReceiverId = 1, Date = new DateTime(2024, 6, 3, 8, 57, 29), Text = "Title2 ist seit 399 Tagen überfällig", Type = MessageType.ExtensionRequest, Payload = "4" },
                new MessageModel { MessageId = 295, SenderId = 0, ReceiverId = 5, Date = new DateTime(2024, 6, 3, 8, 58, 35), Text = "user2 hat Title9 seit 399 Tagen überfällig", Type = MessageType.NewItem, Payload = "9" },
                new MessageModel { MessageId = 296, SenderId = 0, ReceiverId = 5, Date = new DateTime(2024, 6, 3, 8, 58, 35), Text = "user1 hat Title2 seit 399 Tagen überfällig", Type = MessageType.ExtensionRequest, Payload = "4" },
                new MessageModel { MessageId = 297, SenderId = 0, ReceiverId = 5, Date = new DateTime(2024, 6, 3, 8, 58, 35), Text = "user2 hat Title3 seit 399 Tagen überfällig", Type = MessageType.ReturnOverdue, Payload = "5" },
                new MessageModel { MessageId = 298, SenderId = 17, ReceiverId = 5, Date = new DateTime(2024, 6, 3, 9, 16, 58), Text = "Spidey hat einen Schaden an Vogue (44) gemeldet. Die Schadensbeschreibung lautet: 'Risse'", Type = MessageType.DamageReport, Payload = "NULL" },
                new MessageModel { MessageId = 299, SenderId = 0, ReceiverId = 1, Date = new DateTime(2024, 6, 3, 11, 37, 56), Text = "Vogue ist in 2 Tagen fällig", Type = MessageType.ReturnReminder, Payload = "102" },
                new MessageModel { MessageId = 300, SenderId = 1, ReceiverId = 5, Date = new DateTime(2024, 6, 3, 13, 17, 25), Text = "user1 hat einen Schaden an Vogue (44) gemeldet. Die Schadensbeschreibung lautet: 'Knicke'", Type = MessageType.DamageReport, Payload = "NULL" },
                new MessageModel { MessageId = 301, SenderId = 1, ReceiverId = 5, Date = new DateTime(2024, 6, 3, 13, 27, 45), Text = "user1 hat einen Schaden an Vogue (44) gemeldet. Die Schadensbeschreibung lautet: 'Tassenabdruck'", Type = MessageType.DamageReport, Payload = "NULL" },
                new MessageModel { MessageId = 302, SenderId = 0, ReceiverId = 2, Date = new DateTime(2024, 6, 3, 13, 33, 0), Text = "Der von Ihnen reservierte Artikel Title8 ist jetzt verfügbar", Type = MessageType.ReservationNotification, Payload = "8" },
                new MessageModel { MessageId = 303, SenderId = 0, ReceiverId = 2, Date = new DateTime(2024, 6, 3, 13, 33, 28), Text = "Title3 ist seit 399 Tagen überfällig", Type = MessageType.ReturnReminder, Payload = "5" },
                new MessageModel { MessageId = 304, SenderId = 0, ReceiverId = 2, Date = new DateTime(2024, 6, 3, 13, 33, 28), Text = "Title9 ist seit 399 Tagen überfällig", Type = MessageType.ReturnReminder, Payload = "9" },
                new MessageModel { MessageId = 305, SenderId = 0, ReceiverId = 2, Date = new DateTime(2024, 6, 3, 13, 39, 27), Text = "TestReservation4 ist in 3 Tagen fällig", Type = MessageType.ReturnReminder, Payload = "104" },
                new MessageModel { MessageId = 306, SenderId = 0, ReceiverId = 2, Date = new DateTime(2024, 6, 3, 13, 52, 44), Text = "Vogue ist in 3 Tagen fällig", Type = MessageType.ReturnReminder, Payload = "105" },
                new MessageModel { MessageId = 307, SenderId = 0, ReceiverId = 17, Date = new DateTime(2024, 6, 3, 14, 4, 5), Text = "Vogue ist in 3 Tagen fällig", Type = MessageType.ReturnReminder, Payload = "109" },
                new MessageModel { MessageId = 308, SenderId = 0, ReceiverId = 17, Date = new DateTime(2024, 6, 4, 6, 46, 6), Text = "Vogue ist in 2 Tagen fällig", Type = MessageType.ReturnReminder, Payload = "110" },
                new MessageModel { MessageId = 309, SenderId = 2, ReceiverId = 5, Date = new DateTime(2024, 6, 4, 7, 11, 50), Text = "user2 hat einen Schaden an TestReservation4 (28) gemeldet. Die Schadensbeschreibung lautet: 'Feuer'", Type = MessageType.DamageReport, Payload = "NULL" },
                new MessageModel { MessageId = 310, SenderId = 0, ReceiverId = 3, Date = new DateTime(2024, 6, 4, 7, 16, 58), Text = "Der von Ihnen reservierte Artikel Title2 ist jetzt verfügbar", Type = MessageType.ReservationNotification, Payload = "2" },
                new MessageModel { MessageId = 311, SenderId = 0, ReceiverId = 2, Date = new DateTime(2024, 6, 4, 7, 19, 22), Text = "TestReservation1 ist in 3 Tagen fällig", Type = MessageType.ReturnReminder, Payload = "113" },
                new MessageModel { MessageId = 312, SenderId = 2, ReceiverId = 5, Date = new DateTime(2024, 6, 4, 7, 20, 17), Text = "user2 hat einen Schaden an TestReservation1 (25) gemeldet. Die Schadensbeschreibung lautet: 'Zerissen'", Type = MessageType.DamageReport, Payload = "NULL" },
                new MessageModel { MessageId = 313, SenderId = 2, ReceiverId = 5, Date = new DateTime(2024, 6, 4, 7, 24, 19), Text = "user2 hat einen Schaden an TestReservation2 (26) gemeldet. Die Schadensbeschreibung lautet: 'Explodiert'", Type = MessageType.DamageReport, Payload = "NULL" },
                new MessageModel { MessageId = 314, SenderId = 3, ReceiverId = 5, Date = new DateTime(2024, 6, 4, 7, 27, 44), Text = "user3 hat einen Schaden an TestReservation2 (26) gemeldet. Die Schadensbeschreibung lautet: 'Feuer'", Type = MessageType.DamageReport, Payload = "NULL" },
                new MessageModel { MessageId = 315, SenderId = 1, ReceiverId = 5, Date = new DateTime(2024, 6, 4, 7, 31, 35), Text = "user1 hat einen Schaden an Title2 (2) gemeldet. Die Schadensbeschreibung lautet: 'kaputt'", Type = MessageType.DamageReport, Payload = "NULL" },
                new MessageModel { MessageId = 316, SenderId = 0, ReceiverId = 1, Date = new DateTime(2024, 6, 4, 7, 36, 24), Text = "Vogue ist in 2 Tagen fällig", Type = MessageType.ReturnReminder, Payload = "118" },
                new MessageModel { MessageId = 317, SenderId = 1, ReceiverId = 5, Date = new DateTime(2024, 6, 4, 8, 33, 15), Text = "user1 hat einen Schaden an TestReservation2 (26) gemeldet. Die Schadensbeschreibung lautet: 'Eselsohr'", Type = MessageType.DamageReport, Payload = "NULL" },
                new MessageModel { MessageId = 318, SenderId = 0, ReceiverId = 2, Date = new DateTime(2024, 6, 4, 8, 53, 55), Text = "Der von Ihnen reservierte Artikel TestReservation3 ist jetzt verfügbar", Type = MessageType.ReservationNotification, Payload = "27" },
                new MessageModel { MessageId = 319, SenderId = 0, ReceiverId = 2, Date = new DateTime(2024, 6, 4, 8, 54, 21), Text = "Der von Ihnen reservierte Artikel TestReservation4 ist jetzt verfügbar", Type = MessageType.ReservationNotification, Payload = "28" },
                new MessageModel { MessageId = 320, SenderId = 1, ReceiverId = 5, Date = new DateTime(2024, 6, 4, 8, 54, 21), Text = "user1 hat einen Schaden an TestReservation4 (28) gemeldet. Die Schadensbeschreibung lautet: ''", Type = MessageType.DamageReport, Payload = "NULL" },
                new MessageModel { MessageId = 321, SenderId = 2, ReceiverId = 5, Date = new DateTime(2024, 6, 4, 9, 0, 34), Text = "user2 hat einen Schaden an TestReservation4 (28) gemeldet. Die Schadensbeschreibung lautet: 'Risse'", Type = MessageType.DamageReport, Payload = "NULL" },
                new MessageModel { MessageId = 322, SenderId = 3, ReceiverId = 5, Date = new DateTime(2024, 6, 4, 9, 3, 11), Text = "user3 hat einen Schaden an TestReservation4 (28) gemeldet. Die Schadensbeschreibung lautet: 'Feuer'", Type = MessageType.DamageReport, Payload = "NULL" },
                new MessageModel { MessageId = 323, SenderId = 0, ReceiverId = 0, Date = new DateTime(2024, 6, 4, 11, 22, 39), Text = "Der Artikel Supernatural Evangelium wurde zum Katalog hinzugefügt", Type = MessageType.NewItem, Payload = "Supernatural Evangelium" },
                new MessageModel { MessageId = 324, SenderId = 22, ReceiverId = 4, Date = new DateTime(2024, 6, 4, 11, 51, 37), Text = "tano@email.com hat eine Zurücksetzung des Passworts angefragt", Type = MessageType.PasswordReset, Payload = "tano@email.com" },
                new MessageModel { MessageId = 325, SenderId = 22, ReceiverId = 5, Date = new DateTime(2024, 6, 4, 11, 57, 30), Text = "snips hat einen Schaden an Schach (42) gemeldet. Die Schadensbeschreibung lautet: 'Dame fehlt'", Type = MessageType.DamageReport, Payload = "NULL" },
                new MessageModel { MessageId = 326, SenderId = 22, ReceiverId = 5, Date = new DateTime(2024, 6, 4, 12, 4, 25), Text = "snips hat einen Schaden an Title4 (4) gemeldet. Die Schadensbeschreibung lautet: '4 Seiten fehelen'", Type = MessageType.DamageReport, Payload = "NULL" },
                new MessageModel { MessageId = 327, SenderId = 22, ReceiverId = 5, Date = new DateTime(2024, 6, 5, 6, 57, 7), Text = "snips hat einen Schaden an Title1Updated (1) gemeldet. Die Schadensbeschreibung lautet: 'Seite 34 fehlt'", Type = MessageType.DamageReport, Payload = "NULL" },
                new MessageModel { MessageId = 328, SenderId = 0, ReceiverId = 0, Date = new DateTime(2024, 6, 5, 9, 29, 58), Text = "Der Artikel Es wurde zum Katalog hinzugefügt", Type = MessageType.NewItem, Payload = "Es" },
                new MessageModel { MessageId = 329, SenderId = 0, ReceiverId = 0, Date = new DateTime(2024, 6, 5, 10, 53, 53), Text = "Der Artikel Mensch-ärger-dich-nicht wurde zum Katalog hinzugefügt", Type = MessageType.NewItem, Payload = "Mensch-ärger-dich-nicht" },
                new MessageModel { MessageId = 330, SenderId = 0, ReceiverId = 0, Date = new DateTime(2024, 6, 5, 10, 59, 34), Text = "Der Artikel Phase 10 wurde zum Katalog hinzugefügt", Type = MessageType.NewItem, Payload = "Phase 10" },
                new MessageModel { MessageId = 331, SenderId = 0, ReceiverId = 0, Date = new DateTime(2024, 6, 5, 11, 0, 55), Text = "Der Artikel Skyjo wurde zum Katalog hinzugefügt", Type = MessageType.NewItem, Payload = "Skyjo" },
                new MessageModel { MessageId = 332, SenderId = 0, ReceiverId = 0, Date = new DateTime(2024, 6, 5, 11, 3, 16), Text = "Der Artikel Catan wurde zum Katalog hinzugefügt", Type = MessageType.NewItem, Payload = "Catan" },
                new MessageModel { MessageId = 333, SenderId = 0, ReceiverId = 0, Date = new DateTime(2024, 6, 5, 11, 5, 4), Text = "Der Artikel Risiko wurde zum Katalog hinzugefügt", Type = MessageType.NewItem, Payload = "Risiko" },
                new MessageModel { MessageId = 334, SenderId = 0, ReceiverId = 0, Date = new DateTime(2024, 6, 7, 11, 30, 5), Text = "Der Artikel TestReturnItem wurde zum Katalog hinzugefügt", Type = MessageType.NewItem, Payload = "TestReturnItem" },
                new MessageModel { MessageId = 335, SenderId = 0, ReceiverId = 3, Date = new DateTime(2024, 6, 7, 12, 17, 40), Text = "Der von Ihnen reservierte Artikel TestReturnItem ist jetzt verfügbar", Type = MessageType.ReservationNotification, Payload = "52" },
                new MessageModel { MessageId = 348, SenderId = 22, ReceiverId = 5, Date = new DateTime(2024, 6, 10, 7, 22, 16), Text = "snips hat einen Schaden an TestReservation2 (26) gemeldet. Die Schadensbeschreibung lautet: 'Keine Beschreibung'", Type = MessageType.DamageReport, Payload = "NULL" },
                new MessageModel { MessageId = 349, SenderId = 22, ReceiverId = 5, Date = new DateTime(2024, 6, 10, 7, 23, 41), Text = "snips hat einen Schaden an Hexenjagd (31) gemeldet. Die Schadensbeschreibung lautet: 'Keine Beschreibung'", Type = MessageType.DamageReport, Payload = "NULL" },
                new MessageModel { MessageId = 350, SenderId = 0, ReceiverId = 5, Date = new DateTime(2024, 9, 17, 6, 42, 32), Text = "user2 hat Title1Updated seit 91 Tagen überfällig", Type = MessageType.ReturnReminder, Payload = "218" },
                new MessageModel { MessageId = 351, SenderId = 0, ReceiverId = 5, Date = new DateTime(2024, 9, 17, 6, 42, 32), Text = "user2 hat Vogue seit 96 Tagen überfällig", Type = MessageType.ReturnReminder, Payload = "220" },
                new MessageModel { MessageId = 352, SenderId = 0, ReceiverId = 5, Date = new DateTime(2024, 9, 17, 6, 42, 32), Text = "user2 hat Supernatural Evangelium seit 96 Tagen überfällig", Type = MessageType.ReturnReminder, Payload = "221" },
                new MessageModel { MessageId = 353, SenderId = 0, ReceiverId = 5, Date = new DateTime(2024, 9, 17, 6, 42, 32), Text = "user2 hat Title4 seit 96 Tagen überfällig", Type = MessageType.ReturnReminder, Payload = "219" },
                new MessageModel { MessageId = 354, SenderId = 0, ReceiverId = 5, Date = new DateTime(2024, 9, 17, 6, 42, 32), Text = "user2 hat Biene Maja seit 97 Tagen überfällig", Type = MessageType.ReturnReminder, Payload = "217" },
                new MessageModel { MessageId = 355, SenderId = 0, ReceiverId = 5, Date = new DateTime(2024, 9, 17, 6, 42, 32), Text = "user2 hat TestReservation1 seit 89 Tagen überfällig", Type = MessageType.ReturnReminder, Payload = "216" },
                new MessageModel { MessageId = 356, SenderId = 0, ReceiverId = 0, Date = new DateTime(2024, 9, 17, 6, 43, 0), Text = "Der Artikel Das Simarillion wurde zum Katalog hinzugefügt", Type = MessageType.NewItem, Payload = "Das Simarillion" },
                new MessageModel { MessageId = 357, SenderId = 25, ReceiverId = 5, Date = new DateTime(2024, 9, 17, 12, 23, 4), Text = "userin5 hat einen Schaden an Vogue (44) gemeldet. Die Schadensbeschreibung lautet: 'Wasserschaden'", Type = MessageType.DamageReport, Payload = "NULL" },
                new MessageModel { MessageId = 359, SenderId = 0, ReceiverId = 25, Date = new DateTime(2024, 9, 17, 12, 24, 13), Text = "Title2 ist in 2 Tagen fällig", Type = MessageType.ReturnReminder, Payload = "241" },
                new MessageModel { MessageId = 360, SenderId = 5, ReceiverId = 0, Date = new DateTime(2024, 9, 17, 12, 27, 4), Text = "userin5 hat den Schaden an Vogue (44) gemeldet", Type = MessageType.DamageReport, Payload = "NULL" }

           );
        }
    }
}
