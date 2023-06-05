using mschreiber_c971MobileApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace mschreiber_c971MobileApp.Services
{
    public static class DatabaseService
    {
        #region Term methods
        public static async Task AddTerm(string name, string color, int inStock, decimal price, DateTime creationDate)
        {
            await Init();

            var term = new TermInfo()
            {
                Name = name,
                Color = color,
                InStock = inStock,
                Price = price,
                CreateionDate = creationDate,

            };

            await _db.InsertAsync(term);

            var id = term.Id; //returns the TermId.

        }
        public static async Task RemoveTerm(int id)
        {
            await Init();

            await _db.DeleteAsync<TermInfo>(id);
        }

        public static async Task UpdateTerms()
        {
            await Init();
        }

        public static async Task UpdateTerm(int id, string name, string color, int inStock, decimal price, DateTime creationDate)
        {
            await Init();

            var termQuery = await _db.Table<TermInfo>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();

            if (termQuery != null)
            {
                termQuery.Name = name;
                termQuery.Color = color;
                termQuery.InStock = inStock;
                termQuery.Price = price;
                termQuery.CreateionDate = creationDate;

                await _db.UpdateAsync(termQuery);

            }
        }

        public static async Task<IEnumerable<TermInfo>> GetTerms()
        {
            await Init();

            var terms = await _db.Table<TermInfo>().ToListAsync();

            return terms;
        }


        #endregion

        #region Classes methods

        public static async Task AddClass(int termId, string name, string color, int inStock, decimal price, DateTime creationDate, bool notificationStart, string notes)
        {
            await Init();

            var classInfo = new ClassInfo
            {
                TermId = termId,
                Name = name,
                Color = color,
                InStock = inStock,
                Price = price,
                CreationDate = creationDate,
                StartNotification = notificationStart,
                Notes = notes
            };

            await _db.InsertAsync(classInfo);

            var id = classInfo.Id; //returns the WidgetId

        }

        public static async Task RemoveClass(int id)
        {
            await Init();

            await _db.DeleteAsync<ClassInfo>(id);
        }

        public static async Task<IEnumerable<ClassInfo>> GetWidgets(int termId) 
        {
            await Init();

            var widgets = await _db.Table<ClassInfo>().Where(i => i.TermId == termId).ToListAsync();

            return widgets;
        }

        public static async Task<IEnumerable<ClassInfo>> GetWidgets() //get ALL widgets for notifications
        {
            await Init();

            var classes = await _db.Table<ClassInfo>().ToListAsync();


            return classes;
        }

        public static async Task UpdateClass(int id, string name, string color, int inStock, decimal price, DateTime creationDate, bool notificationStart, string notes)
        {
            await Init();

            var classQuery = await _db.Table<ClassInfo>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();

            if (classQuery != null)
            {
                classQuery.Name = name;
                classQuery.Color = color;
                classQuery.InStock = inStock;
                classQuery.Price = price;
                classQuery.CreationDate = creationDate;
                classQuery.StartNotification = notificationStart;
                classQuery.Notes = notes;

                await _db.UpdateAsync(classQuery);
            }

        }


        #endregion

        private static SQLiteAsyncConnection _db;
        private static SQLiteConnection _dbConnection;
        static async Task Init()
        {
            if (_db != null)
            {
                return;
            }

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Terms.db");

            _db = new SQLiteAsyncConnection(databasePath);
            _dbConnection = new SQLiteConnection(databasePath);

            await _db.CreateTableAsync<TermInfo>();
            await _db.CreateTableAsync<ClassInfo>();
        }


    }
}
