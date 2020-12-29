namespace MyBlogLister
{
    /// <summary>
    /// Type of data source from which the application obtains configuration.
    /// </summary>
    public enum DataSourceType
    {
        /// <summary>
        /// Configuration information is to be obtained from a database.
        /// </summary>
        Database,

        /// <summary>
        /// Configuration information is to be obtained from a JSON-formatted file.
        /// </summary>
        JsonFile
    }
}