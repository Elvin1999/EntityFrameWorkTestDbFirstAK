using EntityFrameWorkTestDbFirst.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EntityFrameWorkTestDbFirst.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
		private ObservableCollection<Book> allBooks;

		public ObservableCollection<Book> AllBooks
		{
			get { return allBooks; }
			set { allBooks = value; OnPropertyChanged(); }
		}


		public MainViewModel()
		{
			AllBooks = new ObservableCollection<Book>();
			//CallAddAsync();
			//UpdateAsync();
			//RemoveAsync();
			//GetAsync();

			CallStoredProcedure();
		}

		private void CallStoredProcedure()
		{
            //using (var context=new LibraryEntities())
            //{
            //	var result=context.sp_GetBookById(4).First();
            //	var author = context.Authors.SingleOrDefault(a => a.Id == result.AuthorId);
            //	var book = new Book
            //	{
            //		 Id=result.Id,
            //		  AuthorId=result.AuthorId,
            //		  Author=author,
            //		   CategoryId=result.CategoryId,
            //		    Name=result.Name,
            //			 Pages=result.Pages
            //	};
            //	AllBooks = new ObservableCollection<Book>
            //	{
            //		book
            //	};
            //         }

            using (var context = new LibraryEntities())
            {
                var result = context.sp_GetBookAuthorCategoryById2(4).First();
				MessageBox.Show($"{result.Book}  {result.Author}   {result.Category}");
            }

        }

		private async void UpdateAsync()
		{
			using (var context=new LibraryEntities())
			{
				var book = await context.Books
					.SingleOrDefaultAsync(b => b.Id == 5);
				if (book != null)
				{
					book.Name = "I updated 3";
					context.Entry(book).State = EntityState.Modified;
					await context.SaveChangesAsync();
				}
                GetAsync();
            }
		}

		private async void RemoveAsync()
		{
			using (var context=new LibraryEntities())
			{
				var deletedBook = await context
					.Books
					.FirstOrDefaultAsync(b => b.Id == 7);
				if (deletedBook != null)
				{
					context.Entry(deletedBook).State = EntityState.Deleted;
					await context.SaveChangesAsync();
				}
                GetAsync();
            }
		}

		private async void CallAddAsync()
		{
			string data = await AddAsync();
		}

		private async Task<string> AddAsync()
		{
			using (var context=new LibraryEntities())
			{
				var book = new Book
				{
					Name="My New book",
					AuthorId=1,
					CategoryId=1,
					Pages=1111
				};
				context.Entry(book).State= EntityState.Added;
				return (await context.SaveChangesAsync()).ToString();
			}
		}

		private async void GetAsync()
		{
			using (var context=new LibraryEntities())
			{
				var books = await context
					.Books
					.Include(nameof(Book.Author))
					.Include(nameof(Book.Category))
					.ToListAsync();


				AllBooks = new ObservableCollection<Book>(books);

				//var books = await context
				//	.Books
				//	.Include(nameof(Book. Author))
				//	.Include(nameof(Book.Category))
				//	.FirstOrDefaultAsync(b => b.Id == 1);

    //            AllBooks = new ObservableCollection<Book>
				//{
				//	books,
				//};
			}
		}
	}
}
