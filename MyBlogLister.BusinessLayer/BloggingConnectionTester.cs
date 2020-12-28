//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data;
using System.Data.Entity;
using MyBlogLister.Data;

namespace MyBlogLister.BusinessLayer.BusinessLayer
{
    /// <summary>
    ///     Tests whether the data source that undergirds the Blogging
    ///     is connected and/or available.
    /// </summary>
    public static class BloggingConnectionTester
    {
        /// <summary>
        ///     Initializes the one and only static instance of this class.
        /// </summary>
        static BloggingConnectionTester() => ResetDiagnosticProperties();
        
        /// <summary>
        ///     Gets the connection string that was most recently utilized
        ///     in order to test the connection to the data source.
        /// </summary>
        public static string LastUsedConnectionString { get; private set; }
        
        /// <summary>
        ///     Gets a reference to a <see cref="T:System.Exception" /> object
        ///     that contains information about the last error.
        /// </summary>
        public static Exception LastError { get; private set; }
        
        /// <summary>
        ///     Checks whether a database associated with the given DbContext is even
        ///     available
        ///     (i.e., online vs. offline).
        /// </summary>
        /// <returns>True if the database is online and accessible; false otherwise.</returns>
        public static bool IsDatabaseOnline()
        {
            var result = false;
        
            using (var db = new BloggingContext())
            {
                result = TestConnectionToDatabase(db);
            }
        
            return result;
        }
        
        /// <summary>
        ///     Checks whether a database associated with the given DbContext is even
        ///     available
        ///     (i.e., online vs. offline).
        /// </summary>
        /// <returns>True if the database is online and accessible; false otherwise.</returns>
        public static bool IsDatabaseOnline(string connectionString)
        {
            var result = false;
        
            if (string.IsNullOrWhiteSpace(connectionString))
                return result;
        
            using (var db = new BloggingContext(connectionString))
            {
                result = TestConnectionToDatabase(db);
            }
        
            return result;
        }
        
        /// <summary>
        ///     Used internally to ensure the data source connection associated with a
        ///     <see cref="T:System.Data.Entity.DbContext" /> is gracefully closed.
        /// </summary>
        /// <param name="db">
        ///     A <see cref="T:System.Data.Entity.DbContext" /> that is a reference to the
        ///     database context object whose connection is to be closed.
        /// </param>
        /// <remarks>
        ///     This method should only be called from a <c>finally</c> block.
        /// </remarks>
        private static void CloseDatabaseConnection(DbContext db)
        {
            if (db == null)
                return; // simply fail to operate if passed a null
        
            // check the state of the db connection.  If it's in any other
            // state except for closed, then call Close() on it to release
            // operating system resources.  We do this in the finally block
            // because this needs to happen whether or not an exception got
            // thrown.
            if (db.Database.Connection.State != ConnectionState.Closed)
                db.Database.Connection.Close();
        }
        
        /// <summary>
        ///     Initializes the value of the
        ///     <see
        ///         cref="P:MyBlogLister.BusinessLayer.BusinessLayer.BloggingConnectionTester.LastUsedConnectionString" />
        ///     property to the connection string that was last utilized by the
        ///     <paramref name="db" /> object.
        /// </summary>
        /// <param name="db">
        ///     A <see cref="T:System.Data.Entity.DbContext" /> that is a reference to the
        ///     database context object whose connection is to be closed.
        /// </param>
        /// <remarks>
        ///     This method does nothing if <paramref name="db" /> or any of its
        ///     properties are a null reference.
        /// </remarks>
        private static void InitializeLastUsedConnectionString(DbContext db)
        {
            if (db == null || db.Database == null ||
                db.Database.Connection == null)
                return;
        
            LastUsedConnectionString = db.Database.Connection.ConnectionString;
        }
        
        /// <summary>
        ///     Tests the connection to the database that is held by the
        ///     data context, a reference to which is passed in the
        ///     <paramref name="db" /> parameter.
        /// </summary>
        /// <param name="db">
        ///     A <see cref="T:System.Data.Entity.DbContext" /> that is a reference to the
        ///     database context object whose connection is to be closed.
        /// </param>
        /// <returns>
        ///     Value indicating whether the connection to the data source could be
        ///     opened successfully.
        /// </returns>
        private static bool TestConnectionToDatabase(DbContext db)
        {
            var result = false;
        
            ResetDiagnosticProperties();
        
            if (db == null)
                return result;
        
            InitializeLastUsedConnectionString(db);
        
            try
            {
                if (db.Database.Connection.State != ConnectionState.Open)
                    db.Database.Connection.Open();
        
                result = db.Database.Exists();
            }
            catch (Exception ex)
            {
                result = false;
        
                LastError = ex;
            }
            finally
            {
                CloseDatabaseConnection(db);
            }
        
            return result;
        }
        
        /// <summary>
        ///     Resets the value of the
        ///     <see
        ///         cref="P:MyBlogLister.BusinessLayer.BusinessLayer.BloggingConnectionTester.LastUsedConnectionString" />
        ///     and
        ///     <see
        ///         cref="P:MyBlogLister.BusinessLayer.BusinessLayer.BloggingConnectionTester.LastError" />
        ///     properties to their default values.
        /// </summary>
        private static void ResetDiagnosticProperties()
        {
            LastUsedConnectionString = string.Empty;
            LastError = null;
        }
    }
}
