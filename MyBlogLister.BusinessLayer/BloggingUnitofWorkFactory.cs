//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyBlogLister.BusinessLayer.BusinessLayer
{
    /// <summary>Creates new unit of work objects on the Blogging data
    /// source.</summary>
    public static class BloggingUnitOfWorkFactory
    {
    
    /// <summary>Creates a new instance of an object that implements <see cref="T:MyBlogLister.BusinessLayer.BusinessLayer.IBloggingUnitOfWork"/>.</summary>
    /// <returns>Reference to a new instance of an object that implements <see cref="T:MyBlogLister.BusinessLayer.BusinessLayer.IBloggingUnitOfWork"/>.</returns>
    public static IBloggingUnitOfWork Make()
    {
        return new BloggingUnitOfWork();
    }
    
    /// <summary>Creates a new instance of an object that implements <see cref="T:MyBlogLister.BusinessLayer.BusinessLayer.IBloggingUnitOfWork"/>and attempts to connect to the underlying data source using the specified <paramref name="connectionString"/>.</summary>
    /// <param name="connectionString">String containing the connection string to be utilized to establish
    /// a connection to the data source.</param>
    /// <returns>Reference to a new instance of an object that implements <see cref="T:MyBlogLister.BusinessLayer.BusinessLayer.IBloggingUnitOfWork"/>.</returns>
    public static IBloggingUnitOfWork Make(string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            return Make();  // use default overload if connection string is blank
    
        return new BloggingUnitOfWork(connectionString);
    }
}
}
