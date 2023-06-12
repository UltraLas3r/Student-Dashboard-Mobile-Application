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

        #region courses methods

        public static async Task AddCourse(int termId, string name, string color, int inStock, decimal price, DateTime creationDate, bool notificationStart, string notes)
        {
            await Init();

            var courseInfo = new CourseInfo
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

            await _db.InsertAsync(courseInfo);

            var id = courseInfo.Id; //returns the course Id

        }

        public static async Task RemoveCourse(int id)
        {
            await Init();

            await _db.DeleteAsync<CourseInfo>(id);
        }

        public static async Task<IEnumerable<CourseInfo>> GetCourses(int termId) 
        {
            await Init();

            var courses = await _db.Table<CourseInfo>().Where(i => i.TermId == termId).ToListAsync();

            return courses;
        }

        public static async Task<IEnumerable<CourseInfo>> GetCourses() //get ALL courses for notifications
        {
            await Init();

            var courses = await _db.Table<CourseInfo>().ToListAsync();


            return courses;
        }

        public static async Task UpdateCourse(int id, string name, string color, int inStock, decimal price, DateTime creationDate, bool notificationStart, string notes)
        {
            await Init();

            var courseQuery = await _db.Table<CourseInfo>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();

            if (courseQuery != null)
            {
                courseQuery.Name = name;
                courseQuery.Color = color;
                courseQuery.InStock = inStock;
                courseQuery.Price = price;
                courseQuery.CreationDate = creationDate;
                courseQuery.StartNotification = notificationStart;
                courseQuery.Notes = notes;

                await _db.UpdateAsync(courseQuery);
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
            await _db.CreateTableAsync<CourseInfo>();
        }


    }
}
