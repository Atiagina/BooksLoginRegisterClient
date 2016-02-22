using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookReviewLoginService" in code, svc and config file together.
public class BookReviewLoginService : IBookReviewLoginService
{
    BookReviewDbEntities db = new BookReviewDbEntities();

    

    public int ReviewerLogin(string username, string password)
    {
         int result = db.usp_ReviewerLogin(username, password);
        if (result != -1)
        {
            var key = from k in db.Reviewers
                      where k.ReviewerUserName.Equals(username)
                      select new { k.ReviewerKey };

            foreach (var k in key){

            result = (int)k.ReviewerKey;
        }
        }
        
        return result;
    }

    public int ReviewerRegistration(ReviewerLite r)
    {
        Reviewer rv = new Reviewer();


        int result = db.usp_NewReviewer(r.UserName, r.FirstName, r.LastName, r.Email, r.Password);
        return result;
    }


    public int AddAuthor(string authorName)
    {
        int result = 1;
        Author a = new Author();
        a.AuthorName = authorName;

        try
        {

            db.Authors.Add(a);
            db.SaveChanges();
        }
        catch(Exception ex){
        result = 0;
        throw ex;
        }

        return result;
      
    }

    public int AddBook(BookLite bl)
    {
        Author au = new Author();
        au.AuthorName = "Don Norman";
            bl.AuthorNames.Add(au);

        Book b = new Book();
        b.BookTitle = bl.Title;
        b.BookISBN = bl.ISBN;
        b.BookEntryDate = DateTime.Now;
        if (b.Authors !=null){
            foreach(var a in b.Authors){
                Author author = db.Authors.FirstOrDefault(x => x.AuthorName.ToString().Equals(a));
                 b.Authors.Add(author);
            }
        }

        db.Books.Add(b);
        db.SaveChanges();

        return 1;
    }

    public int AddReview(ReviewLite rl)
    {
        throw new NotImplementedException();
    }
}
