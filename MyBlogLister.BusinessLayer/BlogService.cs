//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MyBlogLister.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlogLister.BusinessLayer.BusinessLayer
{
    /// <summary>
    /// Performs operations on the database to store/retrieve entries
    /// in the data source for Blogs.
    /// </summary>
    public partial class BlogService : BloggingServiceBase
    {
        /// <summary>
        /// Empty, static constructor to prohibit direct allocation of this class.
        /// </summary>
        static BlogService() { }
        
        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this class.
        /// </summary>
        protected BlogService() { }
        
        /// <summary>
        /// Gets a reference to the one and only instance of
        /// <see cref="T:MyBlogLister.BusinessLayer.BusinessLayer.BlogService" />.
        /// </summary>
        public static BlogService Instance { get; } =
            new BlogService();
        
        /// <summary>
        /// Adds the data specified by the
        /// <see cref="T:MyBlogLister.BusinessLayer.BusinessLayer.Blog" /> entity
        /// object to the data source.
        /// </summary>
        /// <param name="newEntity">
        /// Reference to an instance of the entity object that
        /// contains the data to be added.
        /// </param>
        /// <param name="existingItemPredicate">
        /// (Optional.) Lambda expression that defines a query to be executed to see if any 
        /// records with the specified criteria already exist in the data source.  If this 
        /// paramete is not provided, no search for an already-existing record is conducted.
        /// </param>
        /// <returns>If the add was successful, the primary key value of the new row.</returns>
        /// <remarks>Optionally searches the data source for an existing item, where 'existing'
        /// is defined by whatever criteria are specified in the <paramref name="existingItemPredicate"/>.
        /// If a row matching the criteria is found, the method simply returns its primary key
        /// value but otherwise will not perform the Add operation.  If no predicate is supplied,
        /// or a row matching the criteria is not found, then the method attempts to perform
        /// the Add operation.
        /// </remarks>
        public int Add(Blog newEntity, Func<Blog, bool> existingItemPredicate = null)
        {
            var result = -1;        // failed to add new entry
        
            // If the reference to the new entity POCO containing data to be
            // added is a null reference, then we can't do anything.
            if (newEntity == null)
                return result;
        
            // Search the data source for an existing record. Criteria for the match
            // are specified by the implementation of the delegate pointed to by the
            // existingItemPredicate parameter.  If no predicate is provided, then do
            // not conduct a search.
            var idOfExistingRow = -1;
            if (existingItemPredicate != null)
            {
                var foundEntity = GetAll().FirstOrDefault(existingItemPredicate);
                idOfExistingRow = foundEntity == null ? -1 : foundEntity.BlogId;
            }
        
            // If we have a value of 1 or greater for the primary key value of an
            // existing item matching the criteria mandated by the existingItemPredicate
            // parameter, then stop and return the primary key ID value of that row.
            if (idOfExistingRow >= 1)
                return idOfExistingRow;
        
            // If we are here, then no existing row was located.  Perform the Add
            // operation on the data source.
            try
            {
                UnitOfWork.Blogs.Add(newEntity);
                if (UnitOfWork.Save() > 0)
                    result = newEntity.BlogId;
            }
            catch (Exception ex)
            {
                result = -1;
        
                OnExceptionRaised(ex);
            }
        
            return result;
        }
        
        /// <summary>
        /// Deletes the record with the primary key value of <paramref name="id" />. if
        /// it's still in the table.
        /// </summary>
        /// <param name="id">Primary key value of the entity to be deleted.</param>
        /// <returns>Number of rows affected by the delete; -1 if a problem occurred.</returns>
        /// <remarks>
        /// This method calls the
        /// <see
        ///     cref="M:MyBlogLister.BusinessLayer.BusinessLayer.BlogService.GetById" />
        /// method to look up the entity object to delete from the data source, and then
        /// performs the Delete operation.
        /// </remarks>
        public int Delete(int id)
        {
            var result = -1;
            if (id < 1) // ID values always start from 1
                return result;
        
            // Attempt to perform the Delete operation.
            try
            {
                var entityToDelete = GetById(id);
                if (entityToDelete == null) // not found
                    return result;
        
                result = Delete(entityToDelete);
            }
            catch (Exception ex)
            {
                result = -1;
        
                OnExceptionRaised(ex);
            }
        
            return result;
        }
        
        /// <summary>
        /// Deletes the record specified by <paramref name="entityToDelete" />.
        /// </summary>
        /// <param name="entityToDelete">
        /// Reference to an instance of
        /// <see cref="T:MyBlogLister.BusinessLayer.BusinessLayer.Blog" /> that
        /// indicates the row to be deleted.
        /// </param>
        /// <returns>Number of rows affected by the delete; -1 if a problem occurred.</returns>
        /// <remarks>
        /// This method calls the
        /// <see
        ///     cref="M:MyBlogLister.BusinessLayer.BusinessLayer.BlogService.GetById" />
        /// method to look up the entity object to delete from the data source, and then
        /// performs the Delete operation.
        /// </remarks>
        public int Delete(Blog entityToDelete)
        {
            var result = -1;
            if (entityToDelete == null) // we don't know what to do with a null reference
                return result;
        
            // Attempt to perform the Delete operation.
            try
            {
                UnitOfWork.Blogs.Delete(entityToDelete);
                result = UnitOfWork.Save();
            }
            catch (Exception ex)
            {
                result = -1;
        
                OnExceptionRaised(ex);
            }
        
            return result;
        }
        
        /// <summary>
        /// Given the name of a Blog, looks up its database ID.
        /// </summary>
        /// <param name="searchPredicate">
        /// Labmda expression for a search predicate that will determine when a
        /// row's data matches the criteria for finding the ID of that row.
        /// </param>
        /// <returns>Blog ID, or -1 if not found.</returns>
        public int FindBlogId(Func<Blog, bool> searchPredicate)
        {
            var result = -1;
        
            if (searchPredicate == null)
                return -1;
        
            try
            {
                // If none of the records match the search criteria, then give up.
                if (GetAll().All(x => !searchPredicate(x)))
                    return -1;
        
                // If we've made it here, then there should be a positive match.
                var entityFound = GetAll()
                    .FirstOrDefault(x=>searchPredicate(x));
        
                if (entityFound != null)
                    result = entityFound.BlogId;
            }
            catch (Exception ex)
            {
                result = -1;
        
                OnExceptionRaised(ex);
            }
        
            return result;
        }
        
        /// <summary>
        /// Gets a reference to an enumerable collection of entity data table
        /// entries.
        /// </summary>
        /// <returns>
        /// Reference to an enumerable collection of entity data table
        /// entries.
        /// </returns>
        public IEnumerable<Blog> GetAll()
        {
            IEnumerable<Blog> result;
        
            try
            {
                result = UnitOfWork.Blogs.GetAll();
            }
            catch (Exception ex)
            {
                result = Enumerable.Empty<Blog>();
        
                OnExceptionRaised(ex);
            }
        
            return result;
        }
        
        /// <summary>
        /// Retrieves a record with primary key value <paramref name="id" /> from the data
        /// source.
        /// </summary>
        /// <param name="id">Value of the primary key to look up.</param>
        /// <returns>
        /// Reference to the instance of
        /// <see cref="T:MyBlogLister.BusinessLayer.BusinessLayer.Blog" /> containing
        /// the requested data, or a null reference if the requested record cannot be
        /// located.
        /// </returns>
        public Blog GetById(int id)
        {
            Blog entity;
        
            if (id < 1)
                return null;
        
            try
            {
                entity = UnitOfWork.Blogs.GetById(id);
            }
            catch(Exception ex)
            {
                entity = null;
        
                OnExceptionRaised(ex);
            }
        
            return entity;
        }
    }
}
