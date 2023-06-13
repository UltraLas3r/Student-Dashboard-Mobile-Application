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

        #region Term methods
        public static async Task AddTerm(string name, string season, int enrolled, decimal price, DateTime creationDate)
        {
            await Init();

            var term = new TermInfo()
            {
                Name = name,
                Season = season,
                Enrolled = enrolled,
                Price = price,
                CreationDate = creationDate,

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

        public static async Task UpdateTerm(int id, string name, string season, int enrolled, decimal price, DateTime creationDate)
        {
            await Init();

            var termQuery = await _db.Table<TermInfo>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();

            if (termQuery != null)
            {
                termQuery.Name = name;
                termQuery.Season = season;
                termQuery.Enrolled = enrolled;
                termQuery.Price = price;
                termQuery.CreationDate = creationDate;

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

        public static async Task AddCourse(int termId, string name, string season, int enrolled, decimal price, DateTime creationDate, bool notificationStart, string notes)
        {
            await Init();

            var courseInfo = new CourseInfo
            {
                TermId = termId,
                Name = name,
                Season = season,
                Enrolled = enrolled,
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

        public static async Task UpdateCourse(int id, string name, string season, int enrolled, decimal price, DateTime creationDate, bool notificationStart, string notes)
        {
            await Init();

            var courseQuery = await _db.Table<CourseInfo>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();

            if (courseQuery != null)
            {
                courseQuery.Name = name;
                courseQuery.Season = season;
                courseQuery.Enrolled = enrolled;
                courseQuery.Price = price;
                courseQuery.CreationDate = creationDate;
                courseQuery.StartNotification = notificationStart;
                courseQuery.Notes = notes;

                await _db.UpdateAsync(courseQuery);
            }

        }


        #endregion

        #region Sample Data

        public static async void LoadSampleData()
        {
            await Init();

            TermInfo term1 = new TermInfo
            {
                Name = "Term 1",
                Season = "Fall",
                Enrolled = 235,
                Price = 925,
                CreationDate = DateTime.Today.Date
            };

            await _db.InsertAsync(term1);

            CourseInfo course1a = new CourseInfo
            {
                Name = "Lion Course",
                Season = "Winter",
                Enrolled = 11,
                Price = 423,
                CreationDate = DateTime.Now,
                StartNotification = true,
                TermId = term1.Id

            };
            await _db.InsertAsync(course1a);

            CourseInfo course1b = new CourseInfo
            {
                Name = "Tiger Course",
                Season = "Orange",
                Enrolled = 13,
                Price = 322,
                CreationDate = DateTime.Now,
                StartNotification = true,
                TermId = term1.Id
            };
            await _db.InsertAsync(course1b);

            //insert another gadget with some widgets

            TermInfo term2 = new TermInfo
            {
                Name = "Term 2",
                Season = "Winter",
                Enrolled = 545,
                Price = 1500,
                CreationDate = DateTime.Today.Date
            };
            await _db.InsertAsync(term2);

            CourseInfo course2a = new CourseInfo
            {
                Name = "Otter Course",
                Season = "Winter",
                Enrolled= 175,
                Price = 145,
                CreationDate = DateTime.Now,
                StartNotification = true,
                TermId = term2.Id
            };
            await _db.InsertAsync(course2a);

            CourseInfo course2b = new CourseInfo
            {
                Name = "Giraffe Course",
                Season = "Winter",
                Enrolled = 165,
                Price = 175,
                CreationDate = DateTime.Now,
                StartNotification = true,
                TermId = term2.Id
            };
            await _db.InsertAsync(course2b);

            CourseInfo course2c = new CourseInfo
            {
                Name = "Cheetah Course",
                Season = "Winter",
                Enrolled = 166,
                Price = 168,
                CreationDate = DateTime.Now,
                StartNotification = true,
                TermId = term2.Id
            };
            await _db.InsertAsync(course2c);

        }

        public static async
        Task
         ClearSampleData()
        {
            await Init();

            await _db.DropTableAsync<TermInfo>();
            await _db.DropTableAsync<CourseInfo>();

            _db = null;
            _dbConnection = null;

        }

        public static async void LoadSampleDataSql()
        {
            await Init();
        }

        #endregion



      
       


    }
}
