using Microsoft.EntityFrameworkCore;

namespace WinFormsApp1.DataBase
{
    public class LoginHistory
    {
        public int LoginHistoryId { get; set; }
        public DateTime AttemptTime { get; set; } = DateTime.Now;
        public string Login { get; set; } = string.Empty;
        public bool IsSuccessful { get; set; }
    }


    public class LocalDbContext : DbContext
    {
        public LocalDbContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<LoginHistory> LoginHistories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=local_history.db");
        }

        public void AddLoginHistory(string login, bool isSuccessful)
        {
            try
            {
                using var db = new LocalDbContext();
                db.LoginHistories.Add(new LoginHistory
                {
                    Login = login,
                    IsSuccessful = isSuccessful,
                    AttemptTime = DateTime.Now
                });
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении истории входа: " + ex.Message);
            }
        }

        public List<LoginHistory> GetLoginHistory(string? filter = null, bool sortDesc = false)
        {
            try
            {
                var query = LoginHistories.AsQueryable();

                if (!string.IsNullOrWhiteSpace(filter))
                    query = query.Where(h => h.Login.Contains(filter));

                query = sortDesc
                    ? query.OrderByDescending(h => h.AttemptTime)
                    : query.OrderBy(h => h.AttemptTime);

                return query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при чтении истории входа: " + ex.Message);
                return new List<LoginHistory>();
            }
        }
    }
}
