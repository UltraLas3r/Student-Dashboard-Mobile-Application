using mschreiber_c971MobileApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace mschreiber_c971MobileApp.Services
{
    public class DatabaseService
    {
        private static SQLiteAsyncConnection _db;
        private static SQLiteConnection _dbConnection;
        private readonly int _totalCourseCount;
        
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
            await _db.CreateTableAsync<Assessment>(); 
            
        }

        #region Count Methods
        public static async Task<int> GetCourseCount(int _termId)
        {
            await Init();
            var allCourseRecords = _dbConnection.Query<CourseInfo>($"SELECT * FROM CourseInfo WHERE TermId = '{_termId}'");
            int courseCount = allCourseRecords.Count();

            return courseCount;

        }

        public static async Task<int> GetTermCount()
        {
            await Init();
            var termCount = _dbConnection.ExecuteScalar<int>("SELECT COUNT(*) FROM TermInfo");
            return termCount;
        }

        
       
        public static async Task<int> GetOACount(int _courseId, string testType)
        {
            var ObjectiveAssessments = await _db.QueryAsync<Assessment>($"SELECT AssessmentType FROM Assessment WHERE courseId = '{_courseId}' AND AssessmentType ='{testType}'");
            int ObjectiveCount = ObjectiveAssessments.Count();
            return ObjectiveCount;

        }

        public static async Task<int> GetPACount(int _courseId, string testType)
        {
            var performanceAssessments = await _db.QueryAsync<Assessment>($"SELECT AssessmentType FROM Assessment WHERE courseId = '{_courseId}' AND AssessmentType ='{testType}'");
            int performanceCount = performanceAssessments.Count();
            return performanceCount;

        }


        //TODO: Remove these, for testing purposes
        public static async Task<int> GetALLPACount()
        {
            var performanceAssessments = await _db.QueryAsync<Assessment>($"SELECT AssessmentType FROM Assessment WHERE AssessmentType = 'Performance'");
            int performanceCount = performanceAssessments.Count();
           
            return performanceCount;
        }

        public static async Task<int> GetALLOACount()
        {
            var objectiveAssessments = await _db.QueryAsync<Assessment>($"SELECT AssessmentType FROM Assessment WHERE AssessmentType = 'Objective'");
            int objectiveCount = objectiveAssessments.Count();
            return objectiveCount;
        }

        #endregion

        #region Term methods
        public static async Task AddTerm(string name, DateTime startDate, DateTime anticipatedEndDate)
        {
            await Init();

            var term = new TermInfo()
            {
                Name = name,
                StartDate = startDate,
                AnticipatedEndDate = anticipatedEndDate
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

        public static async Task UpdateTerm(int id, string name, DateTime startDate, DateTime endDate)
        {
            await Init();

            var termQuery = await _db.Table<TermInfo>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();

            if (termQuery != null)
            {
                termQuery.Name = name;  
                termQuery.StartDate = startDate;
                termQuery.AnticipatedEndDate = endDate;

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

        #region Assessment Methods

        public static async Task<IEnumerable<Assessment>> GetAssessments(int courseId)
        {
            await Init();
            var newAssessment = await _db.Table<Assessment>()
            .Where(i => i.CourseId == courseId)
            .ToListAsync();

            
            return newAssessment;
        }

       

        public static async Task<IEnumerable<Assessment>> GetAssessments() //get ALL assessments for notifications
        {
            await Init();

            var assessments = await _db.Table<Assessment>().ToListAsync();


            return assessments;
        }


        public static async Task AddAssessments(int courseId, string assessmentName, string assessmentType, DateTime startDate, DateTime anticipatedEndDate, bool startDateNotify, bool endDateNotify)
        {
            await Init();

            var Assessment = new Assessment()
            {
                  //assessmentId    <<< Gonna need some work to adjust this if i Change anything in the constructor
                CourseId = courseId,  
                AssessmentName = assessmentName,
                AssessmentType = assessmentType,
                StartDate = startDate,
                AnticipatedEndDate = anticipatedEndDate,
                StartDateNotify = startDateNotify,
                EndDateNotify = endDateNotify
            };

            await _db.InsertAsync(Assessment);

            var assessmentNameThing = Assessment.AssessmentName;
        }


        public static async Task UpdateAssessment(int courseId, string assessmentName, DateTime startDate, DateTime anticipatedEndDate)
        {
            await Init();

            var assessmentQuery = await _db.Table<Assessment>()
                .Where(i => i.CourseId == courseId)
                .FirstOrDefaultAsync();

            if (assessmentQuery != null)
            {
                assessmentQuery.CourseId = courseId;
                assessmentQuery.AssessmentName = assessmentName;
                assessmentQuery.StartDate = startDate;
                assessmentQuery.AnticipatedEndDate = anticipatedEndDate;

                await _db.UpdateAsync(assessmentQuery);
            }

        }


        public static async Task RemoveAssessment(int courseId, string assessmentType)
        {
            await Init();

            //var assessmentQuery = await _db.Table<Assessment>()
            // .Where(i => i.CourseId == courseId)
            // .FirstOrDefaultAsync();

            var assessmentQuery = await _db.Table<Assessment>()
                .Where(i => i.CourseId == courseId && i.AssessmentType == assessmentType)
                .FirstOrDefaultAsync();

            if (assessmentQuery != null)
            {
                assessmentQuery.CourseId = courseId;
                assessmentQuery.AssessmentType = assessmentType;
                

                await _db.UpdateAsync(assessmentQuery);
            }




            await _db.DeleteAsync<Assessment>(courseId);
        }


        #endregion

        #region courses methods

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

        public static async Task AddCourse(int termId, string courseName, string courseStatus, DateTime startDate, DateTime anticipatedEndDate, string instructor, string phone, string email, string notes)
        {
            var _termId = termId;
            int courseCount = await GetCourseCount(_termId);

            if (courseCount >= 6)
            {
                await Application.Current.MainPage.DisplayAlert("Term Full", "Only 6 courses per term \nUnable to add more courses to term", "Ok");
            }

            if (courseCount <= 6)
            {
                await Init();

                var courseInfo = new CourseInfo
                {
                    TermId = termId,
                    CourseName = courseName,
                    CourseStatus = courseStatus,
                    Instructor = instructor,
                    Phone = phone,
                    Email = email,
                    StartDate = startDate,
                    AnticipatedEndDate = anticipatedEndDate,
                    Notes = notes
                };

                await _db.InsertAsync(courseInfo);

                var id = courseInfo.Id; //returns the course Id

            }
        }

        public static async Task RemoveCourse(int id)
        {
            await Init();

            await _db.DeleteAsync<CourseInfo>(id);
        }

        public static async Task UpdateCourse(int courseId, string courseName, string courseStatus, DateTime startDate, DateTime anticipatedEndDate, string instructor, string phone, string email, string notes)
        {
            await Init();

            var courseQuery = await _db.Table<CourseInfo>()
                .Where(i => i.Id == courseId)
                .FirstOrDefaultAsync();

            if (courseQuery != null)
            {
                courseQuery.Id = courseId;
                courseQuery.CourseName = courseName;
                courseQuery.CourseStatus = courseStatus;
                courseQuery.Instructor = instructor;
                courseQuery.Phone = phone;
                courseQuery.Email = email;
                courseQuery.StartDate = startDate;
                courseQuery.AnticipatedEndDate = anticipatedEndDate;
                
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
                Name = "Sample 1",
                StartDate = DateTime.Now,
                AnticipatedEndDate = DateTime.Now.AddDays(+100),
            };

            await _db.InsertAsync(term1);

            CourseInfo course1a = new CourseInfo
            {
                CourseName = "Lion Course",
                Instructor = "Joe Bob",
                Phone = "555 555 5555",
                Email = "Joe@gmail.com",
                StartDate = DateTime.Now,
                AnticipatedEndDate = DateTime.Now.AddDays(+90),
                StartNotification = true,
                TermId = term1.Id
            };
            await _db.InsertAsync(course1a);

            CourseInfo course1b = new CourseInfo
            {
                CourseName = "Tiger Course",
                Instructor = "Jessica Anne",
                Phone = "556 777 8888",
                Email = "Janne@gmail.com",
                StartDate = DateTime.Now,
                AnticipatedEndDate = DateTime.Now.AddDays(+90),
                StartNotification = true,
                TermId = term1.Id
            };
            await _db.InsertAsync(course1b);

            CourseInfo course1c = new CourseInfo
            {
                CourseName = "Eagle Course",
                Instructor = "Maureen McDevitt",
                Phone = "888 888 0099",
                Email = "MAMCD@gmail.com",
                StartDate = DateTime.Now,
                AnticipatedEndDate = DateTime.Now.AddDays(+90),
                StartNotification = true,
                TermId = term1.Id
            };

            await _db.InsertAsync(course1c);

            //TODO delete this extra data insert another Term with Courses attached

        //    TermInfo term2 = new TermInfo
        //    {
        //        Name = "Term 2",
        //        StartDate = DateTime.Now,
        //        AnticipatedEndDate = DateTime.Now.AddDays(+100),
        //    };
        //    await _db.InsertAsync(term2);

        //    CourseInfo course2a = new CourseInfo
        //    {
        //        CourseName = "Mountain Course",
        //        Instructor = "John Muir",
        //        Phone = "555555555",
        //        Email = "yosemiteGuy@gmail.com",
        //        StartDate = DateTime.Now,
        //        AnticipatedEndDate = DateTime.Now.AddDays(+90),
        //        StartNotification = true,
        //        TermId = term2.Id
        //    };
        //    await _db.InsertAsync(course2a);

        //    CourseInfo course2b = new CourseInfo
        //    {
        //        CourseName = "River Course",
        //        Instructor = "Mary Catherine Ruth",
        //        Phone = "555555555",
        //        Email = "Priory@gmail.com",
        //        StartDate = DateTime.Now,
        //        AnticipatedEndDate = DateTime.Now.AddDays(+90),
        //        StartNotification = true,
        //        TermId = term2.Id
        //    };
        //    await _db.InsertAsync(course2b);

        //    CourseInfo course2c = new CourseInfo
        //    {
        //        CourseName = "Meadows Course",
        //        Instructor = "Tiger Woods",
        //        Phone = "555555555",
        //        Email = "GolfLvr@gmail.com",
        //        StartDate = DateTime.Now,
        //        AnticipatedEndDate = DateTime.Now.AddDays(+90),
        //        StartNotification = true,
        //        TermId = term2.Id
        //    };
        //    await _db.InsertAsync(course2c);

        }

        public static async
        Task
         ClearSampleData()
        {
            await Init();

            await _db.DropTableAsync<TermInfo>();
            await _db.DropTableAsync<CourseInfo>();
            await _db.DropTableAsync<Assessment>();

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
