//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using MyBlogLister.Data;

namespace MyBlogLister.BusinessLayer.BusinessLayer
{
    /// <summary> Defines the functionality for a unit of work on the Blogging data
    /// source. </summary>
    public partial interface IBloggingUnitOfWork : IDisposable
    {
            
        /// <summary>Gets a reference to an instance of an object that implements <see cref="T:MyBlogLister.BusinessLayer.BusinessLayer.IPostRepository"/> and which accesses the data in the Posts table of the data source.</summary>
        IPostRepository Posts { get; }
            
        /// <summary>Gets a reference to an instance of an object that implements <see cref="T:MyBlogLister.BusinessLayer.BusinessLayer.IBlogRepository"/> and which accesses the data in the Blogs table of the data source.</summary>
        IBlogRepository Blogs { get; }
            
        /// <summary>
        /// Gets a string containing the connection string (or the configuraton-file section name)
        /// that was used to create this instance.
        /// </summary>
        string ConnectionString { get; }
            
        /// <summary>Saves changes made to the data source.</summary>
        /// <returns>Number of records affected by the Save operation; -1 if an 
        /// error occurred.</returns>
        /// <remarks>This method will automatically attempt a graceful closure 
        /// of the handle to the underlying data source in the case that the return
        // value is -1.</remarks>
        int Save();
        
        /// <summary>Gets a reference to the data context object.</summary>
        BloggingContext Context { get; }
        
        /// <summary>Raised when the connection to the data source is successful.</summary>
        event EventHandler DatabaseConnected;
        
        /// <summary>Raised when a connection cannot be successfully established 
        /// to the underlying data store.</summary>
        event EventHandler DatabaseNotAvailable;
        
        /// <summary>Raised when an error occurs.</summary>
        event Action<Exception> ExceptionRaised;
        
        /// <summary>
        /// Gets a value that indicates whether there are changes pending to be
        /// saved to the underlying data source.
        /// </summary>
        bool HasChanges { get; }
    }
}
