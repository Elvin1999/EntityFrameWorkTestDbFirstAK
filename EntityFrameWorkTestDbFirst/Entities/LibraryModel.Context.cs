//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameWorkTestDbFirst.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class LibraryEntities : DbContext
    {
        public LibraryEntities()
            : base("name=LibraryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    
        public virtual ObjectResult<Procedure_Result> Procedure(Nullable<int> param1, Nullable<int> param2)
        {
            var param1Parameter = param1.HasValue ?
                new ObjectParameter("param1", param1) :
                new ObjectParameter("param1", typeof(int));
    
            var param2Parameter = param2.HasValue ?
                new ObjectParameter("param2", param2) :
                new ObjectParameter("param2", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Procedure_Result>("Procedure", param1Parameter, param2Parameter);
        }
    
        public virtual ObjectResult<sp_GetBookAuthorCategoryById_Result> sp_GetBookAuthorCategoryById(Nullable<int> book_id)
        {
            var book_idParameter = book_id.HasValue ?
                new ObjectParameter("book_id", book_id) :
                new ObjectParameter("book_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetBookAuthorCategoryById_Result>("sp_GetBookAuthorCategoryById", book_idParameter);
        }
    
        public virtual ObjectResult<sp_GetBookAuthorCategoryById2_Result> sp_GetBookAuthorCategoryById2(Nullable<int> book_id)
        {
            var book_idParameter = book_id.HasValue ?
                new ObjectParameter("book_id", book_id) :
                new ObjectParameter("book_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetBookAuthorCategoryById2_Result>("sp_GetBookAuthorCategoryById2", book_idParameter);
        }
    
        public virtual ObjectResult<sp_GetBookById_Result> sp_GetBookById(Nullable<int> book_id)
        {
            var book_idParameter = book_id.HasValue ?
                new ObjectParameter("book_id", book_id) :
                new ObjectParameter("book_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetBookById_Result>("sp_GetBookById", book_idParameter);
        }
    }
}
