namespace StaffPro.Person.Domain.Entities.PersonInfo;

/// <summary>
/// Замечание/Комментарий сущности Person
/// </summary>
public class Comment
{
    /// <summary>
    /// Замечание/Комментарий
    /// </summary>
    public string CommentStr { get; private set; }

    /// <summary>
    /// Конструктор класса Comment
    /// </summary>
    /// <param name="commentStr"></param>
    public Comment(string commentStr = "")
    {
        CommentStr = commentStr;
    }

    /// <summary>
    /// Изменить Замечание/Комментарий
    /// </summary>
    /// <param name="commentStr"></param>
    public void ChangeComment(string commentStr)
    {
        CommentStr = commentStr;
    }
}
