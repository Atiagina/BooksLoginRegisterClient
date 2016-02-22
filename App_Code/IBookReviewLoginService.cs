using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBookReviewLoginService" in both code and config file together.
[ServiceContract]
public interface IBookReviewLoginService
{
    [OperationContract]

    int ReviewerLogin(string username, string password);

    [OperationContract]
    int ReviewerRegistration(ReviewerLite r);

    [OperationContract]
    int AddAuthor(string authorName);

    [OperationContract]
    int AddBook(BookLite bl);

    [OperationContract]
    int AddReview(ReviewLite rl);

}

[DataContract]
public class ReviewerLite
{

    [DataMember]
    public string LastName { set; get; }

    [DataMember]
    public string FirstName { set; get; }

    [DataMember]
    public string UserName { set; get; }

    [DataMember]
    public string Password { set; get; }

    [DataMember]
    public string Email { set; get; }
}

[DataContract]
public class BookLite {

    [DataMember]
    public string Title {get; set;}

    [DataMember]
    public string ISBN {get; set;}

    [DataMember]
    public List<Author> AuthorNames {get; set;}

}

[DataContract]

public class ReviewLite
{
    [DataMember]
    public string BookTitle { set; get; }

    [DataMember]
    public string ReviewerKey { set; get; }

    [DataMember]
    public string ReviewTitle { set; get; }

    [DataMember]
    public int Rating { set; get; }

    [DataMember]
    public string ReviewText { set; get; }

}